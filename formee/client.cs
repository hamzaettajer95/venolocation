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
            MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string);
            cn.Open();

            string q = "SELECT COUNT(*) FROM clients WHERE cin=@c";

            MySqlCommand cmd = new MySqlCommand(q, cn);
            cmd.Parameters.AddWithValue("@c", cin);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            cn.Close();

            return count > 0;
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
            if (txtCinClient.Text == "")
            {
                MessageBox.Show("CIN obligatoire !");
                return;
            }
            if (CinExists(txtCinClient.Text))
            {
                MessageBox.Show("CIN déjà exist !");
                return;
            }
            using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
            {
                cn.Open();

                string query = @"INSERT INTO clients
                        (nom, prenom, cin, telephone, ville, permis_num)
                        VALUES (@nom,@prenom,@cin,@tel,@ville,@permis)";

                MySqlCommand cmd = new MySqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@nom", txtNomClient.Text);
                cmd.Parameters.AddWithValue("@prenom", txtPrenomClient.Text);
                cmd.Parameters.AddWithValue("@cin", txtCinClient.Text);
                cmd.Parameters.AddWithValue("@tel", txtTelephone.Text);
                cmd.Parameters.AddWithValue("@ville", cmbVilleClient.Text);
                cmd.Parameters.AddWithValue("@permis", txtPermisClient.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Ajouté !");
                LoadClients();
            }           
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
            {
                cn.Open();

                string query = @"UPDATE clients SET
                                    nom=@nom,
                                    prenom=@prenom,
                                    telephone=@tel,
                                    ville=@ville,
                                    permis_num=@permis
                                    WHERE cin=@cin";

                MySqlCommand cmd = new MySqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@nom", txtNomClient.Text);
                cmd.Parameters.AddWithValue("@prenom", txtPrenomClient.Text);
                cmd.Parameters.AddWithValue("@cin", txtCinClient.Text);
                cmd.Parameters.AddWithValue("@tel", txtTelephone.Text);
                cmd.Parameters.AddWithValue("@ville", cmbVilleClient.Text);
                cmd.Parameters.AddWithValue("@permis", txtPermisClient.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Modifié !");
                LoadClients();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
            {
                cn.Open();

                string query = "DELETE FROM clients WHERE cin=@cin";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@cin", txtCinClient.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Supprimé !");
                LoadClients();
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

        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvClients.Rows[e.RowIndex];

                txtNomClient.Text = row.Cells["nom"].Value.ToString();
                txtPrenomClient.Text = row.Cells["prenom"].Value.ToString();
                txtCinClient.Text = row.Cells["cin"].Value.ToString();
                txtTelephone.Text = row.Cells["telephone"].Value.ToString();
                cmbVilleClient.Text = row.Cells["ville"].Value.ToString();
                txtPermisClient.Text = row.Cells["permis_num"].Value.ToString();
            }
        }

        private void btnSearchTop_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string);
            cn.Open();

            string q = @"SELECT * FROM clients 
                 WHERE nom LIKE @s 
                 OR prenom LIKE @s 
                 OR cin LIKE @s";

            MySqlCommand cmd = new MySqlCommand(q, cn);
            cmd.Parameters.AddWithValue("@s", "%" + txtRecherche.Text + "%");

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

           dgvClients.DataSource = dt;

            cn.Close();
        }
    }
}
