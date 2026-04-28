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
using venolocation.classee;
using venolocation.formee;



namespace venolocation.droit
{
    public partial class historique_contrats : Form
    {
        public historique_contrats()
        {
            InitializeComponent();
        }


        private void LoadContracts()
        {
            if (cb_statut.SelectedItem == null)
                return;

            try
            {
                string selectedStatus = cb_statut.SelectedItem.ToString();

                string query;
                List<MySqlParameter> ps = new List<MySqlParameter>();

                string filter = " WHERE 1=1 ";

                if (cb_client.SelectedValue != null && Convert.ToInt32(cb_client.SelectedValue) > 0)
                {
                    filter += " AND client_id = @client_id ";
                    ps.Add(new MySqlParameter("@client_id", Convert.ToInt32(cb_client.SelectedValue)));
                }

                if (cb_voiture.SelectedValue != null && Convert.ToInt32(cb_voiture.SelectedValue) > 0)
                {
                    filter += " AND voiture_id = @voiture_id ";
                    ps.Add(new MySqlParameter("@voiture_id", Convert.ToInt32(cb_voiture.SelectedValue)));
                }

                filter += " AND DATE(date_contrat) >= @date_debut AND DATE(date_retour_prevu) <= @date_fin ";
                ps.Add(new MySqlParameter("@date_debut", dtp_debut.Value.Date));
                ps.Add(new MySqlParameter("@date_fin", dtp_fin.Value.Date));

                if (selectedStatus == AppStatus.ContratEnCours)
                {
                    query = @"
                                SELECT 
                                    contrat_id AS 'ID',
                                    client_id AS 'Client ID',
                                    voiture_id AS 'Voiture ID',
                                    status AS 'Statut',
                                    DATE_FORMAT(date_contrat, '%d/%m/%Y') AS 'Date contrat',
                                    DATE_FORMAT(date_retour_prevu, '%d/%m/%Y') AS 'Retour prévu',
                                    total AS 'Total'
                                FROM contrats " + filter + @"
                                ORDER BY contrat_id DESC
                                LIMIT 300;";
                }
                else if (selectedStatus == "--- Tout ---")
                {
                    query = @"
                            SELECT 
                                c.contrat_id AS 'ID',
                                c.client_id AS 'Client ID',
                                c.voiture_id AS 'Voiture ID',
                                c.status AS 'Statut',
                                DATE_FORMAT(c.date_contrat, '%d/%m/%Y') AS 'Date contrat',
                                DATE_FORMAT(c.date_retour_prevu, '%d/%m/%Y') AS 'Retour prévu',
                                c.total AS 'Total'
                            FROM contrats c
                            WHERE 1=1 ";

                    if (cb_client.SelectedValue != null && Convert.ToInt32(cb_client.SelectedValue) > 0)
                        query += " AND c.client_id = @client_id ";

                    if (cb_voiture.SelectedValue != null && Convert.ToInt32(cb_voiture.SelectedValue) > 0)
                        query += " AND c.voiture_id = @voiture_id ";

                    query += @" 
                                AND DATE(c.date_contrat) >= @date_debut 
                                AND DATE(c.date_retour_prevu) <= @date_fin

                            UNION ALL

                            SELECT 
                                o.contrat_id AS 'ID',
                                o.client_id AS 'Client ID',
                                o.voiture_id AS 'Voiture ID',
                                o.status AS 'Statut',
                                DATE_FORMAT(o.date_contrat, '%d/%m/%Y') AS 'Date contrat',
                                DATE_FORMAT(o.date_retour_prevu, '%d/%m/%Y') AS 'Retour prévu',
                                o.total AS 'Total'
                            FROM old_contrats o
                            WHERE 1=1 ";

                    if (cb_client.SelectedValue != null && Convert.ToInt32(cb_client.SelectedValue) > 0)
                        query += " AND o.client_id = @client_id ";

                    if (cb_voiture.SelectedValue != null && Convert.ToInt32(cb_voiture.SelectedValue) > 0)
                        query += " AND o.voiture_id = @voiture_id ";

                    query += @"
                                    AND DATE(o.date_contrat) >= @date_debut 
                                    AND DATE(o.date_retour_prevu) <= @date_fin
                                    AND NOT EXISTS (
                                        SELECT 1 
                                        FROM contrats c2 
                                        WHERE c2.contrat_id = o.contrat_id
                                    )

                                ORDER BY ID DESC
                                LIMIT 300;";
                }
            
                else
                {
                    filter += " AND status = @status ";
                    ps.Add(new MySqlParameter("@status", selectedStatus));

                    query = @"
                            SELECT 
                            contrat_id AS 'ID',
                            client_id AS 'Client ID',
                            voiture_id AS 'Voiture ID',
                            status AS 'Statut',
                            DATE_FORMAT(date_contrat, '%d/%m/%Y') AS 'Date contrat',
                            DATE_FORMAT(date_retour_prevu, '%d/%m/%Y') AS 'Retour prévu',
                            total AS 'Total'
                            FROM old_contrats " + filter + @"
                            ORDER BY contrat_id DESC
                            LIMIT 300;";
                }

                dgvHistory.DataSource = Dbexec.GetData(query, ps.ToArray());

                GridStyleHelper_1.Apply(dgvHistory);

                if (dgvHistory.Columns.Count > 0)
                {
                    dgvHistory.Columns["ID"].FillWeight = 10;
                    dgvHistory.Columns["Client ID"].FillWeight = 15;
                    dgvHistory.Columns["Voiture ID"].FillWeight = 15;
                    dgvHistory.Columns["Statut"].FillWeight = 18;
                    dgvHistory.Columns["Date contrat"].FillWeight = 18;
                    dgvHistory.Columns["Retour prévu"].FillWeight = 18;
                    dgvHistory.Columns["Total"].FillWeight = 15;
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "historique_contrats", "LoadContracts");
                MessageBox.Show("Erreur lors de la récupération des données : " + ex.Message);
            }
        }

