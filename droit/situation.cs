using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using venolocation.classee;
using System.Windows.Forms.DataVisualization.Charting;
using WinChart = System.Windows.Forms.DataVisualization.Charting.Chart;
using WinSeries = System.Windows.Forms.DataVisualization.Charting.Series;
using WinChartArea = System.Windows.Forms.DataVisualization.Charting.ChartArea;
using WinLegend = System.Windows.Forms.DataVisualization.Charting.Legend;
using WinDocking = System.Windows.Forms.DataVisualization.Charting.Docking;
using WinChartColorPalette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette;
using WinSeriesChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType;



namespace venolocation.droit
{
    public partial class situation : Form
    {
        public situation()
        {
            InitializeComponent();
        }
        private Timer tmrHorloge;
        private const int capaciteParking = 30;
        private void situation_Load(object sender, EventArgs e)
        {
            try
            {
                InitialiserHorloge();
                InitialiserCharts();
                ChargerTout();

                
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "situation_Load");
                MessageService.Error("Erreur lors du chargement du formulaire situation.");
            }
        }
        private void InitialiserHorloge()
        {
            try
            {
                tmrHorloge = new Timer();
                tmrHorloge.Interval = 1000;
                tmrHorloge.Tick += TmrHorloge_Tick;
                tmrHorloge.Start();
                MettreAJourDateHeure();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "InitialiserHorloge");
            }
        }
        private void TmrHorloge_Tick(object sender, EventArgs e)
        {
            MettreAJourDateHeure();
        }
        private void MettreAJourDateHeure()
        {
            try
            {
                CultureInfo fr = new CultureInfo("fr-FR");
                lblDateHeure.Text = DateTime.Now.ToString("dddd dd MMMM yyyy    HH:mm:ss", fr);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "MettreAJourDateHeure");
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            try
            {
                ChargerTout();
               
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
            AppliquerStylesGrids();
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
                int vehiculesMaintenance = GetIntValue("SELECT COUNT(*) FROM voitures WHERE etat IN ('En maintenance','Maintenance','Réparation')");
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

                int percentLouees = totalVehicules > 0 ? (vehiculesLouees * 100) / totalVehicules : 0;
                int percentDisponibles = totalVehicules > 0 ? (vehiculesDisponibles * 100) / totalVehicules : 0;
                int percentMaintenance = totalVehicules > 0 ? (vehiculesMaintenance * 100) / totalVehicules : 0;
                int percentClients = totalClients > 0 ? 100 : 0;
                int tauxOccupation = parkTotal > 0 ? (parkOccupe * 100) / parkTotal : 0;

                // values
                lblTotalVehicules.Text = totalVehicules.ToString();
                lblVehiculesLouees.Text = vehiculesLouees.ToString();
                lblVehiculesDisponibles.Text = vehiculesDisponibles.ToString();
                lblVehiculesMaintenance.Text = vehiculesMaintenance.ToString();
                lblTotalClients.Text = totalClients.ToString();

                // percents
                lblPercentTotalVehicules.Text = "100%";
                lblPercentLouees.Text = percentLouees + "%";
                lblPercentDisponibles.Text = percentDisponibles + "%";
                lblPercentMaintenance.Text = percentMaintenance + "%";
                lblPercentClients.Text = percentClients + "%";

                // progress
                pbTotalVehicules.Value = 100;
                pbVehiculesLouees.Value = Math.Max(0, Math.Min(100, percentLouees));
                pbVehiculesDisponibles.Value = Math.Max(0, Math.Min(100, percentDisponibles));
                pbVehiculesMaintenance.Value = Math.Max(0, Math.Min(100, percentMaintenance));
                pbTotalClients.Value = Math.Max(0, Math.Min(100, percentClients));

                // finance jour
                lblEntreesJour.Text = entreesJour.ToString("N2") + " DH";
                lblSortiesJour.Text = sortiesJour.ToString("N2") + " DH";
                lblSoldeJour.Text = soldeJour.ToString("N2") + " DH";

                // parking
                lblParkTotal.Text = parkTotal.ToString();
                lblParkOccupe.Text = parkOccupe.ToString();
                lblParkDisponible.Text = parkDisponible.ToString();
                lblTauxOccupation.Text = tauxOccupation + "%";

                // mois
                lblEntreesMois.Text = entreesMois.ToString("N2") + " DH";
                lblSortiesMois.Text = sortiesMois.ToString("N2") + " DH";
                lblBeneficeNet.Text = beneficeNet.ToString("N2") + " DH";

                ChargerChartVehicules(vehiculesLouees, vehiculesDisponibles, vehiculesMaintenance);
                //ChargerChartRevenus(entreesMois, sortiesMois, beneficeNet);
                ChargerChartRevenusMois();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "ChargerStatistiques");
                MessageService.Error("Erreur lors du chargement des statistiques.");
            }
        }

        private void InitialiserCharts()
        {
            try
            {
                InitialiserChart(chartVehicules);
                InitialiserChart(chartRevenus);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "InitialiserCharts");
            }
        }

        private void InitialiserChart(Chart chart)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Legends.Clear();

            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.White;
            chart.ChartAreas.Add(area);

            Legend legend = new Legend("Legend1");
            legend.Docking = Docking.Right;
            legend.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            chart.Legends.Add(legend);

            chart.BackColor = Color.White;
            chart.Palette = ChartColorPalette.None;
        }

        private void ChargerChartVehicules(int louees, int disponibles, int maintenance)
        {
            chartVehicules.Series.Clear();

            Series s = new Series("Répartition");
            s.ChartType = SeriesChartType.Doughnut;
            s.IsValueShownAsLabel = true;
            s.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            s.Points.AddXY("Louées", louees);
            s.Points.AddXY("Disponibles", disponibles);
            s.Points.AddXY("Maintenance", maintenance);

            s.Points[0].Color = Color.FromArgb(34, 197, 94);
            s.Points[1].Color = Color.FromArgb(245, 158, 11);
            s.Points[2].Color = Color.FromArgb(239, 68, 68);

            chartVehicules.Series.Add(s);
        }

        private void ChargerChartRevenusMois()
        {
            try
            {
                chartRevenus.Series.Clear();
                chartRevenus.ChartAreas.Clear();
                chartRevenus.Legends.Clear();

                WinChartArea area = new WinChartArea("RevenusArea");
                area.BackColor = Color.White;
                chartRevenus.ChartAreas.Add(area);

                WinLegend legend = new WinLegend("Legend1");
                legend.Docking = WinDocking.Right;
                legend.BackColor = Color.White;
                legend.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                chartRevenus.Legends.Add(legend);

                chartRevenus.BackColor = Color.White;
                chartRevenus.Palette = WinChartColorPalette.None;

                WinSeries s = new WinSeries("Revenus");
                s.ChartType = WinSeriesChartType.Doughnut;
                s.IsValueShownAsLabel = true;
                s.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                s.LabelForeColor = Color.FromArgb(45, 55, 72);
                s.LegendText = "#VALX";
                s.Label = "#VALY{N0} DH";
                s["PieLabelStyle"] = "Outside";
                s["DoughnutRadius"] = "58";

                decimal locations = GetDecimalValue(@"
            SELECT IFNULL(SUM(montant),0)
            FROM recettes
            WHERE MONTH(date_recette)=MONTH(CURDATE())
              AND YEAR(date_recette)=YEAR(CURDATE())
              AND (type = 'Location' OR type = 'Contrat')");

                decimal accidents = GetDecimalValue(@"
            SELECT IFNULL(SUM(montant),0)
            FROM recettes
            WHERE MONTH(date_recette)=MONTH(CURDATE())
              AND YEAR(date_recette)=YEAR(CURDATE())
              AND type = 'Accident'");

                decimal autres = GetDecimalValue(@"
            SELECT IFNULL(SUM(montant),0)
            FROM recettes
            WHERE MONTH(date_recette)=MONTH(CURDATE())
              AND YEAR(date_recette)=YEAR(CURDATE())
              AND type NOT IN ('Location', 'Contrat', 'Accident')");

                if (locations > 0) s.Points.AddXY("Locations", locations);
                if (accidents > 0) s.Points.AddXY("Accidents", accidents);
                if (autres > 0) s.Points.AddXY("Autres", autres);

                if (s.Points.Count > 0) s.Points[0].Color = Color.FromArgb(59, 130, 246);
                if (s.Points.Count > 1) s.Points[1].Color = Color.FromArgb(34, 197, 94);
                if (s.Points.Count > 2) s.Points[2].Color = Color.FromArgb(245, 158, 11);

                chartRevenus.Series.Add(s);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "ChargerChartRevenusMois");
                MessageService.Error("Erreur chargement chart revenus.");
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
                MessageService.Error("Erreur chargement Top véhicules.");
            }
        }

        private void ChargerDernieresLocations()
        {
            try
            {
                string query = @"
                    SELECT
                        c.contrat_id AS 'Contrat',
                        CONCAT(cl.nom, ' ', cl.prenom) AS 'Client',
                        CONCAT(v.matricule, ' - ', v.marque, ' ', v.modele) AS 'Véhicule',
                        DATE_FORMAT(c.date_contrat, '%d/%m/%Y') AS 'Date début',
                        DATE_FORMAT(c.date_retour_prevu, '%d/%m/%Y') AS 'Date fin',
                        CONCAT(FORMAT(c.total, 2), ' DH') AS 'Montant'
                    FROM contrats c
                    LEFT JOIN clients cl ON c.client_id = cl.client_id
                    LEFT JOIN voitures v ON c.voiture_id = v.voiture_id
                    ORDER BY c.contrat_id DESC
                    LIMIT 5;";

                dgvDernieresLocations.DataSource = Dbexec.GetData(query);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "ChargerDernieresLocations");
                MessageService.Error("Erreur chargement dernières locations.");
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
                        DATE_FORMAT(date, '%d/%m/%Y') AS 'Date'
                    FROM logs
                    ORDER BY id DESC
                    LIMIT 8;";

                dgvActivites.DataSource = Dbexec.GetData(query);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "ChargerActivites");
                MessageService.Error("Erreur chargement activités.");
            }
        }

        private void AppliquerStylesGrids()
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
                    dgvTopVehicules.Columns["Véhicule"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                if (dgvDernieresLocations.Columns.Count > 0)
                {
                    dgvDernieresLocations.Columns["Contrat"].FillWeight = 12;
                    dgvDernieresLocations.Columns["Client"].FillWeight = 20;
                    dgvDernieresLocations.Columns["Véhicule"].FillWeight = 30;
                    dgvDernieresLocations.Columns["Date début"].FillWeight = 16;
                    dgvDernieresLocations.Columns["Date fin"].FillWeight = 16;
                    dgvDernieresLocations.Columns["Montant"].FillWeight = 16;
                    dgvDernieresLocations.Columns["Client"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
                dbErreur.AddLog(ex.Message, Session.Username, "situation", "AppliquerStylesGrids");
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
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 36;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(40, 40, 40);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 252);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 253);
            dgv.RowTemplate.Height = 32;
        }
    }
}
