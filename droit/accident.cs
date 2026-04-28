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
    public partial class accident : Form
    {
        private int accidentIdSelectionne = -1;
        public accident()
        {
            InitializeComponent();
        }

        private void ChargerContrats()
        {
            try
            {
                string query = @"
                SELECT 
                    contrat_id,
                    CONCAT('Contrat N° ', contrat_id) AS contrat_display
                FROM contrats
                ORDER BY contrat_id DESC
                LIMIT 300;";

                DataTable dt = Dbexec.GetData(query);

                cbContrat.DataSource = dt;
                cbContrat.DisplayMember = "contrat_display";
                cbContrat.ValueMember = "contrat_id";
                cbContrat.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "accident", "ChargerContrats");
                MessageService.Error("Erreur chargement contrats.");
            }
        }

        private void ChargerAccidents()
        {
            try
            {
                string query = @"
                SELECT
                    accident_id AS 'ID',
                    contrat_id AS 'Contrat',
                    DATE_FORMAT(date_accident, '%d/%m/%Y') AS 'Date accident',
                    description AS 'Description',
                    montant_reparation AS 'Montant réparation',
                    montant_paye AS 'Montant payé',
                    nom_utilisateur AS 'Utilisateur',
                    DATE_FORMAT(created_at, '%d/%m/%Y %H:%i:%s') AS 'Créé le'
                FROM accidents
                ORDER BY accident_id DESC
                LIMIT 300;";

                dgvAccidents.DataSource = Dbexec.GetData(query);

                GridStyleHelper_1.Apply(dgvAccidents);

                if (dgvAccidents.Columns.Count > 0)
                {
                    dgvAccidents.Columns["ID"].FillWeight = 10;
                    dgvAccidents.Columns["Contrat"].FillWeight = 14;
                    dgvAccidents.Columns["Date accident"].FillWeight = 16;
                    dgvAccidents.Columns["Description"].FillWeight = 34;
                    dgvAccidents.Columns["Montant réparation"].FillWeight = 18;
                    dgvAccidents.Columns["Montant payé"].FillWeight = 18;
                    dgvAccidents.Columns["Utilisateur"].FillWeight = 15;
                    dgvAccidents.Columns["Créé le"].FillWeight = 22;

                    GridStyleHelper_1.AlignLeft(dgvAccidents, "Description");
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "accident", "ChargerAccidents");
                MessageService.Error("Erreur chargement accidents.");
            }
        }

        private void ViderChamps()
        {
            accidentIdSelectionne = -1;
            cbContrat.SelectedIndex = -1;
            txtMontantReparation.Clear();
            txtMontantPaye.Clear();
            txtDescription.Clear();
            dtDateAccident.Value = DateTime.Now;
        }

        private bool ChampsValides()
        {
            if (cbContrat.SelectedIndex == -1)
            {
                MessageService.Warning("Sélectionnez un contrat.");
                cbContrat.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageService.Warning("Saisissez la description.");
                txtDescription.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMontantReparation.Text.Trim(), out decimal montantRep) || montantRep < 0)
            {
                MessageService.Warning("Montant réparation invalide.");
                txtMontantReparation.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtMontantPaye.Text))
            {
                if (!decimal.TryParse(txtMontantPaye.Text.Trim(), out decimal montantPaye) || montantPaye < 0)
                {
                    MessageService.Warning("Montant payé invalide.");
                    txtMontantPaye.Focus();
                    return false;
                }
            }

            return true;
        }

        private decimal LireMontantPaye()
        {
            if (string.IsNullOrWhiteSpace(txtMontantPaye.Text))
                return 0;

            return decimal.Parse(txtMontantPaye.Text.Trim());
        }



        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ChampsValides())
                return;

            try
            {
                string query = @"
                INSERT INTO accidents
                (contrat_id, date_accident, description, montant_reparation, montant_paye, nom_utilisateur, created_at)
                VALUES
                (@contrat_id, @date_accident, @description, @montant_reparation, @montant_paye, @nom_utilisateur, NOW())";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@contrat_id", cbContrat.SelectedValue),
                    new MySqlParameter("@date_accident", dtDateAccident.Value.Date),
                    new MySqlParameter("@description", txtDescription.Text.Trim()),
                    new MySqlParameter("@montant_reparation", decimal.Parse(txtMontantReparation.Text.Trim())),
                    new MySqlParameter("@montant_paye", LireMontantPaye()),
                    new MySqlParameter("@nom_utilisateur", Session.Username)
                };

                Dbexec.ExecuteQuery(query, ps);

                LogHelper.AddLog("Ajout accident contrat ID: " + cbContrat.SelectedValue, Session.Username);
                MessageService.Success("Accident enregistré avec succès.");

                ChargerAccidents();
                ViderChamps();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "accident", "btnEnregistrer_Click");
                MessageService.Error("Erreur enregistrement accident.");
            }
        }

        private void accident_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                ChargerContrats();
                ChargerAccidents();
                ViderChamps();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "accident", "accident_Load");
                MessageService.Error("Erreur lors du chargement du formulaire.");
            }
            finally
            {
                this.ResumeLayout();
            }

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (accidentIdSelectionne <= 0)
            {
                MessageService.Warning("Sélectionnez un accident.");
                return;
            }

            if (!ChampsValides())
                return;

            try
            {
                string query = @"
                UPDATE accidents SET
                    contrat_id = @contrat_id,
                    date_accident = @date_accident,
                    description = @description,
                    montant_reparation = @montant_reparation,
                    montant_paye = @montant_paye,
                    nom_utilisateur = @nom_utilisateur
                WHERE accident_id = @accident_id";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@contrat_id", cbContrat.SelectedValue),
                    new MySqlParameter("@date_accident", dtDateAccident.Value.Date),
                    new MySqlParameter("@description", txtDescription.Text.Trim()),
                    new MySqlParameter("@montant_reparation", decimal.Parse(txtMontantReparation.Text.Trim())),
                    new MySqlParameter("@montant_paye", LireMontantPaye()),
                    new MySqlParameter("@nom_utilisateur", Session.Username),
                    new MySqlParameter("@accident_id", accidentIdSelectionne)
                };

                Dbexec.ExecuteQuery(query, ps);

                LogHelper.AddLog("Modification accident ID: " + accidentIdSelectionne, Session.Username);
                MessageService.Success("Accident modifié avec succès.");

                ChargerAccidents();
                ViderChamps();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "accident", "btnModifier_Click");
                MessageService.Error("Erreur modification accident.");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (accidentIdSelectionne <= 0)
            {
                MessageService.Warning("Sélectionnez un accident.");
                return;
            }

            if (MessageService.Confirm("Voulez-vous vraiment supprimer cet accident ?") != DialogResult.Yes)
                return;

            try
            {
                string query = "DELETE FROM accidents WHERE accident_id = @id";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@id", accidentIdSelectionne)
                };

                Dbexec.ExecuteQuery(query, ps);

                LogHelper.AddLog("Suppression accident ID: " + accidentIdSelectionne, Session.Username);
                MessageService.Success("Accident supprimé avec succès.");

                ChargerAccidents();
                ViderChamps();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "accident", "btnSupprimer_Click");
                MessageService.Error("Erreur suppression accident.");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ViderChamps();
        }

        private void dgvAccidents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAccidents.Rows[e.RowIndex];

                accidentIdSelectionne = Convert.ToInt32(row.Cells["ID"].Value);
                cbContrat.SelectedValue = row.Cells["Contrat"].Value;
                txtDescription.Text = row.Cells["Description"].Value?.ToString();
                txtMontantReparation.Text = row.Cells["Montant réparation"].Value?.ToString();
                txtMontantPaye.Text = row.Cells["Montant payé"].Value?.ToString();

                if (row.Cells["Date accident"].Value != null)
                {
                    DateTime dt;
                    if (DateTime.TryParse(row.Cells["Date accident"].Value.ToString(), out dt))
                        dtDateAccident.Value = dt;
                }
            }
        }

        private void txtMontantPaye_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;

            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (txtMontantReparation.Text.Contains(",") || txtMontantReparation.Text.Contains(".")))
                e.Handled = true;
        }

        private void txtMontantReparation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;

            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (txtMontantPaye.Text.Contains(",") || txtMontantPaye.Text.Contains(".")))
                e.Handled = true;
        }
    }
}
