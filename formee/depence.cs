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

namespace venolocation.formee
{
    public partial class depence : Form
    {
        public depence()
        {
            InitializeComponent();
        }

        private DataTable ChargerDepencesFiltres()
        {
            string query = @"
                        SELECT 
                            depense_id AS 'ID',
                            type AS 'Type',
                            montant AS 'Montant',
                            DATE_FORMAT(date_depense, '%d/%m/%Y %H:%i:%s') AS 'Date'
                        FROM depenses
                        WHERE 1=1 ";

            List<MySqlParameter> ps = new List<MySqlParameter>();

            if (cb_annee.SelectedIndex > 0)
            {
                query += " AND YEAR(date_depense) = @annee ";
                ps.Add(new MySqlParameter("@annee", Convert.ToInt32(cb_annee.Text)));
            }

            if (cb_mois.SelectedIndex > 0)
            {
                query += " AND MONTH(date_depense) = @mois ";
                ps.Add(new MySqlParameter("@mois", cb_mois.SelectedIndex));
            }

            if (cb_jour.SelectedIndex > 0)
            {
                query += " AND DAY(date_depense) = @jour ";
                ps.Add(new MySqlParameter("@jour", Convert.ToInt32(cb_jour.Text)));
            }

            query += " ORDER BY depense_id DESC LIMIT 300;";

            return Dbexec.GetData(query, ps.ToArray());
        }
        private void FillDateCombos()
        {

            cb_annee.Items.Add("Année");
            for (int i = 2024; i <= 2040; i++)
            {
                cb_annee.Items.Add(i.ToString());
            }
            cb_annee.SelectedIndex = 0;


            cb_mois.Items.Add("Mois");
            for (int i = 1; i <= 12; i++)
            {
                cb_mois.Items.Add(i.ToString("D2"));
            }
            cb_mois.SelectedIndex = 0;


            cb_jour.Items.Add("Jour");
            for (int i = 1; i <= 31; i++)
            {
                cb_jour.Items.Add(i.ToString("D2"));
            }
            cb_jour.SelectedIndex = 0;
        }

        private void LoadDepences()
        {
            try
            {
                DataTable dt = ChargerDepencesFiltres();
                dgvDepence.DataSource = dt;

                GridStyleHelper_1.Apply(dgvDepence);

                if (dgvDepence.Columns.Count > 0)
                {
                    dgvDepence.Columns["ID"].FillWeight = 10;
                    dgvDepence.Columns["Type"].FillWeight = 35;
                    dgvDepence.Columns["Montant"].FillWeight = 20;
                    dgvDepence.Columns["Date"].FillWeight = 25;

                    GridStyleHelper_1.AlignLeft(dgvDepence, "Type");
                }

                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Montant"] != DBNull.Value)
                        total += Convert.ToDecimal(row["Montant"]);
                }

                lbl_totale.Text = total.ToString("N2") + " DH";
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "depence", "LoadDepences");
                MessageBox.Show("Erreur lors du chargement des dépenses : " + ex.Message);
            }
        }
        private void depence_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                FillDateCombos();
                LoadDepences();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "depence", "depence_Load");
                MessageBox.Show("Erreur lors du chargement du formulaire : " + ex.Message);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_type.Text))
                {
                    MessageBox.Show("Saisissez le type de dépense.");
                    txt_type.Focus();
                    return;
                }

                if (!decimal.TryParse(txt_montant.Text.Trim(), out decimal montant) || montant <= 0)
                {
                    MessageBox.Show("Montant invalide.");
                    txt_montant.Focus();
                    return;
                }

                string query = @"
                                INSERT INTO depenses (type, montant, date_depense) 
                                VALUES (@type, @montant, NOW())";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@type", txt_type.Text.Trim()),
                    new MySqlParameter("@montant", montant)
                };

                if (Dbexec.ExecuteQuery(query, ps) > 0)
                {
                    LogHelper.AddLog("Ajout dépense type: " + txt_type.Text.Trim(), Session.Username);
                    MessageBox.Show("Dépense ajoutée !", "Succès");
                    LoadDepences();
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "depence", "btn_ajouter_Click");
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }
        }

        private void btn_suprimmer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDepence.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionnez une dépense.");
                    return;
                }

                int id = Convert.ToInt32(dgvDepence.CurrentRow.Cells["ID"].Value);

                if (MessageBox.Show("Voulez-vous vraiment supprimer cette dépense ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                string query = "DELETE FROM depenses WHERE depense_id = @id";

                Dbexec.ExecuteQuery(query, new MySqlParameter[]
                {
            new MySqlParameter("@id", id)
                });

                LogHelper.AddLog("Suppression dépense ID: " + id, Session.Username);
                LoadDepences();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "depence", "btn_suprimmer_Click");
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
            }
        }
        private void CalculateTotal()
        {
            try
            {
                decimal total = 0;

                foreach (DataGridViewRow row in dgvDepence.Rows)
                {
                    if (row.Cells["Montant"].Value != null && row.Cells["Montant"].Value != DBNull.Value)
                        total += Convert.ToDecimal(row.Cells["Montant"].Value);
                }

                lbl_totale.Text = total.ToString("N2") + " DH";
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "depence", "CalculateTotal");
                MessageBox.Show("Erreur lors du calcul du total : " + ex.Message);
            }
        }
        private void btn_filtrer_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDepences();

                LogHelper.AddLog("Filtrage dépenses", Session.Username);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "depence", "btn_filtrer_Click");
                MessageBox.Show("Erreur lors du filtrage : " + ex.Message);
            }
        }
    }
}
