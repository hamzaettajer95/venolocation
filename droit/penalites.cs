using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using venolocation.classee;
using MySqlConnector;

namespace venolocation.droit
{
    public partial class penalites : Form
    {
     
            private int selectedPenaliteId = -1;
            private int selectedContratId = -1;
            private decimal selectedReste = 0m;
            private string selectedTypePenalite = "";

            public penalites()
            {
                InitializeComponent();

                cbModePaiement.Items.Clear();
                cbModePaiement.Items.Add("Cash");
                cbModePaiement.Items.Add("Carte");
                cbModePaiement.Items.Add("Virement");
                cbModePaiement.Items.Add("Chèque");
                cbModePaiement.SelectedIndex = 0;

                chkSeulementNon.Checked = true;

                lblTotalReste.Text = "Total reste : 0.00 DH";
                lblSelection.Text = "Aucune pénalité sélectionnée";

                ChargerPenalites();
            }

            private decimal LireMontant(string texte)
            {
                if (string.IsNullOrWhiteSpace(texte))
                    return 0m;

                texte = texte.Trim().Replace(" ", "").Replace(",", ".");

                decimal montant;

                if (!decimal.TryParse(
                    texte,
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out montant))
                {
                    throw new Exception("Montant invalide : " + texte);
                }

                if (montant < 0)
                    throw new Exception("Le montant ne peut pas être négatif.");

                return montant;
            }

            private void ChargerPenalites()
            {
                try
                {
                    selectedPenaliteId = -1;
                    selectedContratId = -1;
                    selectedReste = 0m;
                    selectedTypePenalite = "";
                    txtMontantPaye.Clear();
                    lblSelection.Text = "Aucune pénalité sélectionnée";

                    string recherche = txtRecherche.Text.Trim();

                string sql = @"
                                SELECT
                                    p.penalite_id AS Id,
                                    p.contrat_id AS Contrat,
                                    CONCAT(IFNULL(cl.nom,''), ' ', IFNULL(cl.prenom,'')) AS Client,
                                    cl.telephone AS Telephone,
                                    CONCAT(IFNULL(v.marque,''), ' ', IFNULL(v.modele,''), ' - ', IFNULL(v.matricule,'')) AS Voiture,
                                    p.type_penalite AS Type,
                                    IFNULL(p.montant, 0) AS Montant,
                                    IFNULL(p.montant_paye, 0) AS Paye,
                                    (IFNULL(p.montant, 0) - IFNULL(p.montant_paye, 0)) AS Reste,
                                    CASE
                                        WHEN (IFNULL(p.montant, 0) - IFNULL(p.montant_paye, 0)) <= 0 THEN 'Payée'
                                        ELSE 'Non payée'
                                    END AS Statut,
                                    p.description AS Description,
                                    p.created_at AS DateCreation
                                FROM contrat_penalites p
                                INNER JOIN contrats c ON c.contrat_id = p.contrat_id
                                LEFT JOIN clients cl ON cl.client_id = c.client_id
                                LEFT JOIN voitures v ON v.voiture_id = c.voiture_id
                                WHERE
                                    (@only_unpaid = 0 OR (IFNULL(p.montant, 0) - IFNULL(p.montant_paye, 0)) > 0)
                                    AND
                                    (
                                        @search = ''
                                        OR CAST(p.contrat_id AS CHAR) LIKE @like_search
                                        OR cl.nom LIKE @like_search
                                        OR cl.prenom LIKE @like_search
                                        OR cl.cin LIKE @like_search
                                        OR cl.telephone LIKE @like_search
                                        OR v.matricule LIKE @like_search
                                        OR p.type_penalite LIKE @like_search
                                    )
                                ORDER BY p.created_at DESC, p.penalite_id DESC;";

                DataTable dt = new DataTable();

                    using (MySqlConnection cn = Dbexec.GetConnection())
                    {
                        cn.Open();

                        using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                        {
                            cmd.Parameters.AddWithValue("@only_unpaid", chkSeulementNon.Checked ? 1 : 0);
                            cmd.Parameters.AddWithValue("@search", recherche);
                            cmd.Parameters.AddWithValue("@like_search", "%" + recherche + "%");

                            using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                            {
                                da.Fill(dt);
                            }
                        }
                    }

                    dgvPenalites.DataSource = dt;

                    FormaterGrid();
                    CalculerTotalReste(dt);
                }
                catch (Exception ex)
                {
                    ErrorReporter.SendError(ex, "penalites", "ChargerPenalites");
                    dbErreur.AddLog(ex.Message, Session.Username, "penalites", "ChargerPenalites");

                    MessageBox.Show(
                        "Erreur chargement pénalités : " + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

            private void FormaterGrid()
            {
                if (dgvPenalites.Columns.Count == 0)
                    return;

                dgvPenalites.ReadOnly = true;
                dgvPenalites.AllowUserToAddRows = false;
                dgvPenalites.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvPenalites.MultiSelect = false;
                dgvPenalites.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvPenalites.Columns.Contains("Id"))
                    dgvPenalites.Columns["Id"].Visible = false;

                if (dgvPenalites.Columns.Contains("Montant"))
                    dgvPenalites.Columns["Montant"].DefaultCellStyle.Format = "N2";

                if (dgvPenalites.Columns.Contains("Paye"))
                    dgvPenalites.Columns["Paye"].DefaultCellStyle.Format = "N2";

                if (dgvPenalites.Columns.Contains("Reste"))
                    dgvPenalites.Columns["Reste"].DefaultCellStyle.Format = "N2";

                if (dgvPenalites.Columns.Contains("DateCreation"))
                    dgvPenalites.Columns["DateCreation"].HeaderText = "Date";

                if (dgvPenalites.Columns.Contains("Paye"))
                    dgvPenalites.Columns["Paye"].HeaderText = "Payé";

            GridStyleHelper_1.Apply(dgvPenalites);
        }

            private void CalculerTotalReste(DataTable dt)
            {
                decimal total = 0m;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["Reste"] != DBNull.Value)
                        total += Convert.ToDecimal(row["Reste"]);
                }

                lblTotalReste.Text = "Total reste : " + total.ToString("0.00") + " DH";
            }

