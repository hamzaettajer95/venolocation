using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using venolocation.classee;
using venolocation.formee;



namespace venolocation.droit
{
    public partial class historique_contrats : Form
    {
        public historique_contrats()
        {
            InitializeComponent();
        }

        private int contratIdSelectionne = 0;
        private void LoadContracts()
        {
            try
            {
                string selectedStatus = cb_statut.SelectedItem == null
                    ? "--- Tout ---"
                    : cb_statut.SelectedItem.ToString();

                bool afficherArchive = chkArchive.Checked;

                string tableName = afficherArchive ? "contrats_archive" : "contrats";

                List<MySqlParameter> ps = new List<MySqlParameter>();

                string query = @"
                        SELECT 
                            c.contrat_id AS 'ID',

                            c.client_id AS 'Client ID',
                            cl.cin AS 'CIN Client',

                            c.voiture_id AS 'Voiture ID',
                            v.matricule AS 'Matricule',

                            c.status AS 'Statut',
                            DATE_FORMAT(c.date_contrat, '%d/%m/%Y') AS 'Date contrat',
                            DATE_FORMAT(c.date_retour_prevu, '%d/%m/%Y') AS 'Retour prévu',
                            c.total AS 'Total'
                        FROM " + tableName + @" c
                        LEFT JOIN clients cl ON cl.client_id = c.client_id
                        LEFT JOIN voitures v ON v.voiture_id = c.voiture_id
                        WHERE 1=1 ";

                if (cb_client.SelectedValue != null && Convert.ToInt32(cb_client.SelectedValue) > 0)
                {
                    query += " AND c.client_id = @client_id ";
                    ps.Add(new MySqlParameter("@client_id", Convert.ToInt32(cb_client.SelectedValue)));
                }

                if (cb_voiture.SelectedValue != null && Convert.ToInt32(cb_voiture.SelectedValue) > 0)
                {
                    query += " AND c.voiture_id = @voiture_id ";
                    ps.Add(new MySqlParameter("@voiture_id", Convert.ToInt32(cb_voiture.SelectedValue)));
                }

                if (selectedStatus != "--- Tout ---")
                {
                    query += " AND c.status = @status ";
                    ps.Add(new MySqlParameter("@status", selectedStatus));
                }

                
                if (chkFiltrerDate.Checked)
                {
                    query += @"
                            AND DATE(c.date_contrat) >= @date_debut
                            AND DATE(c.date_retour_prevu) <= @date_fin ";

                    ps.Add(new MySqlParameter("@date_debut", dtp_debut.Value.Date));
                    ps.Add(new MySqlParameter("@date_fin", dtp_fin.Value.Date));
                }

                query += @"
                            ORDER BY c.contrat_id DESC
                            LIMIT 400;
                        ";

                dgvHistory.DataSource = Dbexec.GetData(query, ps.ToArray());

                GridStyleHelper_1.Apply(dgvHistory);

                if (dgvHistory.Columns.Count > 0)
                {
                    
                    if (dgvHistory.Columns.Contains("Client ID"))
                        dgvHistory.Columns["Client ID"].Visible = false;

                    if (dgvHistory.Columns.Contains("Voiture ID"))
                        dgvHistory.Columns["Voiture ID"].Visible = false;

                    dgvHistory.Columns["ID"].FillWeight = 8;
                    dgvHistory.Columns["CIN Client"].FillWeight = 18;
                    dgvHistory.Columns["Matricule"].FillWeight = 18;
                    dgvHistory.Columns["Statut"].FillWeight = 16;
                    dgvHistory.Columns["Date contrat"].FillWeight = 16;
                    dgvHistory.Columns["Retour prévu"].FillWeight = 16;
                    dgvHistory.Columns["Total"].FillWeight = 12;
                }
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "historique_contrats", "LoadContracts");

                dbErreur.AddLog(
                    ex.Message,
                    Session.Username,
                    "historique_contrats",
                    "LoadContracts"
                );

                MessageBox.Show(
                    "Erreur lors de la récupération des données : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void ActiverAutoComplete(ComboBox combo)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void FillCombos()
        {
            try
            {
                DataTable dtClients = Dbexec.GetData(@"SELECT client_id, cin FROM clients ORDER BY cin LIMIT 500;");

                DataRow drClient = dtClients.NewRow();
                drClient["client_id"] = 0;
                drClient["cin"] = "--- Tout ---";
                dtClients.Rows.InsertAt(drClient, 0);

                cb_client.DataSource = dtClients;
                cb_client.DisplayMember = "cin";
                cb_client.ValueMember = "client_id";
                ActiverAutoComplete(cb_client);


                DataTable dtCars = Dbexec.GetData(@" SELECT voiture_id, matricule  FROM voitures ORDER BY matricule  LIMIT 500;");

                DataRow drCar = dtCars.NewRow();
                drCar["voiture_id"] = 0;
                drCar["matricule"] = "--- Tout ---";
                dtCars.Rows.InsertAt(drCar, 0);

                cb_voiture.DataSource = dtCars;
                cb_voiture.DisplayMember = "matricule";
                cb_voiture.ValueMember = "voiture_id";
                ActiverAutoComplete(cb_voiture);

                cb_client.SelectedIndex = 0;
                cb_voiture.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "historique_contrats", "FillCombos");
                dbErreur.AddLog(ex.Message, Session.Username, "historique_contrats", "FillCombos");
                MessageBox.Show("Erreur lors du chargement des listes : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void historique_contrats_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                FillCombos();

                chkFiltrerDate.Checked = false;
                dtp_debut.Enabled = false;
                dtp_fin.Enabled = false;

                cb_statut.Items.Clear();
                cb_statut.Items.Add("--- Tout ---");
                cb_statut.Items.Add(AppStatus.ContratEnCours);
                cb_statut.Items.Add(AppStatus.ContratTermine);
                cb_statut.Items.Add(AppStatus.ContratAnnule);
                cb_statut.SelectedIndex = 0;

                
                dtp_debut.Value = DateTime.Now.AddMonths(-1);
                dtp_fin.Value = DateTime.Now.AddMonths(1);

                chkFiltrerDate.Checked = false;
                dtp_debut.Enabled = false;
                dtp_fin.Enabled = false;

                LoadContracts();

                
            }
            catch (Exception ex)
            {
               // ErrorReporter.SendError(ex, "historique_contrats", "historique_contrats_Load");
                dbErreur.AddLog(ex.Message, Session.Username, "historique_contrats", "historique_contrats_Load");
                MessageBox.Show("Erreur lors du chargement du formulaire : " + ex.Message);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void btnannuller_Click(object sender, EventArgs e)
        {
           
            
        }

        private void dgvHistory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvHistory.CurrentRow == null || dgvHistory.CurrentRow.Cells["Statut"].Value == null)
                return;

            if (chkArchive.Checked)
            {
                btnAnnuler.Enabled = false;
                return;
            }

            string status = dgvHistory.CurrentRow.Cells["Statut"].Value.ToString();
            btnAnnuler.Enabled = (status == AppStatus.ContratEnCours);


            contratIdSelectionne = Convert.ToInt32(dgvHistory.CurrentRow.Cells["ID"].Value);
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {

            LoadContracts();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            AnnulerContratSelectionne();
        }

        private void AnnulerContratSelectionne()
        {
            if (dgvHistory.CurrentRow == null)
                return;

            string status = dgvHistory.CurrentRow.Cells["Statut"].Value == null
                ? ""
                : dgvHistory.CurrentRow.Cells["Statut"].Value.ToString();

            if (status != AppStatus.ContratEnCours)
            {
                MessageBox.Show(
                    "Vous ne pouvez pas annuler un contrat déjà terminé ou annulé.",
                    "Action Interdite",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            int idContrat = Convert.ToInt32(dgvHistory.CurrentRow.Cells["ID"].Value);
            int idVoiture = Convert.ToInt32(dgvHistory.CurrentRow.Cells["Voiture ID"].Value);

            DialogResult res = MessageBox.Show(
                "Êtes-vous sûr de vouloir annuler ce contrat ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (res != DialogResult.Yes)
                return;

            try
            {
                // 1) Changer seulement le statut du contrat
                string updateContrat = @"
            UPDATE contrats
            SET status = @status
            WHERE contrat_id = @id;";

                Dbexec.ExecuteQuery(
                    updateContrat,
                    new MySqlParameter[]
                    {
                new MySqlParameter("@status", AppStatus.ContratAnnule),
                new MySqlParameter("@id", idContrat)
                    }
                );

                // 2) Libérer la voiture
                string updateVoiture = @"
            UPDATE voitures
            SET etat = @etat
            WHERE voiture_id = @vid;";

                Dbexec.ExecuteQuery(
                    updateVoiture,
                    new MySqlParameter[]
                    {
                new MySqlParameter("@etat", AppStatus.VoitureDisponible),
                new MySqlParameter("@vid", idVoiture)
                    }
                );

                LogHelper.AddLog("Annulation contrat ID: " + idContrat, Session.Username);

                MessageBox.Show(
                    "Contrat annulé avec succès et véhicule libéré.",
                    "Succès",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadContracts();
                id_contrat_selectionne = -1;
                matricule_selectionne = "";
                panel2.Enabled = false;
            }
            catch (Exception ex)
            {
                ErrorReporter.SendError(ex, "historique_contrats", "AnnulerContratSelectionne");

                dbErreur.AddLog(
                    ex.Message,
                    Session.Username,
                    "historique_contrats",
                    "AnnulerContratSelectionne"
                );

                MessageBox.Show(
                    "Echec de l'opération : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void chkArchive_CheckedChanged(object sender, EventArgs e)
        {
            cb_statut.Items.Clear();
            cb_statut.Items.Add("--- Tout ---");

            if (chkArchive.Checked)
            {
                cb_statut.Items.Add(AppStatus.ContratTermine);
                cb_statut.Items.Add(AppStatus.ContratAnnule);
            }
            else
            {
                cb_statut.Items.Add(AppStatus.ContratEnCours);
                cb_statut.Items.Add(AppStatus.ContratTermine);
                cb_statut.Items.Add(AppStatus.ContratAnnule);
            }

            cb_statut.SelectedIndex = 0;

           
            LoadContracts();
        }

        private void btnimprimer_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (dgvHistory.Rows.Count == 0)
            //    {
            //        MessageBox.Show(
            //            "Aucune donnée à imprimer.",
            //            "Impression",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Warning
            //        );
            //        return;
            //    }

            //    DataGridViewPrinter printer = new DataGridViewPrinter(
            //        dgvHistory,
            //        "Historique des contrats",
            //        Session.Username
            //    );

            //    printer.ShowPreview();
            //}
            //catch (Exception ex)
            //{


            //    dbErreur.AddLog(
            //        ex.Message,
            //        Session.Username,
            //        "historique_contrats",
            //        "btnImprimer_Click"
            //    );

            //    MessageBox.Show(
            //        "Erreur lors de l'impression : " + ex.Message,
            //        "Erreur",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Error
            //    );
            //}

            try
            {
                int contratId = id_contrat_selectionne;

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



                ContratLocationPrinter printer = new ContratLocationPrinter(
                    data,
                    pictureBoxLogo.Image,
                    pictureBoxEtatVoiture.Image,
                    pictureBoxEtatVoiture2.Image
                );

                printer.ShowPreview();
                id_contrat_selectionne = -1;
                matricule_selectionne ="";
                panel2.Enabled = false;
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
       
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkFiltrerDate_CheckedChanged(object sender, EventArgs e)
        {
            dtp_debut.Enabled = chkFiltrerDate.Checked;
            dtp_fin.Enabled = chkFiltrerDate.Checked;

            LoadContracts();
            id_contrat_selectionne = -1;
            matricule_selectionne = "";
            panel2.Enabled = false;
        }

        private void btn_prolongation_Click(object sender, EventArgs e)
        {
            prolongation po = new prolongation(id_contrat_selectionne);
            po.ShowDialog();

            id_contrat_selectionne = -1;
            matricule_selectionne = "";
            panel2.Enabled = false;
        }

        private void btn_change_voiture_Click(object sender, EventArgs e)
        {
            liste_contrat li = new liste_contrat(id_contrat_selectionne, matricule_selectionne);
            li.ShowDialog();
            id_contrat_selectionne = -1;
            matricule_selectionne = "";
            panel2.Enabled = false;
        }



        int id_contrat_selectionne = -1;
        string matricule_selectionne = "";
        private void dgvHistory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHistory.Rows[e.RowIndex];

                id_contrat_selectionne =Convert.ToInt16( row.Cells[0].Value.ToString());
                matricule_selectionne = row.Cells["Matricule"].Value.ToString();
                panel2.Enabled = true;
            }
        }
    }
}
