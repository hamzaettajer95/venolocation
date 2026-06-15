using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using venolocation.classee;

namespace venolocation.formee
{
    public partial class prolongation : Form
    {
        int idContrat;
        public prolongation(int _idContrat)
        {
            InitializeComponent();
            idContrat = _idContrat;
        }


        //public DataTable LoadContrats()
        //{
        //    DataTable table = new DataTable();

        //    try
        //    {
        //        using (MySqlConnection cn = new MySqlConnection(DbConfig.GetConnectionString()))
        //        {
        //            cn.Open();

        //            string sql = @"
        //                        SELECT
        //                            contrat_id,
        //                            client_id,
        //                            voiture_id,
        //                            reservation_id,
        //                            date_contrat,
        //                            heure_debut,
        //                            date_retour_prevu,
        //                            heure_retour_prevu,
        //                            kilometrage_sortie,
        //                            kilometrage_retour,
        //                            prix_jour,
        //                            prix_heure,
        //                            avance,
        //                            total,
        //                            status,
        //                            has_changed,
        //                            nom_utilisateur,
        //                            created_at
        //                        FROM contrats
        //                            where contrat_id = @id";

        //            using (MySqlCommand cmd = new MySqlCommand(sql, cn))
        //            {
        //                cmd.Parameters.AddWithValue("@id", this.idContrat);

        //                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
        //                {
        //                    da.Fill(table);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    return table;
        //}


        public DataTable LoadContrats()
        {
            DataTable table = new DataTable();

            try
            {
                using (MySqlConnection cn = new MySqlConnection(DbConfig.GetConnectionString()))
                {
                    cn.Open();

                    string sql = @"
                        SELECT 
                            c.contrat_id ,

                            c.client_id ,
                            cl.cin ,

                            c.voiture_id ,
                            v.matricule ,

                            c.status,
                            c.date_contrat, 
                            c.date_retour_prevu, 
                            c.heure_retour_prevu,
                            c.prix_jour,
                            c.prix_heure,
                            c.total 
                        FROM contrats c
                        LEFT JOIN clients cl ON cl.client_id = c.client_id
                        LEFT JOIN voitures v ON v.voiture_id = c.voiture_id
                        WHERE contrat_id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", this.idContrat);

                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            da.Fill(table);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return table;
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

        decimal prixJour;
        decimal prixHeure;
        DateTime dateRetourPrevu;
        string heureretour;

        private DateTime ConstruireDateHeure(DateTime date, string heure)
        {
            if (string.IsNullOrWhiteSpace(heure))
                return date;

            TimeSpan ts;

            if (!TimeSpan.TryParse(heure, out ts))
                return date;

            return date.Date.Add(ts);
        }
        private int CalculerNombreJours()
        {
            DateTime debut = ConstruireDateHeure(dateRetourPrevu.Date, heureretour);
            DateTime fin = ConstruireDateHeure(dtDateFin.Value.Date, cbHeureRetour.Text);

            int jours = (fin.Date - debut.Date).Days;

            if (jours < 1)
                jours = 1;

            return jours;
        }
        private decimal CalculerTotal()
        {
            DateTime debut = ConstruireDateHeure(dateRetourPrevu.Date, heureretour);
            DateTime fin = ConstruireDateHeure(dtDateFin.Value.Date, cbHeureRetour.Text);

            if (fin <= debut)
                return prixHeure;

            TimeSpan diff = fin - debut;

            
            int jours = (int)Math.Floor(diff.TotalDays);

           
            int heures = diff.Hours;

           
            if (diff.Minutes > 0 || diff.Seconds > 0)
                heures++;

           
            if (jours < 0) jours = 0;
            if (heures < 0) heures = 0;

            decimal total = (jours * prixJour) + (heures * prixHeure);

            return total;
        }
        void importer_donne()
        {
            DataTable table = LoadContrats();

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Aucun contrat trouvé !");
                return;
            }

            DataRow contrat = table.Rows[0];

            txt_id_contrat.Text = idContrat.ToString();

            prixJour = Convert.ToDecimal(contrat["prix_jour"]);
            prixHeure = Convert.ToDecimal(contrat["prix_heure"]);

            dateRetourPrevu = Convert.ToDateTime(contrat["date_retour_prevu"]);

            heureretour = contrat["heure_retour_prevu"]?.ToString() ?? "00:00";
        }

        private void prolongation_Load(object sender, EventArgs e)
        {
            InitialiserHeures();
            
            importer_donne();

            txtNombreJours.Text = CalculerNombreJours().ToString();
            txtTtl.Text = CalculerTotal().ToString("0.00");
        }

       
        private void btncalculer_Click(object sender, EventArgs e)
        {
            importer_donne();

            txtNombreJours.Text = CalculerNombreJours().ToString();
            txtTtl.Text = CalculerTotal().ToString("0.00");

            decimal avance = 0;

            if (!decimal.TryParse(txt_Avance.Text, out avance))
            {
                MessageBox.Show("Entrer un montant valide pour l'avance");
                txt_Avance.Focus();
                return;
            }

            decimal reste = CalculerTotal() - avance;

            if (reste < 0)
                reste = 0;

            txtRestePayer.Text = reste.ToString("0.00");
        }

        private void tnImprimer_Click(object sender, EventArgs e)
        {
            try
            {
                int contratId = Convert.ToInt32(txt_id_contrat.Text);

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

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {

        }
    }
}
