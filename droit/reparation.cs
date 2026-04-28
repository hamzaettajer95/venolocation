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
using venolocation.formee;

namespace venolocation.droit
{
    public partial class reparation : Form
    {
        public reparation()
        {
            InitializeComponent();
        }
        string connectionString = dashboard.connection_string;
        int reparationIdSelectionnee = -1;
        int voitureIdSelectionnee = -1;

        private void ChargerVoitures()
        {
            try
            {
                string query = @"
                            SELECT 
                                voiture_id,
                                CONCAT(matricule, ' - ', marque, ' ', modele) AS voiture
                            FROM voitures
                            ORDER BY matricule
                            LIMIT 500;";

                DataTable dt = Dbexec.GetData(query);

                cbVoiture.DataSource = dt;
                cbVoiture.DisplayMember = "voiture";
                cbVoiture.ValueMember = "voiture_id";
                cbVoiture.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reparation", "ChargerVoitures");
                MessageBox.Show("Erreur chargement voitures : " + ex.Message);
            }
        }
        private void ColorierStatutReparations()
        {
            if (!dgvReparations.Columns.Contains("Statut"))
                return;

            foreach (DataGridViewRow row in dgvReparations.Rows)
            {
                if (row.IsNewRow || row.Cells["Statut"].Value == null)
                    continue;

                string statut = row.Cells["Statut"].Value.ToString().Trim();
                DataGridViewCell cell = row.Cells["Statut"];

                cell.Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (statut == AppStatus.ReparationMaintenanceText)
                {
                    cell.Style.BackColor = Color.FromArgb(252, 220, 220);
                    cell.Style.ForeColor = Color.FromArgb(200, 55, 55);
                    cell.Style.SelectionBackColor = Color.FromArgb(245, 205, 205);
                    cell.Style.SelectionForeColor = Color.FromArgb(200, 55, 55);
                }
                else if (statut == AppStatus.ReparationTermineeText)
                {
                    cell.Style.BackColor = Color.FromArgb(220, 245, 228);
                    cell.Style.ForeColor = Color.FromArgb(28, 137, 74);
                    cell.Style.SelectionBackColor = Color.FromArgb(200, 235, 214);
                    cell.Style.SelectionForeColor = Color.FromArgb(28, 137, 74);
                }
            }
        }
        private void ChargerReparations()
        {
            try
            {
                string query = @"
                            SELECT 
                                reparation_id AS 'ID',
                                voiture_id AS 'Voiture ID',
                                type_operation AS 'Type opération',
                                description AS 'Description',
                                montant AS 'Montant',
                                DATE_FORMAT(date_operation, '%d/%m/%Y') AS 'Date opération',
                                CASE 
                                    WHEN status = b'1' THEN @maintenance_text
                                    ELSE @terminee_text
                                END AS 'Statut',
                                nom_utilisateur AS 'Utilisateur',
                                DATE_FORMAT(created_at, '%d/%m/%Y %H:%i:%s') AS 'Créé le'
                            FROM reparations
                            ORDER BY reparation_id DESC
                            LIMIT 300;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@maintenance_text", AppStatus.ReparationMaintenanceText),
                    new MySqlParameter("@terminee_text", AppStatus.ReparationTermineeText)
                };

                dgvReparations.DataSource = Dbexec.GetData(query, ps);

                GridStyleHelper_1.Apply(dgvReparations);

                if (dgvReparations.Columns.Count > 0)
                {
                    dgvReparations.Columns["ID"].FillWeight = 10;
                    dgvReparations.Columns["Voiture ID"].FillWeight = 16;
                    dgvReparations.Columns["Type opération"].FillWeight = 20;
                    dgvReparations.Columns["Description"].FillWeight = 32;
                    dgvReparations.Columns["Montant"].FillWeight = 14;
                    dgvReparations.Columns["Date opération"].FillWeight = 16;
                    dgvReparations.Columns["Statut"].FillWeight = 14;
                    dgvReparations.Columns["Utilisateur"].FillWeight = 14;
                    dgvReparations.Columns["Créé le"].FillWeight = 20;

                    GridStyleHelper_1.AlignLeft(dgvReparations, "Description");
                    GridStyleHelper_1.AlignLeft(dgvReparations, "Type opération");
                }

                ColorierStatutReparations();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reparation", "ChargerReparations");
                MessageBox.Show("Erreur chargement réparations : " + ex.Message);
            }
        }


