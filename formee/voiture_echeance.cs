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
    public partial class voiture_echeance : Form
    {
        private int voitureIdFiltre = 0;
        public voiture_echeance()
        {
            InitializeComponent();
        }
        public voiture_echeance(int voitureId)
        {
            InitializeComponent();
            voitureIdFiltre = voitureId;
        }

        private void cardInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void voiture_echeance_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                InitialiserTypesEcheance();
                InitialiserStatuts();
                ChargerVoitures();

                dtDateDebut.Format = DateTimePickerFormat.Short;
                dtDateFin.Format = DateTimePickerFormat.Short;

                if (voitureIdFiltre > 0)
                {
                    cbVoiture.SelectedValue = voitureIdFiltre;
                    cbVoiture.Enabled = false;
                }

                ChargerEcheances();
                ViderChamps();

                if (voitureIdFiltre > 0)
                {
                    cbVoiture.SelectedValue = voitureIdFiltre;
                    cbVoiture.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture_echeance", "voiture_echeance_Load");
                MessageService.Error("Erreur chargement formulaire échéances.");
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!ChampsValides())
                return;

            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    using (MySqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            decimal? montant = LireMontant();

                            long newEcheanceId = 0;

                            string queryEcheance = @"
                                        INSERT INTO voiture_echeances
                                        (voiture_id, type_echeance, numero_document, date_debut, date_fin, montant, remarque, statut)
                                        VALUES
                                        (@voiture_id, @type_echeance, @numero_document, @date_debut, @date_fin, @montant, @remarque, @statut);";

                            using (MySqlCommand cmd = new MySqlCommand(queryEcheance, cn, tr))
                            {
                                cmd.Parameters.AddWithValue("@voiture_id", cbVoiture.SelectedValue);
                                cmd.Parameters.AddWithValue("@type_echeance", GetTypeEcheanceValue());
                                cmd.Parameters.AddWithValue("@numero_document", txtNumeroDocument.Text.Trim());
                                cmd.Parameters.AddWithValue("@date_debut", dtDateDebut.Value.Date);
                                cmd.Parameters.AddWithValue("@date_fin", dtDateFin.Value.Date);
                                cmd.Parameters.AddWithValue("@montant", montant.HasValue ? (object)montant.Value : DBNull.Value);
                                cmd.Parameters.AddWithValue("@remarque", string.IsNullOrWhiteSpace(txtRemarque.Text) ? (object)DBNull.Value : txtRemarque.Text.Trim());
                                cmd.Parameters.AddWithValue("@statut", string.IsNullOrWhiteSpace(cbStatut.Text) ? CalculerStatutAuto() : GetStatutValue());

                                cmd.ExecuteNonQuery();
                                newEcheanceId = cmd.LastInsertedId;
                            }

                            if (montant.HasValue && montant.Value > 0)
                            {
                                string typeDepense = "Échéance - " + cbTypeEcheance.Text;

                                string queryDepense = @"
                                        INSERT INTO depenses
                                        (type, montant, date_depense, echeance_id)
                                        VALUES
                                        (@type, @montant, NOW(), @echeance_id);";

                                using (MySqlCommand cmdDep = new MySqlCommand(queryDepense, cn, tr))
                                {
                                    cmdDep.Parameters.AddWithValue("@type", typeDepense);
                                    cmdDep.Parameters.AddWithValue("@montant", montant.Value);
                                    cmdDep.Parameters.AddWithValue("@echeance_id", newEcheanceId);

                                    cmdDep.ExecuteNonQuery();
                                }
                            }

                            tr.Commit();

                            LogHelper.AddLog("Ajout échéance véhicule : " + cbVoiture.Text + " - " + cbTypeEcheance.Text, Session.Username);
                            MessageService.Success("Échéance ajoutée avec succès.");

                            ChargerEcheances();
                            ViderChamps();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();

                            dbErreur.AddLog(ex.Message, Session.Username, "voiture_echeance", "btnAjouter_Click_Transaction");
                            MessageService.Error("Erreur lors de l'ajout de l'échéance.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture_echeance", "btnAjouter_Click");
                MessageService.Error("Erreur connexion base de données.");
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (echeanceIdSelectionne <= 0)
            {
                MessageService.Warning("Sélectionnez une échéance.");
                return;
            }

            if (!ChampsValides())
                return;

            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    using (MySqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            decimal? nouveauMontant = LireMontant();

                            string queryEcheance = @"
                                    UPDATE voiture_echeances SET
                                        voiture_id = @voiture_id,
                                        type_echeance = @type_echeance,
                                        numero_document = @numero_document,
                                        date_debut = @date_debut,
                                        date_fin = @date_fin,
                                        montant = @montant,
                                        remarque = @remarque,
                                        statut = @statut
                                    WHERE echeance_id = @echeance_id;";

                            using (MySqlCommand cmd = new MySqlCommand(queryEcheance, cn, tr))
                            {
                                cmd.Parameters.AddWithValue("@voiture_id", cbVoiture.SelectedValue);
                                cmd.Parameters.AddWithValue("@type_echeance", GetTypeEcheanceValue());
                                cmd.Parameters.AddWithValue("@numero_document", txtNumeroDocument.Text.Trim());
                                cmd.Parameters.AddWithValue("@date_debut", dtDateDebut.Value.Date);
                                cmd.Parameters.AddWithValue("@date_fin", dtDateFin.Value.Date);
                                cmd.Parameters.AddWithValue("@montant", nouveauMontant.HasValue ? (object)nouveauMontant.Value : DBNull.Value);
                                cmd.Parameters.AddWithValue("@remarque", string.IsNullOrWhiteSpace(txtRemarque.Text) ? (object)DBNull.Value : txtRemarque.Text.Trim());
                                cmd.Parameters.AddWithValue("@statut", string.IsNullOrWhiteSpace(cbStatut.Text) ? CalculerStatutAuto() : GetStatutValue());
                                cmd.Parameters.AddWithValue("@echeance_id", echeanceIdSelectionne);

                                cmd.ExecuteNonQuery();
                            }

                            int depenseExiste = 0;

                            string queryCheckDepense = @"
                                    SELECT COUNT(*)
                                    FROM depenses
                                    WHERE echeance_id = @echeance_id;";

                            using (MySqlCommand cmdCheck = new MySqlCommand(queryCheckDepense, cn, tr))
                            {
                                cmdCheck.Parameters.AddWithValue("@echeance_id", echeanceIdSelectionne);
                                depenseExiste = Convert.ToInt32(cmdCheck.ExecuteScalar());
                            }

                            if (nouveauMontant.HasValue && nouveauMontant.Value > 0)
                            {
                                string typeDepense = "Échéance - " + cbTypeEcheance.Text;

                                if (depenseExiste > 0)
                                {
                                    string queryUpdateDepense = @"
                                            UPDATE depenses
                                            SET type = @type,
                                                montant = @montant,
                                                date_depense = NOW()
                                            WHERE echeance_id = @echeance_id;";

                                    using (MySqlCommand cmdDep = new MySqlCommand(queryUpdateDepense, cn, tr))
                                    {
                                        cmdDep.Parameters.AddWithValue("@type", typeDepense);
                                        cmdDep.Parameters.AddWithValue("@montant", nouveauMontant.Value);
                                        cmdDep.Parameters.AddWithValue("@echeance_id", echeanceIdSelectionne);

                                        cmdDep.ExecuteNonQuery();
                                    }
                                }
                                else
                                {
                                    string queryInsertDepense = @"
                                            INSERT INTO depenses
                                            (type, montant, date_depense, echeance_id)
                                            VALUES
                                            (@type, @montant, NOW(), @echeance_id);";

                                    using (MySqlCommand cmdDep = new MySqlCommand(queryInsertDepense, cn, tr))
                                    {
                                        cmdDep.Parameters.AddWithValue("@type", typeDepense);
                                        cmdDep.Parameters.AddWithValue("@montant", nouveauMontant.Value);
                                        cmdDep.Parameters.AddWithValue("@echeance_id", echeanceIdSelectionne);

                                        cmdDep.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                if (depenseExiste > 0)
                                {
                                    string queryDeleteDepense = @"
                                            DELETE FROM depenses
                                            WHERE echeance_id = @echeance_id;";

                                    using (MySqlCommand cmdDep = new MySqlCommand(queryDeleteDepense, cn, tr))
                                    {
                                        cmdDep.Parameters.AddWithValue("@echeance_id", echeanceIdSelectionne);
                                        cmdDep.ExecuteNonQuery();
                                    }
                                }
                            }

                            tr.Commit();

                            LogHelper.AddLog("Modification échéance ID: " + echeanceIdSelectionne, Session.Username);
                            MessageService.Success("Échéance modifiée avec succès.");

                            ChargerEcheances();
                            ViderChamps();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            dbErreur.AddLog(ex.Message, Session.Username, "voiture_echeance", "btnModifier_Click_Transaction");
                            MessageService.Error("Erreur lors de la modification.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture_echeance", "btnModifier_Click");
                MessageService.Error("Erreur connexion base de données.");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (echeanceIdSelectionne <= 0)
            {
                MessageService.Warning("Sélectionnez une échéance.");
                return;
            }

            if (MessageService.Confirm("Voulez-vous vraiment supprimer cette échéance ?") != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    using (MySqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            string deleteDepense = @"
                                    DELETE FROM depenses
                                    WHERE echeance_id = @echeance_id;";

                            using (MySqlCommand cmdDep = new MySqlCommand(deleteDepense, cn, tr))
                            {
                                cmdDep.Parameters.AddWithValue("@echeance_id", echeanceIdSelectionne);
                                cmdDep.ExecuteNonQuery();
                            }

                            string deleteEcheance = @"
                                    DELETE FROM voiture_echeances
                                    WHERE echeance_id = @echeance_id;";

                            using (MySqlCommand cmd = new MySqlCommand(deleteEcheance, cn, tr))
                            {
                                cmd.Parameters.AddWithValue("@echeance_id", echeanceIdSelectionne);
                                cmd.ExecuteNonQuery();
                            }

                            tr.Commit();

                            LogHelper.AddLog("Suppression échéance ID: " + echeanceIdSelectionne, Session.Username);
                            MessageService.Success("Échéance supprimée avec succès.");

                            ChargerEcheances();
                            ViderChamps();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            dbErreur.AddLog(ex.Message, Session.Username, "voiture_echeance", "btnSupprimer_Click_Transaction");
                            MessageService.Error("Erreur lors de la suppression.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture_echeance", "btnSupprimer_Click");
                MessageService.Error("Erreur connexion base de données.");
            }
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ViderChamps();
        }


        private void InitialiserTypesEcheance()
        {
            cbTypeEcheance.Items.Clear();
            cbTypeEcheance.Items.Add("Assurance");
            cbTypeEcheance.Items.Add("Visite technique");
            cbTypeEcheance.Items.Add("Vignette");
            cbTypeEcheance.SelectedIndex = -1;
        }

        private void InitialiserStatuts()
        {
            cbStatut.Items.Clear();
            cbStatut.Items.Add("Active");
            cbStatut.Items.Add("Expirée");
            cbStatut.Items.Add("À renouveler");
            cbStatut.SelectedIndex = -1;
        }

        private string GetTypeEcheanceValue()
        {
            if (cbTypeEcheance.Text == "Assurance")
                return "assurance";

            if (cbTypeEcheance.Text == "Visite technique")
                return "visite_technique";

            if (cbTypeEcheance.Text == "Vignette")
                return "vignette";

            return "assurance";
        }

        private void SetTypeEcheanceText(string value)
        {
            if (value == "assurance")
                cbTypeEcheance.Text = "Assurance";
            else if (value == "visite_technique")
                cbTypeEcheance.Text = "Visite technique";
            else if (value == "vignette")
                cbTypeEcheance.Text = "Vignette";
            else
                cbTypeEcheance.SelectedIndex = -1;
        }

        private string GetStatutValue()
        {
            if (cbStatut.Text == "Active")
                return "active";

            if (cbStatut.Text == "Expirée")
                return "expiree";

            if (cbStatut.Text == "À renouveler")
                return "a_renouveler";

            return CalculerStatutAuto();
        }

        private void SetStatutText(string value)
        {
            if (value == "active")
                cbStatut.Text = "Active";
            else if (value == "expiree")
                cbStatut.Text = "Expirée";
            else if (value == "a_renouveler")
                cbStatut.Text = "À renouveler";
            else
                cbStatut.SelectedIndex = -1;
        }

        private string CalculerStatutAuto()
        {
            if (dtDateFin.Value.Date < DateTime.Today)
                return "expiree";

            if (dtDateFin.Value.Date <= DateTime.Today.AddDays(30))
                return "a_renouveler";

            return "active";
        }

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
                dbErreur.AddLog(ex.Message, Session.Username, "voiture_echeance", "ChargerVoitures");
                MessageService.Error("Erreur chargement voitures.");
            }
        }

        private void ChargerEcheances()
        {
            try
            {
                string query = @"
        SELECT 
            e.echeance_id AS 'ID',
            e.voiture_id AS 'Voiture ID',
            CONCAT(v.matricule, ' - ', v.marque, ' ', v.modele) AS 'Véhicule',
            e.type_echeance AS 'TypeValue',
            CASE
                WHEN e.type_echeance = 'assurance' THEN 'Assurance'
                WHEN e.type_echeance = 'visite_technique' THEN 'Visite technique'
                WHEN e.type_echeance = 'vignette' THEN 'Vignette'
                ELSE e.type_echeance
            END AS 'Type',
            e.numero_document AS 'Document',
            DATE_FORMAT(e.date_debut, '%d/%m/%Y') AS 'Début',
            DATE_FORMAT(e.date_fin, '%d/%m/%Y') AS 'Fin',
            DATEDIFF(e.date_fin, CURDATE()) AS 'Jours',
            e.montant AS 'Montant',
            e.remarque AS 'Remarque',
            e.statut AS 'StatutValue',
            CASE
                WHEN e.statut = 'active' THEN 'Active'
                WHEN e.statut = 'expiree' THEN 'Expirée'
                WHEN e.statut = 'a_renouveler' THEN 'À renouveler'
                ELSE e.statut
            END AS 'Statut',
            DATE_FORMAT(e.created_at, '%d/%m/%Y %H:%i:%s') AS 'Créé le'
        FROM voiture_echeances e
        INNER JOIN voitures v ON v.voiture_id = e.voiture_id
        WHERE (@voiture_id = 0 OR e.voiture_id = @voiture_id)
        ORDER BY e.date_fin ASC, e.echeance_id DESC
        LIMIT 300;";

                MySqlParameter[] ps =
                {
            new MySqlParameter("@voiture_id", voitureIdFiltre)
        };

                dgvEcheances.DataSource = Dbexec.GetData(query, ps);

                GridStyleHelper_1.Apply(dgvEcheances);

                if (dgvEcheances.Columns.Count > 0)
                {
                    GridStyleHelper_1.HideColumn(dgvEcheances, "Voiture ID");
                    GridStyleHelper_1.HideColumn(dgvEcheances, "TypeValue");
                    GridStyleHelper_1.HideColumn(dgvEcheances, "StatutValue");
                    GridStyleHelper_1.HideColumn(dgvEcheances, "Remarque");
                    GridStyleHelper_1.HideColumn(dgvEcheances, "Créé le");

                    dgvEcheances.Columns["ID"].FillWeight = 7;
                    dgvEcheances.Columns["Véhicule"].FillWeight = 30;
                    dgvEcheances.Columns["Type"].FillWeight = 18;
                    dgvEcheances.Columns["Document"].FillWeight = 18;
                    dgvEcheances.Columns["Début"].FillWeight = 14;
                    dgvEcheances.Columns["Fin"].FillWeight = 14;
                    dgvEcheances.Columns["Jours"].FillWeight = 10;
                    dgvEcheances.Columns["Montant"].FillWeight = 13;
                    dgvEcheances.Columns["Statut"].FillWeight = 16;

                    GridStyleHelper_1.AlignLeft(dgvEcheances, "Véhicule");

                    dgvEcheances.Columns["Type"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvEcheances.Columns["Document"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvEcheances.Columns["Début"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvEcheances.Columns["Fin"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvEcheances.Columns["Jours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvEcheances.Columns["Montant"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvEcheances.Columns["Statut"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                ColorierStatutEcheances();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture_echeance", "ChargerEcheances");
                MessageService.Error("Erreur chargement échéances.");
            }
        }
        private void ColorierStatutEcheances()
        {
            if (!dgvEcheances.Columns.Contains("Statut"))
                return;

            foreach (DataGridViewRow row in dgvEcheances.Rows)
            {
                if (row.IsNewRow || row.Cells["Statut"].Value == null)
                    continue;

                string statut = row.Cells["Statut"].Value.ToString();
                DataGridViewCell cell = row.Cells["Statut"];

                cell.Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (statut == "Expirée")
                {
                    cell.Style.BackColor = Color.FromArgb(252, 220, 220);
                    cell.Style.ForeColor = Color.FromArgb(200, 55, 55);
                    cell.Style.SelectionBackColor = Color.FromArgb(245, 205, 205);
                    cell.Style.SelectionForeColor = Color.FromArgb(200, 55, 55);
                }
                else if (statut == "À renouveler")
                {
                    cell.Style.BackColor = Color.FromArgb(255, 239, 213);
                    cell.Style.ForeColor = Color.FromArgb(212, 133, 0);
                    cell.Style.SelectionBackColor = Color.FromArgb(250, 228, 190);
                    cell.Style.SelectionForeColor = Color.FromArgb(212, 133, 0);
                }
                else if (statut == "Active")
                {
                    cell.Style.BackColor = Color.FromArgb(220, 245, 228);
                    cell.Style.ForeColor = Color.FromArgb(28, 137, 74);
                    cell.Style.SelectionBackColor = Color.FromArgb(200, 235, 214);
                    cell.Style.SelectionForeColor = Color.FromArgb(28, 137, 74);
                }
            }
        }

        private bool ChampsValides()
        {
            if (cbVoiture.SelectedIndex == -1)
            {
                MessageService.Warning("Sélectionnez un véhicule.");
                cbVoiture.Focus();
                return false;
            }

            if (cbTypeEcheance.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cbTypeEcheance.Text))
            {
                MessageService.Warning("Sélectionnez le type d'échéance.");
                cbTypeEcheance.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNumeroDocument.Text))
            {
                MessageService.Warning("Saisissez le numéro du document.");
                txtNumeroDocument.Focus();
                return false;
            }

            if (dtDateFin.Value.Date < dtDateDebut.Value.Date)
            {
                MessageService.Warning("La date fin doit être supérieure ou égale à la date début.");
                dtDateFin.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtMontant.Text))
            {
                if (!decimal.TryParse(txtMontant.Text.Trim(), out decimal montant) || montant < 0)
                {
                    MessageService.Warning("Montant invalide.");
                    txtMontant.Focus();
                    return false;
                }
            }

            return true;
        }
        private int echeanceIdSelectionne = -1;
        private decimal? LireMontant()
        {
            if (string.IsNullOrWhiteSpace(txtMontant.Text))
                return null;

            return decimal.Parse(txtMontant.Text.Trim());
        }

        private void ViderChamps()
        {
            echeanceIdSelectionne = -1;

            if (voitureIdFiltre > 0)
            {
                cbVoiture.SelectedValue = voitureIdFiltre;
                cbVoiture.Enabled = false;
            }
            else
            {
                cbVoiture.SelectedIndex = -1;
                cbVoiture.Enabled = true;
            }

            cbTypeEcheance.SelectedIndex = -1;
            cbStatut.SelectedIndex = -1;

            txtNumeroDocument.Clear();
            txtMontant.Clear();
            txtRemarque.Clear();

            dtDateDebut.Value = DateTime.Today;
            dtDateFin.Value = DateTime.Today;

            cbTypeEcheance.Focus();
        }

        private void dgvEcheances_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvEcheances.Rows[e.RowIndex];

            echeanceIdSelectionne = Convert.ToInt32(row.Cells["ID"].Value);

            cbVoiture.SelectedValue = Convert.ToInt32(row.Cells["Voiture ID"].Value);

            SetTypeEcheanceText(row.Cells["TypeValue"].Value?.ToString());
            txtNumeroDocument.Text = row.Cells["N° Document"].Value?.ToString();

            DateTime dateDebut;
            if (DateTime.TryParse(row.Cells["Date début"].Value?.ToString(), out dateDebut))
                dtDateDebut.Value = dateDebut;

            DateTime dateFin;
            if (DateTime.TryParse(row.Cells["Date fin"].Value?.ToString(), out dateFin))
                dtDateFin.Value = dateFin;

            txtMontant.Text = row.Cells["Montant"].Value?.ToString();
            txtRemarque.Text = row.Cells["Remarque"].Value?.ToString();

            SetStatutText(row.Cells["StatutValue"].Value?.ToString());
        }

        private void txtMontant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
               !char.IsDigit(e.KeyChar) &&
               e.KeyChar != ',' &&
               e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (txtMontant.Text.Contains(",") || txtMontant.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }
    }
}
