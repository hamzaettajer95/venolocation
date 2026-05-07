using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
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

            foreach (SettingsProperty prop in Properties.Settings.Default.Properties)
            {
                string nom = prop.Name;
                string type = prop.PropertyType.Name;

                object value = Properties.Settings.Default[nom];
                string valeur = value == null ? "" : value.ToString();

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
            string nouvelleValeur = txtValeur.Text;

            try
            {
                SettingsProperty prop = Properties.Settings.Default.Properties[nom];

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

                object ancienneValeurObj = Properties.Settings.Default[nom];
                string ancienneValeur = ancienneValeurObj == null ? "" : ancienneValeurObj.ToString();

                DialogResult rep = MessageBox.Show(
                    "Voulez-vous modifier ce paramètre ?\n\n" +
                    "Nom : " + nom + "\n" +
                    "Ancienne valeur : " + MasquerSiSensible(nom, ancienneValeur) + "\n" +
                    "Nouvelle valeur : " + MasquerSiSensible(nom, nouvelleValeur),
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (rep != DialogResult.Yes)
                    return;

                object convertedValue = ConvertirValeur(nouvelleValeur, prop.PropertyType);

                Properties.Settings.Default[nom] = convertedValue;
                Properties.Settings.Default.Save();

                LogHelper.AddLog(
                    "Modification paramètre application : " +
                    nom +
                    " | Ancienne valeur : " + MasquerSiSensible(nom, ancienneValeur) +
                    " | Nouvelle valeur : " + MasquerSiSensible(nom, nouvelleValeur),
                    Session.Username
                );

                MessageBox.Show(
                    "Paramètre enregistré avec succès.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ChargerSettings();
                SelectionnerLigne(nom);
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

        private object ConvertirValeur(string valeur, Type type)
        {
            if (type == typeof(string))
                return valeur ?? "";

            if (type == typeof(int))
            {
                int result;
                if (int.TryParse(valeur, out result))
                    return result;

                throw new Exception("Valeur invalide pour un entier.");
            }

            if (type == typeof(bool))
            {
                bool result;
                if (bool.TryParse(valeur, out result))
                    return result;

                if (valeur == "1")
                    return true;

                if (valeur == "0")
                    return false;

                throw new Exception("Valeur invalide pour un booléen. Utilisez true/false.");
            }

            if (type == typeof(decimal))
            {
                decimal result;
                if (decimal.TryParse(valeur, out result))
                    return result;

                throw new Exception("Valeur invalide pour un decimal.");
            }

            if (type == typeof(double))
            {
                double result;
                if (double.TryParse(valeur, out result))
                    return result;

                throw new Exception("Valeur invalide pour un double.");
            }

            if (type == typeof(DateTime))
            {
                DateTime result;
                if (DateTime.TryParse(valeur, out result))
                    return result;

                throw new Exception("Valeur invalide pour une date.");
            }

            return valeur;
        }

        private string MasquerSiSensible(string nom, string valeur)
        {
            if (string.IsNullOrWhiteSpace(nom))
                return valeur;

            string n = nom.ToLower();

            if (n.Contains("password") || n.Contains("pass") || n.Contains("pwd"))
                return "********";

            return valeur;
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
