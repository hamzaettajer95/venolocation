using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using Guna.UI2.WinForms;

using venolocation.classee;

namespace venolocation.settin
{
    public partial class activation : Form
    {
        public activation()
        {
            InitializeComponent();
        }

        private void AfficherLicenceActive()
        {
            pnlLicenceStatus.FillColor = Color.FromArgb(220, 255, 230);
            pnlLicenceStatus.BackColor = Color.FromArgb(220, 255, 230);
            pnlLicenceStatus.ForeColor = Color.Green;


            lblLicenceStatus.Text = "Licence active";
            lblLicenceStatus.ForeColor = Color.Green;

            txtActivation.Enabled = false;
            btnActiver.Enabled = false;
        }

        private void AfficherLicenceInactive()
        {
            pnlLicenceStatus.BackColor = Color.FromArgb(255, 246, 246);
            pnlLicenceStatus.FillColor = Color.FromArgb(255, 246, 246);
            pnlLicenceStatus.ForeColor = Color.DarkRed;

            lblLicenceStatus.Text = "Licence inactive";
            lblLicenceStatus.ForeColor = Color.DarkRed;

            txtActivation.Enabled = true;
            btnActiver.Enabled = true;
            txtActivation.Focus();
        }
        bool test_serial()
        {
            string programName = App_Config.Instance.name_programe;

            string driveUrl = App_Config.Instance.url_licence;

            bool active = ActivationHelper.CheckActivationFromDrive(programName, driveUrl);

            if (!active)
            {

                AfficherLicenceInactive();
                return false;
            }
            else
            {
                AfficherLicenceActive();
                return true;
                //classee.ErrorReporter.SendTestMessage("Ce Client active ce programme avec le serial : "+txtActivation.Text);
            }
                

        }
        private void activation_Load(object sender, EventArgs e)
        {
            txtActivation.Text = App_Config.Instance.serial;
            test_serial();
        }

        private void cardLicence_Paint(object sender, PaintEventArgs e)
        {

        }

        private string NettoyerCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return "";

            return code.Replace("-", "").Trim().ToUpper();
        }
        private void btnActiver_Click(object sender, EventArgs e)
        {
            App_Config.Instance.serial=NettoyerCode(txtActivation.Text);
            App_Config.Save(App_Config.Instance);
            
            if (test_serial())
            {
                classee.ErrorReporter.SendTestMessage("Ce Client active ce programme avec le serial : " + txtActivation.Text);
            }
        }

        private bool isFormatting = false;
        private void txtActivation_TextChanged(object sender, EventArgs e)
        {
            if (isFormatting)
                return;

            isFormatting = true;


            string text = txtActivation.Text.Replace("-", "").ToUpper();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < text.Length; i++)
            {
                if (i > 0 && i % 5 == 0)
                {
                    sb.Append("-");
                }

                sb.Append(text[i]);
            }

            txtActivation.Text = sb.ToString();
            txtActivation.SelectionStart = txtActivation.Text.Length;

            isFormatting = false;
        }
    }
}
