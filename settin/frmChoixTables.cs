using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace venolocation.settin
{
    public partial class frmChoixTables : Form
    {
        public frmChoixTables()
        {
            InitializeComponent();
        }

        public List<string> TablesSelectionnees { get; private set; } = new List<string>();
        public int AnneeSelectionnee { get; private set; } = 0;

        private bool demanderAnnee = false;

        public frmChoixTables(string titre, string[] tables, bool avecAnnee)
        {
            InitializeComponent();

            demanderAnnee = avecAnnee;
            lblTitle.Text = titre;

            txtAnnee.Visible = avecAnnee;
            lblAnnee.Visible = avecAnnee;

            if (avecAnnee)
                txtAnnee.Text = DateTime.Now.Year.ToString();

            clbTables.Items.Clear();

            foreach (string table in tables)
                clbTables.Items.Add(table, false);
        }
        private void frmChoixTables_Load(object sender, EventArgs e)
        {
            try
            {
                btnValider.FlatAppearance.BorderSize = 0;
                btnAnnuler.FlatAppearance.BorderSize = 0;

                btnValider.BackColor = Color.FromArgb(24, 86, 197);
                btnAnnuler.BackColor = Color.FromArgb(107, 114, 128);
                btnValider.ForeColor = Color.White;
                btnAnnuler.ForeColor = Color.White;
            }
            catch
            {
            }
        }

        private void btnValide_Click(object sender, EventArgs e)
        {
            TablesSelectionnees.Clear();

            foreach (object item in clbTables.CheckedItems)
                TablesSelectionnees.Add(item.ToString());

            if (TablesSelectionnees.Count == 0)
            {
                MessageBox.Show("Sélectionnez au moins une table.", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (demanderAnnee)
            {
                if (!int.TryParse(txtAnnee.Text.Trim(), out int annee))
                {
                    MessageBox.Show("Année invalide.", "Attention",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnnee.Focus();
                    return;
                }

                if (annee < 2000 || annee > 2100)
                {
                    MessageBox.Show("Année invalide.", "Attention",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnnee.Focus();
                    return;
                }
                AnneeSelectionnee = annee;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtAnnee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
    }
}
