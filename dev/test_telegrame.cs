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

namespace venolocation.dev
{
    public partial class test_telegrame : Form
    {
        public test_telegrame()
        {
            InitializeComponent();
        }

       
        private void test_telegrame_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRetourSimple_Click(object sender, EventArgs e)
        {
            classee.ErrorReporter.SendTestMessage(txtmessage.Text);
        }
    }
}
