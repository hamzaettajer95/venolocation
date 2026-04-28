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
using MySql.Data.MySqlClient;

using MySql.Data.MySqlClient;

using venolocation.classee;

namespace venolocation.settin
{
    public partial class affi_erreur : Form
    {
        public affi_erreur()
        {
            InitializeComponent();
        }
        void LoadErreur()
        {
            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = @"SELECT * FROM erreur";

                    MySqlDataAdapter da = new MySqlDataAdapter(q, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    guna2DataGridView1.DataSource = dt;
                    GridStyleHelper_1.ApplyCompact(guna2DataGridView1);
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture", "voiture_load");
                MessageService.Error(AppMessages.UnexpectedError);
            }

        }
        private void affi_erreur_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                LoadErreur();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "Erreur", "Erreur_Load");
                MessageService.Error(AppMessages.UnexpectedError);
            }
            finally
            {
                this.ResumeLayout();
            }
        }
    }
}
