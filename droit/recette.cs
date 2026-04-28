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
using venolocation.formee;
using venolocation.classee;

namespace venolocation.droit
{
    public partial class recette : Form
    {
        public recette()
        {
            InitializeComponent();
        }
        private DataTable ChargerRecettesFiltres()
        {
            string query = @"
                            SELECT 
                                recette_id AS 'ID',
                                type AS 'Type',
                                montant AS 'Montant',
                                DATE_FORMAT(date_recette, '%d/%m/%Y %H:%i:%s') AS 'Date'
                            FROM recettes
                            WHERE 1=1 ";

            List<MySqlParameter> ps = new List<MySqlParameter>();

            if (cb_annee.SelectedIndex > 0)
            {
                query += " AND YEAR(date_recette) = @annee ";
                ps.Add(new MySqlParameter("@annee", Convert.ToInt32(cb_annee.Text)));
            }

            if (cb_mois.SelectedIndex > 0)
            {
                query += " AND MONTH(date_recette) = @mois ";
                ps.Add(new MySqlParameter("@mois", cb_mois.SelectedIndex));
            }

            if (cb_jour.SelectedIndex > 0)
            {
                query += " AND DAY(date_recette) = @jour ";
                ps.Add(new MySqlParameter("@jour", Convert.ToInt32(cb_jour.Text)));
            }

            query += " ORDER BY recette_id DESC LIMIT 300;";

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
        private void LoadRecettes()
        {
            try
            {
                DataTable dt = ChargerRecettesFiltres();
                dgvRecette.DataSource = dt;

                GridStyleHelper_1.Apply(dgvRecette);

                if (dgvRecette.Columns.Count > 0)
                {
                    dgvRecette.Columns["ID"].FillWeight = 10;
                    dgvRecette.Columns["Type"].FillWeight = 35;
                    dgvRecette.Columns["Montant"].FillWeight = 20;
                    dgvRecette.Columns["Date"].FillWeight = 25;

                    GridStyleHelper_1.AlignLeft(dgvRecette, "Type");
                }

                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Montant"] != DBNull.Value)
                        total += Convert.ToDecimal(row["Montant"]);
                }

                lbl_totale.Text = "Le Totale : " + total.ToString("N2") + " DH";
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "recette", "LoadRecettes");
                MessageBox.Show("Erreur lors du chargement des recettes : " + ex.Message);
            }
        }
        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_type.Text))
                {
                    MessageBox.Show("Saisissez le type de recette.");
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
                                INSERT INTO recettes (type, montant, date_recette)
                                VALUES (@type, @montant, NOW())";

                MySqlParameter[] ps =
                {
                        new MySqlParameter("@type", txt_type.Text.Trim()),
                        new MySqlParameter("@montant", montant)
                };

                Dbexec.ExecuteQuery(query, ps);

                LogHelper.AddLog("Ajout recette type: " + txt_type.Text.Trim(), Session.Username);
                LoadRecettes();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "recette", "btn_ajouter_Click");
                MessageBox.Show("Erreur lors de l'ajout : " + ex.Message);
            }
        }

        private void btn_suprimmer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecette.CurrentRow == null)
                {
                    MessageBox.Show("Sélectionnez une recette.");
                    return;
                }

                int id = Convert.ToInt32(dgvRecette.CurrentRow.Cells["ID"].Value);

                if (MessageBox.Show("Voulez-vous vraiment supprimer cette recette ?", "Confirmation",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                string query = "DELETE FROM recettes WHERE recette_id = @id";

                Dbexec.ExecuteQuery(query, new MySqlParameter[]
                {
            new MySqlParameter("@id", id)
                });

                LogHelper.AddLog("Suppression recette ID: " + id, Session.Username);
                LoadRecettes();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "recette", "btn_suprimmer_Click");
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
            }
        }

        private void recette_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                FillDateCombos();
                LoadRecettes();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "recette", "recette_Load");
                MessageBox.Show("Erreur lors du chargement du formulaire : " + ex.Message);
            }
            finally
            {
                this.ResumeLayout();
            }

        }

       

        private void btn_filtrer_Click(object sender, EventArgs e)
        {
            try
            {
                LoadRecettes();

                //LogHelper.AddLog("Filtrage recettes", Session.Username);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "recette", "btn_filtrer_Click");
                MessageBox.Show("Erreur lors du filtrage : " + ex.Message);
            }
        }
    }
}
