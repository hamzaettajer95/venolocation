using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using venolocation.classee;
using venolocation.dev;
using venolocation.settin;

namespace venolocation.formee
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }
        public static string connection_string= DbConfig.GetConnectionString();

        private readonly string connectionString = connection_string;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
       
        void mise_a_jour()
        {
            string updateUrl = Properties.Settings.Default.updateUrl;

            UpdateInfo update = UpdateHelper.CheckForUpdate(updateUrl);

            if (update != null && update.IsNewVersion)
            {
                update frm = new settin.update(update);
                frm.ShowDialog();

                if (update.Obligatoire && frm.UpdateInstalled == false)
                {
                    MessageBox.Show(
                        "Cette mise à jour est obligatoire. Le logiciel va se fermer.",
                        "Mise à jour obligatoire",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    Application.Exit();
                    return;
                }
            }

           
        }
        private string GetConnectionStringFromTextBox()
        {
            string server = Properties.Settings.Default.db_server;
            string database = Properties.Settings.Default.db_name;
            string user = Properties.Settings.Default.db_user;
            string password = Properties.Settings.Default.db_password;
            string portText = Properties.Settings.Default.db_port;

            uint port = 3306;

            if (!string.IsNullOrWhiteSpace(portText))
            {
                if (!uint.TryParse(portText, out port))
                {
                    port = 3306;
                }
            }
           
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = server,
                Database = database,
                UserID = user,
                Password = password,
                Port = port
            };

            return builder.ConnectionString;
        }
        bool verifier_connection()
        {
           
                try
                {
                
                //string connectionString = GetConnectionStringFromTextBox();

                using (MySqlConnection con = new MySqlConnection(connectionString))
                        {
                            con.Open();
                        }

                        return true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Erreur de connexion à la base de données : " + ex.Message, "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ErrorReporter.SendError(ex, "dashboard", "erreur connection");
                    

                        return false;
                }
            //test
        }
        private void dashboard_Load(object sender, EventArgs e)
        {
            if (verifier_connection())
            {

                try
                {
                    this.SuspendLayout();
                    mise_a_jour();
                    timer1.Start();
                    lbldate.Text = DateTime.Now.ToString("dddd dd/MM/yyyy");
                    ChargerToutesLesDonnees();
                    deconnecte();
                    Dbexec.ExecuteQuery("CALL sp_generer_alertes();");
                   
                    //test_serial();
                    MakePanelClickable(panel1, panel1_Click);
                }
                catch (Exception ex)
                {
                    ErrorReporter.SendError(ex, "dashboard", "erreur connection");
                    dbErreur.AddLog(ex.Message, Session.Username, "dashboard", "dashboard_Load");
                    MessageBox.Show("Erreur chargement dashboard : " + ex.Message);
                }
                finally
                {
                    this.ResumeLayout();
                }
            }
            else
            {
                dev.server ser = new dev.server();
                ser.ShowDialog();
            }


        }
        private void ChargerToutesLesDonnees()
        {
            ChargerStatistiquesDashboard();
            ChargerRetoursPrevusAujourdhui();
            ChargerAlertesDocumentsExpires();
            ChargerDernieresOperations();
        }

        private void ChargerStatistiquesDashboard()
        {
            try
            {
                lblVoituresDisponibles.Text = Dbexec.ExecuteScalarInt(
                    @"SELECT COUNT(*) 
                      FROM voitures 
                      WHERE etat = @etat OR etat IS NULL",
                    new MySqlParameter[]
                    {
                        new MySqlParameter("@etat", AppStatus.VoitureDisponible)
                    }).ToString();

                lblVoituresLouees.Text = Dbexec.ExecuteScalarInt(
                    @"SELECT COUNT(*) 
                      FROM voitures 
                      WHERE etat = @etat",
                    new MySqlParameter[]
                    {
                        new MySqlParameter("@etat", AppStatus.VoitureEnLocation)
                    }).ToString();

                lblReservations.Text = Dbexec.ExecuteScalarInt(
                    @"SELECT COUNT(*) 
                      FROM reservations 
                      WHERE status = @status",
                    new MySqlParameter[]
                    {
                        new MySqlParameter("@status", AppStatus.ReservationConfirmee)
                    }).ToString();

                decimal totalJour = Dbexec.ExecuteScalarDecimal(
                    @"SELECT IFNULL(SUM(montant), 0)
                      FROM recettes
                      WHERE DATE(date_recette) = CURDATE()");

                lblRecetteJour.Text = totalJour.ToString("0.00");
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "dashboard", "ChargerStatistiquesDashboard");
                dbErreur.AddLog(ex.Message, Session.Username, "dashboard", "ChargerStatistiquesDashboard");
                MessageBox.Show("Erreur dashboard : " + ex.Message);
            }
        }

        private void ChargerRetoursPrevusAujourdhui()
        {
            try
            {
                string query = @"
                SELECT 
                    CONCAT(cl.nom, ' ', cl.prenom) AS Client,
                    CONCAT(v.matricule, ' - ', v.marque, ' ', v.modele) AS Véhicule,
                    CONCAT(DATE_FORMAT(c.date_retour_prevu, '%d/%m/%Y'), ' ', TIME_FORMAT(c.heure_retour_prevu, '%H:%i')) AS `Retour prévu`
                FROM contrats c
                INNER JOIN clients cl ON cl.client_id = c.client_id
                INNER JOIN voitures v ON v.voiture_id = c.voiture_id
                WHERE c.date_retour_prevu = CURDATE()
                  AND c.status <> @status_termine
                ORDER BY c.heure_retour_prevu ASC
                LIMIT 50;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@status_termine", AppStatus.ContratTermine)
                };

                dgvRetoursPrevus.DataSource = Dbexec.GetData(query, ps);

                GridStyleHelper_1.ApplyCompact(dgvRetoursPrevus);
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "dashboard", "ChargerStatistiquesDashboard");
                dbErreur.AddLog(ex.Message, Session.Username, "dashboard", "ChargerRetoursPrevusAujourdhui");
                MessageBox.Show("Erreur retours prévus : " + ex.Message);
            }
        }

        private void ChargerAlertesDocumentsExpires()
        {
            try
            {
                string query = @"
                        SELECT 
                            type AS 'Type',
                            voiture AS 'Voiture',
                            message AS 'Message',
                            DATE_FORMAT(date_alerte, '%d/%m/%Y') AS 'Date',
                            statut AS 'Statut'
                        FROM alerte
                        WHERE vue = b'0'
                        ORDER BY date_alerte DESC, id DESC
                        LIMIT 50;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@vue", 0)
                };

                dgvAlertes.DataSource = Dbexec.GetData(query, ps);
                
                GridStyleHelper_1.ApplyCompact(dgvAlertes);
                ColorierStatutAlertes();
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "dashboard", "ChargerStatistiquesDashboard");
                dbErreur.AddLog(ex.Message, Session.Username, "dashboard", "ChargerAlertesDocumentsExpires");
                MessageBox.Show("Erreur alertes : " + ex.Message);
            }
        }
        private void ColorierStatutAlertes()
        {
            if (!dgvAlertes.Columns.Contains("Statut"))
                return;

            foreach (DataGridViewRow row in dgvAlertes.Rows)
            {
                if (row.IsNewRow || row.Cells["Statut"].Value == null)
                    continue;

                string statut = row.Cells["Statut"].Value.ToString().Trim().ToLower();
                DataGridViewCell cell = row.Cells["Statut"];

                cell.Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (statut == "rouge")
                {
                    cell.Style.BackColor = Color.FromArgb(252, 220, 220);
                    cell.Style.ForeColor = Color.FromArgb(200, 55, 55);
                    cell.Style.SelectionBackColor = Color.FromArgb(245, 205, 205);
                    cell.Style.SelectionForeColor = Color.FromArgb(200, 55, 55);
                }
                else if (statut == "orange")
                {
                    cell.Style.BackColor = Color.FromArgb(255, 239, 213);
                    cell.Style.ForeColor = Color.FromArgb(212, 133, 0);
                    cell.Style.SelectionBackColor = Color.FromArgb(250, 228, 190);
                    cell.Style.SelectionForeColor = Color.FromArgb(212, 133, 0);
                }
            }
        }
        private void ChargerDernieresOperations()
        {
            try
            {
                string query = @"
                SELECT 
                    utilisateur AS Utilisateur,
                    message AS Opération,
                    DATE_FORMAT(date, '%d/%m/%Y %H:%i:%s') AS Date
                FROM logs
                ORDER BY id DESC
                LIMIT 20;";

                dgvDernieresOperations.DataSource = Dbexec.GetData(query);

                GridStyleHelper_1.ApplyCompact(dgvDernieresOperations);

                if (dgvDernieresOperations.Columns.Count > 0)
                {
                    dgvDernieresOperations.Columns["Utilisateur"].FillWeight = 25;
                    dgvDernieresOperations.Columns["Opération"].FillWeight = 50;
                    dgvDernieresOperations.Columns["Date"].FillWeight = 25;

                    GridStyleHelper_1.AlignLeft(dgvDernieresOperations, "Opération");
                }
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "dashboard", "ChargerDernieresOperations");
                dbErreur.AddLog(ex.Message, Session.Username, "dashboard", "ChargerDernieresOperations");
                MessageBox.Show("Erreur dernières opérations : " + ex.Message);
            }
        }


       

        private void cmsUser_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnUserMenu_Click(object sender, EventArgs e)
        {
            cmsUser.Show(btnUserMenu, 0, btnUserMenu.Height);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            formee.client cl    = new client();
            cl.ShowDialog();
        }

        private void btncar_Click(object sender, EventArgs e)
        {
            formee.voiture voi = new voiture();
            voi.ShowDialog();
        }

        private void btnreservation_Click(object sender, EventArgs e)
        {
            formee.reservation res = new reservation();
            res.ShowDialog();
        }

        private void Accueil_Click(object sender, EventArgs e)
        {
            formee.login log = new login();
            log.ShowDialog();
        }

        private void btncontrat_Click(object sender, EventArgs e)
        {
          formee.contrats con = new contrats();
            con.ShowDialog();
        }

        private void btnDepence_Click(object sender, EventArgs e)
        {
            formee.depence de = new depence();
            de.ShowDialog();
        }

        private void btretour_Click(object sender, EventArgs e)
        {
            formee.retour retour = new retour();
            retour.ShowDialog();
        }

        private void btnalerte_Click(object sender, EventArgs e)
        {
            formee.alerte al = new alerte();
            al.ShowDialog();
        }

        private void btnentretient_Click(object sender, EventArgs e)
        {
            formee.Entretient en = new Entretient();
            en.ShowDialog();
        }

        private void dashboard_Activated(object sender, EventArgs e)
        {
            if (Session.Username == "")
                return;
            try
            {
                this.SuspendLayout();
                ChargerToutesLesDonnees();
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "dashboard", "dashboard_Activated");
                dbErreur.AddLog(ex.Message, Session.Username, "dashboard", "dashboard_Activated");
                MessageBox.Show("Erreur actualisation dashboard : " + ex.Message);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void btnHistorique_Click(object sender, EventArgs e)
        {
            droit.historique_contrats hi = new droit.historique_contrats();
            hi.ShowDialog();
        }

        private void btnRecettes_Click(object sender, EventArgs e)
        {
            droit.recette re = new droit.recette();
            re.ShowDialog();
        }

        private void btnReparation_Click(object sender, EventArgs e)
        {
            droit.reparation re = new droit.reparation();
            re.ShowDialog();
        }

        private void btnAccidents_Click(object sender, EventArgs e)
        {
            droit.accident acc = new droit.accident();
            acc.ShowDialog();
        }

        private void btnSituation_Click(object sender, EventArgs e)
        {
            droit.situation df = new droit.situation();
            df.ShowDialog();
        }

        void deconnecte()
        {
            flowMenu.Enabled = false;
            btnAccidents.Enabled=false;
            btnSituation.Enabled=false;
            btnRecettes.Enabled = false;
            btnDepence.Enabled = false;
            btnReparation.Enabled = false;
            btnSetting.Enabled = false;
            btnHistorique.Enabled = false;
            dgvAlertes.DataSource = null;
            dgvDernieresOperations.DataSource = null;
            dgvRetoursPrevus.DataSource = null;


        }

        void connecter()
        {
            lblUser.Text = Session.Username;
            if(Session.Role=="Admin")
            {
                btnSituation.Enabled = true;
                btnRecettes.Enabled = true;
                btnDepence.Enabled = true;
                btnSetting.Enabled = true;
            }
            // Employé
            flowMenu.Enabled = true;
            btnAccidents.Enabled = true;            
            btnReparation.Enabled = true;            
            btnHistorique.Enabled = true;
        }

        void developpeur()
        {
            Session.Role = "Développeur";
            Session.Username = "Développeur";
            lblUser.Text = Session.Username;

            btnSituation.Enabled = true;
            btnRecettes.Enabled = true;
            btnDepence.Enabled = true;
            btnSetting.Enabled = true;
            flowMenu.Enabled = true;
            btnAccidents.Enabled = true;
            btnReparation.Enabled = true;
            btnHistorique.Enabled = true;
            LogHelper.AddLog("Connexion réussie.", Session.Username);
        }

        private void deconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deconnecte();
            btndeveloppeur.Enabled = true;

            Session.Username = "";
            Session.Role = "";

            LogHelper.AddLog(" Quitter Connexion.", Session.Username);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            droit.setting set = new droit.setting();
            set.ShowDialog();
        }

        private void ProfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login frm = new login();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ChargerToutesLesDonnees();
                connecter();
            }
        }

        private void btndeveloppeur_Click(object sender, EventArgs e)
        {
            droit.developpeur de = new droit.developpeur();
            de.ShowDialog();
            if (de.mode_dev == true)
            {
               
                developpeur();
                ChargerToutesLesDonnees();
            }
            
        }

        private void btnecheances_Click(object sender, EventArgs e)
        {
            voiture_echeance de = new voiture_echeance();
            de.ShowDialog();
        }


        void test_serial()
        {
            string programName = Properties.Settings.Default.name_programe;

            string driveUrl = Properties.Settings.Default.url_licence;

            bool active = ActivationHelper.CheckActivationFromDrive(programName, driveUrl);

            if (!active)
            {
                classee.ErrorReporter.SendTestMessage("Probleme de l'activation !!!");
                btnavtiveLicence.Visible = true;
                deconnecte();
                panel1.Enabled = false;
                btnUserMenu.Enabled = false;
            }
            else
            {
                btnUserMenu.Enabled = true;
                panel1.Enabled = true;
                btnavtiveLicence.Visible = false;
            }
                

        }
        void panel1_Click(object sender, EventArgs e)
        {
            login frm = new login();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ChargerToutesLesDonnees();
                connecter();
            }
        }

        private void MakePanelClickable(Panel pnl, EventHandler clickEvent)
        {
            pnl.Cursor = Cursors.Hand;
            pnl.Click += clickEvent;

            foreach (Control c in pnl.Controls)
            {
                c.Cursor = Cursors.Hand;
                c.Click += clickEvent;
            }
        }

        private void btnavtiveLicence_Click(object sender, EventArgs e)
        {
            settin.activation acti = new activation();
            acti.ShowDialog();
            btnavtiveLicence.Visible = false;
        }
    }
}
