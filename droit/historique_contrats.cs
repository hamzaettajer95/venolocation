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

            if (cb_statut.SelectedItem == null) return;

            string selectedStatus = cb_statut.SelectedItem.ToString();
            string query = "";
            string filter = " WHERE 1=1 ";

            
            if (cb_client.SelectedValue != null && Convert.ToInt32(cb_client.SelectedValue) > 0)
                filter += $" AND client_id = {cb_client.SelectedValue}";

            
            if (cb_voiture.SelectedValue != null && Convert.ToInt32(cb_voiture.SelectedValue) > 0)
                filter += $" AND voiture_id = {cb_voiture.SelectedValue}";


          
            string dateStart = dtp_debut.Value.ToString("yyyy-MM-dd");
            string dateEnd = dtp_fin.Value.ToString("yyyy-MM-dd");

          
            filter += $" AND DATE(date_contrat) >= '{dateStart}' AND DATE(date_retour_prevu) <= '{dateEnd}'";




            if (selectedStatus == "En cours")
            {
                query = "SELECT contrat_id, client_id, voiture_id, status, date_contrat, date_retour_prevu, total FROM contrats" + filter;
            }
            else if (selectedStatus == "Tout")
            {
                
                query = $@"SELECT contrat_id, client_id, voiture_id, status, date_contrat, date_retour_prevu, total FROM contrats {filter}
                          UNION 
                          SELECT contrat_id, client_id, voiture_id, status, date_contrat, date_retour_prevu, total FROM old_contrats {filter}";
            }
            else
            {
                
                query = $"SELECT contrat_id, client_id, voiture_id, status, date_contrat, date_retour_prevu, total FROM old_contrats {filter} AND status = '{selectedStatus}'";
            }

            try
            {
                dgvHistory.DataSource = DbHelper.GetData(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la récupération des données : " + ex.Message);
            }
        }

        private void FillCombos()
        {
            try
            {
                
                DataTable dtClients = DbHelper.GetData("SELECT client_id, nom FROM clients");
                DataRow drClient = dtClients.NewRow();
                drClient["client_id"] = 0; 
                drClient["nom"] = "--- Tout ---";
                dtClients.Rows.InsertAt(drClient, 0); 

                cb_client.DataSource = dtClients;
                cb_client.DisplayMember = "nom";
                cb_client.ValueMember = "client_id";

               
                DataTable dtCars = DbHelper.GetData("SELECT voiture_id, matricule FROM voitures");
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
                MessageBox.Show("Erreur lors du chargement des listes : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void historique_contrats_Load(object sender, EventArgs e)
        {
            FillCombos();            
            cb_statut.SelectedIndex = 0;
            dtp_debut.Value = DateTime.Now.AddMonths(-1);
            dtp_fin.Value = DateTime.Now.AddMonths(1);

            LoadContracts();
        }

        private void btnannuller_Click(object sender, EventArgs e)
        {
            if (dgvHistory.CurrentRow != null)
            {
                string status = dgvHistory.CurrentRow.Cells["status"].Value.ToString();
                if (status != "En cours")
                {
                    MessageBox.Show("Vous ne pouvez pas annuler un contrat déjà terminé ou annulé.", "Action Interdite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idContrat = Convert.ToInt32(dgvHistory.CurrentRow.Cells["contrat_id"].Value);
                int idVoiture = Convert.ToInt32(dgvHistory.CurrentRow.Cells["voiture_id"].Value);

                DialogResult res = MessageBox.Show("Êtes-vous sûr de vouloir annuler ce contrat ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    try
                    {
                        string archiveQuery = @"INSERT INTO old_contrats (contrat_id, client_id, voiture_id, date_contrat, date_retour_prevu, status, total) 
                                               SELECT contrat_id, client_id, voiture_id, date_contrat, date_retour_prevu, 'Annulé', total 
                                               FROM contrats WHERE contrat_id = @id";
                        DbHelper.ExecuteQuery(archiveQuery, new MySqlParameter[] { new MySqlParameter("@id", idContrat) });

                        DbHelper.ExecuteQuery("DELETE FROM contrats WHERE contrat_id = @id", new MySqlParameter[] { new MySqlParameter("@id", idContrat) });

                        DbHelper.ExecuteQuery("UPDATE voitures SET etat = 'Disponible' WHERE voiture_id = @vid", new MySqlParameter[] { new MySqlParameter("@vid", idVoiture) });

                        MessageBox.Show("Contrat annulé avec succès et véhicule libéré.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadContracts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Echec de l'opération : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistory.CurrentRow != null && dgvHistory.CurrentRow.Cells["status"].Value != null)
            {
                string status = dgvHistory.CurrentRow.Cells["status"].Value.ToString();
                btnAnnuler.Enabled = (status == "En cours");
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {


        
            LoadContracts();
        }
    }
}
