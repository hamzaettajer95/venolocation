using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;

namespace venolocation.formee
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public static string nom;
        public static string role;

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(formee.dashboard.connection_string))
                {
                    cn.Open();

                    string query = "SELECT nom, role FROM utilisateurs WHERE login=@u AND mot_de_passe=@p";

                    MySqlCommand cmd = new MySqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                    MySqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        nom = dr["nom"].ToString();
                        role = dr["role"].ToString();

                        MessageBox.Show("Bienvenue " + nom + " (" + role + ")");

                     
                    }
                    else
                    {
                        MessageBox.Show("Username ou Password incorrect");
                    }

                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}