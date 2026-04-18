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
    public partial class reservation : Form
    {
       
        private int reservationIdSelectionnee = -1;
        public reservation()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            
        }

        private void pnlDateTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlDateFields_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reservation_Load(object sender, EventArgs e)
        {
            try
            {
                InitialiserHeures();
                ChargerVoitures();
                ChargerClients();
                ChargerReservations();
                InitialiserFormulaire();

                
            }
            catch (Exception ex)
            {
                LogHelper.AddLog("Erreur chargement formulaire réservation : " + ex.Message, Session.Username);
                MessageService.Error(AppMessages.UnexpectedError);
            }
           

        }
        private void InitialiserFormulaire()
        {
            dtDateDebut.Value = DateTime.Today;
            dtDateFin.Value = DateTime.Today;

            cbVoiture.SelectedIndex = -1;
            cbClient.SelectedIndex = -1;
            cbHeureDebut.SelectedIndex = -1;
            cbHeureFin.SelectedIndex = -1;

            btnReserver.Enabled = false;
            btnConfirmer.Enabled = false;
            btnAnnuler.Enabled = false;
        }

        private void InitialiserHeures()
        {
            cbHeureDebut.Items.Clear();
            cbHeureFin.Items.Clear();

            for (int h = 0; h < 24; h++)
            {
                string heure = h.ToString("00") + ":00";
                cbHeureDebut.Items.Add(heure);
                cbHeureFin.Items.Add(heure);
            }
        }

        private void ChargerVoitures()
        {
            using (MySqlConnection cn = Dbexec.GetConnection())
            {
                cn.Open();

                string query = @"
                    SELECT voiture_id, CONCAT(matricule, ' - ', marque, ' ', modele) AS voiture
                    FROM voitures
                    ORDER BY matricule;";

                using (MySqlDataAdapter da = new MySqlDataAdapter(query, cn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbVoiture.DataSource = dt;
                    cbVoiture.DisplayMember = "voiture";
                    cbVoiture.ValueMember = "voiture_id";
                    cbVoiture.SelectedIndex = -1;
                }
            }
        }

        private void ChargerClients()
        {
            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string query = @"
                    SELECT client_id, CONCAT(nom, ' ', prenom, ' - ', cin) AS client
                    FROM clients
                    ORDER BY nom, prenom;";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cbClient.DataSource = dt;
                        cbClient.DisplayMember = "client";
                        cbClient.ValueMember = "client_id";
                        cbClient.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement clients : " + ex.Message);
            }
        }

        private void ChargerReservations()
        {
            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string query = @"
                    SELECT 
                        r.reservation_id AS 'ID',
                        CONCAT(v.matricule, ' - ', v.marque, ' ', v.modele) AS 'Voiture',
                        CONCAT(c.nom, ' ', c.prenom) AS 'Client',
                        CONCAT(DATE_FORMAT(r.date_debut, '%d/%m/%Y'), ' ', TIME_FORMAT(r.heure_debut, '%H:%i')) AS 'Date Début',
                        CONCAT(DATE_FORMAT(r.date_fin, '%d/%m/%Y'), ' ', TIME_FORMAT(r.heure_fin, '%H:%i')) AS 'Date Fin',
                        r.status AS 'Statut'
                    FROM reservations r
                    INNER JOIN voitures v ON v.voiture_id = r.voiture_id
                    INNER JOIN clients c ON c.client_id = r.client_id
                    ORDER BY r.reservation_id DESC;";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, cn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvReservations.DataSource = dt;
                    }
                }

                ColorierStatutsReservations();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur chargement réservations : " + ex.Message);
            }
        }

        private bool ChampsValides()
        {
            if (cbVoiture.SelectedIndex == -1)
            {
                MessageService.Warning("Sélectionnez une voiture.");
                cbVoiture.Focus();
                LogHelper.AddLog("Validation réservation refusée : voiture non sélectionnée.", Session.Username);
                return false;
            }

            if (cbClient.SelectedIndex == -1)
            {
                MessageService.Warning("Sélectionnez un client.");
                cbClient.Focus();
                LogHelper.AddLog("Validation réservation refusée : client non sélectionné.", Session.Username);
                return false;
            }

            if (cbHeureDebut.SelectedIndex == -1)
            {
                MessageService.Warning("Sélectionnez l'heure de début.");
                cbHeureDebut.Focus();
                LogHelper.AddLog("Validation réservation refusée : heure début non sélectionnée.", Session.Username);
                return false;
            }

            if (cbHeureFin.SelectedIndex == -1)
            {
                MessageService.Warning("Sélectionnez l'heure de fin.");
                cbHeureFin.Focus();
                LogHelper.AddLog("Validation réservation refusée : heure fin non sélectionnée.", Session.Username);
                return false;
            }

            DateTime debut = ConstruireDateHeure(dtDateDebut.Value.Date, cbHeureDebut.Text);
            DateTime fin = ConstruireDateHeure(dtDateFin.Value.Date, cbHeureFin.Text);

            if (fin <= debut)
            {
                MessageService.Warning("La date et l'heure de fin doivent être supérieures à la date et l'heure de début.");
                LogHelper.AddLog("Validation réservation refusée : période invalide.", Session.Username);
                return false;
            }

            return true;
        }

        private DateTime ConstruireDateHeure(DateTime date, string heure)
        {
            TimeSpan ts = TimeSpan.Parse(heure);
            return date.Date.Add(ts);
        }

        private decimal ObtenirPrixTotal(int voitureId, DateTime debut, DateTime fin)
        {
            decimal prixJour = 0;
            decimal prixHeure = 0;

            using (MySqlConnection cn = Dbexec.GetConnection())
            {
                cn.Open();

                string query = "SELECT prix_jour, prix_heure FROM voitures WHERE voiture_id = @voiture_id";
                using (MySqlCommand cmd = new MySqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@voiture_id", voitureId);

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            prixJour = dr["prix_jour"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["prix_jour"]);
                            prixHeure = dr["prix_heure"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["prix_heure"]);
                        }
                    }
                }
            }

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

        private bool VoitureDisponible(int voitureId, DateTime debut, DateTime fin)
        {
            using (MySqlConnection cn = Dbexec.GetConnection())
            {
                cn.Open();

                string queryReservations = @"
                    SELECT COUNT(*)
                    FROM reservations
                    WHERE voiture_id = @voiture_id
                      AND status = 'Confirmée'
                      AND ((@debut < TIMESTAMP(date_fin, heure_fin))
                      AND (@fin > TIMESTAMP(date_debut, heure_debut)));";

                using (MySqlCommand cmd = new MySqlCommand(queryReservations, cn))
                {
                    cmd.Parameters.AddWithValue("@voiture_id", voitureId);
                    cmd.Parameters.AddWithValue("@debut", debut);
                    cmd.Parameters.AddWithValue("@fin", fin);

                    int countReservations = Convert.ToInt32(cmd.ExecuteScalar());
                    if (countReservations > 0)
                        return false;
                }

                string queryContrats = @"
                    SELECT COUNT(*)
                    FROM contrats
                    WHERE voiture_id = @voiture_id
                      AND status = 'En cours'
                      AND (
                            (@debut < TIMESTAMP(date_retour_prevu, heure_retour_prevu))
                            AND
                            (@fin > TIMESTAMP(date_contrat, heure_debut))
                          );";

                using (MySqlCommand cmd2 = new MySqlCommand(queryContrats, cn))
                {
                    cmd2.Parameters.AddWithValue("@voiture_id", voitureId);
                    cmd2.Parameters.AddWithValue("@debut", debut);
                    cmd2.Parameters.AddWithValue("@fin", fin);

                    int countContrats = Convert.ToInt32(cmd2.ExecuteScalar());
                    if (countContrats > 0)
                        return false;
                }
            }

            return true;
        }

        private void btnVerifierDate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ChampsValides())
                    return;

                int voitureId = Convert.ToInt32(cbVoiture.SelectedValue);
                DateTime debut = ConstruireDateHeure(dtDateDebut.Value.Date, cbHeureDebut.Text);
                DateTime fin = ConstruireDateHeure(dtDateFin.Value.Date, cbHeureFin.Text);

                bool disponible = VoitureDisponible(voitureId, debut, fin);

                if (disponible)
                {
                    decimal total = ObtenirPrixTotal(voitureId, debut, fin);

                    MessageService.Info("La voiture est disponible.\nPrix estimé : " + total.ToString("0.00") + " DH");
                    LogHelper.AddLog("Disponibilité vérifiée : voiture disponible. Prix estimé = " + total.ToString("0.00") + " DH.", Session.Username);

                    btnReserver.Enabled = true;
                }
                else
                {
                    MessageService.Warning("La voiture n'est pas disponible dans cette période.");
                    LogHelper.AddLog("Disponibilité vérifiée : voiture indisponible.", Session.Username);

                    btnReserver.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddLog("Erreur vérification disponibilité : " + ex.Message, Session.Username);
                MessageService.Error(AppMessages.UnexpectedError);
            }

        }

        private void ColorierStatutsReservations()
        {
            foreach (DataGridViewRow row in dgvReservations.Rows)
            {
                if (row.Cells["Statut"].Value == null)
                    continue;

                string statut = row.Cells["Statut"].Value.ToString();

                if (statut == "Confirmée")
                {
                    row.Cells["Statut"].Style.BackColor = System.Drawing.Color.LightGreen;
                    row.Cells["Statut"].Style.ForeColor = System.Drawing.Color.DarkGreen;
                }
                else if (statut == "En attente")
                {
                    row.Cells["Statut"].Style.BackColor = System.Drawing.Color.Khaki;
                    row.Cells["Statut"].Style.ForeColor = System.Drawing.Color.DarkOrange;
                }
                else if (statut == "Annulée")
                {
                    row.Cells["Statut"].Style.BackColor = System.Drawing.Color.LightCoral;
                    row.Cells["Statut"].Style.ForeColor = System.Drawing.Color.DarkRed;
                }
                else
                {
                    row.Cells["Statut"].Style.BackColor = System.Drawing.Color.White;
                    row.Cells["Statut"].Style.ForeColor = System.Drawing.Color.Black;
                }

                row.Cells["Statut"].Style.Font = new System.Drawing.Font(dgvReservations.Font, System.Drawing.FontStyle.Bold);
            }
        } 

        private void ViderSaisie()
        {
            cbVoiture.SelectedIndex = -1;
            cbClient.SelectedIndex = -1;
            cbHeureDebut.SelectedIndex = -1;
            cbHeureFin.SelectedIndex = -1;

            dtDateDebut.Value = DateTime.Today;
            dtDateFin.Value = DateTime.Today;

            btnReserver.Enabled = false;
            btnConfirmer.Enabled = false;
            btnAnnuler.Enabled = false;
            reservationIdSelectionnee = -1;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {

            if (cbVoiture.SelectedIndex == -1 || cbClient.SelectedIndex == -1)
            {
                MessageService.Warning("Sélectionnez la voiture et le client.");
                LogHelper.AddLog("Validation voiture/client refusée : sélection incomplète.", Session.Username);
                return;
            }

            MessageService.Success("Voiture et client validés.");
           // LogHelper.AddLog("Voiture et client validés pour réservation.", Session.Username);
        }

        private void btnNouvelle_Click(object sender, EventArgs e)
        {
            ViderSaisie();
        }

        private void btnReserver_Click(object sender, EventArgs e)
        {
            if (!ChampsValides())
                return;

            int voitureId = Convert.ToInt32(cbVoiture.SelectedValue);
            int clientId = Convert.ToInt32(cbClient.SelectedValue);

            DateTime debut = ConstruireDateHeure(dtDateDebut.Value.Date, cbHeureDebut.Text);
            DateTime fin = ConstruireDateHeure(dtDateFin.Value.Date, cbHeureFin.Text);

            if (!VoitureDisponible(voitureId, debut, fin))
            {
                MessageService.Warning("La voiture n'est plus disponible.");
                LogHelper.AddLog("Réservation refusée : voiture non disponible.", Session.Username);
                return;
            }

            decimal prixTotal = ObtenirPrixTotal(voitureId, debut, fin);

            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string insertQuery = @"
                        INSERT INTO reservations
                        (client_id, voiture_id, date_debut, heure_debut, date_fin, heure_fin, prix_total, status, nom_utilisateur)
                        VALUES
                        (@client_id, @voiture_id, @date_debut, @heure_debut, @date_fin, @heure_fin, @prix_total, @status, @nom_utilisateur);";

                    using (MySqlCommand cmd = new MySqlCommand(insertQuery, cn))
                    {
                        cmd.Parameters.AddWithValue("@client_id", clientId);
                        cmd.Parameters.AddWithValue("@voiture_id", voitureId);
                        cmd.Parameters.AddWithValue("@date_debut", debut.Date);
                        cmd.Parameters.AddWithValue("@heure_debut", debut.TimeOfDay);
                        cmd.Parameters.AddWithValue("@date_fin", fin.Date);
                        cmd.Parameters.AddWithValue("@heure_fin", fin.TimeOfDay);
                        cmd.Parameters.AddWithValue("@prix_total", prixTotal);
                        cmd.Parameters.AddWithValue("@status", "En attente");
                        cmd.Parameters.AddWithValue("@nom_utilisateur", Session.Username);

                        cmd.ExecuteNonQuery();
                    }
                }

                LogHelper.AddLog("Réservation ajoutée avec succès. Prix total = " + prixTotal.ToString("0.00") + " DH.", Session.Username);
                MessageService.Success("Réservation ajoutée avec succès.");

                ChargerReservations();
                ViderSaisie();
            }
            catch (Exception ex)
            {
                LogHelper.AddLog("Erreur ajout réservation : " + ex.Message, Session.Username);
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            if (reservationIdSelectionnee <= 0)
            {
                MessageService.Warning("Sélectionnez une réservation dans la liste.");
                return;
            }
            string statut = dgvReservations.CurrentRow.Cells["Statut"].Value?.ToString();
            if (statut != "En attente")
            {
                MessageService.Warning("Seules les réservations en attente peuvent être confirmées.");
                return;
            }

            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string query = @"
                        UPDATE reservations
                        SET status = 'Confirmée'
                        WHERE reservation_id = @reservation_id;";

                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@reservation_id", reservationIdSelectionnee);
                        cmd.ExecuteNonQuery();
                    }
                }

                LogHelper.AddLog("Réservation confirmée. ID = " + reservationIdSelectionnee, Session.Username);
                MessageService.Success("Réservation confirmée.");

                ChargerReservations();
                ViderSaisie();
            }
            catch (Exception ex)
            {
                LogHelper.AddLog("Erreur confirmation réservation : " + ex.Message, Session.Username);
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (reservationIdSelectionnee <= 0)
            {
                MessageService.Warning("Sélectionnez une réservation dans la liste.");
                return;
            }
            string statut = dgvReservations.CurrentRow.Cells["Statut"].Value?.ToString();
            if (statut != "En attente" && statut != "Confirmée")
            {
                MessageService.Warning("Cette réservation ne peut pas être annulée.");
                return;
            }

            if (MessageService.Confirm("Voulez-vous vraiment annuler cette réservation ?") != DialogResult.Yes)
            {
                //LogHelper.AddLog("Annulation réservation interrompue par l'utilisateur.", Session.Username);
                return;
            }

            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string query = @"
                        UPDATE reservations
                        SET status = 'Annulée'
                        WHERE reservation_id = @reservation_id;";

                    using (MySqlCommand cmd = new MySqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@reservation_id", reservationIdSelectionnee);
                        cmd.ExecuteNonQuery();
                    }
                }

                LogHelper.AddLog("Réservation annulée. ID = " + reservationIdSelectionnee, Session.Username);
                MessageService.Success("Réservation annulée.");

                ChargerReservations();
                ViderSaisie();
            }
            catch (Exception ex)
            {
                LogHelper.AddLog("Erreur annulation réservation : " + ex.Message, Session.Username);
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvReservations.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                reservationIdSelectionnee = Convert.ToInt32(dgvReservations.Rows[e.RowIndex].Cells["ID"].Value);

                string statut = dgvReservations.Rows[e.RowIndex].Cells["Statut"].Value?.ToString();

                btnConfirmer.Enabled = (statut == "En attente");
                btnAnnuler.Enabled = (statut == "En attente" || statut == "Confirmée");
            }
        }
    }
}
