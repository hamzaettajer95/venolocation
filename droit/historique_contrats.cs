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
        private void LoadContracts()
        {

            if (cb_statut.SelectedItem == null) return;

            string selectedStatus = cb_statut.SelectedItem.ToString();
            string query ;
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
            else if (selectedStatus == "--- Tout ---")
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
                dgvHistory.DataSource = Dbexec.GetData(query);
                StyleGrid(dgvHistory);
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
                
                DataTable dtClients = Dbexec.GetData("SELECT client_id, nom FROM clients");
                DataRow drClient = dtClients.NewRow();
                drClient["client_id"] = 0; 
                drClient["nom"] = "--- Tout ---";
                dtClients.Rows.InsertAt(drClient, 0); 

                cb_client.DataSource = dtClients;
                cb_client.DisplayMember = "nom";
                cb_client.ValueMember = "client_id";

               
                DataTable dtCars = Dbexec.GetData("SELECT voiture_id, matricule FROM voitures");
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
                        Dbexec.ExecuteQuery(archiveQuery, new MySqlParameter[] { new MySqlParameter("@id", idContrat) });

                        Dbexec.ExecuteQuery("DELETE FROM contrats WHERE contrat_id = @id", new MySqlParameter[] { new MySqlParameter("@id", idContrat) });

                        Dbexec.ExecuteQuery("UPDATE voitures SET etat = 'Disponible' WHERE voiture_id = @vid", new MySqlParameter[] { new MySqlParameter("@vid", idVoiture) });
                        
                        
                        
                        LogHelper.AddLog("Annulation contrat ID: " + idContrat, Session.Username);
                        MessageBox.Show("Contrat annulé avec succès et véhicule libéré.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadContracts();
                    }
                    catch (Exception ex)
                    {
                        dbErreur.AddLog(ex.Message, Session.Username, "historique_contrats", "btnannuller_Click");
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

        private void btnAnnuler_Click(object sender, EventArgs e)
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
                        Dbexec.ExecuteQuery(archiveQuery, new MySqlParameter[] { new MySqlParameter("@id", idContrat) });

                        Dbexec.ExecuteQuery("DELETE FROM contrats WHERE contrat_id = @id", new MySqlParameter[] { new MySqlParameter("@id", idContrat) });

                        Dbexec.ExecuteQuery("UPDATE voitures SET etat = 'Disponible' WHERE voiture_id = @vid", new MySqlParameter[] { new MySqlParameter("@vid", idVoiture) });



                        LogHelper.AddLog("Annulation contrat ID: " + idContrat, Session.Username);
                        MessageBox.Show("Contrat annulé avec succès et véhicule libéré.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadContracts();
                    }
                    catch (Exception ex)
                    {
                        dbErreur.AddLog(ex.Message, Session.Username, "historique_contrats", "btnannuller_Click");
                        MessageBox.Show("Echec de l'opération : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
