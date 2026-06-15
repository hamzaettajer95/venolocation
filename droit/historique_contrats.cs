using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;
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

        private int contratIdSelectionne = 0;
        private void LoadContracts()
        {
            try
            {
                string selectedStatus = cb_statut.SelectedItem == null
                    ? "--- Tout ---"
                    : cb_statut.SelectedItem.ToString();

                bool afficherArchive = chkArchive.Checked;

                string tableName = afficherArchive ? "contrats_archive" : "contrats";

                List<MySqlParameter> ps = new List<MySqlParameter>();

                string query = @"
                        SELECT 
                            c.contrat_id AS 'ID',

                            c.client_id AS 'Client ID',
                            cl.cin AS 'CIN Client',

                            c.voiture_id AS 'Voiture ID',
                            v.matricule AS 'Matricule',

                            c.status AS 'Statut',
                            DATE_FORMAT(c.date_contrat, '%d/%m/%Y') AS 'Date contrat',
                            DATE_FORMAT(c.date_retour_prevu, '%d/%m/%Y') AS 'Retour prévu',
                            c.total AS 'Total'
                        FROM " + tableName + @" c
                        LEFT JOIN clients cl ON cl.client_id = c.client_id
                        LEFT JOIN voitures v ON v.voiture_id = c.voiture_id
                        WHERE 1=1 ";

                if (cb_client.SelectedValue != null && Convert.ToInt32(cb_client.SelectedValue) > 0)
                {
                    query += " AND c.client_id = @client_id ";
                    ps.Add(new MySqlParameter("@client_id", Convert.ToInt32(cb_client.SelectedValue)));
                }

                if (cb_voiture.SelectedValue != null && Convert.ToInt32(cb_voiture.SelectedValue) > 0)
                {
                    query += " AND c.voiture_id = @voiture_id ";
                    ps.Add(new MySqlParameter("@voiture_id", Convert.ToInt32(cb_voiture.SelectedValue)));
                }

                if (selectedStatus != "--- Tout ---")
                {
                    query += " AND c.status = @status ";
                    ps.Add(new MySqlParameter("@status", selectedStatus));
                }

                
                if (chkFiltrerDate.Checked)
                {
                    query += @"
                            AND DATE(c.date_contrat) >= @date_debut
                            AND DATE(c.date_retour_prevu) <= @date_fin ";

                    ps.Add(new MySqlParameter("@date_debut", dtp_debut.Value.Date));
                    ps.Add(new MySqlParameter("@date_fin", dtp_fin.Value.Date));
                }

                query += @"
                            ORDER BY c.contrat_id DESC
                            LIMIT 400;
                        ";

                dgvHistory.DataSource = Dbexec.GetData(query, ps.ToArray());

                GridStyleHelper_1.Apply(dgvHistory);

                if (dgvHistory.Columns.Count > 0)
                {
                    
                    if (dgvHistory.Columns.Contains("Client ID"))
                        dgvHistory.Columns["Client ID"].Visible = false;

                    if (dgvHistory.Columns.Contains("Voiture ID"))
                        dgvHistory.Columns["Voiture ID"].Visible = false;

                    dgvHistory.Columns["ID"].FillWeight = 8;
                    dgvHistory.Columns["CIN Client"].FillWeight = 18;
                    dgvHistory.Columns["Matricule"].FillWeight = 18;
                    dgvHistory.Columns["Statut"].FillWeight = 16;
                    dgvHistory.Columns["Date contrat"].FillWeight = 16;
                    dgvHistory.Columns["Retour prévu"].FillWeight = 16;
                    dgvHistory.Columns["Total"].FillWeight = 12;
                }
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "historique_contrats", "LoadContracts");

                dbErreur.AddLog(
                    ex.Message,
                    Session.Username,
                    "historique_contrats",
                    "LoadContracts"
                );

                MessageBox.Show(
                    "Erreur lors de la récupération des données : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void ActiverAutoComplete(ComboBox combo)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void FillCombos()
        {
            try
            {
                DataTable dtClients = Dbexec.GetData(@"SELECT client_id, cin FROM clients ORDER BY cin LIMIT 500;");

                DataRow drClient = dtClients.NewRow();
                drClient["client_id"] = 0;
                drClient["cin"] = "--- Tout ---";
                dtClients.Rows.InsertAt(drClient, 0);

                cb_client.DataSource = dtClients;
                cb_client.DisplayMember = "cin";
                cb_client.ValueMember = "client_id";
                ActiverAutoComplete(cb_client);


                DataTable dtCars = Dbexec.GetData(@" SELECT voiture_id, matricule  FROM voitures ORDER BY matricule  LIMIT 500;");

                DataRow drCar = dtCars.NewRow();
                drCar["voiture_id"] = 0;
                drCar["matricule"] = "--- Tout ---";
                dtCars.Rows.InsertAt(drCar, 0);

                cb_voiture.DataSource = dtCars;
                cb_voiture.DisplayMember = "matricule";
                cb_voiture.ValueMember = "voiture_id";
                ActiverAutoComplete(cb_voiture);

                cb_client.SelectedIndex = 0;
                cb_voiture.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "historique_contrats", "FillCombos");
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

                chkFiltrerDate.Checked = false;
                dtp_debut.Enabled = false;
                dtp_fin.Enabled = false;

                cb_statut.Items.Clear();
                cb_statut.Items.Add("--- Tout ---");
                cb_statut.Items.Add(AppStatus.ContratEnCours);
                cb_statut.Items.Add(AppStatus.ContratTermine);
                cb_statut.Items.Add(AppStatus.ContratAnnule);
                cb_statut.SelectedIndex = 0;

                
                dtp_debut.Value = DateTime.Now.AddMonths(-1);
                dtp_fin.Value = DateTime.Now.AddMonths(1);

                chkFiltrerDate.Checked = false;
                dtp_debut.Enabled = false;
                dtp_fin.Enabled = false;

                LoadContracts();

                
            }
            catch (Exception ex)
            {
               // ErrorReporter.SendError(ex, "historique_contrats", "historique_contrats_Load");
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
            if (dgvHistory.CurrentRow == null || dgvHistory.CurrentRow.Cells["Statut"].Value == null)
                return;

            if (chkArchive.Checked)
            {
                btnAnnuler.Enabled = false;
                return;
            }

            string status = dgvHistory.CurrentRow.Cells["Statut"].Value.ToString();
            btnAnnuler.Enabled = (status == AppStatus.ContratEnCours);


            contratIdSelectionne = Convert.ToInt32(dgvHistory.CurrentRow.Cells["ID"].Value);
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
                ErrorReporter.SendError(ex, "historique_contrats", "AnnulerContratSelectionne");
                dbErreur.AddLog(ex.Message, Session.Username, "historique_contrats", "AnnulerContratSelectionne");
                MessageBox.Show("Echec de l'opération : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkArchive_CheckedChanged(object sender, EventArgs e)
        {
            cb_statut.Items.Clear();
            cb_statut.Items.Add("--- Tout ---");

            if (chkArchive.Checked)
            {
                cb_statut.Items.Add(AppStatus.ContratTermine);
                cb_statut.Items.Add(AppStatus.ContratAnnule);
            }
            else
            {
                cb_statut.Items.Add(AppStatus.ContratEnCours);
                cb_statut.Items.Add(AppStatus.ContratTermine);
                cb_statut.Items.Add(AppStatus.ContratAnnule);
            }

            cb_statut.SelectedIndex = 0;

           
            LoadContracts();
        }

        private void btnimprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHistory.Rows.Count == 0)
                {
                    MessageBox.Show(
                        "Aucune donnée à imprimer.",
                        "Impression",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                DataGridViewPrinter printer = new DataGridViewPrinter(
                    dgvHistory,
                    "Historique des contrats",
                    Session.Username
                );

                printer.ShowPreview();
            }
            catch (Exception ex)
            {
                

                dbErreur.AddLog(
                    ex.Message,
                    Session.Username,
                    "historique_contrats",
                    "btnImprimer_Click"
                );

                MessageBox.Show(
                    "Erreur lors de l'impression : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkFiltrerDate_CheckedChanged(object sender, EventArgs e)
        {
            dtp_debut.Enabled = chkFiltrerDate.Checked;
            dtp_fin.Enabled = chkFiltrerDate.Checked;

            LoadContracts();
        }

        private void btn_prolongation_Click(object sender, EventArgs e)
        {
            prolongation po = new prolongation(id_contrat_selectionne);
            po.ShowDialog();
        }

        private void btn_change_voiture_Click(object sender, EventArgs e)
        {
            liste_contrat li = new liste_contrat(id_contrat_selectionne, matricule_selectionne);
            li.ShowDialog();
        }
        int id_contrat_selectionne = -1;
        string matricule_selectionne = "";
        private void dgvHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHistory.Rows[e.RowIndex];

                id_contrat_selectionne =Convert.ToInt16( row.Cells[0].Value.ToString());
                matricule_selectionne = row.Cells["Matricule"].Value.ToString();
            }
        }
    }
}
