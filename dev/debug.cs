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
    public partial class debug : Form
    {
        public debug()
        {
            InitializeComponent();
        }

        private void debug_Load(object sender, EventArgs e)
        {
            try
            {
                txtQuery.Multiline = true;
                txtQuery.ScrollBars = ScrollBars.Vertical;

                dgvResult.ReadOnly = true;
                dgvResult.AllowUserToAddRows = false;
                dgvResult.AllowUserToDeleteRows = false;
                dgvResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                GridStyleHelper_1.Apply(dgvResult);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "debug", "debug_Load");
                MessageBox.Show("Erreur chargement debug : " + ex.Message);
            }
        }

        private bool IsSelectQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return false;

            string q = query.Trim().ToLower();

            return q.StartsWith("select") ||
                   q.StartsWith("show") ||
                   q.StartsWith("describe") ||
                   q.StartsWith("desc");
        }

        private bool IsDangerousQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return false;

            string q = query.Trim().ToLower();

            return q.Contains("drop database") ||
                   q.Contains("drop table") ||
                   q.Contains("truncate") ||
                   q.Contains("delete from") ||
                   q.Contains("alter table");
        }

        private void button_exec_Click(object sender, EventArgs e)
        {
            try
            {
                string query = txtQuery.Text.Trim();

                if (string.IsNullOrWhiteSpace(query))
                {
                    MessageBox.Show("Écrivez une requête SQL.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQuery.Focus();
                    return;
                }

                if (IsSelectQuery(query))
                {
                    MessageBox.Show("Cette opération est pour INSERT / UPDATE / DELETE. Utilisez Execute Data pour SELECT.",
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (IsDangerousQuery(query))
                {
                    DialogResult danger = MessageBox.Show(
                        "Attention : cette requête peut modifier ou supprimer des données importantes.\nVoulez-vous continuer ?",
                        "Confirmation dangereuse",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (danger != DialogResult.Yes)
                        return;
                }

                DialogResult res = MessageBox.Show(
                    "Voulez-vous exécuter cette requête ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res != DialogResult.Yes)
                    return;

                int rows = Dbexec.ExecuteQuery(query);

                LogHelper.AddLog("Debug SQL ExecuteQuery : " + query, Session.Username);

                MessageBox.Show("Requête exécutée avec succès.\nLignes affectées : " + rows,
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "debug", "btnExecuteQuery_Click");
                MessageBox.Show("Erreur SQL : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_data_Click(object sender, EventArgs e)
        {
            try
            {
                string query = txtQuery.Text.Trim();

                if (string.IsNullOrWhiteSpace(query))
                {
                    string table = txtTable.Text.Trim();

                    if (string.IsNullOrWhiteSpace(table))
                    {
                        MessageBox.Show("Écrivez une requête SELECT ou le nom de la table.",
                            "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    query = "SELECT * FROM `" + table.Replace("`", "") + "` LIMIT 1000;";
                }

                if (!IsSelectQuery(query))
                {
                    MessageBox.Show("Execute Data accepte seulement SELECT / SHOW / DESCRIBE.",
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = Dbexec.GetData(query);

                dgvResult.DataSource = null;
                dgvResult.Columns.Clear();
                dgvResult.AutoGenerateColumns = true;
                dgvResult.DataSource = dt;

                GridStyleHelper_1.Apply(dgvResult);

                LogHelper.AddLog("Debug SQL GetData : " + query, Session.Username);

                MessageBox.Show("Données chargées : " + dt.Rows.Count + " ligne(s).",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "debug", "btnExecuteData_Click");
                MessageBox.Show("Erreur SQL : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
