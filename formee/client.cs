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
            using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
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
            using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
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
            using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
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
                if (txtCinClient.Text.Trim() == "")
                {
                    MessageBox.Show("CIN obligatoire");
                    return;
                }

                if (CinExists(txtCinClient.Text.Trim()))
                {
                    MessageBox.Show("CIN déjà existe");
                    return;
                }

                using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
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
                    cmd.Parameters.AddWithValue("@user", login.nom);

                    cmd.ExecuteNonQuery();
                }

                LogHelper.AddLog("Ajout client CIN: " + txtCinClient.Text, login.nom);
                MessageBox.Show("Client ajouté avec succès");
                LoadClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClients.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionne un client");
                    return;
                }

                int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["client_id"].Value);

                if (txtCinClient.Text.Trim() == "")
                {
                    MessageBox.Show("CIN obligatoire");
                    return;
                }

                if (CinExistsForOtherClient(txtCinClient.Text.Trim(), clientId))
                {
                    MessageBox.Show("CIN déjà existe pour un autre client");
                    return;
                }

                using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
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
                    cmd.Parameters.AddWithValue("@user", login.nom);
                    cmd.Parameters.AddWithValue("@id", clientId);

                    cmd.ExecuteNonQuery();
                }

                LogHelper.AddLog("Modification client CIN: " + txtCinClient.Text, login.nom);
                MessageBox.Show("Client modifié avec succès");
                LoadClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClients.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionne un client");
                    return;
                }

                int clientId = Convert.ToInt32(dgvClients.CurrentRow.Cells["client_id"].Value);

                DialogResult rep = MessageBox.Show("Tu veux vraiment supprimer ce client ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rep != DialogResult.Yes)
                    return;

                using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
                {
                    cn.Open();

                    string q = "DELETE FROM clients WHERE client_id=@id";
                    MySqlCommand cmd = new MySqlCommand(q, cn);
                    cmd.Parameters.AddWithValue("@id", clientId);

                    cmd.ExecuteNonQuery();
                }

                LogHelper.AddLog("Suppression client CIN: " + txtCinClient.Text, login.nom);
                MessageBox.Show("Client supprimé avec succès");
                LoadClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
                {
                    cn.Open();

                    string q = @"SELECT client_id, nom, prenom, cin, telephone, adresse, ville, 
                                        date_naissance, permis_num, permis_date, nom_utilisateur, created_at
                                 FROM clients
                                 WHERE nom LIKE @s
                                    OR prenom LIKE @s
                                    OR cin LIKE @s
                                    OR telephone LIKE @s
                                    OR ville LIKE @s";

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
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