        private void FillCombos()
        {
            try
            {
                DataTable dtClients = Dbexec.GetData(@"
                                                        SELECT client_id, nom
                                                        FROM clients
                                                        ORDER BY nom
                                                        LIMIT 500;");

                DataRow drClient = dtClients.NewRow();
                drClient["client_id"] = 0;
                drClient["nom"] = "--- Tout ---";
                dtClients.Rows.InsertAt(drClient, 0);

                cb_client.DataSource = dtClients;
                cb_client.DisplayMember = "nom";
                cb_client.ValueMember = "client_id";

                DataTable dtCars = Dbexec.GetData(@"
                                                    SELECT voiture_id, matricule
                                                    FROM voitures
                                                    ORDER BY matricule
                                                    LIMIT 500;");

                DataRow drCar = dtCars.NewRow();
                drCar["voiture_id"] = 0;
                drCar["matricule"] = "--- Tout ---";
                dtCars.Rows.InsertAt(drCar, 0);

                cb_voiture.DataSource = dtCars;
                cb_voiture.DisplayMember = "matricule";
                cb_voiture.ValueMember = "voiture_id";

                cb_client.SelectedIndex = 0;
                cb_voiture.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "historique_contrats", "FillCombos");
                MessageBox.Show("Erreur lors du chargement des listes : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void historique_contrats_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                FillCombos();

                cb_statut.Items.Clear();
                cb_statut.Items.Add("--- Tout ---");
                cb_statut.Items.Add(AppStatus.ContratEnCours);
                cb_statut.Items.Add(AppStatus.ContratTermine);
                cb_statut.Items.Add(AppStatus.ContratAnnule);
                cb_statut.SelectedIndex = 0;

                dtp_debut.Value = DateTime.Now.AddMonths(-1);
                dtp_fin.Value = DateTime.Now.AddMonths(1);

                LoadContracts();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "historique_contrats", "historique_contrats_Load");
                MessageBox.Show("Erreur lors du chargement du formulaire : " + ex.Message);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void btnannuller_Click(object sender, EventArgs e)
        {
           
            
        }

        private void dgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistory.CurrentRow != null && dgvHistory.CurrentRow.Cells["Statut"].Value != null)
            {
                string status = dgvHistory.CurrentRow.Cells["Statut"].Value.ToString();
                btnAnnuler.Enabled = (status == AppStatus.ContratEnCours);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {


        
            LoadContracts();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            AnnulerContratSelectionne();
        }

        private void AnnulerContratSelectionne()
        {
            if (dgvHistory.CurrentRow == null)
                return;

            string status = dgvHistory.CurrentRow.Cells["Statut"].Value.ToString();

            if (status != AppStatus.ContratEnCours)
            {
                MessageBox.Show("Vous ne pouvez pas annuler un contrat déjà terminé ou annulé.", "Action Interdite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idContrat = Convert.ToInt32(dgvHistory.CurrentRow.Cells["ID"].Value);
            int idVoiture = Convert.ToInt32(dgvHistory.CurrentRow.Cells["Voiture ID"].Value);

            DialogResult res = MessageBox.Show("Êtes-vous sûr de vouloir annuler ce contrat ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
                return;

            try
            {
                string archiveQuery = @"
                            INSERT INTO old_contrats 
                            (contrat_id, client_id, voiture_id, date_contrat, date_retour_prevu, status, total)
                            SELECT 
                                contrat_id, client_id, voiture_id, date_contrat, date_retour_prevu, @status_annule, total
                            FROM contrats 
                            WHERE contrat_id = @id";

                MySqlParameter[] psArchive =
                {
                                new MySqlParameter("@status_annule", AppStatus.ContratAnnule),
                                new MySqlParameter("@id", idContrat)
                   };

                Dbexec.ExecuteQuery(archiveQuery, psArchive);

                Dbexec.ExecuteQuery(
                    "DELETE FROM contrats WHERE contrat_id = @id",
                    new MySqlParameter[]
                    {
                new MySqlParameter("@id", idContrat)
                    });

                Dbexec.ExecuteQuery(
                    "UPDATE voitures SET etat = @etat WHERE voiture_id = @vid",
                    new MySqlParameter[]
                    {
                new MySqlParameter("@etat", AppStatus.VoitureDisponible),
                new MySqlParameter("@vid", idVoiture)
                    });

                LogHelper.AddLog("Annulation contrat ID: " + idContrat, Session.Username);
                MessageBox.Show("Contrat annulé avec succès et véhicule libéré.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadContracts();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "historique_contrats", "AnnulerContratSelectionne");
                MessageBox.Show("Echec de l'opération : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
