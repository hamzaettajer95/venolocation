using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

using venolocation.classee;

namespace venolocation
{
    public partial class situation : Form
    {
        private Timer tmrHorloge;
        private const int capaciteParking = 30; 

        public situation()
        {
            InitializeComponent();
            InitialiserHorloge();
        }

        private void situation_Load(object sender, EventArgs e)
        {
            try
            {
                ChargerTout();
                LogHelper.AddLog("Ouverture formulaire situation", Session.Username);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "situation_Load");
                MessageService.Error("Erreur lors du chargement du formulaire situation.");
            }
        }

        private void InitialiserHorloge()
        {
            tmrHorloge = new Timer();
            tmrHorloge.Interval = 1000;
            tmrHorloge.Tick += TmrHorloge_Tick;
            tmrHorloge.Start();
            ActualiserDateHeure();
        }

        private void TmrHorloge_Tick(object sender, EventArgs e)
        {
            ActualiserDateHeure();
        }

        private void ActualiserDateHeure()
        {
            try
            {
                CultureInfo fr = new CultureInfo("fr-FR");
                lblDateHeure.Text = DateTime.Now.ToString("dddd dd/MM/yyyy    HH:mm:ss", fr);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "ActualiserDateHeure");
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            try
            {
                ChargerTout();
                LogHelper.AddLog("Actualisation tableau de bord situation", Session.Username);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "btnActualiser_Click");
                MessageService.Error("Erreur lors de l'actualisation.");
            }
        }

        private void ChargerTout()
        {
            ChargerStatistiques();
            ChargerTopVehicules();
            ChargerDernieresLocations();
            ChargerActivites();
            AppliquerStyles();
        }

        private int GetIntValue(string query)
        {
            DataTable dt = Dbexec.GetData(query);

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                return Convert.ToInt32(dt.Rows[0][0]);

            return 0;
        }

        private decimal GetDecimalValue(string query)
        {
            DataTable dt = Dbexec.GetData(query);

            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
                return Convert.ToDecimal(dt.Rows[0][0]);

            return 0;
        }

        private void ChargerStatistiques()
        {
            try
            {
                int totalVehicules = GetIntValue("SELECT COUNT(*) FROM voitures");
                int vehiculesLouees = GetIntValue("SELECT COUNT(*) FROM voitures WHERE etat = 'En location'");
                int vehiculesDisponibles = GetIntValue("SELECT COUNT(*) FROM voitures WHERE etat = 'Disponible' OR etat IS NULL");
                int vehiculesMaintenance = GetIntValue("SELECT COUNT(*) FROM voitures WHERE etat IN ('En maintenance', 'Maintenance', 'Réparation')");
                int totalClients = GetIntValue("SELECT COUNT(*) FROM clients");

                decimal entreesJour = GetDecimalValue("SELECT IFNULL(SUM(montant),0) FROM recettes WHERE DATE(date_recette) = CURDATE()");
                decimal sortiesJour = GetDecimalValue("SELECT IFNULL(SUM(montant),0) FROM depenses WHERE DATE(date_depense) = CURDATE()");
                decimal soldeJour = entreesJour - sortiesJour;

                decimal entreesMois = GetDecimalValue("SELECT IFNULL(SUM(montant),0) FROM recettes WHERE MONTH(date_recette)=MONTH(CURDATE()) AND YEAR(date_recette)=YEAR(CURDATE())");
                decimal sortiesMois = GetDecimalValue("SELECT IFNULL(SUM(montant),0) FROM depenses WHERE MONTH(date_depense)=MONTH(CURDATE()) AND YEAR(date_depense)=YEAR(CURDATE())");
                decimal beneficeNet = entreesMois - sortiesMois;

                int parkTotal = capaciteParking;
                int parkOccupe = GetIntValue("SELECT COUNT(*) FROM voitures WHERE etat <> 'En location' OR etat IS NULL");
                int parkDisponible = parkTotal - parkOccupe;
                if (parkDisponible < 0) parkDisponible = 0;

                double tauxOccupation = 0;
                if (parkTotal > 0)
                    tauxOccupation = (double)parkOccupe * 100 / parkTotal;

                lblTotalVehicules.Text = totalVehicules.ToString();
                lblVehiculesLouees.Text = vehiculesLouees.ToString();
                lblVehiculesDisponibles.Text = vehiculesDisponibles.ToString();
                lblVehiculesMaintenance.Text = vehiculesMaintenance.ToString();
                lblTotalClients.Text = totalClients.ToString();

                lblEntreesJour.Text = entreesJour.ToString("N2") + " DH";
                lblSortiesJour.Text = sortiesJour.ToString("N2") + " DH";
                lblSoldeJour.Text = soldeJour.ToString("N2") + " DH";

                lblParkTotal.Text = parkTotal.ToString();
                lblParkOccupe.Text = parkOccupe.ToString();
                lblParkDisponible.Text = parkDisponible.ToString();
                lblTauxOccupation.Text = tauxOccupation.ToString("0.##") + " % occupées";

                lblEntreesMois.Text = entreesMois.ToString("N2") + " DH";
                lblSortiesMois.Text = sortiesMois.ToString("N2") + " DH";
                lblBeneficeNet.Text = beneficeNet.ToString("N2") + " DH";
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "ChargerStatistiques");
                MessageService.Error("Erreur lors du chargement des statistiques.");
            }
        }

        private void ChargerTopVehicules()
        {
            try
            {
                string query = @"
                    SELECT 
                        CONCAT(v.matricule, ' - ', v.marque, ' ', v.modele) AS 'Véhicule',
                        COUNT(*) AS 'Nombre locations'
                    FROM contrats c
                    INNER JOIN voitures v ON c.voiture_id = v.voiture_id
                    GROUP BY c.voiture_id, v.matricule, v.marque, v.modele
                    ORDER BY COUNT(*) DESC
                    LIMIT 5;";

                dgvTopVehicules.DataSource = Dbexec.GetData(query);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "ChargerTopVehicules");
                MessageService.Error("Erreur lors du chargement des véhicules les plus loués.");
            }
        }

        private void ChargerDernieresLocations()
        {
            try
            {
                string query = @"
                    SELECT
                        c.contrat_id AS 'Contrat',
                        c.client_id AS 'Client ID',
                        CONCAT(v.matricule, ' - ', v.marque, ' ', v.modele) AS 'Véhicule',
                        DATE_FORMAT(c.date_contrat, '%d/%m/%Y') AS 'Date début',
                        DATE_FORMAT(c.date_retour_prevu, '%d/%m/%Y') AS 'Date fin',
                        CONCAT(FORMAT(c.total, 2), ' DH') AS 'Montant'
                    FROM contrats c
                    LEFT JOIN voitures v ON c.voiture_id = v.voiture_id
                    ORDER BY c.contrat_id DESC
                    LIMIT 5;";

                dgvDernieresLocations.DataSource = Dbexec.GetData(query);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "ChargerDernieresLocations");
                MessageService.Error("Erreur lors du chargement des dernières locations.");
            }
        }

        private void ChargerActivites()
        {
            try
            {
                string query = @"
                    SELECT
                        utilisateur AS 'Utilisateur',
                        message AS 'Opération',
                        DATE_FORMAT(date, '%d/%m/%Y %H:%i:%s') AS 'Date'
                    FROM logs
                    ORDER BY id DESC
                    LIMIT 8;";

                dgvActivites.DataSource = Dbexec.GetData(query);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "ChargerActivites");
                MessageService.Error("Erreur lors du chargement des activités.");
            }
        }

        private void AppliquerStyles()
        {
            try
            {
                StyleGrid(dgvTopVehicules);
                StyleGrid(dgvDernieresLocations);
                StyleGrid(dgvActivites);

                if (dgvTopVehicules.Columns.Count > 0)
                {
                    dgvTopVehicules.Columns["Véhicule"].FillWeight = 70;
                    dgvTopVehicules.Columns["Nombre locations"].FillWeight = 30;
                }

                if (dgvDernieresLocations.Columns.Count > 0)
                {
                    dgvDernieresLocations.Columns["Contrat"].FillWeight = 12;
                    dgvDernieresLocations.Columns["Client ID"].FillWeight = 15;
                    dgvDernieresLocations.Columns["Véhicule"].FillWeight = 35;
                    dgvDernieresLocations.Columns["Date début"].FillWeight = 18;
                    dgvDernieresLocations.Columns["Date fin"].FillWeight = 18;
                    dgvDernieresLocations.Columns["Montant"].FillWeight = 18;

                    dgvDernieresLocations.Columns["Véhicule"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                if (dgvActivites.Columns.Count > 0)
                {
                    dgvActivites.Columns["Utilisateur"].FillWeight = 20;
                    dgvActivites.Columns["Opération"].FillWeight = 55;
                    dgvActivites.Columns["Date"].FillWeight = 25;

                    dgvActivites.Columns["Opération"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "AppliquerStyles");
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

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 61, 122);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 36;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(45, 55, 72);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);
            dgv.RowTemplate.Height = 32;
        }
    }
}