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
    public partial class voiture : Form
    {
        public voiture()
        {
            InitializeComponent();
        }
        string imagePath = "";
        void LoadVoitures()
        {
            using (MySqlConnection cn = Dbexec.GetConnection())
            {
                cn.Open();

                string q = @"SELECT voiture_id, matricule, marque, modele, categorie, carburant, boite,
                            kilometrage, etat, prix_jour, prix_heure, annee, couleur, image_url
                            FROM voitures";

                MySqlDataAdapter da = new MySqlDataAdapter(q, cn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvVoitures.DataSource = dt;
            }
        }
        private void voiture_Load(object sender, EventArgs e)
        {
            LoadVoitures();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtImmatriculation.Text))
                {
                    MessageService.Warning("Matricule obligatoire");
                    LogHelper.AddLog("Ajout voiture refusé : matricule vide", Session.Username);
                    return;
                }

                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = @"INSERT INTO voitures
                    (matricule, marque, modele, categorie, carburant, boite, kilometrage, etat,
                     prix_jour, prix_heure, annee, couleur, image_url, nom_utilisateur)
                    VALUES
                    (@mat, @marque, @modele, @cat, @carb, @boite, @kilomet, @etat,
                     @pj, @ph, @annee, @coul, @img, @user)";

                    MySqlCommand cmd = new MySqlCommand(q, cn);

                    cmd.Parameters.AddWithValue("@mat", txtImmatriculation.Text);
                    cmd.Parameters.AddWithValue("@marque", txtMarque.Text);
                    cmd.Parameters.AddWithValue("@modele", txtModele.Text);
                    cmd.Parameters.AddWithValue("@cat", cmbCategorie.Text);
                    cmd.Parameters.AddWithValue("@carb", cmbTypeCarburant.Text);
                    cmd.Parameters.AddWithValue("@boite", cmbBoiteVitesse.Text);
                    cmd.Parameters.AddWithValue("@kilomet", txtKilometrage.Text);
                    cmd.Parameters.AddWithValue("@etat", cmbEtat.Text);
                    cmd.Parameters.AddWithValue("@pj", txtPrixJour.Text);
                    cmd.Parameters.AddWithValue("@ph", txtPrixHeure.Text);
                    cmd.Parameters.AddWithValue("@annee", txtAnnee.Text);
                    cmd.Parameters.AddWithValue("@coul", txtCouleur.Text);
                    cmd.Parameters.AddWithValue("@img", imagePath);
                    cmd.Parameters.AddWithValue("@user", Session.Username);

                    cmd.ExecuteNonQuery();
                }

                LogHelper.AddLog("Ajout voiture: " + txtImmatriculation.Text, Session.Username);
                MessageService.Success(AppMessages.SaveSuccess);

                LoadVoitures();
            }
            catch (Exception ex)
            {
                LogHelper.AddLog("Erreur ajout voiture: " + ex.Message, Session.Username);
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvVoitures.CurrentRow == null)
                {
                    MessageService.Warning(AppMessages.NoSelection);
                    return;
                }

                int id = Convert.ToInt32(dgvVoitures.CurrentRow.Cells["voiture_id"].Value);

                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = @"UPDATE voitures SET
                    matricule=@mat,
                    marque=@marque,
                    modele=@modele,
                    categorie=@cat,
                    carburant=@carb,
                    boite=@boite,
                    kilometrage=@kilomet,
                    etat=@etat,
                    prix_jour=@pj,
                    prix_heure=@ph,
                    annee=@annee,
                    couleur=@coul,
                    image_url=@img,
                    nom_utilisateur=@user
                    WHERE voiture_id=@id";

                    MySqlCommand cmd = new MySqlCommand(q, cn);

                    cmd.Parameters.AddWithValue("@mat", txtImmatriculation.Text);
                    cmd.Parameters.AddWithValue("@marque", txtMarque.Text);
                    cmd.Parameters.AddWithValue("@modele", txtModele.Text);
                    cmd.Parameters.AddWithValue("@cat", cmbCategorie.Text);
                    cmd.Parameters.AddWithValue("@carb", cmbTypeCarburant.Text);
                    cmd.Parameters.AddWithValue("@boite", cmbBoiteVitesse.Text);
                    cmd.Parameters.AddWithValue("@kilomet", txtKilometrage.Text);
                    cmd.Parameters.AddWithValue("@etat", cmbEtat.Text);
                    cmd.Parameters.AddWithValue("@pj", txtPrixJour.Text);
                    cmd.Parameters.AddWithValue("@ph", txtPrixHeure.Text);
                    cmd.Parameters.AddWithValue("@annee", txtAnnee.Text);
                    cmd.Parameters.AddWithValue("@coul", txtCouleur.Text);
                    cmd.Parameters.AddWithValue("@img", imagePath);
                    cmd.Parameters.AddWithValue("@user", Session.Username);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                LogHelper.AddLog("Modification voiture: " + txtImmatriculation.Text, Session.Username);
                MessageService.Success(AppMessages.UpdateSuccess);

                LoadVoitures();
            }
            catch (Exception ex)
            {
                LogHelper.AddLog("Erreur modification voiture: " + ex.Message, Session.Username);
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvVoitures.CurrentRow == null)
                {
                    MessageService.Warning(AppMessages.NoSelection);
                    return;
                }

                if (MessageService.Confirm(AppMessages.DeleteConfirm) != DialogResult.Yes)
                {
                    LogHelper.AddLog("Suppression voiture annulée", Session.Username);
                    return;
                }

                int id = Convert.ToInt32(dgvVoitures.CurrentRow.Cells["voiture_id"].Value);

                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = "DELETE FROM voitures WHERE voiture_id=@id";
                    MySqlCommand cmd = new MySqlCommand(q, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                LogHelper.AddLog("Suppression voiture: " + txtImmatriculation.Text, Session.Username);
                MessageService.Success(AppMessages.DeleteSuccess);

                LoadVoitures();
            }
            catch (Exception ex)
            {
                LogHelper.AddLog("Erreur suppression voiture: " + ex.Message, Session.Username);
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }
        

        private void btnChoisirImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Images|*.jpg;*.png;*.jpeg";

            if (op.ShowDialog() == DialogResult.OK)
            {
                imagePath = op.FileName;
                pbVoiture.ImageLocation = imagePath;

               // LogHelper.AddLog("Image sélectionnée pour voiture", Session.Username);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();

                    string q = @"SELECT * FROM voitures
                                 WHERE matricule LIKE @s
                                 OR marque LIKE @s
                                 OR modele LIKE @s";

                    MySqlCommand cmd = new MySqlCommand(q, cn);
                    cmd.Parameters.AddWithValue("@s", "%" + txtRecherche.Text + "%");

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvVoitures.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                LogHelper.AddLog("Erreur recherche voiture: " + ex.Message, Session.Username);
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }


        private void dgvVoitures_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                var r = dgvVoitures.Rows[e.RowIndex];

                txtImmatriculation.Text = r.Cells["matricule"].Value?.ToString();
                txtMarque.Text = r.Cells["marque"].Value?.ToString();
                txtModele.Text = r.Cells["modele"].Value?.ToString();
                cmbCategorie.Text = r.Cells["categorie"].Value?.ToString();
                cmbTypeCarburant.Text = r.Cells["carburant"].Value?.ToString();
                cmbBoiteVitesse.Text = r.Cells["boite"].Value?.ToString();
                cmbEtat.Text = r.Cells["etat"].Value?.ToString();
                txtKilometrage.Text = r.Cells["kilometrage"].Value?.ToString();
                txtPrixJour.Text = r.Cells["prix_jour"].Value?.ToString();
                txtPrixHeure.Text = r.Cells["prix_heure"].Value?.ToString();
                txtAnnee.Text = r.Cells["annee"].Value?.ToString();
                txtCouleur.Text = r.Cells["couleur"].Value?.ToString();

                if (dgvVoitures.Columns.Contains("image_url") && r.Cells["image_url"].Value != DBNull.Value)
                {
                    imagePath = r.Cells["image_url"].Value?.ToString();

                    if (!string.IsNullOrWhiteSpace(imagePath))
                        pbVoiture.ImageLocation = imagePath;
                    else
                        pbVoiture.Image = null;
                }
                else
                {
                    imagePath = "";
                    pbVoiture.Image = null;
                }
            }
        }
    }
}
