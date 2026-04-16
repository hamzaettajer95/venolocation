using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

                    // Réservations confirmées ou en attente pour aujourd'hui ou futures
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT COUNT(*) 
                  FROM reservations 
                  WHERE status IN ('En attente', 'Confirmée')", cn))
                    {
                        lblReservations.Text = cmd.ExecuteScalar().ToString();
                    }

                    // Recette du jour
                    using (MySqlCommand cmd = new MySqlCommand(
                        @"SELECT IFNULL(SUM(montant),0) 
                  FROM recettes 
                  WHERE date_recette = CURDATE()", cn))
                    {
                        decimal totalJour = Convert.ToDecimal(cmd.ExecuteScalar());
                        lblRecetteJour.Text = totalJour.ToString("0.00");
                    }
                }
            }
            catch (Exception ex)
            {
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
                    }
                }

                StyleGrid(dgvRetoursPrevus);
            }
            catch (Exception ex)
            {
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
                    CONCAT(type_echeance, ' - voiture ID ', voiture_id) AS Description,
                    DATE_FORMAT(date_fin, '%d/%m/%Y') AS Échéance
                FROM voiture_echeances
                WHERE date_fin <= CURDATE()
                ORDER BY date_fin ASC;";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvAlertes.DataSource = dt;
                    }
                }

                StyleGrid(dgvAlertes);
            }
            catch (Exception ex)
            {
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
                    DATE_FORMAT(date, '%d/%m/%Y') AS Date
                FROM logs
                ORDER BY id DESC
                LIMIT 20;";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvDernieresOperations.DataSource = dt;
                    }
                }

                StyleGrid(dgvDernieresOperations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur dernières opérations : " + ex.Message);
            }
        }

        private void StyleGrid(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 152, 219);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
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
    }
}