            private void SelectionnerPenalite()
            {
                if (dgvPenalites.CurrentRow == null)
                    return;

                DataGridViewRow row = dgvPenalites.CurrentRow;

                if (row.Cells["Id"].Value == null || row.Cells["Id"].Value == DBNull.Value)
                    return;

                selectedPenaliteId = Convert.ToInt32(row.Cells["Id"].Value);
                selectedContratId = Convert.ToInt32(row.Cells["Contrat"].Value);
                selectedTypePenalite = Convert.ToString(row.Cells["Type"].Value);

                selectedReste = row.Cells["Reste"].Value == DBNull.Value
                    ? 0m
                    : Convert.ToDecimal(row.Cells["Reste"].Value);

                txtMontantPaye.Text = selectedReste.ToString("0.00");

                lblSelection.Text =
                    "Contrat N° " + selectedContratId +
                    " | Type : " + selectedTypePenalite +
                    " | Reste : " + selectedReste.ToString("0.00") + " DH";
            }

            private void PayerPenaliteSelectionnee(decimal montantAPayer)
            {
                if (selectedPenaliteId <= 0)
                {
                    MessageBox.Show(
                        "Sélectionnez une pénalité.",
                        "Attention",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (montantAPayer <= 0)
                {
                    MessageBox.Show(
                        "Montant payé doit être supérieur à 0.",
                        "Attention",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (MySqlConnection cn = Dbexec.GetConnection())
                    {
                        cn.Open();

                        using (MySqlTransaction tr = cn.BeginTransaction())
                        {
                            try
                            {
                                int contratId = 0;
                                string typePenalite = "";
                                decimal montant = 0m;
                                decimal montantPayeActuel = 0m;
                                decimal reste = 0m;

                                string selectSql = @"
                                SELECT contrat_id, type_penalite, montant, montant_paye
                                FROM contrat_penalites
                                WHERE penalite_id = @penalite_id
                                FOR UPDATE;";

                                using (MySqlCommand cmd = new MySqlCommand(selectSql, cn, tr))
                                {
                                    cmd.Parameters.AddWithValue("@penalite_id", selectedPenaliteId);

                                    using (MySqlDataReader dr = cmd.ExecuteReader())
                                    {
                                        if (!dr.Read())
                                            throw new Exception("Pénalité introuvable.");

                                        contratId = Convert.ToInt32(dr["contrat_id"]);
                                        typePenalite = Convert.ToString(dr["type_penalite"]);
                                        montant = Convert.ToDecimal(dr["montant"]);
                                        montantPayeActuel = Convert.ToDecimal(dr["montant_paye"]);
                                    }
                                }

                                reste = montant - montantPayeActuel;

                                if (reste <= 0)
                                {
                                    tr.Rollback();

                                    MessageBox.Show(
                                        "Cette pénalité est déjà payée.",
                                        "Information",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                    return;
                                }

                                if (montantAPayer > reste)
                                {
                                    MessageBox.Show(
                                        "Montant payé supérieur au reste.\nReste : " + reste.ToString("0.00") + " DH",
                                        "Attention",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                                    return;
                                }

                                string updateSql = @"
                                UPDATE contrat_penalites
                                SET montant_paye = montant_paye + @montant_paye
                                WHERE penalite_id = @penalite_id;";

                                using (MySqlCommand cmd = new MySqlCommand(updateSql, cn, tr))
                                {
                                    cmd.Parameters.AddWithValue("@montant_paye", montantAPayer);
                                    cmd.Parameters.AddWithValue("@penalite_id", selectedPenaliteId);
                                    cmd.ExecuteNonQuery();
                                }

                                string modePaiement = cbModePaiement.Text.Trim();
                                if (string.IsNullOrWhiteSpace(modePaiement))
                                    modePaiement = "Cash";

                                PaymentService.AjouterPaiementContrat(
                                    cn,
                                    tr,
                                    contratId,
                                    montantAPayer,
                                    "Pénalité",
                                    modePaiement,
                                    typePenalite,
                                    Session.Username
                                );

                                tr.Commit();

                                MessageBox.Show(
                                    "Paiement enregistré avec succès.\n" +
                                    "Type : " + typePenalite + "\n" +
                                    "Montant payé : " + montantAPayer.ToString("0.00") + " DH",
                                    "Succès",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                ChargerPenalites();
                            }
                            catch (Exception ex)
                            {
                                tr.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorReporter.SendError(ex, "penalites", "PayerPenaliteSelectionnee");
                    dbErreur.AddLog(ex.Message, Session.Username, "penalites", "PayerPenaliteSelectionnee");

                    MessageBox.Show(
                        "Erreur paiement pénalité : " + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

           


    
        private void penalites_Load(object sender, EventArgs e)
        {

        }

        private void btnCharger_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            ChargerPenalites();
        }

        private void btnPayer_Click(object sender, EventArgs e)
        {
            decimal montantAPayer;

            try
            {
                montantAPayer = LireMontant(txtMontantPaye.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Montant invalide",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            PayerPenaliteSelectionnee(montantAPayer);
        }

        private void btnPayerTout_Click(object sender, EventArgs e)
        {
            if (selectedPenaliteId <= 0)
            {
                MessageBox.Show(
                    "Sélectionnez une pénalité.",
                    "Attention",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (selectedReste <= 0)
            {
                MessageBox.Show(
                    "Cette pénalité est déjà payée.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            txtMontantPaye.Text = selectedReste.ToString("0.00");
            PayerPenaliteSelectionnee(selectedReste);
        }

        private void dgvPenalites_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                SelectionnerPenalite();
        }

        private void chkSeulementNon_CheckedChanged(object sender, EventArgs e)
        {
            ChargerPenalites();
        }
    }
}
