using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using venolocation.classee;

namespace venolocation.formee
{
    public partial class liste_contrat : Form
    {

        int id_contrat = -1;
        string matricule_selectionne = "";

        public liste_contrat(int _id_contrat,string _matricule )
        {
            InitializeComponent();
            this.id_contrat = _id_contrat;
            this.matricule_selectionne = _matricule;
        }
        private void ActiverAutoComplete(ComboBox combo)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void remplire_combo()
        {
            DataTable dtCars = Dbexec.GetData(@" SELECT voiture_id, matricule,kilometrage  FROM voitures ORDER BY matricule  LIMIT 500;");

            DataRow drCar = dtCars.NewRow();
            //drCar["voiture_id"] = 0;
            //drCar["matricule"] = "--- Tout ---";
            //dtCars.Rows.InsertAt(drCar, 0);

            cb_voiture.DataSource = dtCars;
            cb_voiture.DisplayMember = "matricule";
            cb_voiture.ValueMember = "voiture_id";
            ActiverAutoComplete(cb_voiture);
            cb_voiture.SelectedIndex = 0;
            
        }
        private void InitialiserHeures()
        {

            cbHeureRetour.Items.Clear();

            for (int h = 0; h < 24; h++)
            {

                cbHeureRetour.Items.Add(h.ToString("00") + ":00");
            }


            cbHeureRetour.SelectedIndex = 1;
        }


        private void liste_contrat_Load(object sender, EventArgs e)
        {
            txt_ancine_voiture.Text = this.matricule_selectionne;
            txt_contrat.Text= this.id_contrat.ToString();
            InitialiserHeures();
            remplire_combo();
            
        }

        private void txtPrixJour_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void cb_voiture_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataRowView row = (DataRowView)cb_voiture.SelectedItem;
            txt_kilometrage.Text = row["kilometrage"].ToString();
        }

        void save()
        {
            string connStr = DbConfig.GetConnectionString();
            using (MySqlConnection cn = new MySqlConnection(connStr))
            {
                cn.Open();
                MySqlTransaction tr = cn.BeginTransaction();

                try
                {
                    // 1. INSERT INTO change table
                    string insert = @"
                            INSERT INTO contrat_changements_voiture
                            (contrat_id, ancienne_voiture_id, nouvelle_voiture_id,
                             date_changement, heure_changement,
                             kilometrage_ancienne, kilometrage_nouvelle,prix, remarque, nom_utilisateur)
                            VALUES
                            (@contrat, @old, @new, @date, @heure, @kold, @knew,@prix, @remarque, @user)";

                    MySqlCommand cmd = new MySqlCommand(insert, cn, tr);

                    cmd.Parameters.AddWithValue("@contrat", txt_contrat.Text);
                    cmd.Parameters.AddWithValue("@old", txt_ancine_voiture.Text);
                    cmd.Parameters.AddWithValue("@new", cb_voiture.SelectedValue);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@heure", DateTime.Now.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@kold", txt_kilometrage_anciene.Text);
                    cmd.Parameters.AddWithValue("@knew", txt_kilometrage.Text);
                    cmd.Parameters.AddWithValue("@prix", Convert.ToDecimal(txt_prix.Text));
                    cmd.Parameters.AddWithValue("@remarque", txtRemarques.Text);
                    cmd.Parameters.AddWithValue("@user", Session.Username);

                    cmd.ExecuteNonQuery();

                    // 2. UPDATE contrats
                    string update = @"
                                    UPDATE contrats
                                    SET voiture_id = @newVoiture,
                                        has_changed = 1
                                    WHERE contrat_id = @contrat";

                    MySqlCommand cmd2 = new MySqlCommand(update, cn, tr);

                    cmd2.Parameters.AddWithValue("@newVoiture", cb_voiture.SelectedValue);
                    cmd2.Parameters.AddWithValue("@contrat", id_contrat);

                    cmd2.ExecuteNonQuery();



                    string updateOldCar = @"
                                    UPDATE voitures
                                    SET kilometrage = @kmAncien,
                                        etat = 'Disponible'
                                    WHERE matricule = @oldId";

                    MySqlCommand cmd3 = new MySqlCommand(updateOldCar, cn, tr);

                    cmd3.Parameters.AddWithValue("@kmAncien", txt_kilometrage_anciene.Text);
                    cmd3.Parameters.AddWithValue("@oldId", txt_ancine_voiture.Text);

                    cmd3.ExecuteNonQuery();




                    string updateNewCar = @"
                                            UPDATE voitures
                                            SET etat = 'En cours'
                                            WHERE voiture_id = @newId";

                    MySqlCommand cmd4 = new MySqlCommand(updateNewCar, cn, tr);

                    cmd4.Parameters.AddWithValue("@newId", cb_voiture.SelectedValue);

                    cmd4.ExecuteNonQuery();


                    if (txt_prix.Text != "0" && !string.IsNullOrEmpty(txt_prix.Text))
                    {
                        string addrecette = @"
                                            INSERT INTO recettes (contrat_id, montant, type, date_recette, nom_utilisateur)
                                            VALUES (@contrat_id, @montant, 'Changement voiture', NOW(), @nom_utilisateur);";

                        MySqlCommand cmd5 = new MySqlCommand(addrecette, cn, tr);

                        cmd5.Parameters.AddWithValue("@contrat_id", txt_contrat.Text);
                        cmd5.Parameters.AddWithValue("@montant", Convert.ToDecimal(txt_prix.Text));
                        cmd5.Parameters.AddWithValue("@nom_utilisateur", Session.Username);

                        cmd5.ExecuteNonQuery();

                    }
                    
                        

                    tr.Commit();
                    LogHelper.AddLog("Changement voiture enregistré avec succès " + txt_contrat.Text.Trim(), Session.Username);
                    MessageBox.Show("Changement enregistré avec succès !");
                
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Erreur: " + ex.Message);
                    dbErreur.AddLog(
                   ex.Message,
                   Session.Username,
                   "change voiture",
                   "save" );
                }
            }
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            
        
