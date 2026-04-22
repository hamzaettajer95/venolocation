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
    public partial class Entretient : Form
    {
        public Entretient()
        {
            InitializeComponent();
        }
        string connectionString=dashboard.connection_string;
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private bool ValiderChamps()
        {
            if (cbVoiture.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner une voiture.");
                cbVoiture.Focus();
                return false;
            }

            if (cbTypeEntretien.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cbTypeEntretien.Text))
            {
                MessageBox.Show("Veuillez sélectionner le type d'entretien.");
                cbTypeEntretien.Focus();
                return false;
            }

            if (!int.TryParse(txtKilometrage.Text.Trim(), out int kilometrage) || kilometrage < 0)
            {
                MessageBox.Show("Kilométrage invalide.");
                txtKilometrage.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtProchainKilometrage.Text))
            {
                if (!int.TryParse(txtProchainKilometrage.Text.Trim(), out int prochainKm) || prochainKm < 0)
                {
                    MessageBox.Show("Prochain kilométrage invalide.");
                    txtProchainKilometrage.Focus();
                    return false;
                }
            }

            if (!string.IsNullOrWhiteSpace(txtPrix.Text))
            {
                if (!decimal.TryParse(txtPrix.Text.Trim(), out decimal prix) || prix < 0)
                {
                    MessageBox.Show("Prix invalide.");
                    txtPrix.Focus();
                    return false;
                }
            }

            return true;
        }
        private void ChargerTypesEntretien()
        {
            cbTypeEntretien.Items.Clear();

            cbTypeEntretien.Items.Add("Vidange");
            cbTypeEntretien.Items.Add("Filtre à huile");
            cbTypeEntretien.Items.Add("Filtre à air");
            cbTypeEntretien.Items.Add("Plaquettes de frein");
            cbTypeEntretien.Items.Add("Pneus");
            cbTypeEntretien.Items.Add("Batterie");
            cbTypeEntretien.Items.Add("Révision");
            cbTypeEntretien.Items.Add("Climatisation");
            cbTypeEntretien.Items.Add("Distribution");
            cbTypeEntretien.Items.Add("Autre");

            cbTypeEntretien.SelectedIndex = -1;
        }


        private void ChargerVoitures()
        {
            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();

                    string query = @"SELECT voiture_id, CONCAT(matricule, ' - ', marque, ' ', modele) AS voiture
                                     FROM voitures
                                     ORDER BY matricule";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cbVoiture.DataSource = dt;
                        cbVoiture.DisplayMember = "voiture";
                        cbVoiture.ValueMember = "voiture_id";
                        cbVoiture.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "Entretient", "ChargerVoitures");
                MessageBox.Show("Erreur chargement voitures : " + ex.Message);
            }
        }

        private void Entretient_Load(object sender, EventArgs e)
        {
            ChargerVoitures();
            ChargerTypesEntretien();

            dtDateEntretien.Value = DateTime.Now;
            dtDateEntretien.Format = DateTimePickerFormat.Short;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (!ValiderChamps())
                return;

            try
            {
                using (MySqlConnection cn = new MySqlConnection(connectionString))
                {
                    cn.Open();
                    MySqlTransaction tr = cn.BeginTransaction();

                    try
                    {
                        string insertEntretien = @"
                            INSERT INTO entretiens
                            (voiture_id, type_entretien, description, date_entretien, kilometrage, date_prochaine, prochain_km, prix, nom_utilisateur)
                            VALUES
                            (@voiture_id, @type_entretien, @description, @date_entretien, @kilometrage, @date_prochaine, @prochain_km, @prix, @nom_utilisateur)";

                        using (MySqlCommand cmd = new MySqlCommand(insertEntretien, cn, tr))
                        {
                            cmd.Parameters.AddWithValue("@voiture_id", cbVoiture.SelectedValue);
                            cmd.Parameters.AddWithValue("@type_entretien", cbTypeEntretien.Text.Trim());
                            cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(txtDescription.Text) ? (object)DBNull.Value : txtDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@date_entretien", dtDateEntretien.Value.Date);
                            cmd.Parameters.AddWithValue("@kilometrage", int.Parse(txtKilometrage.Text.Trim()));
                            cmd.Parameters.AddWithValue("@date_prochaine",dtprocheEntretien.Value.Date); 
                            cmd.Parameters.AddWithValue("@prochain_km",
                                string.IsNullOrWhiteSpace(txtProchainKilometrage.Text)
                                ? (object)DBNull.Value
                                : int.Parse(txtProchainKilometrage.Text.Trim()));
                            cmd.Parameters.AddWithValue("@prix",
                                string.IsNullOrWhiteSpace(txtPrix.Text)
                                ? (object)DBNull.Value
                                : decimal.Parse(txtPrix.Text.Trim()));
                            cmd.Parameters.AddWithValue("@nom_utilisateur", Session.Username);

                            cmd.ExecuteNonQuery();
                        }

                        string updateVoiture = @"
                            UPDATE voitures
                            SET kilometrage = @kilometrage
                            WHERE voiture_id = @voiture_id
                              AND (@kilometrage > IFNULL(kilometrage, 0))";

                        using (MySqlCommand cmdUpdate = new MySqlCommand(updateVoiture, cn, tr))
                        {
                            cmdUpdate.Parameters.AddWithValue("@kilometrage", int.Parse(txtKilometrage.Text.Trim()));
                            cmdUpdate.Parameters.AddWithValue("@voiture_id", cbVoiture.SelectedValue);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        tr.Commit();
                        LogHelper.AddLog("Ajoute Entretien voiture : " + cbVoiture.Text+" et le type :"+cbTypeEntretien.Text, Session.Username);
                        MessageBox.Show("Entretien ajouté avec succès.");

                        ViderChamps();
                    }
                    catch (Exception ex)
                    {
                        tr.Rollback();
                        dbErreur.AddLog(ex.Message, Session.Username, "Entretient", "btnValider_Click_Transaction");
                        MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "Entretient", "btnValider_Click");
                MessageBox.Show("Erreur connexion : " + ex.Message);
            }

        }

        private void ViderChamps()
        {
            cbVoiture.SelectedIndex = -1;
            cbTypeEntretien.SelectedIndex = -1;
            txtDescription.Clear();
            txtKilometrage.Clear();
            txtProchainKilometrage.Clear();
            txtPrix.Clear();
            dtDateEntretien.Value = DateTime.Now;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {

        }

        private void txtKilometrage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtProchainKilometrage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtPrix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ','
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (txtPrix.Text.Contains(",") || txtPrix.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }
    }
}
