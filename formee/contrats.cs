using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using venolocation.classee;
using MySqlConnector;
using System.IO;

namespace venolocation.formee
{
    public partial class contrats : Form
    {

        private readonly string nomUtilisateur = Session.Username;
        private DataTable dtClients;
        private DataTable dtClients2;
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
                ErrorReporter.SendError(ex, "contrats", "ChargerReservationsConfirmees");
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
            string heureActuelle = DateTime.Now.ToString("HH:00");
            cbHeureDebut.Text= heureActuelle;
            cbHeureRetour.Text = heureActuelle;
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
            decimal avance = numAvance.Text == "" ? 0 : Convert.ToDecimal(numAvance.Text.Replace('.', ','));
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
            if (check_active.Checked && cbClient2.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez saisir la CIN du 2ème conducteur.");
                cbClient2.Focus();
                return false;
            }

            //if (!ValiderDeuxiemeConducteur())
            //    return false;

            return true;
        }

        private void btnNouveau_Click_1(object sender, EventArgs e)
        {
            NouveauContrat();

        }

        private void btncalculer_Click_1(object sender, EventArgs e)
        {
            MettreAJourCalcul();
            btnEnregistrer.Enabled = true;
        }

        private void btnannuller_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private DataRow GetClientByCin(string cin, MySqlConnection cn, MySqlTransaction tr)
        {
            string query = @"
                SELECT nom, prenom, cin, telephone, adresse, permis_num, permis_date
                FROM clients
                WHERE client_id = @cin AND actif = 1
                LIMIT 1;";

            using (MySqlCommand cmd = new MySqlCommand(query, cn, tr))
            {
                cmd.Parameters.AddWithValue("@cin", cin.Trim());

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];

                    return null;
                }
            }
        }

        int dernierContratId = 0;

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

                decimal avance = numAvance.Text == "" ? 0 : Convert.ToDecimal(numAvance.Text.Replace('.', ','));
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

                                using (MySqlCommand cmdId = new MySqlCommand("SELECT LAST_INSERT_ID();", cn, tr))
                                {
                                    dernierContratId = Convert.ToInt32(cmdId.ExecuteScalar());
                                }
                            }

                            // ================================
                            // 1 er conducteur depuis table clients
                            // ================================

                            string cin = cbClient.SelectedValue?.ToString();

                            DataRow client = GetClientByCin(cin, cn, tr);

                            if (client == null)
                            {
                                MessageBox.Show(
                                    "Le client conducteur avec CIN : " + cin + " n'existe pas dans la table clients.",
                                    "1er conducteur",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );

                                tr.Rollback();
                                return;
                            }

                            string queryConducteur1 = @"
                                    INSERT INTO contrat_conducteurs
                                    (contrat_id, type_conducteur, nom, prenom, cin, telephone, adresse,
                                     permis_num, permis_date, nom_utilisateur)
                                    VALUES
                                    (@contrat_id, @type_conducteur, @nom, @prenom, @cin, @telephone, @adresse,
                                     @permis_num, @permis_date, @nom_utilisateur);";

                            using (MySqlCommand cmdCond1 = new MySqlCommand(queryConducteur1, cn, tr))
                            {
                                cmdCond1.Parameters.AddWithValue("@contrat_id", dernierContratId);
                                cmdCond1.Parameters.AddWithValue("@type_conducteur", "principal");

                                cmdCond1.Parameters.AddWithValue("@nom",
                                    client["nom"] == DBNull.Value ? "" : client["nom"].ToString());

                                cmdCond1.Parameters.AddWithValue("@prenom",
                                    client["prenom"] == DBNull.Value ? "" : client["prenom"].ToString());

                                cmdCond1.Parameters.AddWithValue("@cin",
                                    client["cin"] == DBNull.Value ? "" : client["cin"].ToString());

                                cmdCond1.Parameters.AddWithValue("@telephone",
                                    client["telephone"] == DBNull.Value ? "" : client["telephone"].ToString());

                                cmdCond1.Parameters.AddWithValue("@adresse",
                                    client["adresse"] == DBNull.Value ? "" : client["adresse"].ToString());

                                cmdCond1.Parameters.AddWithValue("@permis_num",
                                    client["permis_num"] == DBNull.Value ? "" : client["permis_num"].ToString());

                                cmdCond1.Parameters.AddWithValue("@permis_date",
                                    client["permis_date"] == DBNull.Value ? (object)DBNull.Value : client["permis_date"]);

                                cmdCond1.Parameters.AddWithValue("@nom_utilisateur", nomUtilisateur);

                                cmdCond1.ExecuteNonQuery();
                            }


                            // ================================
                            // 2ème conducteur depuis table clients
                            // ================================
                            if (check_active.Checked)
                            {
                                string cin2 = cbClient2.SelectedValue?.ToString();

                                DataRow client2 = GetClientByCin(cin2, cn, tr);

                                if (client2 == null)
                                {
                                    MessageBox.Show(
                                        "Le 2ème conducteur avec CIN : " + cin2 + " n'existe pas dans la table clients.",
                                        "2ème conducteur",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning
                                    );

                                    tr.Rollback();
                                    return;
                                }

                                string queryConducteur = @"
                                    INSERT INTO contrat_conducteurs
                                    (contrat_id, type_conducteur, nom, prenom, cin, telephone, adresse,
                                     permis_num, permis_date, nom_utilisateur)
                                    VALUES
                                    (@contrat_id, @type_conducteur, @nom, @prenom, @cin, @telephone, @adresse,
                                     @permis_num, @permis_date, @nom_utilisateur);";

                                using (MySqlCommand cmdCond = new MySqlCommand(queryConducteur, cn, tr))
                                {
                                    cmdCond.Parameters.AddWithValue("@contrat_id", dernierContratId);
                                    cmdCond.Parameters.AddWithValue("@type_conducteur", "secondaire");

                                    cmdCond.Parameters.AddWithValue("@nom",
                                        client2["nom"] == DBNull.Value ? "" : client2["nom"].ToString());

                                    cmdCond.Parameters.AddWithValue("@prenom",
                                        client2["prenom"] == DBNull.Value ? "" : client2["prenom"].ToString());

                                    cmdCond.Parameters.AddWithValue("@cin",
                                        client2["cin"] == DBNull.Value ? "" : client2["cin"].ToString());

                                    cmdCond.Parameters.AddWithValue("@telephone",
                                        client2["telephone"] == DBNull.Value ? "" : client2["telephone"].ToString());

                                    cmdCond.Parameters.AddWithValue("@adresse",
                                        client2["adresse"] == DBNull.Value ? "" : client2["adresse"].ToString());

                                    cmdCond.Parameters.AddWithValue("@permis_num",
                                        client2["permis_num"] == DBNull.Value ? "" : client2["permis_num"].ToString());

                                    cmdCond.Parameters.AddWithValue("@permis_date",
                                        client2["permis_date"] == DBNull.Value ? (object)DBNull.Value : client2["permis_date"]);

                                    cmdCond.Parameters.AddWithValue("@nom_utilisateur", nomUtilisateur);

                                    cmdCond.ExecuteNonQuery();
                                }
                            }

                            // ================================
                            // Update reservation
                            // ================================
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

                MessageBox.Show(
                    "Contrat enregistré avec succès.\nN° Contrat : " + dernierContratId,
                    "Contrat",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LogHelper.AddLog(
                    "Enregistrement contrat ID: " + dernierContratId +
                    " client ID: " + clientId +
                    " voiture ID: " + voitureId,
                    Session.Username
                );

                DialogResult rep = MessageBox.Show(
                    "Voulez-vous imprimer le contrat maintenant ?",
                    "Impression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (rep == DialogResult.Yes)
                {
                    FactureEtatVehiculeData data = ChargerFactureDepuisContrat(dernierContratId);

                    if (data != null)
                    {
                        data.Observations = txtRemarques.Text;

                        ContratLocationPrinter printer = new ContratLocationPrinter(
                            data,
                            pictureBoxLogo.Image,
                            pictureBoxEtatVoiture.Image,
                            pictureBoxEtatVoiture2.Image
                        );

                        printer.ShowPreview();
                    }
                }
                tnImprimer.Enabled = true;
                btnEnregistrer.Enabled = false;
                ChargerReservationsConfirmees();
                ChargerVoituresDisponibles();
                NouveauContrat();
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "contrats", "btnEnregistrer_Click_1");
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
                ChargerClients_2();
                ChargerVoituresDisponibles();
                ChargerReservationsConfirmees();
                InitialiserModePaiement();
                InitialiserHeures();
                NouveauContrat();
                groupBox1.Enabled = check_active.Checked;
                string heureActuelle = DateTime.Now.ToString("HH:00");
                cbHeureDebut.Text = heureActuelle;
                cbHeureRetour.Text = heureActuelle;
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "contrats", "contrats_Load");
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

            }
        }

        private void InitialiserModePaiement()
        {
            cbModePaiement.Items.Clear();
            cbModePaiement.Items.Add("Espèce");
            cbModePaiement.Items.Add("Carte");
            cbModePaiement.Items.Add("Virement");
            cbModePaiement.Text= "Espèce";
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
                ErrorReporter.SendError(ex, "contrats", "ChargerClients");
                dbErreur.AddLog(ex.Message, Session.Username, "contrats", "ChargerClients");
                MessageBox.Show("Erreur chargement clients : " + ex.Message);
            }
        }

        private void ChargerClients_2()
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

                dtClients2 = Dbexec.GetData(query);

                cbClient2.DataSource = dtClients2;
                cbClient2.DisplayMember = "client_display";
                cbClient2.ValueMember = "client_id";
                cbClient2.SelectedIndex = -1;



            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "contrats", "ChargerClients");
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
                ErrorReporter.SendError(ex, "contrats", "ChargerVoituresDisponibles");
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

            dtDateDebut.Value = DateTime.Today;
            dtDateFin.Value = DateTime.Today.AddDays(1);

            cbHeureDebut.SelectedIndex = -1;
            cbHeureRetour.SelectedIndex = -1;

            txtNombreJours.Text = "1";

            numAvance.Text = "0";
            txtTtl.Text = "0,00";
            txtRestePayer.Text = "0,00";

            cbModePaiement.SelectedIndex = -1;
            txtRemarques.Clear();

            lblContratNumero.Text = GenererNumeroContrat();
            lblDuree.Text = "1 jour";
            lblTotal.Text = "0,00 DH";

            string heureActuelle = DateTime.Now.ToString("HH:00");
            cbHeureDebut.Text = heureActuelle;
            cbHeureRetour.Text = heureActuelle;
            cbModePaiement.Text = "Espèce";

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
                ErrorReporter.SendError(ex, "contrats", "cbReservation_SelectedIndexChanged");
                dbErreur.AddLog(ex.Message, Session.Username, "contrats", "cbReservation_SelectedIndexChanged");
                MessageBox.Show("Erreur chargement réservation : " + ex.Message);
            }
        }

        private void tnImprimer_Click(object sender, EventArgs e)
        {


            try
            {
                int contratId = dernierContratId;

                if (contratId <= 0)
                {
                    MessageBox.Show(
                        "Veuillez choisir ou enregistrer un contrat avant l'impression.",
                        "Impression",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                FactureEtatVehiculeData data = ChargerFactureDepuisContrat(contratId);

                if (data == null)
                {
                    MessageBox.Show(
                        "Contrat introuvable.",
                        "Impression",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                data.Observations = txtRemarques.Text.Trim();

                ContratLocationPrinter printer = new ContratLocationPrinter(
                    data,
                    pictureBoxLogo.Image,
                    pictureBoxEtatVoiture.Image,
                    pictureBoxEtatVoiture2.Image
                );

                printer.ShowPreview();
                NouveauContrat();
                btnEnregistrer.Enabled = false;
                tnImprimer.Enabled = false;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(
                    ex.Message,
                    Session.Username,
                    "contrats",
                    "tnImprimer_Click"
                );

                MessageBox.Show(
                    "Erreur lors de l'impression : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }




        private FactureEtatVehiculeData ChargerFactureDepuisContrat(int contratId)
        {
            string query = @"
                        SELECT 
                            c.contrat_id,
                            c.reservation_id,
                            c.date_contrat,
                            c.heure_debut,
                            c.date_retour_prevu,
                            c.heure_retour_prevu,
                            c.kilometrage_sortie,
                            c.kilometrage_retour,
                            c.prix_jour,
                            c.avance,
                            c.total,
                            c.status,

                            ph.mode_paiement,

                            cl.nom,
                            cl.prenom,
                            cl.cin,
                            cl.telephone,
                            cl.adresse,
                            cl.permis_num,
                            cl.permis_date,

                            cc.nom AS c2_nom,
                            cc.prenom AS c2_prenom,
                            cc.cin AS c2_cin,
                            cc.telephone AS c2_telephone,
                            cc.adresse AS c2_adresse,
                            cc.permis_num AS c2_permis_num,
                            cc.permis_date AS c2_permis_date,
                            cc.passport_num AS c2_passport_num,
                            cc.passport_date AS c2_passport_date,

                            v.matricule,
                            v.marque,
                            v.modele,
                            v.carburant,
                            v.categorie,
                            v.kilometrage,

                            p.ancienne_date_fin,
                            p.ancienne_heure_fin,
                            p.nouvelle_date_fin,
                            p.nouvelle_heure_fin,
                            p.montant_supplementaire,

                            ch.date_changement,
                            ch.heure_changement,
                            ch.kilometrage_nouvelle,

                            vn.marque AS new_marque,
                            vn.modele AS new_modele,
                            vn.matricule AS new_matricule

                        FROM contrats c
                        LEFT JOIN clients cl ON cl.client_id = c.client_id
                        LEFT JOIN voitures v ON v.voiture_id = c.voiture_id

                        LEFT JOIN (
                            SELECT cc1.*
                            FROM contrat_conducteurs cc1
                            INNER JOIN (
                                SELECT contrat_id, MAX(conducteur_id) AS max_id
                                FROM contrat_conducteurs
                                WHERE type_conducteur = 'secondaire'
                                GROUP BY contrat_id
                            ) x ON x.max_id = cc1.conducteur_id
                        ) cc ON cc.contrat_id = c.contrat_id

                        LEFT JOIN (
                            SELECT p1.*
                            FROM contrat_prolongations p1
                            INNER JOIN (
                                SELECT contrat_id, MAX(prolongation_id) AS max_id
                                FROM contrat_prolongations
                                GROUP BY contrat_id
                            ) y ON y.max_id = p1.prolongation_id
                        ) p ON p.contrat_id = c.contrat_id

                        LEFT JOIN (
                            SELECT ch1.*
                            FROM contrat_changements_voiture ch1
                            INNER JOIN (
                                SELECT contrat_id, MAX(changement_id) AS max_id
                                FROM contrat_changements_voiture
                                GROUP BY contrat_id
                            ) z ON z.max_id = ch1.changement_id
                        ) ch ON ch.contrat_id = c.contrat_id

                        LEFT JOIN voitures vn ON vn.voiture_id = ch.nouvelle_voiture_id

                        LEFT JOIN (
                            SELECT ph1.*
                            FROM payment_history ph1
                            INNER JOIN (
                                SELECT contrat_id, MAX(payment_id) AS max_id
                                FROM payment_history
                                WHERE contrat_id IS NOT NULL
                                GROUP BY contrat_id
                            ) m ON m.max_id = ph1.payment_id
                        ) ph ON ph.contrat_id = c.contrat_id

                        WHERE c.contrat_id = @contrat_id
                        LIMIT 1;
                        ";

            using (MySqlConnection con = new MySqlConnection(DbConfig.GetConnectionString()))
            using (MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@contrat_id", contratId);

                con.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (!dr.Read())
                        return null;

                    decimal total = GetDecimal(dr, "total");
                    decimal avance = GetDecimal(dr, "avance");
                    decimal reste = total - avance;

                    DateTime dateDebut = GetDate(dr, "date_contrat");
                    DateTime dateFin = GetDate(dr, "date_retour_prevu");

                    int nombreJours = (dateFin.Date - dateDebut.Date).Days;
                    if (nombreJours <= 0)
                        nombreJours = 1;

                    string reservationId = GetString(dr, "reservation_id");

                    return new FactureEtatVehiculeData
                    {
                        NomSociete = App_Config.Instance.nom_societe,
                        AdresseSociete = App_Config.Instance.adresse_societe,
                        TelephoneSociete = App_Config.Instance.telephone_societe,
                        EmailSociete = App_Config.Instance.email_societe,

                        NumeroContrat = contratId.ToString("0000"),
                        NumeroFacture = contratId.ToString("0000"),
                        DateFacture = DateTime.Now.ToString("dd/MM/yyyy"),
                        Reference = string.IsNullOrWhiteSpace(reservationId) ? "Sans réservation" : "RES-" + reservationId,

                        ClientNom = GetString(dr, "nom"),
                        ClientPrenom = GetString(dr, "prenom"),
                        ClientTelephone = GetString(dr, "telephone"),
                        ClientCin = GetString(dr, "cin"),
                        ClientAdresse = GetString(dr, "adresse"),
                        ClientPermis = GetString(dr, "permis_num"),
                        ClientPermisDate = FormatDate(GetString(dr, "permis_date")),
                        ClientPassport = "",
                        ClientPassportDate = "",

                        Conducteur2Nom = GetString(dr, "c2_nom"),
                        Conducteur2Prenom = GetString(dr, "c2_prenom"),
                        Conducteur2Telephone = GetString(dr, "c2_telephone"),
                        Conducteur2Cin = GetString(dr, "c2_cin"),
                        Conducteur2Adresse = GetString(dr, "c2_adresse"),
                        Conducteur2Permis = GetString(dr, "c2_permis_num"),
                        Conducteur2PermisDate = FormatDate(GetString(dr, "c2_permis_date")),
                        Conducteur2Passport = GetString(dr, "c2_passport_num"),
                        Conducteur2PassportDate = FormatDate(GetString(dr, "c2_passport_date")),

                        Marque = GetString(dr, "marque"),
                        Modele = GetString(dr, "modele"),
                        TypeVoiture = GetString(dr, "categorie"),
                        Immatriculation = GetString(dr, "matricule"),
                        Carburant = GetString(dr, "carburant"),
                        KmDepart = GetString(dr, "kilometrage_sortie"),
                        KmRetour = GetString(dr, "kilometrage_retour"),

                        DateDepart = dateDebut.ToString("dd/MM/yyyy"),
                        HeureDepart = FormatTime(GetString(dr, "heure_debut")),
                        LieuDepart = "",

                        DateRetour = dateFin.ToString("dd/MM/yyyy"),
                        HeureRetour = FormatTime(GetString(dr, "heure_retour_prevu")),
                        LieuRetour = "",

                        NombreJours = nombreJours.ToString(),
                        PrixJour = GetDecimal(dr, "prix_jour").ToString("0.00"),

                        Total = total.ToString("0.00"),
                        Avance = avance.ToString("0.00"),
                        Reste = reste.ToString("0.00"),
                        ModePaiement = GetString(dr, "mode_paiement"),

                        ProlongationDu = FormatDate(GetString(dr, "ancienne_date_fin")) + " " + FormatTime(GetString(dr, "ancienne_heure_fin")),
                        ProlongationAu = FormatDate(GetString(dr, "nouvelle_date_fin")) + " " + FormatTime(GetString(dr, "nouvelle_heure_fin")),
                        ProlongationLieuDepart = "",
                        ProlongationLieuRetour = "",
                        ProlongationFrais = GetDecimal(dr, "montant_supplementaire").ToString("0.00"),

                        ChangementMarque = (GetString(dr, "new_marque") + " " + GetString(dr, "new_modele")).Trim(),
                        ChangementMatricule = GetString(dr, "new_matricule"),
                        ChangementDate = FormatDate(GetString(dr, "date_changement")),
                        ChangementHeure = FormatTime(GetString(dr, "heure_changement")),
                        ChangementLieu = "",
                        ChangementKm = GetString(dr, "kilometrage_nouvelle"),

                        NiveauCarburant = GetString(dr, "carburant"),
                        Observations = ""
                    };
                }
            }
        }

        private string FormatDate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "";

            DateTime d;
            if (DateTime.TryParse(value, out d))
                return d.ToString("dd/MM/yyyy");

            return value;
        }
        private string GetString(MySqlDataReader dr, string columnName)
        {
            try
            {
                object value = dr[columnName];

                if (value == DBNull.Value || value == null)
                    return "";

                return value.ToString();
            }
            catch
            {
                return "";
            }
        }

        private decimal GetDecimal(MySqlDataReader dr, string columnName)
        {
            try
            {
                object value = dr[columnName];

                if (value == DBNull.Value || value == null)
                    return 0;

                return Convert.ToDecimal(value);
            }
            catch
            {
                return 0;
            }
        }

        private DateTime GetDate(MySqlDataReader dr, string columnName)
        {
            try
            {
                object value = dr[columnName];

                if (value == DBNull.Value || value == null)
                    return DateTime.Now;

                return Convert.ToDateTime(value);
            }
            catch
            {
                return DateTime.Now;
            }
        }

        private string FormatTime(string timeValue)
        {
            if (string.IsNullOrWhiteSpace(timeValue))
                return "";

            TimeSpan ts;

            if (TimeSpan.TryParse(timeValue, out ts))
                return ts.ToString(@"hh\:mm");

            DateTime dt;

            if (DateTime.TryParse(timeValue, out dt))
                return dt.ToString("HH:mm");

            return timeValue;
        }

        private void cbClient2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClient2.SelectedIndex < 0 || dtClients2 == null || cbClient2.SelectedValue == null)
                return;

            try
            {
                int clientId = Convert.ToInt32(cbClient2.SelectedValue);
                DataRow[] rows = dtClients2.Select("client_id = " + clientId);

                if (rows.Length > 0)
                {
                    txtNom2.Text = rows[0]["nom"].ToString() + " " + rows[0]["prenom"].ToString();
                    txtTelephone2.Text = rows[0]["telephone"].ToString();
                    txtPermis2.Text = rows[0]["permis_num"].ToString();
                    txtAdresse2.Text = rows[0]["adresse"].ToString();
                }
            }
            catch
            {
            }
        }

        private void check_active_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = check_active.Checked;
        }


        //*********************************************************

        //private bool DeuxiemeConducteurRempli()
        //{
        //    return
        //        !string.IsNullOrWhiteSpace(txtSecondNom.Text) ||
        //        !string.IsNullOrWhiteSpace(txtSecondPrenom.Text) ||
        //        !string.IsNullOrWhiteSpace(txtSecondCin.Text) ||
        //        !string.IsNullOrWhiteSpace(txtSecondTelephone.Text) ||
        //        !string.IsNullOrWhiteSpace(txtSecondPermis.Text) ||
        //        !string.IsNullOrWhiteSpace(txtSecondAdresse.Text);
        //}


        //private bool ValiderDeuxiemeConducteur()
        //{
        //    if (!DeuxiemeConducteurRempli())
        //        return true;

        //    if (string.IsNullOrWhiteSpace(txtSecondNom.Text))
        //    {
        //        MessageBox.Show("Saisir le nom du 2ème conducteur.");
        //        txtSecondNom.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtSecondCin.Text))
        //    {
        //        MessageBox.Show("Saisir le CIN du 2ème conducteur.");
        //        txtSecondCin.Focus();
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(txtSecondPermis.Text))
        //    {
        //        MessageBox.Show("Saisir le numéro de permis du 2ème conducteur.");
        //        txtSecondPermis.Focus();
        //        return false;
        //    }

        //    return true;
        //}

        //private void EnregistrerConducteursContrat(MySqlConnection cn, MySqlTransaction tr, int contratId, int clientId)
        //{

        //    string insertPrincipal = @"
        //            INSERT INTO contrat_conducteurs
        //            (contrat_id, type_conducteur, nom, prenom, cin, telephone, adresse, permis_num, permis_date, nom_utilisateur)
        //            SELECT
        //                @contrat_id,
        //                'principal',
        //                nom,
        //                prenom,
        //                cin,
        //                telephone,
        //                adresse,
        //                permis_num,
        //                permis_date,
        //                @nom_utilisateur
        //            FROM clients
        //            WHERE client_id = @client_id
        //            LIMIT 1;
        //        ";

        //    using (MySqlCommand cmd = new MySqlCommand(insertPrincipal, cn, tr))
        //    {
        //        cmd.Parameters.AddWithValue("@contrat_id", contratId);
        //        cmd.Parameters.AddWithValue("@client_id", clientId);
        //        cmd.Parameters.AddWithValue("@nom_utilisateur", Session.Username);
        //        cmd.ExecuteNonQuery();
        //    }


        //    if (!DeuxiemeConducteurRempli())
        //        return;

        //    string insertSecondaire = @"
        //            INSERT INTO contrat_conducteurs
        //            (contrat_id, type_conducteur, nom, prenom, cin, telephone, adresse, permis_num, nom_utilisateur)
        //            VALUES
        //            (@contrat_id, 'secondaire', @nom, @prenom, @cin, @telephone, @adresse, @permis_num, @nom_utilisateur);
        //        ";

        //    using (MySqlCommand cmd = new MySqlCommand(insertSecondaire, cn, tr))
        //    {
        //        cmd.Parameters.AddWithValue("@contrat_id", contratId);
        //        cmd.Parameters.AddWithValue("@nom", txtSecondNom.Text.Trim());
        //        cmd.Parameters.AddWithValue("@prenom", txtSecondPrenom.Text.Trim());
        //        cmd.Parameters.AddWithValue("@cin", txtSecondCin.Text.Trim());
        //        cmd.Parameters.AddWithValue("@telephone", txtSecondTelephone.Text.Trim());
        //        cmd.Parameters.AddWithValue("@adresse", txtSecondAdresse.Text.Trim());
        //        cmd.Parameters.AddWithValue("@permis_num", txtSecondPermis.Text.Trim());
        //        cmd.Parameters.AddWithValue("@nom_utilisateur", Session.Username);

        //        cmd.ExecuteNonQuery();
        //    }
        //}

    }
}