            save();
            
        }

        void clear()
        {
            txtRemarques.Text = "";
            txt_kilometrage.Text = "";
            txt_prix.Text = "0";
            cb_voiture.SelectedIndex=-1;
            txt_kilometrage_anciene.Text = "";
        }
        private void pnlVoiture_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnannuller_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void tnImprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int contratId =Convert.ToInt32(txt_contrat.Text);

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

                                -- VOITURE LI LFOU9 = ancienne voiture ila kayn changement
                                COALESCE(va.matricule, v.matricule) AS matricule,
                                COALESCE(va.marque, v.marque) AS marque,
                                COALESCE(va.modele, v.modele) AS modele,
                                COALESCE(va.carburant, v.carburant) AS carburant,
                                COALESCE(va.categorie, v.categorie) AS categorie,

                                -- Km li ghadi iban f Km Départ
                                COALESCE(ch.kilometrage_ancienne, c.kilometrage_sortie) AS km_depart_print,

                                p.ancienne_date_fin,
                                p.ancienne_heure_fin,
                                p.nouvelle_date_fin,
                                p.nouvelle_heure_fin,
                                p.montant_supplementaire,

                                ch.date_changement,
                                ch.heure_changement,
                                ch.kilometrage_ancienne,
                                ch.kilometrage_nouvelle,

                                -- VOITURE JDIDA LI LTAHT F CHANGEMENT
                                vn.marque AS new_marque,
                                vn.modele AS new_modele,
                                vn.matricule AS new_matricule

                            FROM contrats c

                            LEFT JOIN clients cl ON cl.client_id = c.client_id

                            -- voiture actuelle/contrat, fallback ila makanch changement
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

                            -- آخر changement voiture ديال هاد contrat
                            LEFT JOIN (
                                SELECT ch1.*
                                FROM contrat_changements_voiture ch1
                                INNER JOIN (
                                    SELECT contrat_id, MAX(changement_id) AS max_id
                                    FROM contrat_changements_voiture
                                    GROUP BY contrat_id
                                ) z ON z.max_id = ch1.changement_id
                            ) ch ON ch.contrat_id = c.contrat_id

                            -- ancienne voiture mn contrat_changements_voiture
                            LEFT JOIN voitures va ON va.voiture_id = ch.ancienne_voiture_id

                            -- nouvelle voiture mn contrat_changements_voiture
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

                        // HADI VOITURE LI LFOUQ:
                        // ila kayn changement => ancienne voiture
                        // ila makaynch changement => voiture dyal contrat
                        Marque = GetString(dr, "marque"),
                        Modele = GetString(dr, "modele"),
                        TypeVoiture = GetString(dr, "categorie"),
                        Immatriculation = GetString(dr, "matricule"),
                        Carburant = GetString(dr, "carburant"),
                        KmDepart = GetString(dr, "km_depart_print"),
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

                        // HADI VOITURE LI LTAHT:
                        // nouvelle voiture
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
    }
}
