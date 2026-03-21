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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lbldate.Text = DateTime.Now.ToString("dddd dd/MM/yyyy");
        }

        private void cmsUser_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnUserMenu_Click(object sender, EventArgs e)
        {
            cmsUser.Show(btnUserMenu, 0, btnUserMenu.Height);
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            formee.client cl    = new client();
            cl.ShowDialog();
        }

        private void btncar_Click(object sender, EventArgs e)
        {
            formee.voiture voi = new voiture();
            voi.ShowDialog();
        }

        private void btnreservation_Click(object sender, EventArgs e)
        {
            formee.reservation res = new reservation();
            res.ShowDialog();
        }

        private void Accueil_Click(object sender, EventArgs e)
        {
            formee.login log = new login();
            log.ShowDialog();
        }

        private void btncontrat_Click(object sender, EventArgs e)
        {
            formee.contrats con = new contrats();
            con.ShowDialog();
        }
    }
}