        private void ViderChamps()
        {
            reparationIdSelectionnee = -1;
            voitureIdSelectionnee = -1;
            cbVoiture.SelectedIndex = -1;
            cbTypeOperation.SelectedIndex = -1;
            txtDescription.Clear();
            txtMontant.Clear();
            dtDateOperation.Value = DateTime.Now;
        }
        private void ChargerTypesOperation()
        {
            cbTypeOperation.Items.Clear();
            cbTypeOperation.Items.Add("Vidange");
            cbTypeOperation.Items.Add("Changement freins");
            cbTypeOperation.Items.Add("Révision");
            cbTypeOperation.Items.Add("Diagnostic moteur");
            cbTypeOperation.Items.Add("Pneus");
            cbTypeOperation.Items.Add("Batterie");
            cbTypeOperation.Items.Add("Suspension");
            cbTypeOperation.Items.Add("Autre");
            cbTypeOperation.SelectedIndex = -1;
        }
        private bool ChampsValides()
        {
            if (cbVoiture.SelectedIndex == -1)
            {
                MessageBox.Show("Sélectionnez un véhicule.");
                cbVoiture.Focus();
                return false;
            }

            if (cbTypeOperation.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cbTypeOperation.Text))
            {
                MessageBox.Show("Sélectionnez le type d'opération.");
                cbTypeOperation.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Saisissez la description.");
                txtDescription.Focus();
                return false;
            }

            if (!decimal.TryParse(txtMontant.Text.Trim(), out decimal montant) || montant < 0)
            {
                MessageBox.Show("Montant invalide.");
                txtMontant.Focus();
                return false;
            }

