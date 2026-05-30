using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using venolocation.classee;

namespace venolocation.dev
{
    public partial class pro_seti_defaut : Form
    {
        public pro_seti_defaut()
        {
            InitializeComponent();
        }


        private void InitialiserGrid()
        {
            dgvSettings.Columns.Clear();
            dgvSettings.Rows.Clear();

            dgvSettings.AllowUserToAddRows = false;
            dgvSettings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSettings.MultiSelect = false;
            dgvSettings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSettings.ReadOnly = true;

            dgvSettings.Columns.Add("Nom", "Nom");
            dgvSettings.Columns.Add("Type", "Type");
            dgvSettings.Columns.Add("Valeur", "Valeur");

            dgvSettings.Columns["Nom"].FillWeight = 30;
            dgvSettings.Columns["Type"].FillWeight = 20;
            dgvSettings.Columns["Valeur"].FillWeight = 50;
        }

        private void ChargerSettings()
        {
            dgvSettings.Rows.Clear();

            var config = App_Config.Instance;

            var props = typeof(App_Config).GetProperties();

            foreach (var prop in props)
            {
                string nom = prop.Name;
                string type = prop.PropertyType.Name;
                string valeur = prop.GetValue(config)?.ToString() ?? "";

                dgvSettings.Rows.Add(nom, type, valeur);
            }

            ClearTextBox();
        }

        private void ClearTextBox()
        {
            txtNom.Clear();
            txtType.Clear();
            txtValeur.Clear();
        }
        private void pro_seti_defaut_Load(object sender, EventArgs e)
        {
            InitialiserGrid();
            ChargerSettings();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageBox.Show(
                    "Veuillez sélectionner un paramètre.",
                    "Paramètres",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
           

            string nom = txtNom.Text.Trim();
            string valeur = txtValeur.Text;

            var config = App_Config.Instance;

            PropertyInfo prop = typeof(App_Config).GetProperty(nom);

            if (prop == null)
            {
                MessageBox.Show(
                    "Paramètre introuvable.",
                    "Paramètres",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            

            try
            {
               
                DialogResult rep = MessageBox.Show(
                    "Voulez-vous modifier ce paramètre ?\n\n" +
                    "Nom : " + nom + "\n",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (rep != DialogResult.Yes)
                    return;

                object value = Convert.ChangeType(valeur, prop.PropertyType);

                prop.SetValue(config, value);

                App_Config.Save(config);

                MessageBox.Show(
                    "Paramètre enregistré avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ChargerSettings();
                SelectionnerLigne(nom);

               

                LogHelper.AddLog(
                    "Modification paramètre application : " + nom ,  Session.Username );

               

               
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(
                    ex.Message,
                    Session.Username,
                    "developpeur",
                    "ModifierPropertiesSettings"
                );

                MessageBox.Show(
                    "Erreur modification paramètre : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            ChargerSettings();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

     
        private void SelectionnerLigne(string nom)
        {
            foreach (DataGridViewRow row in dgvSettings.Rows)
            {
                if (row.Cells["Nom"].Value?.ToString() == nom)
                {
                    row.Selected = true;
                    dgvSettings.CurrentCell = row.Cells["Valeur"];

                    txtNom.Text = row.Cells["Nom"].Value?.ToString();
                    txtType.Text = row.Cells["Type"].Value?.ToString();
                    txtValeur.Text = row.Cells["Valeur"].Value?.ToString();
                    return;
                }
            }
        }

        private void dgvSettings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvSettings.Rows[e.RowIndex];

            txtNom.Text = row.Cells["Nom"].Value?.ToString();
            txtType.Text = row.Cells["Type"].Value?.ToString();
            txtValeur.Text = row.Cells["Valeur"].Value?.ToString();

            txtValeur.Focus();
        }
    }
}
