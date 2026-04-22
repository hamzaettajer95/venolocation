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
            timer1.Start();
            lbldate.Text = DateTime.Now.ToString("dddd dd/MM/yyyy");

            ChargerStatistiquesDashboard();
            ChargerRetoursPrevusAujourdhui();
            ChargerAlertesDocumentsExpires();
            ChargerDernieresOperations();

        }

        private void ChargerStatistiquesDashboard()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    // Voitures disponibles
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM voitures WHERE etat = 'Disponible' OR etat IS NULL", cn))
                    {
                        lblVoituresDisponibles.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Voitures louées
                    using (MySqlCommand cmd = new MySqlCommand(
                        "SELECT COUNT(*) FROM voitures WHERE etat = 'En location'", cn))
                    {
                        lblVoituresLouees.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Réservations confirmées  pour aujourd'hui ou futures
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT COUNT(*) 
                  FROM reservations 
                  WHERE status IN ( 'Confirmée')", cn))
                    {
                        lblReservations.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Recette du jour
                    using (MySqlCommand cmd = new MySqlCommand(
                            @"SELECT IFNULL(SUM(montant),0) 
                              FROM recettes 
                              WHERE DATE(date_recette) = CURDATE()", cn))
                    {
                        decimal totalJour = Convert.ToDecimal(cmd.ExecuteScalar());

                        //MessageBox.Show(totalJour.ToString());
                        lblRecetteJour.Text = totalJour.ToString();
                    }
                }
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
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    string query = @"
                SELECT 
                    CONCAT(cl.nom, ' ', cl.prenom) AS Client,
                    CONCAT(v.matricule, ' - ', v.marque, ' ', v.modele) AS Véhicule,
                    CONCAT(DATE_FORMAT(c.date_retour_prevu, '%d/%m/%Y'), ' ', TIME_FORMAT(c.heure_retour_prevu, '%H:%i')) AS `Retour prévu`
                FROM contrats c
                INNER JOIN clients cl ON cl.client_id = c.client_id
                INNER JOIN voitures v ON v.voiture_id = c.voiture_id
                WHERE c.date_retour_prevu = CURDATE()
                  AND c.status <> 'Terminé'
                ORDER BY c.heure_retour_prevu ASC;";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvRetoursPrevus.DataSource = dt;
                        dgvRetoursPrevus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }

                StyleGrid(dgvRetoursPrevus);
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
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    string query = @"
                SELECT 
                    type AS Type,
                    voiture AS Voiture,
                    DATE_FORMAT(date_alerte, '%d/%m/%Y') AS Date,
                    statut AS Statut
                FROM alerte
                WHERE vue = 0
                ORDER BY date_alerte DESC, id DESC;";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvAlertes.DataSource = dt;
                        dgvAlertes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }

                StyleGrid(dgvAlertes);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "dashboard", "ChargerAlertesDocumentsExpires");
                MessageBox.Show("Erreur alertes : " + ex.Message);
            }
        }

        private void ChargerDernieresOperations()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    string query = @"
                    SELECT 
                        utilisateur AS Utilisateur,
                        message AS Opération,
                        DATE_FORMAT(date, '%d/%m/%Y %H:%i:%s') AS Date
                    FROM logs
                    ORDER BY id DESC
                    LIMIT 20;";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvDernieresOperations.DataSource = dt;
                        dgvDernieresOperations.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvDernieresOperations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvDernieresOperations.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        dgvDernieresOperations.Columns["Utilisateur"].FillWeight = 25;
                        dgvDernieresOperations.Columns["Opération"].FillWeight = 50;
                        dgvDernieresOperations.Columns["Date"].FillWeight = 25;
                    }
                }

                StyleGrid(dgvDernieresOperations);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "dashboard", "ChargerDernieresOperations");
                MessageBox.Show("Erreur dernières opérations : " + ex.Message);
            }
        }

        private void StyleGrid(DataGridView dgv)
        {
           
            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(230, 235, 240);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(18, 73, 139);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 38;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);
            dgv.RowTemplate.Height = 34;
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
            formee.n_reservation res = new n_reservation();
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
            ChargerStatistiquesDashboard();
            ChargerRetoursPrevusAujourdhui();
            ChargerAlertesDocumentsExpires();
            ChargerDernieresOperations();
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
    }
}
