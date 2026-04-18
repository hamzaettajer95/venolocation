using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
            using (MySqlConnection cn = Dbexec.GetConnection())
            {
                cn.Open();

                string q = "SELECT COUNT(*) FROM clients WHERE cin=@cin";
                MySqlCommand cmd = new MySqlCommand(q, cn);
                cmd.Parameters.AddWithValue("@cin", cin);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        bool CinExistsForOtherClient(string cin, int clientId)
        {
            using (MySqlConnection cn = Dbexec.GetConnection())
            {
                cn.Open();

                string q = "SELECT COUNT(*) FROM clients WHERE cin=@cin AND client_id<>@id";
                MySqlCommand cmd = new MySqlCommand(q, cn);
                cmd.Parameters.AddWithValue("@cin", cin);
                cmd.Parameters.AddWithValue("@id", clientId);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
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
            using (MySqlConnection cn = Dbexec.GetConnection())
            {
                cn.Open();

                string query = "SELECT * FROM clients";

                MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvClients.DataSource = dt;
            }
        }

        private void client_Load(object sender, EventArgs e)
        {
            LoadClients();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCinClient.Text))
                {
                    MessageService.Warning("CIN obligatoire");
                    LogHelper.AddLog("Ajout client refusé : CIN vide", classee.Session.Username);
                    return;
                }

                if (CinExists(txtCinClient.Text.Trim()))
                {
                    MessageService.Warning("CIN déjà existant");
                    LogHelper.AddLog("Ajout client refusé : CIN existe " + txtCinClient.Text, classee.Session.Username);
                    return;
                }

                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = @"INSERT INTO clients
                                (nom, prenom, cin, telephone, adresse, ville, date_naissance, permis_num, permis_date, nom_utilisateur)
                                VALUES
                                (@nom, @prenom, @cin, @tel, @adresse, @ville, @dateN, @permis, @datePermis, @user)";

                    MySqlCommand cmd = new MySqlCommand(q, cn);

                    cmd.Parameters.AddWithValue("@nom", txtNomClient.Text);
                    cmd.Parameters.AddWithValue("@prenom", txtPrenomClient.Text);
                    cmd.Parameters.AddWithValue("@cin", txtCinClient.Text);
                    cmd.Parameters.AddWithValue("@tel", txtTelephone.Text);
                    cmd.Parameters.AddWithValue("@adresse", txtAdresseClient.Text);
                    cmd.Parameters.AddWithValue("@ville", txtVilleClient.Text);
                    cmd.Parameters.AddWithValue("@dateN", dtpDateNaissance.Value.Date);
                    cmd.Parameters.AddWithValue("@permis", txtPermisClient.Text);
                    cmd.Parameters.AddWithValue("@datePermis", dtpDelivreLe.Value.Date);
                    cmd.Parameters.AddWithValue("@user", classee.Session.Username);

                    cmd.ExecuteNonQuery();
                }

                LogHelper.AddLog("Client ajouté CIN: " + txtCinClient.Text, classee.Session.Username);
                MessageService.Success(AppMessages.SaveSuccess);

                LoadClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, login.nom, "client", "btnAjouter_Click");
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

                int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["client_id"].Value);

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

                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = @"UPDATE clients SET
                                nom=@nom,
                                prenom=@prenom,
                                cin=@cin,
                                telephone=@tel,
                                adresse=@adresse,
                                ville=@ville,
                                date_naissance=@dateN,
                                permis_num=@permis,
                                permis_date=@datePermis,
                                nom_utilisateur=@user
                                WHERE client_id=@id";

                    MySqlCommand cmd = new MySqlCommand(q, cn);

                    cmd.Parameters.AddWithValue("@nom", txtNomClient.Text);
                    cmd.Parameters.AddWithValue("@prenom", txtPrenomClient.Text);
                    cmd.Parameters.AddWithValue("@cin", txtCinClient.Text);
                    cmd.Parameters.AddWithValue("@tel", txtTelephone.Text);
                    cmd.Parameters.AddWithValue("@adresse", txtAdresseClient.Text);
                    cmd.Parameters.AddWithValue("@ville", txtVilleClient.Text);
                    cmd.Parameters.AddWithValue("@dateN", dtpDateNaissance.Value.Date);
                    cmd.Parameters.AddWithValue("@permis", txtPermisClient.Text);
                    cmd.Parameters.AddWithValue("@datePermis", dtpDelivreLe.Value.Date);
                    cmd.Parameters.AddWithValue("@user", classee.Session.Username);
                    cmd.Parameters.AddWithValue("@id", clientId);

                    cmd.ExecuteNonQuery();
                }

                LogHelper.AddLog("Client modifié CIN: " + txtCinClient.Text, classee.Session.Username);
                MessageService.Success(AppMessages.UpdateSuccess);

                LoadClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, login.nom, "client", "btnModifier_Click");
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
                    LogHelper.AddLog("Suppression client annulée", classee.Session.Username);
                    return;
                }

                int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["client_id"].Value);

                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = "DELETE FROM clients WHERE client_id=@id";
                    MySqlCommand cmd = new MySqlCommand(q, cn);
                    cmd.Parameters.AddWithValue("@id", clientId);

                    cmd.ExecuteNonQuery();
                }

                LogHelper.AddLog("Client supprimé CIN: " + txtCinClient.Text, classee.Session.Username);
                MessageService.Success(AppMessages.DeleteSuccess);

                LoadClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, login.nom, "client", "btnSupprimer_Click");
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
            ClearFields();
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow r = dgvClients.Rows[e.RowIndex];

                txtNomClient.Text = r.Cells["nom"].Value?.ToString();
                txtPrenomClient.Text = r.Cells["prenom"].Value?.ToString();
                txtCinClient.Text = r.Cells["cin"].Value?.ToString();
                txtTelephone.Text = r.Cells["telephone"].Value?.ToString();
                txtAdresseClient.Text = r.Cells["adresse"].Value?.ToString();
                txtVilleClient.Text = r.Cells["ville"].Value?.ToString();
                txtPermisClient.Text = r.Cells["permis_num"].Value?.ToString();

                if (r.Cells["date_naissance"].Value != DBNull.Value)
                    dtpDateNaissance.Value = Convert.ToDateTime(r.Cells["date_naissance"].Value);

                if (r.Cells["permis_date"].Value != DBNull.Value)
                    dtpDelivreLe.Value = Convert.ToDateTime(r.Cells["permis_date"].Value);
            }
        }

        private void btnSearchTop_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = @"SELECT * FROM clients
                                 WHERE nom LIKE @s OR prenom LIKE @s OR cin LIKE @s";

                    MySqlCommand cmd = new MySqlCommand(q, cn);
                    cmd.Parameters.AddWithValue("@s", "%" + txtRecherche.Text + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvClients.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, login.nom, "client", "btnSearchTop_Click");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }
    }
    
}
