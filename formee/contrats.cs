using System;
using System.Drawing;
using System.Windows.Forms;

namespace venolocation.formee
{
    public partial class contrats : Form
    {
        public contrats()
        {
            InitializeComponent();
        }

        

        private void AutoGenerateContractNumber()
        {
            lblContratValue.Text = "CTR-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
        }

        private void UpdateNombreJours()
        {
            int jours = (dtpDateFin.Value.Date - dtpDateDebut.Value.Date).Days;

            if (jours <= 0)
                jours = 1;

            txtNombreJours.Text = jours.ToString();
            lblDureeValue.Text = jours + (jours > 1 ? " jours" : " jour");
        }

        private decimal GetPrixJour()
        {
            string text = txtPrixJour.Text.Replace("DH", "").Trim().Replace(',', '.');

            if (decimal.TryParse(text, System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out decimal prix))
            {
                return prix;
            }

            return 0;
        }

        private void CalculerMontants()
        {
            UpdateNombreJours();

            decimal prixJour = GetPrixJour();
            int jours = int.TryParse(txtNombreJours.Text, out int j) ? j : 1;
            decimal total = prixJour * jours;
            decimal avance = nudAvance.Value;
            decimal reste = total - avance;

            if (reste < 0)
                reste = 0;

            txtPrixTotal.Text = total.ToString("N2") + " DH";
            txtResteAPayer.Text = reste.ToString("N2") + " DH";
            lblTotalValue.Text = total.ToString("N2") + " DH";
        }

        private void btnCalculer_Click(object sender, EventArgs e)
        {
            CalculerMontants();
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            cboClient.SelectedIndex = -1;
            txtNom.Clear();
            txtTelephone.Clear();
            txtPermis.Clear();
            txtAdresse.Clear();

            cboImmatriculation.SelectedIndex = -1;
            cboMarque.SelectedIndex = -1;
            cboModele.SelectedIndex = -1;
            cboCarburant.SelectedIndex = -1;
            cboPuissance.SelectedIndex = -1;
            cboCategorie.SelectedIndex = -1;
            txtKilometrage.Clear();
            txtPrixJour.Text = "0";

            dtpDateDebut.Value = DateTime.Today;
            dtpDateFin.Value = DateTime.Today.AddDays(1);

            nudAvance.Value = 0;
            cboModePaiement.SelectedIndex = -1;
            txtRemarques.Clear();

            txtPrixTotal.Text = "0,00 DH";
            txtResteAPayer.Text = "0,00 DH";
            txtNombreJours.Text = "1";
            lblDureeValue.Text = "1 jour";
            lblTotalValue.Text = "0,00 DH";

            AutoGenerateContractNumber();
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            CalculerMontants();

            MessageBox.Show(
                "Contrat enregistré avec succès.",
                "Enregistrement",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Voulez-vous vraiment annuler ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Fonction d'impression prête à être liée.",
                "Impression",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void dtpDateDebut_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateFin.Value.Date < dtpDateDebut.Value.Date)
                dtpDateFin.Value = dtpDateDebut.Value.AddDays(1);

            CalculerMontants();
        }

        private void dtpDateFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDateFin.Value.Date < dtpDateDebut.Value.Date)
                dtpDateFin.Value = dtpDateDebut.Value.AddDays(1);

            CalculerMontants();
        }

        private void nudAvance_ValueChanged(object sender, EventArgs e)
        {
            CalculerMontants();
        }

        private void txtPrixJour_TextChanged(object sender, EventArgs e)
        {
            CalculerMontants();
        }

        private void cboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboClient.SelectedIndex)
            {
                case 0:
                    txtNom.Text = "Ahmed Benali";
                    txtTelephone.Text = "0612345678";
                    txtPermis.Text = "P123456";
                    txtAdresse.Text = "Casablanca";
                    break;

                case 1:
                    txtNom.Text = "Sara Amrani";
                    txtTelephone.Text = "0622334455";
                    txtPermis.Text = "P789456";
                    txtAdresse.Text = "Rabat";
                    break;

                case 2:
                    txtNom.Text = "Yassine El Idrissi";
                    txtTelephone.Text = "0633445566";
                    txtPermis.Text = "P654321";
                    txtAdresse.Text = "Marrakech";
                    break;
            }
        }

        private void cboImmatriculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboImmatriculation.SelectedIndex)
            {
                case 0:
                    cboMarque.Text = "Dacia";
                    cboModele.Text = "Logan";
                    cboCarburant.Text = "Diesel";
                    cboPuissance.Text = "6 CV";
                    cboCategorie.Text = "Berline";
                    txtKilometrage.Text = "45000";
                    txtPrixJour.Text = "350";
                    break;

                case 1:
                    cboMarque.Text = "Renault";
                    cboModele.Text = "Clio";
                    cboCarburant.Text = "Essence";
                    cboPuissance.Text = "7 CV";
                    cboCategorie.Text = "Citadine";
                    txtKilometrage.Text = "32000";
                    txtPrixJour.Text = "400";
                    break;

                case 2:
                    cboMarque.Text = "Peugeot";
                    cboModele.Text = "208";
                    cboCarburant.Text = "Diesel";
                    cboPuissance.Text = "8 CV";
                    cboCategorie.Text = "Citadine";
                    txtKilometrage.Text = "28000";
                    txtPrixJour.Text = "450";
                    break;
            }

            CalculerMontants();
        }
    }
}