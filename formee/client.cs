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




namespace venolocation.formee
{
    public partial class client : Form
    {
        public client()
        {
            InitializeComponent();
        }

        bool CinExists(string cin)
        {
            string q = "SELECT COUNT(*) FROM clients WHERE cin = @cin";

            MySqlParameter[] ps =
            {
                new MySqlParameter("@cin", cin.Trim())
            };

            return Dbexec.Exists(q, ps);
        }

        bool CinExistsForOtherClient(string cin, int clientId)
        {
            string q = @"
                    SELECT COUNT(*) 
                    FROM clients 
                    WHERE cin = @cin 
                      AND client_id <> @id";

            MySqlParameter[] ps =
            {
                new MySqlParameter("@cin", cin.Trim()),
                new MySqlParameter("@id", clientId)
            };

            return Dbexec.Exists(q, ps);
        }
        void ClearFields()
        {
            txtNomClient.Clear();
            txtPrenomClient.Clear();
            txtCinClient.Clear();
            txtTelephone.Clear();
            txtAdresseClient.Clear();
            txtVilleClient.Clear();
            txtPermisClient.Clear();

            dtpDateNaissance.Value = DateTime.Now;
            dtpDelivreLe.Value = DateTime.Now;

            txtNomClient.Focus();
        }


        void LoadClients()
        {
            
                try
                {
                    string query = @"
                                    SELECT 
                                        client_id AS 'ID',
                                        nom AS 'Nom',
                                        prenom AS 'Prénom',
                                        cin AS 'CIN',
                                        telephone AS 'Téléphone',
                                        adresse AS 'Adresse',
                                        ville AS 'Ville',
                                        DATE_FORMAT(date_naissance, '%d/%m/%Y') AS 'Date naissance',
                                        permis_num AS 'Permis',
                                        DATE_FORMAT(permis_date, '%d/%m/%Y') AS 'Date permis',
                                        nom_utilisateur AS 'Utilisateur'
                                    FROM clients
                                    ORDER BY client_id DESC
                                    LIMIT 300;";

                    dgvClients.DataSource = Dbexec.GetData(query);

                    GridStyleHelper_1.Apply(dgvClients);

                    if (dgvClients.Columns.Count > 0)
                    {
                        dgvClients.Columns["ID"].FillWeight = 8;
                        dgvClients.Columns["Nom"].FillWeight = 18;
                        dgvClients.Columns["Prénom"].FillWeight = 18;
                        dgvClients.Columns["CIN"].FillWeight = 14;
                        dgvClients.Columns["Téléphone"].FillWeight = 15;
                        dgvClients.Columns["Adresse"].FillWeight = 25;
                        dgvClients.Columns["Ville"].FillWeight = 14;
                        dgvClients.Columns["Date naissance"].FillWeight = 18;
                        dgvClients.Columns["Permis"].FillWeight = 16;
                        dgvClients.Columns["Date permis"].FillWeight = 18;
                        dgvClients.Columns["Utilisateur"].FillWeight = 16;

                        GridStyleHelper_1.AlignLeft(dgvClients, "Nom");
                        GridStyleHelper_1.AlignLeft(dgvClients, "Prénom");
                        GridStyleHelper_1.AlignLeft(dgvClients, "Adresse");
                    }
                }
                catch (Exception ex)
                {
                    dbErreur.AddLog(ex.Message, Session.Username, "client", "LoadClients");
                    MessageService.Error(AppMessages.UnexpectedError);
                }
            
        }