            return true;
        }
        private void reparation_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                ChargerVoitures();
                ChargerReparations();
                ChargerTypesOperation();
                dtDateOperation.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reparation", "reparation_Load");
                MessageBox.Show("Erreur chargement formulaire : " + ex.Message);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {

            if (!ChampsValides())
                return;

            try
            {
                string query = @"
                    INSERT INTO reparations
                    (voiture_id, type_operation, description, montant, date_operation, status, nom_utilisateur, created_at)
                    VALUES
                    (@voiture_id, @type_operation, @description, @montant, @date_operation, @status, @nom_utilisateur, NOW())";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@voiture_id", cbVoiture.SelectedValue),
                    new MySqlParameter("@type_operation", cbTypeOperation.Text.Trim()),
                    new MySqlParameter("@description", txtDescription.Text.Trim()),
                    new MySqlParameter("@montant", decimal.Parse(txtMontant.Text.Trim())),
                    new MySqlParameter("@date_operation", dtDateOperation.Value.Date),
                    new MySqlParameter("@status", AppStatus.ReparationMaintenance),
                    new MySqlParameter("@nom_utilisateur", Session.Username)
                };

                Dbexec.ExecuteQuery(query, ps);

                string queryVoiture = "UPDATE voitures SET etat = @etat WHERE voiture_id = @voiture_id";

                MySqlParameter[] psVoiture =
                {
                    new MySqlParameter("@etat", AppStatus.VoitureMaintenance),
                    new MySqlParameter("@voiture_id", cbVoiture.SelectedValue)
                };

                Dbexec.ExecuteQuery(queryVoiture, psVoiture);

                LogHelper.AddLog("Ajout réparation véhicule ID: " + cbVoiture.SelectedValue, Session.Username);
                MessageBox.Show("Réparation enregistrée avec succès.");

                ChargerReparations();
                ViderChamps();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reparation", "btnEnregistrer_Click");
                MessageBox.Show("Erreur enregistrement réparation : " + ex.Message);
            }

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (reparationIdSelectionnee <= 0)
            {
                MessageBox.Show("Sélectionnez une réparation.");
                return;
            }

            if (!ChampsValides())
                return;

            try
            {
                string query = @"
                        UPDATE reparations SET
                            voiture_id = @voiture_id,
                            type_operation = @type_operation,
                            description = @description,
                            montant = @montant,
                            date_operation = @date_operation,
                            nom_utilisateur = @nom_utilisateur
                        WHERE reparation_id = @reparation_id";
                 MySqlParameter[] ps =
                        {
                            new MySqlParameter("@voiture_id", cbVoiture.SelectedValue),
                            new MySqlParameter("@type_operation", cbTypeOperation.Text.Trim()),
                            new MySqlParameter("@description", txtDescription.Text.Trim()),
                            new MySqlParameter("@montant", decimal.Parse(txtMontant.Text.Trim())),
                            new MySqlParameter("@date_operation", dtDateOperation.Value.Date),
                            new MySqlParameter("@nom_utilisateur", Session.Username),
                            new MySqlParameter("@reparation_id", reparationIdSelectionnee)
                        };

                Dbexec.ExecuteQuery(query, ps);

                LogHelper.AddLog("Modification réparation ID: " + reparationIdSelectionnee, Session.Username);
                MessageBox.Show("Réparation modifiée avec succès.");
                ChargerReparations();
                ViderChamps();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reparation", "btnModifier_Click");
                MessageBox.Show("Erreur modification réparation : " + ex.Message);
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (reparationIdSelectionnee <= 0)
            {
                MessageBox.Show("Sélectionnez une réparation.");
                return;
            }

            if (MessageBox.Show("Voulez-vous vraiment supprimer cette réparation ?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string query = "DELETE FROM reparations WHERE reparation_id = @id";

                MySqlParameter[] ps =
                { new MySqlParameter("@id", reparationIdSelectionnee)};

                Dbexec.ExecuteQuery(query, ps);
                LogHelper.AddLog("Suppression réparation ID: " + reparationIdSelectionnee, Session.Username);
                MessageBox.Show("Réparation supprimée avec succès.");
                ChargerReparations();
                ViderChamps();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reparation", "btnSupprimer_Click");
                MessageBox.Show("Erreur suppression réparation : " + ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (reparationIdSelectionnee <= 0)
            {
                MessageBox.Show("Sélectionnez une réparation.");
                return;
            }

            try
            {
                string queryStatus = "UPDATE reparations SET status = 0 WHERE reparation_id = @id";
                MySqlParameter[] psStatus =
                {
                    new MySqlParameter("@id", reparationIdSelectionnee)
                };

                Dbexec.ExecuteQuery(queryStatus, psStatus);

                 string queryCheck = @"
                                SELECT COUNT(*) 
                                FROM reparations
                                WHERE voiture_id = @voiture_id
                                  AND status = @status
                                  AND reparation_id <> @reparation_id";

                 MySqlParameter[] psCheck =
                                                {
                                    new MySqlParameter("@voiture_id", voitureIdSelectionnee),
                                    new MySqlParameter("@status", AppStatus.ReparationMaintenance),
                                    new MySqlParameter("@reparation_id", reparationIdSelectionnee)
                                };

                int nbAutres = Dbexec.ExecuteScalarInt(queryCheck, psCheck);


                if (nbAutres == 0)
                {
                    string queryVoiture = "UPDATE voitures SET etat = @etat WHERE voiture_id = @voiture_id";

                    MySqlParameter[] psVoiture =
                    {
                        new MySqlParameter("@etat", AppStatus.VoitureDisponible),
                        new MySqlParameter("@voiture_id", voitureIdSelectionnee)
                    };

                    Dbexec.ExecuteQuery(queryVoiture, psVoiture);
                }

                LogHelper.AddLog("Réparation terminée ID: " + reparationIdSelectionnee, Session.Username);
                MessageBox.Show("Réparation terminée avec succès.");

                ChargerReparations();
                ViderChamps();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reparation", "btnTerminer_Click");
                MessageBox.Show("Erreur fin réparation : " + ex.Message);
            }
        }

        private void dgvReparations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvReparations.Rows[e.RowIndex];

                reparationIdSelectionnee = Convert.ToInt32(row.Cells["ID"].Value);
                voitureIdSelectionnee = Convert.ToInt32(row.Cells["Voiture ID"].Value);

                cbVoiture.SelectedValue = row.Cells["Voiture ID"].Value;
                cbTypeOperation.Text = row.Cells["Type opération"].Value?.ToString();
                txtDescription.Text = row.Cells["Description"].Value?.ToString();
                txtMontant.Text = row.Cells["Montant"].Value?.ToString();

                if (row.Cells["Date opération"].Value != null)
                {
                    DateTime dt;
                    if (DateTime.TryParse(row.Cells["Date opération"].Value.ToString(), out dt))
                        dtDateOperation.Value = dt;
                }
            }
        }

        private void txtMontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                e.Handled = true;

            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (txtMontant.Text.Contains(",") || txtMontant.Text.Contains(".")))
                e.Handled = true;
        }
    }
}
