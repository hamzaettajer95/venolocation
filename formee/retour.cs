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

using MySqlConnector;

using venolocation.classee;

namespace venolocation.formee
{
    public partial class retour : Form
    {
        public retour()
        {
            InitializeComponent();
        }

        private const int KmAutoriseParJour = 300;
        private const decimal PrixKmSupplementaire = 1m;
        private int contratId = -1;
        private int voitureId = -1;
        private int kilometrageSortie = 0;


        private void retour_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                ChargerVoituresEnLocation();

                txtInfoContrat.ReadOnly = true;
                txtInfoContrat.Clear();

                txtDescriptionAccident.Clear();
                txtMontantReparation.Clear();
                txtKilometrageRetour.Clear();

                btnRetourSimple.Enabled = false;
                btnAccident.Enabled = false;
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "retour", "retour_Load");
                dbErreur.AddLog(ex.Message, Session.Username, "retour", "retour_Load");
                MessageBox.Show("Erreur chargement formulaire : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.ResumeLayout();
            }
        }
        private void ChargerVoituresEnLocation()
        {
            try
            {
                string query = @"
                                SELECT DISTINCT 
                                    v.voiture_id,
                                    CONCAT(v.matricule, ' - ', v.marque, ' ', v.modele) AS voiture
                                FROM contrats c
                                INNER JOIN voitures v ON v.voiture_id = c.voiture_id
                                WHERE c.status <> @status_termine
                                ORDER BY v.matricule
                                LIMIT 500;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@status_termine", AppStatus.ContratTermine)
                };

                DataTable dt = Dbexec.GetData(query, ps);

                cbVoiture.DataSource = dt;
                cbVoiture.DisplayMember = "voiture";
                cbVoiture.ValueMember = "voiture_id";
                cbVoiture.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "retour", "ChargerVoituresEnLocation");
                dbErreur.AddLog(ex.Message, Session.Username, "retour", "ChargerVoituresEnLocation");
                MessageBox.Show("Erreur chargement voitures : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cbVoiture.SelectedIndex == -1)
            {
                MessageBox.Show("Sélectionnez une voiture.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            voitureId = Convert.ToInt32(cbVoiture.SelectedValue);
            ChargerContratEnCours(voitureId);
        }

        private void btnRetourSimple_Click(object sender, EventArgs e)
        {

        }

        private void ReinitialiserForm()
        {
            contratId = -1;
            voitureId = -1;
            kilometrageSortie = 0;

            txtInfoContrat.Clear();
            txtKilometrageRetour.Clear();
            txtDescriptionAccident.Clear();
            txtMontantReparation.Clear();
            txtMontantpaye.Clear();

            btnRetourSimple.Enabled = false;
            btnAccident.Enabled = false;

            ChargerVoituresEnLocation();
            cbVoiture.SelectedIndex = -1;
        }

        private decimal AjouterKilometrageSupplementaireAutomatique(
    MySqlConnection cn,
    MySqlTransaction tr,
    int contratId,
    int kmRetour,
    DateTime retourReel)
        {
            // باش ما يزيدش pénalité kilométrage بجوج مرات لنفس contrat
            string checkSql = @"
        SELECT COUNT(*)
        FROM contrat_penalites
        WHERE contrat_id = @contrat_id
          AND type_penalite = 'Kilométrage';";

            using (MySqlCommand checkCmd = new MySqlCommand(checkSql, cn, tr))
            {
                checkCmd.Parameters.AddWithValue("@contrat_id", contratId);

                int dejaExiste = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (dejaExiste > 0)
                    return 0m;
            }

            string sql = @"
        SELECT date_contrat, heure_debut, kilometrage_sortie
        FROM contrats
        WHERE contrat_id = @contrat_id;";

            DateTime dateDepart;
            int kmSortie;

            using (MySqlCommand cmd = new MySqlCommand(sql, cn, tr))
            {
                cmd.Parameters.AddWithValue("@contrat_id", contratId);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return 0m;

                    if (dr["date_contrat"] == DBNull.Value || dr["heure_debut"] == DBNull.Value)
                        return 0m;

                    DateTime dateContrat = Convert.ToDateTime(dr["date_contrat"]);

                    TimeSpan heureDebut;

                    if (dr["heure_debut"] is TimeSpan)
                        heureDebut = (TimeSpan)dr["heure_debut"];
                    else
                        heureDebut = TimeSpan.Parse(dr["heure_debut"].ToString());

                    dateDepart = dateContrat.Date.Add(heureDebut);

                    kmSortie = dr["kilometrage_sortie"] == DBNull.Value
                        ? kilometrageSortie
                        : Convert.ToInt32(dr["kilometrage_sortie"]);
                }
            }

            int kmParcouru = kmRetour - kmSortie;

            if (kmParcouru <= 0)
                return 0m;

            double totalDays = (retourReel - dateDepart).TotalDays;

            int joursLocation = (int)Math.Ceiling(totalDays);

            if (joursLocation < 1)
                joursLocation = 1;

            int kmAutoriseTotal = joursLocation * KmAutoriseParJour;

            int kmSupplementaire = kmParcouru - kmAutoriseTotal;

            if (kmSupplementaire <= 0)
                return 0m;

            decimal montantPenalite = kmSupplementaire * PrixKmSupplementaire;

            string description =
                "Kilométrage parcouru: " + kmParcouru + " km. " +
                "Autorisé: " + kmAutoriseTotal + " km " +
                "(" + KmAutoriseParJour + " km × " + joursLocation + " jour(s)). " +
                "Supplément: " + kmSupplementaire + " km × " +
                PrixKmSupplementaire.ToString("0.00") + " DH.";

            AjouterPenalite(
                cn,
                tr,
                contratId,
                "Kilométrage",
                montantPenalite,
                0m,
                description
            );

            return montantPenalite;
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

        private void AjouterPenalite(
            MySqlConnection cn,
            MySqlTransaction tr,
            int contratId,
            string typePenalite,
            decimal montant,
            decimal montantPaye,
            string description)
        {
            if (montant <= 0)
                return;

            if (montantPaye < 0)
                montantPaye = 0;

            if (montantPaye > montant)
                montantPaye = montant;

            string insertPenalite = @"
        INSERT INTO contrat_penalites
        (contrat_id, type_penalite, montant, montant_paye, description, nom_utilisateur)
        VALUES
        (@contrat_id, @type_penalite, @montant, @montant_paye, @description, @nom_utilisateur);";

            using (MySqlCommand cmd = new MySqlCommand(insertPenalite, cn, tr))
            {
                cmd.Parameters.AddWithValue("@contrat_id", contratId);
                cmd.Parameters.AddWithValue("@type_penalite", typePenalite);
                cmd.Parameters.AddWithValue("@montant", montant);
                cmd.Parameters.AddWithValue("@montant_paye", montantPaye);
                cmd.Parameters.AddWithValue("@description",
                    string.IsNullOrWhiteSpace(description) ? DBNull.Value : (object)description);
                cmd.Parameters.AddWithValue("@nom_utilisateur", Session.Username);
                cmd.ExecuteNonQuery();
            }

            if (montantPaye > 0)
            {
                PaymentService.AjouterPaiementContrat(
                    cn,
                    tr,
                    contratId,
                    montantPaye,
                    "Pénalité",
                    "Cash",
                    typePenalite,
                    Session.Username
                );
            }
        }

        private decimal AjouterRetardAutomatique(
            MySqlConnection cn,
            MySqlTransaction tr,
            int contratId,
            DateTime retourReel)
        {
            string checkSql = @"
        SELECT COUNT(*)
        FROM contrat_penalites
        WHERE contrat_id = @contrat_id
          AND type_penalite = 'Retard';";

            using (MySqlCommand checkCmd = new MySqlCommand(checkSql, cn, tr))
            {
                checkCmd.Parameters.AddWithValue("@contrat_id", contratId);

                int dejaExiste = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (dejaExiste > 0)
                    return 0m;
            }

            string sql = @"
        SELECT date_retour_prevu, heure_retour_prevu, prix_heure
        FROM contrats
        WHERE contrat_id = @contrat_id;";

            DateTime retourPrevu;
            decimal prixHeure = 0m;

            using (MySqlCommand cmd = new MySqlCommand(sql, cn, tr))
            {
                cmd.Parameters.AddWithValue("@contrat_id", contratId);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return 0m;

                    if (dr["date_retour_prevu"] == DBNull.Value || dr["heure_retour_prevu"] == DBNull.Value)
                        return 0m;

                    DateTime datePrevue = Convert.ToDateTime(dr["date_retour_prevu"]);

                    TimeSpan heurePrevue;

                    if (dr["heure_retour_prevu"] is TimeSpan)
                        heurePrevue = (TimeSpan)dr["heure_retour_prevu"];
                    else
                        heurePrevue = TimeSpan.Parse(dr["heure_retour_prevu"].ToString());

                    retourPrevu = datePrevue.Date.Add(heurePrevue);

                    if (dr["prix_heure"] != DBNull.Value)
                        prixHeure = Convert.ToDecimal(dr["prix_heure"]);
                }
            }

            if (retourReel <= retourPrevu)
                return 0m;

            double totalHours = (retourReel - retourPrevu).TotalHours;
            int heuresRetard = (int)Math.Ceiling(totalHours);

            if (heuresRetard <= 0)
                return 0m;

            decimal montantRetard = heuresRetard * prixHeure;

            string description =
                "Retard de " + heuresRetard + " heure(s). " +
                "Retour prévu: " + retourPrevu.ToString("dd/MM/yyyy HH:mm") +
                " / Retour réel: " + retourReel.ToString("dd/MM/yyyy HH:mm");

            AjouterPenalite(
                cn,
                tr,
                contratId,
                "Retard",
                montantRetard,
                0m,
                description
            );

            return montantRetard;
        }
        private void btnAccident_Click(object sender, EventArgs e)
        {


        }

        private void ChargerContratEnCours(int selectedVoitureId)
        {
            try
            {
                string query = @"
                            SELECT 
                                c.contrat_id,
                                c.voiture_id,
                                c.client_id,
                                c.date_contrat,
                                c.heure_debut,
                                c.date_retour_prevu,
                                c.heure_retour_prevu,
                                c.kilometrage_sortie,
                                c.kilometrage_retour,
                                c.prix_jour,
                                c.prix_heure,
                                c.avance,
                                c.total,
                                c.status,
                                cl.nom,
                                cl.prenom,
                                v.matricule,
                                v.marque,
                                v.modele
                            FROM contrats c
                            INNER JOIN clients cl ON cl.client_id = c.client_id
                            INNER JOIN voitures v ON v.voiture_id = c.voiture_id
                            WHERE c.voiture_id = @voiture_id
                              AND c.status <> @status_termine
                            ORDER BY c.contrat_id DESC
                            LIMIT 1;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@voiture_id", selectedVoitureId),
                    new MySqlParameter("@status_termine", AppStatus.ContratTermine)
                };

                DataTable dt = Dbexec.GetData(query, ps);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    contratId = Convert.ToInt32(dr["contrat_id"]);
                    voitureId = Convert.ToInt32(dr["voiture_id"]);
                    kilometrageSortie = dr["kilometrage_sortie"] == DBNull.Value
                        ? 0
                        : Convert.ToInt32(dr["kilometrage_sortie"]);

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("N° Contrat : " + dr["contrat_id"].ToString());
                    sb.AppendLine("Client : " + dr["nom"].ToString() + " " + dr["prenom"].ToString());
                    sb.AppendLine("Voiture : " + dr["matricule"].ToString() + " - " + dr["marque"].ToString() + " " + dr["modele"].ToString());
                    sb.AppendLine("Date contrat : " + Convert.ToDateTime(dr["date_contrat"]).ToString("dd/MM/yyyy"));
                    sb.AppendLine("Heure début : " + dr["heure_debut"].ToString());
                    sb.AppendLine("Date retour prévu : " + Convert.ToDateTime(dr["date_retour_prevu"]).ToString("dd/MM/yyyy"));
                    sb.AppendLine("Heure retour prévu : " + dr["heure_retour_prevu"].ToString());
                    sb.AppendLine("Kilométrage sortie : " + kilometrageSortie);
                    sb.AppendLine("Prix/Jour : " + dr["prix_jour"].ToString() + " DH");
                    sb.AppendLine("Prix/Heure : " + dr["prix_heure"].ToString() + " DH");
                    sb.AppendLine("Avance : " + dr["avance"].ToString() + " DH");
                    sb.AppendLine("Total : " + dr["total"].ToString() + " DH");
                    sb.AppendLine("Status : " + dr["status"].ToString());

                    txtInfoContrat.Text = sb.ToString();

                    btnRetourSimple.Enabled = true;
                    btnAccident.Enabled = true;
                }
                else
                {
                    contratId = -1;
                    kilometrageSortie = 0;
                    txtInfoContrat.Clear();
                    btnRetourSimple.Enabled = false;
                    btnAccident.Enabled = false;

                    MessageBox.Show("Aucun contrat en cours pour cette voiture.",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "retour", "ChargerContratEnCours");
                dbErreur.AddLog(ex.Message, Session.Username, "retour", "ChargerContratEnCours");
                MessageBox.Show("Erreur chargement contrat : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private bool ValiderKilometrage(out int kmRetour)
        {
            kmRetour = 0;

            if (contratId <= 0)
            {
                MessageBox.Show("Chargez d'abord le contrat de la voiture.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtKilometrageRetour.Text.Trim(), out kmRetour))
            {
                MessageBox.Show("Kilométrage retourné invalide.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKilometrageRetour.Focus();
                return false;
            }

            if (kmRetour < kilometrageSortie)
            {
                MessageBox.Show("Le kilométrage retourné ne peut pas être inférieur au kilométrage de sortie.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKilometrageRetour.Focus();
                return false;
            }

            return true;
        }

        private void txtKilometrageRetour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtMontantReparation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
               !char.IsDigit(e.KeyChar) &&
               e.KeyChar != ',' &&
               e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == ',' || e.KeyChar == '.') &&
                (txtMontantReparation.Text.Contains(",") || txtMontantReparation.Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void btnValider_Click_1(object sender, EventArgs e)
        {

            if (cbVoiture.SelectedIndex == -1)
            {
                MessageBox.Show("Sélectionnez une voiture.",
                    "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            voitureId = Convert.ToInt32(cbVoiture.SelectedValue);
            ChargerContratEnCours(voitureId);
        }

        private void btnRetourSimple_Click_1(object sender, EventArgs e)
        {

            if (!ValiderKilometrage(out int kmRetour))
                return;

            DialogResult rep = MessageBox.Show(
                "Confirmer le retour simple de cette voiture ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rep != DialogResult.Yes)
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
                            DateTime retourReel = DateTime.Now;

                            string updateContrat = @"
                        UPDATE contrats
                        SET kilometrage_retour = @kilometrage_retour,
                            date_retour_reelle = @date_retour_reelle,
                            heure_retour_reelle = @heure_retour_reelle
                        WHERE contrat_id = @contrat_id;";

                            using (MySqlCommand cmd = new MySqlCommand(updateContrat, cn, tr))
                            {
                                cmd.Parameters.AddWithValue("@kilometrage_retour", kmRetour);
                                cmd.Parameters.AddWithValue("@date_retour_reelle", retourReel.Date);
                                cmd.Parameters.AddWithValue("@heure_retour_reelle", retourReel.TimeOfDay);
                                cmd.Parameters.AddWithValue("@contrat_id", contratId);
                                cmd.ExecuteNonQuery();
                            }

                            decimal montantRetard = AjouterRetardAutomatique(cn, tr, contratId, retourReel);

                            decimal montantKmSupp = AjouterKilometrageSupplementaireAutomatique(
                                cn,
                                tr,
                                contratId,
                                kmRetour,
                                retourReel
                            );

                            tr.Commit();

                            LogHelper.AddLog("Retour voiture: " + cbVoiture.Text, Session.Username);

                            string message = "Retour simple enregistré avec succès.";

                            if (montantRetard > 0)
                                message += "\nRetard ajouté : " + montantRetard.ToString("0.00") + " DH";

                            if (montantKmSupp > 0)
                                message += "\nKilométrage supplémentaire : " + montantKmSupp.ToString("0.00") + " DH";

                            MessageBox.Show(
                                message,
                                "Succès",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ReinitialiserForm();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();

                            ErrorReporter.SendError(ex, "retour", "btnRetourSimple_Click_1_Transaction");
                            dbErreur.AddLog(ex.Message, Session.Username, "retour", "btnRetourSimple_Click_1_Transaction");

                            MessageBox.Show(
                                "Erreur enregistrement retour : " + ex.Message,
                                "Erreur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "retour", "btnRetourSimple_Click_1");
                dbErreur.AddLog(ex.Message, Session.Username, "retour", "btnRetourSimple_Click_1");

                MessageBox.Show(
                    "Erreur connexion : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


        }

        private void btnAccident_Click_1(object sender, EventArgs e)
        {

            if (!ValiderKilometrage(out int kmRetour))
                return;

            string descriptionAccident = txtDescriptionAccident.Text.Trim();

            if (string.IsNullOrWhiteSpace(descriptionAccident))
            {
                MessageBox.Show(
                    "Saisissez la description de l'accident.",
                    "Attention",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescriptionAccident.Focus();
                return;
            }

            decimal montantReparation;
            decimal montantpaye;

            try
            {
                montantReparation = LireMontant(txtMontantReparation.Text);
                montantpaye = LireMontant(txtMontantpaye.Text);
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

            if (montantpaye > montantReparation)
            {
                MessageBox.Show(
                    "Montant payé ne peut pas être supérieur au montant réparation.",
                    "Attention",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMontantpaye.Focus();
                return;
            }

            DialogResult rep = MessageBox.Show(
                "Confirmer le retour avec accident ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rep != DialogResult.Yes)
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
                            DateTime retourReel = DateTime.Now;

                            string updateContrat = @"
                        UPDATE contrats
                        SET kilometrage_retour = @kilometrage_retour,
                            date_retour_reelle = @date_retour_reelle,
                            heure_retour_reelle = @heure_retour_reelle
                        WHERE contrat_id = @contrat_id;";

                            using (MySqlCommand cmd1 = new MySqlCommand(updateContrat, cn, tr))
                            {
                                cmd1.Parameters.AddWithValue("@kilometrage_retour", kmRetour);
                                cmd1.Parameters.AddWithValue("@date_retour_reelle", retourReel.Date);
                                cmd1.Parameters.AddWithValue("@heure_retour_reelle", retourReel.TimeOfDay);
                                cmd1.Parameters.AddWithValue("@contrat_id", contratId);
                                cmd1.ExecuteNonQuery();
                            }

                            string insertAccident = @"
                        INSERT INTO accidents
                        (contrat_id, date_accident, description, montant_reparation, montant_paye, nom_utilisateur)
                        VALUES
                        (@contrat_id, @date_accident, @description, @montant_reparation, @montant_paye, @nom_utilisateur);";

                            using (MySqlCommand cmd2 = new MySqlCommand(insertAccident, cn, tr))
                            {
                                cmd2.Parameters.AddWithValue("@contrat_id", contratId);
                                cmd2.Parameters.AddWithValue("@date_accident", retourReel.Date);
                                cmd2.Parameters.AddWithValue("@description", descriptionAccident);
                                cmd2.Parameters.AddWithValue("@montant_reparation", montantReparation);
                                cmd2.Parameters.AddWithValue("@montant_paye", montantpaye);
                                cmd2.Parameters.AddWithValue("@nom_utilisateur", Session.Username);
                                cmd2.ExecuteNonQuery();
                            }

                            decimal montantRetard = AjouterRetardAutomatique(cn, tr, contratId, retourReel);

                            decimal montantKmSupp = AjouterKilometrageSupplementaireAutomatique(
                                cn,
                                tr,
                                contratId,
                                kmRetour,
                                retourReel
                            );

                            if (montantReparation > 0)
                            {
                                AjouterPenalite(
                                    cn,
                                    tr,
                                    contratId,
                                    "Dégât",
                                    montantReparation,
                                    montantpaye,
                                    descriptionAccident
                                );
                            }

                            tr.Commit();

                            LogHelper.AddLog("Retour avec accident voiture: " + cbVoiture.Text, Session.Username);

                            string message = "Retour avec accident enregistré avec succès.";

                            if (montantRetard > 0)
                                message += "\nRetard ajouté : " + montantRetard.ToString("0.00") + " DH";

                            if (montantKmSupp > 0)
                                message += "\nKilométrage supplémentaire : " + montantKmSupp.ToString("0.00") + " DH";

                            if (montantReparation > 0)
                                message += "\nPénalité dégât : " + montantReparation.ToString("0.00") + " DH";

                            if (montantpaye > 0)
                                message += "\nMontant payé : " + montantpaye.ToString("0.00") + " DH";

                            MessageBox.Show(
                                message,
                                "Succès",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            ReinitialiserForm();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();

                            ErrorReporter.SendError(ex, "retour", "btnAccident_Click_1_Transaction");
                            dbErreur.AddLog(ex.Message, Session.Username, "retour", "btnAccident_Click_1_Transaction");

                            MessageBox.Show(
                                "Erreur retour avec accident : " + ex.Message,
                                "Erreur",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "retour", "btnAccident_Click_1");
                dbErreur.AddLog(ex.Message, Session.Username, "retour", "btnAccident_Click_1");

                MessageBox.Show(
                    "Erreur connexion : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }




    }

}
