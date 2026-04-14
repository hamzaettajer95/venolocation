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
            string filter = " WHERE 1=1 ";
            if (cb_annee.SelectedIndex > 0) filter += $" AND YEAR(date_depense) = {cb_annee.Text}";
            if (cb_mois.SelectedIndex > 0) filter += $" AND MONTH(date_depense) = {cb_mois.SelectedIndex}";
            if (cb_jour.SelectedIndex > 0) filter += $" AND DAY(date_depense) = {cb_jour.Text}";

            string query = "SELECT * FROM depenses" + filter;
            DataTable dt = DbHelper.GetData(query);
            dgvDepence.DataSource = dt;

            
            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["montant"]);
            }
            lbl_totale.Text = total.ToString("N2") + " DH";
        }
        private void depence_Load(object sender, EventArgs e)
        {
            FillDateCombos();
            LoadDepences();
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO depenses (type, montant, date_depense) VALUES (@type, @montant, NOW())";
                MySqlParameter[] ps = {
                new MySqlParameter("@type", txt_type.Text),
                new MySqlParameter("@montant", txt_montant.Text)
            };
            if (DbHelper.ExecuteQuery(query, ps) > 0)
            {
                MessageBox.Show("Dépense ajoutée !", "Succès");
                LoadDepences();
            }
        }

        private void btn_suprimmer_Click(object sender, EventArgs e)
        {
            if (dgvDepence.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvDepence.CurrentRow.Cells["depense_id"].Value);
                string query = "DELETE FROM depenses WHERE depense_id = @id";
                DbHelper.ExecuteQuery(query, new MySqlParameter[] { new MySqlParameter("@id", id) });
                LoadDepences();
            }
        }
        private void CalculateTotal()
        {
            decimal total = 0;

            
            foreach (DataGridViewRow row in dgvDepence.Rows)
            {
                
                if (row.Cells["montant"].Value != null && row.Cells["montant"].Value != DBNull.Value)
                {
                    total += Convert.ToDecimal(row.Cells["montant"].Value);
                }
            }

           
            lbl_totale.Text = total.ToString("N2") + " DH";
        }
        private void btn_filtrer_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM depenses WHERE 1=1"; 

           
            if (cb_annee.SelectedIndex > 0)
            {
                query += " AND YEAR(date_depense) = " + cb_annee.SelectedItem.ToString();
            }

            
            if (cb_mois.SelectedIndex > 0)
            {
                query += " AND MONTH(date_depense) = " + cb_mois.SelectedIndex;
            }

           
            if (cb_jour.SelectedIndex > 0)
            {
                query += " AND DAY(date_depense) = " + cb_jour.SelectedItem.ToString();
            }

          
            dgvDepence.DataSource = DbHelper.GetData(query);

            
            CalculateTotal();
        }
    }
}
