using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using venolocation.classee;
using MySql.Data.MySqlClient;

namespace venolocation.formee
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }
        public static string connection_string=Properties.Settings.Default.conx;

        private readonly string connectionString = connection_string;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                timer1.Start();
                lbldate.Text = DateTime.Now.ToString("dddd dd/MM/yyyy");
                Dbexec.ExecuteQuery("CALL sp_generer_alertes();");
                ChargerToutesLesDonnees();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "dashboard", "dashboard_Load");
                MessageBox.Show("Erreur chargement dashboard : " + ex.Message);
            }
            finally
            {
                this.ResumeLayout();
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
            try
            {
                this.SuspendLayout();
                ChargerToutesLesDonnees();
            }
            catch (Exception ex)
            {
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

        private void deconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelRight.Enabled=false;
            flowMenu.Enabled=false;
            LogHelper.AddLog(" Quitter Connexion.", Session.Username);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            droit.setting set = new droit.setting();
            set.ShowDialog();
        }

        private void ProfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login lo = new login();
            lo.ShowDialog();
        }

        private void btndeveloppeur_Click(object sender, EventArgs e)
        {
            droit.developpeur de = new droit.developpeur();
            de.ShowDialog();
        }

        private void btnecheances_Click(object sender, EventArgs e)
        {
            voiture_echeance de = new voiture_echeance();
            de.ShowDialog();
        }
    }
}
