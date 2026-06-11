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
    public partial class prolongation : Form
    {
        public prolongation()
        {
            InitializeComponent();
        }
        private void InitialiserHeures()
        {
            
            cbHeureRetour.Items.Clear();

            for (int h = 0; h < 24; h++)
            {
               
                cbHeureRetour.Items.Add(h.ToString("00") + ":00");
            }

           
            cbHeureRetour.SelectedIndex = 1;
        }

        private void prolongation_Load(object sender, EventArgs e)
        {
            InitialiserHeures();
        }
    }
}
