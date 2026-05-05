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

namespace venolocation.dev
{
    public partial class server : Form
    {
        public server()
        {
            InitializeComponent();
        }

        private void ChargerParametresConnexion()
        {
            txtServer.Text = Properties.Settings.Default.db_server;
            txtDatabase.Text = Properties.Settings.Default.db_name;
            txtUser.Text = Properties.Settings.Default.db_user;
            txtPassword.Text = Properties.Settings.Default.db_password;
            txtPort.Text = Properties.Settings.Default.db_port;
        }

        private string GetConnectionStringFromTextBox()
        {
            string server = txtServer.Text.Trim();
            string database = txtDatabase.Text.Trim();
            string user = txtUser.Text.Trim();
            string password = txtPassword.Text;
            string portText = txtPort.Text.Trim();

            uint port = 3306;

            if (!string.IsNullOrWhiteSpace(portText))
            {
                if (!uint.TryParse(portText, out port))
                {
                    port = 3306;
                }
            }

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = server,
                Database = database,
                UserID = user,
                Password = password,
                Port = port
            };

            return builder.ConnectionString;
        }

        private bool TesterConnexion()
        {
            try
            {
                string connectionString = GetConnectionStringFromTextBox();

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                }

                MessageBox.Show(
                    "Connexion réussie.",
                    "Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur de connexion : " + ex.Message,
                    "Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }
        private void server_Load(object sender, EventArgs e)
        {
            ChargerParametresConnexion();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServer.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir le serveur.",
                    "Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtServer.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDatabase.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir le nom de la base de données.",
                    "Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtDatabase.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                MessageBox.Show(
                    "Veuillez saisir l'utilisateur.",
                    "Connexion",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtUser.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPort.Text))
            {
                txtPort.Text = "3306";
            }

            bool testOk = TesterConnexion();

            if (!testOk)
                return;

            Properties.Settings.Default.db_server = txtServer.Text.Trim();
            Properties.Settings.Default.db_name = txtDatabase.Text.Trim();
            Properties.Settings.Default.db_user = txtUser.Text.Trim();
            Properties.Settings.Default.db_password = txtPassword.Text;
            Properties.Settings.Default.db_port = txtPort.Text.Trim();

            
            Properties.Settings.Default.conx = GetConnectionStringFromTextBox();

            Properties.Settings.Default.Save();

            MessageBox.Show(
                "Paramètres de connexion enregistrés avec succès.\nVeuillez redémarrer le logiciel.",
                "Connexion",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            this.Close();
        
        }

        private void btnTester_Click(object sender, EventArgs e)
        {
            TesterConnexion();
        }
    }
}