        private void client_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                LoadClients();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "client", "client_Load");
                MessageService.Error(AppMessages.UnexpectedError);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCinClient.Text))
                {
                    MessageService.Warning("CIN obligatoire");
                    LogHelper.AddLog("Ajout client refusé : CIN vide", Session.Username);
                    return;
                }

                if (CinExists(txtCinClient.Text.Trim()))
                {
                    MessageService.Warning("CIN déjà existant");
                    LogHelper.AddLog("Ajout client refusé : CIN existe " + txtCinClient.Text, Session.Username);
                    return;
                }

                string q = @"
                        INSERT INTO clients
                        (nom, prenom, cin, telephone, adresse, ville, date_naissance, permis_num, permis_date, nom_utilisateur)
                        VALUES
                        (@nom, @prenom, @cin, @tel, @adresse, @ville, @dateN, @permis, @datePermis, @user)";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@nom", txtNomClient.Text.Trim()),
                    new MySqlParameter("@prenom", txtPrenomClient.Text.Trim()),
                    new MySqlParameter("@cin", txtCinClient.Text.Trim()),
                    new MySqlParameter("@tel", txtTelephone.Text.Trim()),
                    new MySqlParameter("@adresse", txtAdresseClient.Text.Trim()),
                    new MySqlParameter("@ville", txtVilleClient.Text.Trim()),
                    new MySqlParameter("@dateN", dtpDateNaissance.Value.Date),
                    new MySqlParameter("@permis", txtPermisClient.Text.Trim()),
                    new MySqlParameter("@datePermis", dtpDelivreLe.Value.Date),
                    new MySqlParameter("@user", Session.Username)
                };

                Dbexec.ExecuteQuery(q, ps);

                LogHelper.AddLog("Client ajouté CIN: " + txtCinClient.Text.Trim(), Session.Username);
                MessageService.Success(AppMessages.SaveSuccess);

                LoadClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "client", "btnAjouter_Click");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClients.CurrentRow == null)
                {
                    MessageService.Warning(AppMessages.NoSelection);
                    return;
                }

                int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ID"].Value);

                if (string.IsNullOrWhiteSpace(txtCinClient.Text))
                {
                    MessageService.Warning("CIN obligatoire");
                    return;
                }

                if (CinExistsForOtherClient(txtCinClient.Text.Trim(), clientId))
                {
                    MessageService.Warning("CIN déjà utilisé");
                    return;
                }

                string q = @"
                            UPDATE clients SET
                                nom = @nom,
                                prenom = @prenom,
                                cin = @cin,
                                telephone = @tel,
                                adresse = @adresse,
                                ville = @ville,
                                date_naissance = @dateN,
                                permis_num = @permis,
                                permis_date = @datePermis,
                                nom_utilisateur = @user
                            WHERE client_id = @id";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@nom", txtNomClient.Text.Trim()),
                    new MySqlParameter("@prenom", txtPrenomClient.Text.Trim()),
                    new MySqlParameter("@cin", txtCinClient.Text.Trim()),
                    new MySqlParameter("@tel", txtTelephone.Text.Trim()),
                    new MySqlParameter("@adresse", txtAdresseClient.Text.Trim()),
                    new MySqlParameter("@ville", txtVilleClient.Text.Trim()),
                    new MySqlParameter("@dateN", dtpDateNaissance.Value.Date),
                    new MySqlParameter("@permis", txtPermisClient.Text.Trim()),
                    new MySqlParameter("@datePermis", dtpDelivreLe.Value.Date),
                    new MySqlParameter("@user", Session.Username),
                    new MySqlParameter("@id", clientId)
                };

                Dbexec.ExecuteQuery(q, ps);

                LogHelper.AddLog("Client modifié CIN: " + txtCinClient.Text.Trim(), Session.Username);
                MessageService.Success(AppMessages.UpdateSuccess);

                LoadClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "client", "btnModifier_Click");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClients.CurrentRow == null)
                {
                    MessageService.Warning(AppMessages.NoSelection);
                    return;
                }

                if (MessageService.Confirm(AppMessages.DeleteConfirm) != DialogResult.Yes)
                {
                    LogHelper.AddLog("Suppression client annulée", Session.Username);
                    return;
                }

                int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["ID"].Value);
                string cin = dgvClients.CurrentRow.Cells["CIN"].Value?.ToString();

                string q = "DELETE FROM clients WHERE client_id = @id";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@id", clientId)
                };

                Dbexec.ExecuteQuery(q, ps);

                LogHelper.AddLog("Client supprimé CIN: " + cin, Session.Username);
                MessageService.Success(AppMessages.DeleteSuccess);

                LoadClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "client", "btnSupprimer_Click");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRetour_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            LoadClients();
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvClients.Rows[e.RowIndex];

                txtNomClient.Text = r.Cells["Nom"].Value?.ToString();
                txtPrenomClient.Text = r.Cells["Prénom"].Value?.ToString();
                txtCinClient.Text = r.Cells["CIN"].Value?.ToString();
                txtTelephone.Text = r.Cells["Téléphone"].Value?.ToString();
                txtAdresseClient.Text = r.Cells["Adresse"].Value?.ToString();
                txtVilleClient.Text = r.Cells["Ville"].Value?.ToString();
                txtPermisClient.Text = r.Cells["Permis"].Value?.ToString();

                if (r.Cells["Date naissance"].Value != null && r.Cells["Date naissance"].Value != DBNull.Value)
                {
                    DateTime dtNaissance;
                    if (DateTime.TryParse(r.Cells["Date naissance"].Value.ToString(), out dtNaissance))
                        dtpDateNaissance.Value = dtNaissance;
                }

                if (r.Cells["Date permis"].Value != null && r.Cells["Date permis"].Value != DBNull.Value)
                {
                    DateTime dtPermis;
                    if (DateTime.TryParse(r.Cells["Date permis"].Value.ToString(), out dtPermis))
                        dtpDelivreLe.Value = dtPermis;
                }
            }
        }

        private void btnSearchTop_Click(object sender, EventArgs e)
        {
            try
            {
                string q = @"
                        SELECT 
                            client_id AS 'ID',
                            nom AS 'Nom',
                            prenom AS 'Prénom',
                            cin AS 'CIN',
                            telephone AS 'Téléphone',
                            adresse AS 'Adresse',
                            ville AS 'Ville',
                            DATE_FORMAT(date_naissance, '%d/%m/%Y') AS 'Date naissance',
                            permis_num AS 'Permis',
                            DATE_FORMAT(permis_date, '%d/%m/%Y') AS 'Date permis',
                            nom_utilisateur AS 'Utilisateur'
                        FROM clients
                        WHERE nom LIKE @s 
                           OR prenom LIKE @s 
                           OR cin LIKE @s
                           OR telephone LIKE @s
                        ORDER BY client_id DESC
                        LIMIT 100;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@s", "%" + txtRecherche.Text.Trim() + "%")
                };

                dgvClients.DataSource = Dbexec.GetData(q, ps);

                GridStyleHelper_1.Apply(dgvClients);

                if (dgvClients.Columns.Count > 0)
                {
                    dgvClients.Columns["ID"].FillWeight = 8;
                    dgvClients.Columns["Nom"].FillWeight = 18;
                    dgvClients.Columns["Prénom"].FillWeight = 18;
                    dgvClients.Columns["CIN"].FillWeight = 14;
                    dgvClients.Columns["Téléphone"].FillWeight = 15;
                    dgvClients.Columns["Adresse"].FillWeight = 25;
                    dgvClients.Columns["Ville"].FillWeight = 14;
                    dgvClients.Columns["Date naissance"].FillWeight = 18;
                    dgvClients.Columns["Permis"].FillWeight = 16;
                    dgvClients.Columns["Date permis"].FillWeight = 18;
                    dgvClients.Columns["Utilisateur"].FillWeight = 16;

                    GridStyleHelper_1.AlignLeft(dgvClients, "Nom");
                    GridStyleHelper_1.AlignLeft(dgvClients, "Prénom");
                    GridStyleHelper_1.AlignLeft(dgvClients, "Adresse");
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "client", "btnSearchTop_Click");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }
    }
    
}
