using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

using venolocation.classee;

namespace venolocation.formee
{
    public partial class contrats : Form
    {
       
        private readonly string nomUtilisateur = Session.Username;
        private DataTable dtClients;
        private DataTable dtVoitures;
        private DataTable dtReservationsConfirmees;
        private int reservationIdSelectionnee = -1;


        public contrats()
        {
            InitializeComponent();
        }


        private void ChargerReservationsConfirmees()
        {
            try
            {
                string query = @"
                                SELECT 
                                    r.reservation_id,
                                    r.client_id,
                                    r.voiture_id,
                                    r.date_debut,
                                    r.heure_debut,
                                    r.date_fin,
                                    r.heure_fin,
                                    CONCAT('RES-', r.reservation_id, ' | ',
                                           cl.nom, ' ', cl.prenom, ' | ',
                                           v.matricule, ' - ', v.marque, ' ', v.modele) AS reservation_display
                                FROM reservations r
                                INNER JOIN clients cl ON cl.client_id = r.client_id
                                INNER JOIN voitures v ON v.voiture_id = r.voiture_id
                                WHERE r.status = @status
                                ORDER BY r.reservation_id DESC
                                LIMIT 300;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@status", AppStatus.ReservationConfirmee)
                };

                dtReservationsConfirmees = Dbexec.GetData(query, ps);

                cbReservation.DataSource = dtReservationsConfirmees;
                cbReservation.DisplayMember = "reservation_display";
                cbReservation.ValueMember = "reservation_id";
                cbReservation.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "contrats", "ChargerReservationsConfirmees");
                MessageBox.Show("Erreur chargement réservations confirmées : " + ex.Message);
            }
        }

        private void InitialiserHeures()
        {
            cbHeureDebut.Items.Clear();
            cbHeureRetour.Items.Clear();

            for (int h = 0; h < 24; h++)
            {
                cbHeureDebut.Items.Add(h.ToString("00") + ":00");
                cbHeureRetour.Items.Add(h.ToString("00") + ":00");
            }

            cbHeureDebut.SelectedIndex = -1;
            cbHeureRetour.SelectedIndex = -1;
        }



        private void dtpDateDebut_ValueChanged(object sender, EventArgs e)
        {
            MettreAJourCalcul();
        }

        private void dtpDateFin_ValueChanged(object sender, EventArgs e)
        {
            MettreAJourCalcul();
        }

        private void nudAvance_ValueChanged(object sender, EventArgs e)
        {
            MettreAJourCalcul();
        }

        private void txtPrixJour_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cboClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClient.SelectedIndex < 0 || dtClients == null || cbClient.SelectedValue == null)
                return;

            try
            {
                int clientId = Convert.ToInt32(cbClient.SelectedValue);
                DataRow[] rows = dtClients.Select("client_id = " + clientId);

                if (rows.Length > 0)
                {
                    txtNom.Text = rows[0]["nom"].ToString() + " " + rows[0]["prenom"].ToString();
                    txtTelephone.Text = rows[0]["telephone"].ToString();
                    txtPermis.Text = rows[0]["permis_num"].ToString();
                    txtAdresse.Text = rows[0]["adresse"].ToString();
                }
            }
            catch
            {
            }
        }

        private void cboImmatriculation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbImmatriculation.SelectedIndex >= 0 && cbImmatriculation.SelectedValue != null)
            {
                try
                {
                    int voitureId = Convert.ToInt32(cbImmatriculation.SelectedValue);
                    ChargerVoitureParId(voitureId);
                }
                catch
                {
                }
            }
        }
        private DateTime ConstruireDateHeure(DateTime date, string heure)
        {
            if (string.IsNullOrWhiteSpace(heure))
                return date;

            TimeSpan ts = TimeSpan.Parse(heure);
            return date.Date.Add(ts);
        }

        private int CalculerNombreJours()
        {
            DateTime debut = ConstruireDateHeure(dtDateDebut.Value.Date, cbHeureDebut.Text);
            DateTime fin = ConstruireDateHeure(dtDateFin.Value.Date, cbHeureRetour.Text);

            if (fin <= debut)
                return 1;

            TimeSpan diff = fin - debut;

            int jours = (int)Math.Ceiling(diff.TotalDays);
            if (jours <= 0)
                jours = 1;

            return jours;
        }

        private decimal CalculerTotal()
        {
            decimal prixJour = 0;
            decimal.TryParse(txtPrixJour.Text.Replace('.', ','), out prixJour);

            decimal prixHeure = 0;
            if (dtVoitures != null && cbImmatriculation.SelectedValue != null)
            {
                try
                {
                    int voitureId = Convert.ToInt32(cbImmatriculation.SelectedValue);
                    DataRow[] rows = dtVoitures.Select("voiture_id = " + voitureId);
                    if (rows.Length > 0)
                    {
                        prixHeure = rows[0]["prix_heure"] == DBNull.Value ? 0 : Convert.ToDecimal(rows[0]["prix_heure"]);
                    }
                }
                catch
                {
                }
            }

            if (string.IsNullOrWhiteSpace(cbHeureDebut.Text) || string.IsNullOrWhiteSpace(cbHeureRetour.Text))
                return 0;

            DateTime debut = ConstruireDateHeure(dtDateDebut.Value.Date, cbHeureDebut.Text);
            DateTime fin = ConstruireDateHeure(dtDateFin.Value.Date, cbHeureRetour.Text);

            if (fin <= debut)
                return 0;

            TimeSpan diff = fin - debut;
            int jours = (int)diff.TotalDays;
            int heures = diff.Hours;

            if (diff.Minutes > 0 || diff.Seconds > 0)
                heures++;

            decimal total = (jours * prixJour) + (heures * prixHeure);

            if (jours == 0 && heures == 0)
                total = prixHeure;

            return total;
        }
        private void MettreAJourCalcul()
        {
            if (string.IsNullOrWhiteSpace(cbHeureDebut.Text) || string.IsNullOrWhiteSpace(cbHeureRetour.Text))
                return;

            int jours = CalculerNombreJours();
            decimal total = CalculerTotal();
            decimal avance = numAvance.Value;
            decimal reste = total - avance;

            if (reste < 0)
                reste = 0;

            txtNombreJours.Text = jours.ToString();
            txtTtl.Text = total.ToString("0.00");
            txtRestePayer.Text = reste.ToString("0.00");

            lblDuree.Text = jours + (jours > 1 ? " jours" : " jour");
            lblTotal.Text = total.ToString("0.00") + " DH";
        }

        private bool ChampsValides()
        {
            if (cbClient.SelectedIndex == -1)
            {
                MessageBox.Show("Choisissez un client.");
                cbClient.Focus();
                return false;
            }

            if (cbImmatriculation.SelectedIndex == -1)
            {
                MessageBox.Show("Choisissez une voiture.");
                cbImmatriculation.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbHeureDebut.Text))
            {
                MessageBox.Show("Choisissez l'heure de début.");
                cbHeureDebut.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cbHeureRetour.Text))
            {
                MessageBox.Show("Choisissez l'heure de retour.");
                cbHeureRetour.Focus();
                return false;
            }

            DateTime debut = ConstruireDateHeure(dtDateDebut.Value.Date, cbHeureDebut.Text);
            DateTime fin = ConstruireDateHeure(dtDateFin.Value.Date, cbHeureRetour.Text);

            if (fin <= debut)
            {
                MessageBox.Show("La date/heure de retour doit être supérieure à la date/heure début.");
                return false;
            }

            decimal total = CalculerTotal();
            if (total <= 0)
            {
                MessageBox.Show("Le total est invalide.");
                return false;
            }

            return true;
        }

        private void btnNouveau_Click_1(object sender, EventArgs e)
        {
            NouveauContrat();

        }

        private void btncalculer_Click_1(object sender, EventArgs e)
        {
            MettreAJourCalcul();
        }

        private void btnannuller_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {

            if (!ChampsValides())
                return;

            try
            {
                int clientId = Convert.ToInt32(cbClient.SelectedValue);
                int voitureId = Convert.ToInt32(cbImmatriculation.SelectedValue);

                DateTime dateContrat = dtDateDebut.Value.Date;
                TimeSpan heureDebut = TimeSpan.Parse(cbHeureDebut.Text);

                DateTime dateRetour = dtDateFin.Value.Date;
                TimeSpan heureRetour = TimeSpan.Parse(cbHeureRetour.Text);

                int kilometrageSortie = 0;
                int.TryParse(txtKilometrage.Text, out kilometrageSortie);

                decimal prixJour = 0;
                decimal.TryParse(txtPrixJour.Text.Replace('.', ','), out prixJour);

                decimal prixHeure = 0;
                if (dtVoitures != null)
                {
                    DataRow[] rows = dtVoitures.Select("voiture_id = " + voitureId);
                    if (rows.Length > 0)
                        prixHeure = rows[0]["prix_heure"] == DBNull.Value ? 0 : Convert.ToDecimal(rows[0]["prix_heure"]);
                }

                decimal avance = numAvance.Value;
                decimal total = CalculerTotal();

                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    using (MySqlTransaction tr = cn.BeginTransaction())
                    {
                        try
                        {
                            string query = @"
                    INSERT INTO contrats
                    (client_id, voiture_id, reservation_id, date_contrat, heure_debut, 
                     date_retour_prevu, heure_retour_prevu, kilometrage_sortie, 
                     prix_jour, prix_heure, avance, total, status, nom_utilisateur)
                    VALUES
                    (@client_id, @voiture_id, @reservation_id, @date_contrat, @heure_debut,
                     @date_retour_prevu, @heure_retour_prevu, @kilometrage_sortie,
                     @prix_jour, @prix_heure, @avance, @total, @status, @nom_utilisateur);";

                            using (MySqlCommand cmd = new MySqlCommand(query, cn, tr))
                            {
                                cmd.Parameters.AddWithValue("@client_id", clientId);
                                cmd.Parameters.AddWithValue("@voiture_id", voitureId);
                                cmd.Parameters.AddWithValue("@reservation_id",
                                    reservationIdSelectionnee > 0 ? (object)reservationIdSelectionnee : DBNull.Value);
                                cmd.Parameters.AddWithValue("@date_contrat", dateContrat);
                                cmd.Parameters.AddWithValue("@heure_debut", heureDebut);
                                cmd.Parameters.AddWithValue("@date_retour_prevu", dateRetour);
                                cmd.Parameters.AddWithValue("@heure_retour_prevu", heureRetour);
                                cmd.Parameters.AddWithValue("@kilometrage_sortie", kilometrageSortie);
                                cmd.Parameters.AddWithValue("@prix_jour", prixJour);
                                cmd.Parameters.AddWithValue("@prix_heure", prixHeure);
                                cmd.Parameters.AddWithValue("@avance", avance);
                                cmd.Parameters.AddWithValue("@total", total);
                                cmd.Parameters.AddWithValue("@status", AppStatus.ContratEnCours);
                                cmd.Parameters.AddWithValue("@nom_utilisateur", nomUtilisateur);

                                cmd.ExecuteNonQuery();
                            }

                            
                            if (reservationIdSelectionnee > 0)
                            {
                                string updateReservation = @"
                                        UPDATE reservations
                                        SET status = @status
                                        WHERE reservation_id = @reservation_id;";

                                using (MySqlCommand cmdRes = new MySqlCommand(updateReservation, cn, tr))
                                {
                                    cmdRes.Parameters.AddWithValue("@status", AppStatus.ReservationTerminee);
                                    cmdRes.Parameters.AddWithValue("@reservation_id", reservationIdSelectionnee);
                                    cmdRes.ExecuteNonQuery();
                                }
                            }

                            tr.Commit();
                        }
                        catch
                        {
                            tr.Rollback();
                            throw;
                        }
                    }
                }

                MessageBox.Show("Contrat enregistré avec succès.");
                LogHelper.AddLog("Enregistrement contrat client ID: " + clientId + " voiture ID: " + voitureId, Session.Username);

                ChargerReservationsConfirmees();
                ChargerVoituresDisponibles();
                NouveauContrat();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "contrats", "btnEnregistrer_Click_1");
                MessageBox.Show("Erreur enregistrement contrat : " + ex.Message);
            }

        }

        private void contrats_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                ChargerClients();
                ChargerVoituresDisponibles();
                ChargerReservationsConfirmees();
                InitialiserModePaiement();
                InitialiserHeures();
                NouveauContrat();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "contrats", "contrats_Load");
                MessageBox.Show("Erreur chargement formulaire : " + ex.Message);
            }
            finally
            {
                this.ResumeLayout();
            }

        }
        private void ChargerVoitureParId(int voitureId)
        {
            if (dtVoitures == null)
                return;

            DataRow[] rows = dtVoitures.Select("voiture_id = " + voitureId);

            if (rows.Length > 0)
            {
                cbImmatriculation.SelectedValue = voitureId;
                cbMarque.SelectedValue = voitureId;
                cbModele.SelectedValue = voitureId;
                cbCarburant.SelectedValue = voitureId;
                cbCategorie.SelectedValue = voitureId;

                txtKilometrage.Text = rows[0]["kilometrage"].ToString();
                txtPrixJour.Text = Convert.ToDecimal(rows[0]["prix_jour"]).ToString("0.00");
                txtPuissance.Text = "";
            }
        }

        private void InitialiserModePaiement()
        {
            cbModePaiement.Items.Clear();
            cbModePaiement.Items.Add("Espèce");
            cbModePaiement.Items.Add("Carte");
            cbModePaiement.Items.Add("Virement");
            cbModePaiement.SelectedIndex = -1;
        }

        private void ChargerClients()
        {
            try
            {
                string query = @"
                                SELECT 
                                    client_id, 
                                    nom, 
                                    prenom, 
                                    telephone, 
                                    adresse, 
                                    permis_num,
                                    CONCAT(nom, ' ', prenom, ' - ', cin) AS client_display
                                FROM clients
                                ORDER BY nom, prenom
                                LIMIT 500;";

                dtClients = Dbexec.GetData(query);

                cbClient.DataSource = dtClients;
                cbClient.DisplayMember = "client_display";
                cbClient.ValueMember = "client_id";
                cbClient.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "contrats", "ChargerClients");
                MessageBox.Show("Erreur chargement clients : " + ex.Message);
            }
        }

        private void ChargerVoituresDisponibles()
        {
            try
            {
                   string query = @"
                    SELECT 
                        voiture_id, 
                        matricule, 
                        marque, 
                        modele, 
                        carburant, 
                        categorie,
                        kilometrage, 
                        prix_jour, 
                        prix_heure
                    FROM voitures
                    WHERE etat = @etat OR etat IS NULL
                    ORDER BY matricule
                    LIMIT 500;";

                MySqlParameter[] ps =
                {
            new MySqlParameter("@etat", AppStatus.VoitureDisponible)
        };

                dtVoitures = Dbexec.GetData(query, ps);

                cbImmatriculation.DataSource = dtVoitures.Copy();
                cbImmatriculation.DisplayMember = "matricule";
                cbImmatriculation.ValueMember = "voiture_id";
                cbImmatriculation.SelectedIndex = -1;

                cbMarque.DataSource = dtVoitures.Copy();
                cbMarque.DisplayMember = "marque";
                cbMarque.ValueMember = "voiture_id";
                cbMarque.SelectedIndex = -1;

                cbModele.DataSource = dtVoitures.Copy();
                cbModele.DisplayMember = "modele";
                cbModele.ValueMember = "voiture_id";
                cbModele.SelectedIndex = -1;

                cbCarburant.DataSource = dtVoitures.Copy();
                cbCarburant.DisplayMember = "carburant";
                cbCarburant.ValueMember = "voiture_id";
                cbCarburant.SelectedIndex = -1;

                cbCategorie.DataSource = dtVoitures.Copy();
                cbCategorie.DisplayMember = "categorie";
                cbCategorie.ValueMember = "voiture_id";
                cbCategorie.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "contrats", "ChargerVoituresDisponibles");
                MessageBox.Show("Erreur chargement voitures : " + ex.Message);
            }
        }

        private void NouveauContrat()
        {
            reservationIdSelectionnee = -1;

            if (cbReservation.DataSource != null)
                cbReservation.SelectedIndex = -1;

            cbClient.SelectedIndex = -1;

            txtNom.Clear();
            txtTelephone.Clear();
            txtPermis.Clear();
            txtAdresse.Clear();

            cbImmatriculation.SelectedIndex = -1;
            cbMarque.SelectedIndex = -1;
            cbModele.SelectedIndex = -1;
            cbCarburant.SelectedIndex = -1;
            cbCategorie.SelectedIndex = -1;

            txtKilometrage.Clear();
            txtPrixJour.Clear();
            txtPuissance.SelectedIndex = -1;

            dtDateDebut.Value = DateTime.Today;
            dtDateFin.Value = DateTime.Today.AddDays(1);

            cbHeureDebut.SelectedIndex = -1;
            cbHeureRetour.SelectedIndex = -1;

            txtNombreJours.Text = "1";

            numAvance.Value = 0;
            txtTtl.Text = "0,00";
            txtRestePayer.Text = "0,00";

            cbModePaiement.SelectedIndex = -1;
            txtRemarques.Clear();

            lblContratNumero.Text = GenererNumeroContrat();
            lblDuree.Text = "1 jour";
            lblTotal.Text = "0,00 DH";
        }

        private string GenererNumeroContrat()
        {
            try
            {
                int prochainId = Dbexec.ExecuteScalarInt("SELECT IFNULL(MAX(contrat_id), 0) + 1 FROM contrats");
                return "CTR-" + prochainId.ToString("0000");
            }
            catch
            {
                return "CTR-0001";
            }
        }

        private void cbReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbReservation.SelectedIndex < 0 || cbReservation.SelectedValue == null)
                    return;

                if (cbReservation.SelectedValue is DataRowView)
                    return;

                if (!int.TryParse(cbReservation.SelectedValue.ToString(), out int reservationId))
                    return;

                if (dtReservationsConfirmees == null)
                    return;

                DataRow[] rows = dtReservationsConfirmees.Select("reservation_id = " + reservationId);

                if (rows.Length == 0)
                    return;

                reservationIdSelectionnee = reservationId;

                int clientId = Convert.ToInt32(rows[0]["client_id"]);
                int voitureId = Convert.ToInt32(rows[0]["voiture_id"]);

                cbClient.SelectedValue = clientId;
                ChargerVoitureParId(voitureId);

                dtDateDebut.Value = Convert.ToDateTime(rows[0]["date_debut"]);
                dtDateFin.Value = Convert.ToDateTime(rows[0]["date_fin"]);

                cbHeureDebut.Text = Convert.ToDateTime(rows[0]["heure_debut"].ToString()).ToString("HH:mm");
                cbHeureRetour.Text = Convert.ToDateTime(rows[0]["heure_fin"].ToString()).ToString("HH:mm");

                MettreAJourCalcul();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "contrats", "cbReservation_SelectedIndexChanged");
                MessageBox.Show("Erreur chargement réservation : " + ex.Message);
            }
        }
    }
}