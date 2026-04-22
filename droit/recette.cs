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
                string filter = " WHERE 1=1 ";
                if (cb_annee.SelectedIndex > 0) filter += $" AND YEAR(date_recette) = {cb_annee.Text}";
                if (cb_mois.SelectedIndex > 0) filter += $" AND MONTH(date_recette) = {cb_mois.SelectedIndex}";
                if (cb_jour.SelectedIndex > 0) filter += $" AND DAY(date_recette) = {cb_jour.Text}";

                string query = "SELECT * FROM recettes" + filter;
                DataTable dt = Dbexec.GetData(query);
                dgvRecette.DataSource = dt;

                decimal total = 0;
                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToDecimal(row["montant"]);
                }
                lbl_totale.Text = total.ToString("N2") + " DH";
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
                string query = "INSERT INTO recettes (type_recette, montant, date_recette) VALUES (@type, @montant, NOW())";
                MySqlParameter[] ps = {
            new MySqlParameter("@type", txt_type.Text),
            new MySqlParameter("@montant", txt_montant.Text)
        };

                Dbexec.ExecuteQuery(query, ps);
                LogHelper.AddLog("Ajout recette type: " + txt_type.Text, Session.Username);
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
                if (dgvRecette.CurrentRow != null)
                {
                    int id = Convert.ToInt32(dgvRecette.CurrentRow.Cells["recette_id"].Value);
                    string query = "DELETE FROM recettes WHERE recette_id = @id";
                    Dbexec.ExecuteQuery(query, new MySqlParameter[] { new MySqlParameter("@id", id) });

                    LogHelper.AddLog("Suppression recette ID: " + id, Session.Username);
                    LoadRecettes();
                }
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
                FillDateCombos();
                LoadRecettes();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "recette", "recette_Load");
                MessageBox.Show("Erreur lors du chargement du formulaire : " + ex.Message);
            }

        }

        private void CalculateTotal()
        {
            try
            {
                decimal total = 0;

                foreach (DataGridViewRow row in dgvRecette.Rows)
                {
                    if (row.Cells["montant"].Value != null && row.Cells["montant"].Value != DBNull.Value)
                    {
                        total += Convert.ToDecimal(row.Cells["montant"].Value);
                    }
                }

                lbl_totale.Text = "Le Totale : "+total.ToString("N2") + " DH";
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "recette", "CalculateTotal");
                MessageBox.Show("Erreur lors du calcul du total : " + ex.Message);
            }
        }

        private void btn_filtrer_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM recettes WHERE 1=1";

                if (cb_annee.SelectedIndex > 0)
                {
                    query += " AND YEAR(date_recette) = " + cb_annee.SelectedItem.ToString();
                }

                if (cb_mois.SelectedIndex > 0)
                {
                    query += " AND MONTH(date_recette) = " + cb_mois.SelectedIndex;
                }

                if (cb_jour.SelectedIndex > 0)
                {
                    query += " AND DAY(date_recette) = " + cb_jour.SelectedItem.ToString();
                }

                dgvRecette.DataSource = Dbexec.GetData(query);
                LogHelper.AddLog("Filtrage recettes", Session.Username);

                CalculateTotal();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "recette", "btn_filtrer_Click");
                MessageBox.Show("Erreur lors du filtrage : " + ex.Message);
            }
        }
    }
}
