using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

using venolocation.classee;

namespace venolocation.formee
{
    public partial class alerte : Form
    {
        

        public alerte()
        {
            InitializeComponent();
        }

        private void alerte_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                LoadAlertes();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "alerte", "alerte_Load");
                MessageBox.Show("Erreur lors du chargement du formulaire : " + ex.Message);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void LoadAlertes()
        {
            try
            {
                dgvAlertes.Rows.Clear();

                string query = @"
                                SELECT id,type, message, voiture, date_alerte, statut,vue
                                FROM alerte
                                ORDER BY id DESC
                                LIMIT 300;";

                DataTable dt = Dbexec.GetData(query);

                foreach (DataRow row in dt.Rows)
                {
                    bool vue = Convert.ToInt32(row["vue"]) == 1;

                    int rowIndex = dgvAlertes.Rows.Add(
                        row["id"].ToString(),
                        row["type"].ToString(),
                        row["message"].ToString(),
                        row["voiture"].ToString(),
                        Convert.ToDateTime(row["date_alerte"]).ToString("yyyy-MM-dd"),
                        row["statut"].ToString(),
                        vue
                    );

                    ApplyRowStyle(dgvAlertes.Rows[rowIndex], vue);
                }

                lblCount.Text = dgvAlertes.Rows.Count + " alertes";

                GridStyleHelper_1.ApplyCompact(dgvAlertes);

                if (dgvAlertes.Columns.Contains("colMessage"))
                    dgvAlertes.Columns["colMessage"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                if (dgvAlertes.Columns.Contains("colVoiture"))
                    dgvAlertes.Columns["colVoiture"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "alerte", "LoadAlertes");
                MessageBox.Show("Erreur lors du chargement : " + ex.Message);
            }
        }

        private void ApplyRowStyle(DataGridViewRow row, bool vue)
        {
            if (vue)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(220, 252, 231);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 247, 208);
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            }

            if (row.Cells["colStatut"].Value != null)
            {
                string statut = row.Cells["colStatut"].Value.ToString().Trim().ToLower();
                row.Cells["colStatut"].Style.Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold);

                if (statut == "urgent")
                    row.Cells["colStatut"].Style.ForeColor = Color.FromArgb(220, 38, 38);
                else if (statut == "normal")
                    row.Cells["colStatut"].Style.ForeColor = Color.FromArgb(22, 163, 74);
                else
                    row.Cells["colStatut"].Style.ForeColor = Color.FromArgb(217, 119, 6);
            }
        }

        private void dgvAlertes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvAlertes.IsCurrentCellDirty)
            {
                dgvAlertes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvAlertes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvAlertes.Columns[e.ColumnIndex].Name != "colVue")
                return;

            try
            {
                DataGridViewRow row = dgvAlertes.Rows[e.RowIndex];

                int id = Convert.ToInt32(row.Cells["colId"].Value);
                bool nouvelleValeur = Convert.ToBoolean(row.Cells["colVue"].EditedFormattedValue);

                UpdateVueInDatabase(id, nouvelleValeur);
                ApplyRowStyle(row, nouvelleValeur);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "alerte", "dgvAlertes_CellContentClick");
                MessageBox.Show("Erreur lors du changement de statut : " + ex.Message);
            }
        }

        private void UpdateVueInDatabase(int id, bool vue)
        {
            try
            {
                string query = @"
                                UPDATE alerte 
                                SET vue = @vue 
                                WHERE id = @id";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@vue", vue ? 1 : 0),
                    new MySqlParameter("@id", id)
                };

                Dbexec.ExecuteQuery(query, ps);

                LogHelper.AddLog("Mise à jour alerte ID: " + id + " vue = " + (vue ? 1 : 0), Session.Username);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "alerte", "UpdateVueInDatabase");
                MessageBox.Show("Erreur lors de la mise à jour : " + ex.Message);
                LoadAlertes();
            }
        }
    }
}