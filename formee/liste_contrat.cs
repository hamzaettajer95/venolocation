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
                             kilometrage_ancienne, kilometrage_nouvelle, remarque, nom_utilisateur)
                            VALUES
                            (@contrat, @old, @new, @date, @heure, @kold, @knew, @remarque, @user)";

                    MySqlCommand cmd = new MySqlCommand(insert, cn, tr);

                    cmd.Parameters.AddWithValue("@contrat", txt_contrat.Text);
                    cmd.Parameters.AddWithValue("@old", txt_ancine_voiture.Text);
                    cmd.Parameters.AddWithValue("@new", cb_voiture.SelectedValue);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                    cmd.Parameters.AddWithValue("@heure", DateTime.Now.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@kold", txt_kilometrage_anciene.Text);
                    cmd.Parameters.AddWithValue("@knew", txt_kilometrage.Text);
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
                    cmd2.Parameters.AddWithValue("@contrat", txt_contrat.Text);

                    cmd2.ExecuteNonQuery();



                    string updateOldCar = @"
                                    UPDATE voitures
                                    SET kilometrage = @kmAncien,
                                        etat = 'Disponible'
                                    WHERE voiture_id = @oldId";

                    MySqlCommand cmd3 = new MySqlCommand(updateOldCar, cn, tr);

                    cmd3.Parameters.AddWithValue("@kmAncien", txt_kilometrage_anciene.Text);
                    cmd3.Parameters.AddWithValue("@oldId", txt_ancine_voiture.Text);

                    cmd3.ExecuteNonQuery();




                    string updateNewCar = @"
                                            UPDATE voitures
                                            SET etat = 'En cours'
                                            WHERE matricule = @newId";

                    MySqlCommand cmd4 = new MySqlCommand(updateNewCar, cn, tr);

                    cmd4.Parameters.AddWithValue("@newId", cb_voiture.SelectedValue);

                    cmd4.ExecuteNonQuery();
                    tr.Commit();
                    LogHelper.AddLog("Changement enregistré avec succès " + txt_contrat.Text.Trim(), Session.Username);
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
    }
}
