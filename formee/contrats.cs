using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace venolocation.formee
{
    public partial class contrats : Form
    {
        public contrats()
        {
            InitializeComponent();
        }
        //test
       
            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void btnMinimize_Click(object sender, EventArgs e)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            private void btnNouveau_Click(object sender, EventArgs e)
            {
                txtNomClient.Clear();
                txtPrenomClient.Clear();
                txtTelephone.Clear();
                txtPermis.Clear();
                txtAdresse.Clear();

                txtMarque.Clear();
                txtModele.Clear();
                txtKilometrage.Clear();
                txtPrixJour.Clear();

                txtPrixTotal.Text = "0";
                txtAvance.Text = "0";
                txtRestePayer.Text = "0";
                txtNombreJours.Text = "0";

                cmbCinClient.SelectedIndex = -1;
                cmbImmatriculation.SelectedIndex = -1;
                cmbTypeCarburant.SelectedIndex = -1;
                cmbPuissance.SelectedIndex = -1;
                cmbCategorie.SelectedIndex = -1;
                cmbModePaiement.SelectedIndex = -1;

                dtDateDebut.Value = DateTime.Now;
                dtDateFin.Value = DateTime.Now.AddDays(1);
            }

            private void btnCalculerPrix_Click(object sender, EventArgs e)
            {
                CalculerContrat();
            }

            private void txtAvance_TextChanged(object sender, EventArgs e)
            {
                CalculerReste();
            }

            private void dtDateDebut_ValueChanged(object sender, EventArgs e)
            {
                CalculerNombreJours();
            }

            private void dtDateFin_ValueChanged(object sender, EventArgs e)
            {
                CalculerNombreJours();
            }

            private void txtPrixJour_TextChanged(object sender, EventArgs e)
            {
                CalculerContrat();
            }

            private void btnEnregistrer_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Contrat enregistré avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void btnImprimer_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Impression du contrat.", "Imprimer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            private void btnAnnuler_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void CalculerNombreJours()
            {
                int jours = (dtDateFin.Value.Date - dtDateDebut.Value.Date).Days;

                if (jours <= 0)
                    jours = 1;

                txtNombreJours.Text = jours.ToString();
                CalculerContrat();
            }

            private void CalculerContrat()
            {
                int jours = 0;
                decimal prixJour = 0;

                int.TryParse(txtNombreJours.Text, out jours);
                decimal.TryParse(txtPrixJour.Text, out prixJour);

                decimal total = jours * prixJour;
                txtPrixTotal.Text = total.ToString("0.00");

                CalculerReste();
            }

            private void CalculerReste()
            {
                decimal total = 0;
                decimal avance = 0;

                decimal.TryParse(txtPrixTotal.Text, out total);
                decimal.TryParse(txtAvance.Text, out avance);

                decimal reste = total - avance;
                if (reste < 0)
                    reste = 0;

                txtRestePayer.Text = reste.ToString("0.00");
            }
        
    }
}
