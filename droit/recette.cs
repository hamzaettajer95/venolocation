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
            // 1. تعبئة السنوات (من 2024 لـ 2030 مثلاً)
            cb_annee.Items.Add("Année"); // هادي الرتبة 0
            for (int i = 2024; i <= 2030; i++)
            {
                cb_annee.Items.Add(i.ToString());
            }
            cb_annee.SelectedIndex = 0; // اختيار "Année" كافتراضي

            // 2. تعبئة الشهور (1 لـ 12)
            cb_mois.Items.Add("Mois");
            for (int i = 1; i <= 12; i++)
            {
                cb_mois.Items.Add(i.ToString("D2")); // D2 باش تبان 01, 02...
            }
            cb_mois.SelectedIndex = 0;

            // 3. تعبئة الأيام (1 لـ 31)
            cb_jour.Items.Add("Jour");
            for (int i = 1; i <= 31; i++)
            {
                cb_jour.Items.Add(i.ToString("D2"));
            }
            cb_jour.SelectedIndex = 0;
        }
        private void LoadRecettes()
        {
            string filter = " WHERE 1=1 ";
            if (cb_annee.SelectedIndex > 0) filter += $" AND YEAR(date_recette) = {cb_annee.Text}";
            if (cb_mois.SelectedIndex > 0) filter += $" AND MONTH(date_recette) = {cb_mois.SelectedIndex}";
            if (cb_jour.SelectedIndex > 0) filter += $" AND DAY(date_recette) = {cb_jour.Text}";

            string query = "SELECT * FROM recettes" + filter;
            DataTable dt = DbHelper.GetData(query);
            dgvRecette.DataSource = dt;

            decimal total = 0;
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["montant"]);
            }
            lbl_totale.Text = total.ToString("N2") + " DH";
        }
        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO recettes (type_recette, montant, date_recette) VALUES (@type, @montant, NOW())";
            MySqlParameter[] ps = {
        new MySqlParameter("@type", txt_type.Text),
        new MySqlParameter("@montant", txt_montant.Text)
    };
            DbHelper.ExecuteQuery(query, ps);
            LoadRecettes();
        }

        private void btn_suprimmer_Click(object sender, EventArgs e)
        {
            if (dgvRecette.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvRecette.CurrentRow.Cells["recette_id"].Value);
                string query = "DELETE FROM depences WHERE recette_id = @id";
                DbHelper.ExecuteQuery(query, new MySqlParameter[] { new MySqlParameter("@id", id) });
                LoadRecettes();
            }
        }

        private void recette_Load(object sender, EventArgs e)
        {
            FillDateCombos();
            LoadRecettes();

        }

        private void CalculateTotal()
        {
            decimal total = 0;

            // كنمشيو سطر بسطر فـ الـ DataGridView
            foreach (DataGridViewRow row in dgvRecette.Rows)
            {
                // كنأكدو بلي السطر ماشي خاوي وبلي الخانة ديال Montant فيها قيمة
                if (row.Cells["montant"].Value != null && row.Cells["montant"].Value != DBNull.Value)
                {
                    total += Convert.ToDecimal(row.Cells["montant"].Value);
                }
            }

            // كنحطو النتيجة فـ الـ Label مع تنسيق مالي (N2 كتعني جوج أرقام ورا الفاصلة)
            lbl_totale.Text = total.ToString("N2") + " DH";
        }

        private void btn_filtrer_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM recettes WHERE 1=1"; // أو recettes

            // إذا اختار العام (SelectedIndex > 0 حيت 0 هي كلمة Année)
            if (cb_annee.SelectedIndex > 0)
            {
                query += " AND YEAR(date_recette) = " + cb_annee.SelectedItem.ToString();
            }

            // إذا اختار الشهر
            if (cb_mois.SelectedIndex > 0)
            {
                query += " AND MONTH(date_recette) = " + cb_mois.SelectedIndex; // SelectedIndex هنا هو رقم الشهر نيشان
            }

            // إذا اختار النهار
            if (cb_jour.SelectedIndex > 0)
            {
                query += " AND DAY(date_recette) = " + cb_jour.SelectedItem.ToString();
            }

            // نفذ الـ Query وعمر الـ DataGridView
            dgvRecette.DataSource = DbHelper.GetData(query);

            // ما تنساش تعيط للدالة ديال حساب المجموع مورا هادشي
            CalculateTotal();
        }
    }
}
