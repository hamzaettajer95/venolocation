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
        public reservation()
        {
            InitializeComponent();
        }



        private void ColorierStatutsReservations()
        {
            if (!dgvReservations.Columns.Contains("Statut"))
                return;

            foreach (DataGridViewRow row in dgvReservations.Rows)
            {
                if (row.IsNewRow || row.Cells["Statut"].Value == null)
                    continue;

                string statut = row.Cells["Statut"].Value.ToString().Trim();
                DataGridViewCell cell = row.Cells["Statut"];

                cell.Style.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (statut == AppStatus.ReservationConfirmee)
                {
                    cell.Style.BackColor = Color.FromArgb(220, 245, 228);
                    cell.Style.ForeColor = Color.FromArgb(28, 137, 74);
                    cell.Style.SelectionBackColor = Color.FromArgb(200, 235, 214);
                    cell.Style.SelectionForeColor = Color.FromArgb(28, 137, 74);
                }
                else if (statut == AppStatus.ReservationEnAttente)
                {
                    cell.Style.BackColor = Color.FromArgb(255, 239, 213);
                    cell.Style.ForeColor = Color.FromArgb(212, 133, 0);
                    cell.Style.SelectionBackColor = Color.FromArgb(250, 228, 190);
                    cell.Style.SelectionForeColor = Color.FromArgb(212, 133, 0);
                }
                else if (statut == AppStatus.ReservationAnnulee)
                {
                    cell.Style.BackColor = Color.FromArgb(252, 220, 220);
                    cell.Style.ForeColor = Color.FromArgb(200, 55, 55);
                    cell.Style.SelectionBackColor = Color.FromArgb(245, 205, 205);
                    cell.Style.SelectionForeColor = Color.FromArgb(200, 55, 55);
                }
                else if (statut == AppStatus.ReservationTerminee)
                {
                    cell.Style.BackColor = Color.FromArgb(220, 232, 248);
                    cell.Style.ForeColor = Color.FromArgb(53, 100, 170);
                    cell.Style.SelectionBackColor = Color.FromArgb(205, 222, 245);
                    cell.Style.SelectionForeColor = Color.FromArgb(53, 100, 170);
                }
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
            try
            {
                string query = @"
                                SELECT 
                                    voiture_id, 
                                    CONCAT(matricule, ' - ', marque, ' ', modele) AS voiture
                                FROM voitures
                                WHERE etat = @etat OR etat IS NULL
                                ORDER BY matricule
                                LIMIT 500;";

                MySqlParameter[] ps =
                {
            new MySqlParameter("@etat", AppStatus.VoitureDisponible)
        };

                DataTable dt = Dbexec.GetData(query, ps);

                cbVoiture.DataSource = dt;
                cbVoiture.DisplayMember = "voiture";
                cbVoiture.ValueMember = "voiture_id";
                cbVoiture.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reservation", "ChargerVoitures");
                MessageBox.Show("Erreur chargement voiture : " + ex.Message);
            }
        }

        private void ChargerClients()
        {
            try
            {
                string query = @"
                                SELECT 
                                    client_id, 
                                    CONCAT(nom, ' ', prenom, ' - ', cin) AS client
                                FROM clients
                                ORDER BY nom, prenom
                                LIMIT 500;";

                DataTable dt = Dbexec.GetData(query);

                cbClient.DataSource = dt;
                cbClient.DisplayMember = "client";
                cbClient.ValueMember = "client_id";
                cbClient.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reservation", "ChargerClients");
                MessageBox.Show("Erreur chargement clients : " + ex.Message);
            }
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

            try
            {
                string query = @"
                                SELECT prix_jour, prix_heure
                                FROM voitures
                                WHERE voiture_id = @voiture_id
                                LIMIT 1;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@voiture_id", voitureId)
                };

                DataTable dt = Dbexec.GetData(query, ps);

                if (dt.Rows.Count > 0)
                {
                    prixJour = dt.Rows[0]["prix_jour"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["prix_jour"]);
                    prixHeure = dt.Rows[0]["prix_heure"] == DBNull.Value ? 0 : Convert.ToDecimal(dt.Rows[0]["prix_heure"]);
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
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reservation", "ObtenirPrixTotal");
                return 0;
            }
        }

        private bool VoitureDisponible(int voitureId, DateTime debut, DateTime fin)
        {
            try
            {
                string queryReservations = @"
                            SELECT COUNT(*)
                            FROM reservations
                            WHERE voiture_id = @voiture_id
                              AND status = @status
                              AND ((@debut < TIMESTAMP(date_fin, heure_fin))
                              AND (@fin > TIMESTAMP(date_debut, heure_debut)));";

                MySqlParameter[] psReservations =
                {
                    new MySqlParameter("@voiture_id", voitureId),
                    new MySqlParameter("@status", AppStatus.ReservationConfirmee),
                    new MySqlParameter("@debut", debut),
                    new MySqlParameter("@fin", fin)
                };

                if (Dbexec.ExecuteScalarInt(queryReservations, psReservations) > 0)
                    return false;

                string queryContrats = @"
                        SELECT COUNT(*)
                        FROM contrats
                        WHERE voiture_id = @voiture_id
                          AND status = @status
                          AND (
                                (@debut < TIMESTAMP(date_retour_prevu, heure_retour_prevu))
                                AND
                                (@fin > TIMESTAMP(date_contrat, heure_debut))
                              );";

                MySqlParameter[] psContrats =
                {
                    new MySqlParameter("@voiture_id", voitureId),
                    new MySqlParameter("@status", AppStatus.ContratEnCours),
                    new MySqlParameter("@debut", debut),
                    new MySqlParameter("@fin", fin)
                };

                if (Dbexec.ExecuteScalarInt(queryContrats, psContrats) > 0)
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reservation", "VoitureDisponible");
                return false;
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

        private void ChargerReservations()
        {
            try
            {
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
                                ORDER BY r.reservation_id DESC
                                LIMIT 300;";

                dgvReservations.DataSource = Dbexec.GetData(query);

                GridStyleHelper_1.Apply(dgvReservations);

                if (dgvReservations.Columns.Count > 0)
                {
                    dgvReservations.Columns["ID"].FillWeight = 10;
                    dgvReservations.Columns["Voiture"].FillWeight = 30;
                    dgvReservations.Columns["Client"].FillWeight = 25;
                    dgvReservations.Columns["Date Début"].FillWeight = 20;
                    dgvReservations.Columns["Date Fin"].FillWeight = 20;
                    dgvReservations.Columns["Statut"].FillWeight = 16;

                    GridStyleHelper_1.AlignLeft(dgvReservations, "Voiture");
                    GridStyleHelper_1.AlignLeft(dgvReservations, "Client");
                }

                ColorierStatutsReservations();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reservation", "ChargerReservations");
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


        private int reservationIdSelectionnee = -1;
        private void n_reservation_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                InitialiserHeures();
                ChargerVoitures();
                ChargerClients();
                ChargerReservations();
                InitialiserFormulaire();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reservation", "n_reservation_Load");
                MessageService.Error(AppMessages.UnexpectedError);
            }
            finally
            {
                this.ResumeLayout();
            }
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
                string insertQuery = @"
                            INSERT INTO reservations
                            (client_id, voiture_id, date_debut, heure_debut, date_fin, heure_fin, prix_total, status, nom_utilisateur)
                            VALUES
                            (@client_id, @voiture_id, @date_debut, @heure_debut, @date_fin, @heure_fin, @prix_total, @status, @nom_utilisateur);";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@client_id", clientId),
                    new MySqlParameter("@voiture_id", voitureId),
                    new MySqlParameter("@date_debut", debut.Date),
                    new MySqlParameter("@heure_debut", debut.TimeOfDay),
                    new MySqlParameter("@date_fin", fin.Date),
                    new MySqlParameter("@heure_fin", fin.TimeOfDay),
                    new MySqlParameter("@prix_total", prixTotal),
                    new MySqlParameter("@status", AppStatus.ReservationEnAttente),
                    new MySqlParameter("@nom_utilisateur", Session.Username)
                };

                Dbexec.ExecuteQuery(insertQuery, ps);

                LogHelper.AddLog("Réservation ajoutée avec succès. Prix total = " + prixTotal.ToString("0.00") + " DH.", Session.Username);
                MessageService.Success("Réservation ajoutée avec succès.");

                ChargerReservations();
                ViderSaisie();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reservation", "btnReserver_Click");
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

            if (statut != AppStatus.ReservationEnAttente)
            {
                MessageService.Warning("Seules les réservations en attente peuvent être confirmées.");
                return;
            }

            try
            {
                string query = @"
                            UPDATE reservations
                            SET status = @status
                            WHERE reservation_id = @reservation_id;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@status", AppStatus.ReservationConfirmee),
                    new MySqlParameter("@reservation_id", reservationIdSelectionnee)
                };

                Dbexec.ExecuteQuery(query, ps);

                LogHelper.AddLog("Réservation confirmée. ID = " + reservationIdSelectionnee, Session.Username);
                MessageService.Success("Réservation confirmée.");

                ChargerReservations();
                ViderSaisie();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reservation", "btnConfirmer_Click");
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

            if (statut != AppStatus.ReservationEnAttente && statut != AppStatus.ReservationConfirmee)
            {
                MessageService.Warning("Cette réservation ne peut pas être annulée.");
                return;
            }

            if (MessageService.Confirm("Voulez-vous vraiment annuler cette réservation ?") != DialogResult.Yes)
                return;

            try
            {
                        string query = @"
                UPDATE reservations
                SET status = @status
                WHERE reservation_id = @reservation_id;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@status", AppStatus.ReservationAnnulee),
                    new MySqlParameter("@reservation_id", reservationIdSelectionnee)
                };

                Dbexec.ExecuteQuery(query, ps);

                LogHelper.AddLog("Réservation annulée. ID = " + reservationIdSelectionnee, Session.Username);
                MessageService.Success("Réservation annulée.");

                ChargerReservations();
                ViderSaisie();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "reservation", "btnAnnuler_Click");
                MessageService.Error(AppMessages.UnexpectedError);
            }
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
        }

        private void btnVerifierDate_Click(object sender, EventArgs e)
        {

        }

        private void btnVerifierDate_Click_1(object sender, EventArgs e)
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
                dbErreur.AddLog(ex.Message, Session.Username, "n_reservation", "btnVerifierDate_Click_1");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvReservations.Rows[e.RowIndex].Cells["ID"].Value != null)
            {
                reservationIdSelectionnee = Convert.ToInt32(dgvReservations.Rows[e.RowIndex].Cells["ID"].Value);

                string statut = dgvReservations.Rows[e.RowIndex].Cells["Statut"].Value?.ToString();

                btnConfirmer.Enabled = (statut == AppStatus.ReservationEnAttente);
                btnAnnuler.Enabled = (statut == AppStatus.ReservationEnAttente || statut == AppStatus.ReservationConfirmee);
            }
        }
    }
}
