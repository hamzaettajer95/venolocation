using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

using venolocation.classee;

namespace venolocation.settin
{
    public partial class aff_logs : Form
    {
        public aff_logs()
        {
            InitializeComponent();
        }
        void LoadLogs()
        {
            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = @"SELECT * FROM logs ORDER BY id DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(q, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    guna2DataGridView1.DataSource = dt;
                    GridStyleHelper_1.ApplyCompact(guna2DataGridView1);
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "Afficher Logs", "Chargement Logs");
                MessageService.Error(AppMessages.UnexpectedError);
            }

        }
        private void aff_logs_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                LoadLogs();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "Logs", "Logs_Load");
                MessageService.Error(AppMessages.UnexpectedError);
            }
            finally
            {
                this.ResumeLayout();
            }
        }
    }
}
