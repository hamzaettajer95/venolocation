using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            pnlLicenceStatus.BackColor = Color.FromArgb(220, 255, 230);
            pnlLicenceStatus.ForeColor = Color.Green;

            lblLicenceStatus.Text = "Licence active";
            lblLicenceStatus.ForeColor = Color.Green;

            txtActivation.Enabled = false;
            btnActiver.Enabled = false;
        }

        private void AfficherLicenceInactive()
        {
            pnlLicenceStatus.BackColor = Color.FromArgb(255, 225, 225);
            pnlLicenceStatus.ForeColor = Color.DarkRed;

            lblLicenceStatus.Text = "Licence inactive";
            lblLicenceStatus.ForeColor = Color.DarkRed;

            txtActivation.Enabled = true;
            btnActiver.Enabled = true;
            txtActivation.Focus();
        }
        void test_serial()
        {
            string programName = "venolocation";

            string driveUrl = Properties.Settings.Default.url_drive;

            bool active = ActivationHelper.CheckActivationFromDrive(programName, driveUrl);

            if (!active)
            {

                AfficherLicenceInactive();

            }
            else
                AfficherLicenceActive();

        }
        private void activation_Load(object sender, EventArgs e)
        {
            test_serial();
        }
    }
}
