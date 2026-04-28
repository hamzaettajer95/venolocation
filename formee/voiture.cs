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
            try
            {
                string q = @"
                        SELECT 
                            voiture_id AS 'ID',
                            matricule AS 'Matricule',
                            marque AS 'Marque',
                            modele AS 'Modèle',
                            categorie AS 'Catégorie',
                            carburant AS 'Carburant',
                            boite AS 'Boite',
                            kilometrage AS 'Kilométrage',
                            etat AS 'État',
                            prix_jour AS 'Prix jour',
                            prix_heure AS 'Prix heure',
                            annee AS 'Année',
                            couleur AS 'Couleur',
                            image_url AS 'Image'
                        FROM voitures
                        ORDER BY voiture_id DESC
                        LIMIT 300;";

                dgvVoitures.DataSource = Dbexec.GetData(q);

                GridStyleHelper_1.Apply(dgvVoitures);

                if (dgvVoitures.Columns.Count > 0)
                {
                    dgvVoitures.Columns["ID"].FillWeight = 8;
                    dgvVoitures.Columns["Matricule"].FillWeight = 16;
                    dgvVoitures.Columns["Marque"].FillWeight = 16;
                    dgvVoitures.Columns["Modèle"].FillWeight = 16;
                    dgvVoitures.Columns["Catégorie"].FillWeight = 16;
                    dgvVoitures.Columns["Carburant"].FillWeight = 15;
                    dgvVoitures.Columns["Boite"].FillWeight = 14;
                    dgvVoitures.Columns["Kilométrage"].FillWeight = 16;
                    dgvVoitures.Columns["État"].FillWeight = 15;
                    dgvVoitures.Columns["Prix jour"].FillWeight = 14;
                    dgvVoitures.Columns["Prix heure"].FillWeight = 14;
                    dgvVoitures.Columns["Année"].FillWeight = 12;
                    dgvVoitures.Columns["Couleur"].FillWeight = 14;

                    GridStyleHelper_1.HideColumn(dgvVoitures, "Image");

                    GridStyleHelper_1.AlignLeft(dgvVoitures, "Matricule");
                    GridStyleHelper_1.AlignLeft(dgvVoitures, "Marque");
                    GridStyleHelper_1.AlignLeft(dgvVoitures, "Modèle");
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture", "LoadVoitures");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }
        private void voiture_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                LoadVoitures();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture", "voiture_Load");
                MessageService.Error(AppMessages.UnexpectedError);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
           
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {

           
        }

        

        private void btnSupprimer_Click(object sender, EventArgs e)
        {

            
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
            clear();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
          
            try
            {
                string q = @"
                        SELECT 
                            voiture_id AS 'ID',
                            matricule AS 'Matricule',
                            marque AS 'Marque',
                            modele AS 'Modèle',
                            categorie AS 'Catégorie',
                            carburant AS 'Carburant',
                            boite AS 'Boite',
                            kilometrage AS 'Kilométrage',
                            etat AS 'État',
                            prix_jour AS 'Prix jour',
                            prix_heure AS 'Prix heure',
                            annee AS 'Année',
                            couleur AS 'Couleur',
                            image_url AS 'Image'
                        FROM voitures
                        WHERE matricule LIKE @s
                           OR marque LIKE @s
                           OR modele LIKE @s
                           OR categorie LIKE @s
                           OR carburant LIKE @s
                        ORDER BY voiture_id DESC
                        LIMIT 100;";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@s", "%" + txtRecherche.Text.Trim() + "%")
                };

                dgvVoitures.DataSource = Dbexec.GetData(q, ps);

                GridStyleHelper_1.Apply(dgvVoitures);

                if (dgvVoitures.Columns.Count > 0)
                {
                    GridStyleHelper_1.HideColumn(dgvVoitures, "Image");

                    GridStyleHelper_1.AlignLeft(dgvVoitures, "Matricule");
                    GridStyleHelper_1.AlignLeft(dgvVoitures, "Marque");
                    GridStyleHelper_1.AlignLeft(dgvVoitures, "Modèle");
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture", "btnRecherche_Click");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }
        


        private void dgvVoitures_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                var r = dgvVoitures.Rows[e.RowIndex];

                txtImmatriculation.Text = r.Cells["Matricule"].Value?.ToString();
                txtMarque.Text = r.Cells["Marque"].Value?.ToString();
                txtModele.Text = r.Cells["Modèle"].Value?.ToString();
                cmbCategorie.Text = r.Cells["Catégorie"].Value?.ToString();
                cmbTypeCarburant.Text = r.Cells["Carburant"].Value?.ToString();
                cmbBoiteVitesse.Text = r.Cells["Boite"].Value?.ToString();
                cmbEtat.Text = r.Cells["État"].Value?.ToString();
                txtKilometrage.Text = r.Cells["Kilométrage"].Value?.ToString();
                txtPrixJour.Text = r.Cells["Prix jour"].Value?.ToString();
                txtPrixHeure.Text = r.Cells["Prix heure"].Value?.ToString();
                txtAnnee.Text = r.Cells["Année"].Value?.ToString();
                txtCouleur.Text = r.Cells["Couleur"].Value?.ToString();

                if (dgvVoitures.Columns.Contains("Image") && r.Cells["Image"].Value != DBNull.Value)
                {
                    imagePath = r.Cells["Image"].Value?.ToString();

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

        private void btnAjouter_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtImmatriculation.Text))
                {
                    MessageService.Warning("Matricule obligatoire");
                    LogHelper.AddLog("Ajout voiture refusé : matricule vide", Session.Username);
                    return;
                }

                string q = @"
                            INSERT INTO voitures
                            (matricule, marque, modele, categorie, carburant, boite, kilometrage, etat,
                             prix_jour, prix_heure, annee, couleur, image_url, nom_utilisateur)
                            VALUES
                            (@mat, @marque, @modele, @cat, @carb, @boite, @kilomet, @etat,
                             @pj, @ph, @annee, @coul, @img, @user)";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@mat", txtImmatriculation.Text.Trim()),
                    new MySqlParameter("@marque", txtMarque.Text.Trim()),
                    new MySqlParameter("@modele", txtModele.Text.Trim()),
                    new MySqlParameter("@cat", cmbCategorie.Text),
                    new MySqlParameter("@carb", cmbTypeCarburant.Text),
                    new MySqlParameter("@boite", cmbBoiteVitesse.Text),
                    new MySqlParameter("@kilomet", txtKilometrage.Text.Trim()),
                    new MySqlParameter("@etat", string.IsNullOrWhiteSpace(cmbEtat.Text) ? AppStatus.VoitureDisponible : cmbEtat.Text),
                    new MySqlParameter("@pj", txtPrixJour.Text.Trim()),
                    new MySqlParameter("@ph", txtPrixHeure.Text.Trim()),
                    new MySqlParameter("@annee", txtAnnee.Text.Trim()),
                    new MySqlParameter("@coul", txtCouleur.Text.Trim()),
                    new MySqlParameter("@img", imagePath),
                    new MySqlParameter("@user", Session.Username)
                };

                Dbexec.ExecuteQuery(q, ps);

                LogHelper.AddLog("Ajout voiture: " + txtImmatriculation.Text.Trim(), Session.Username);
                MessageService.Success(AppMessages.SaveSuccess);

                LoadVoitures();
                clear();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture", "btnAjouter_Click");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        private void btnModifier_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvVoitures.CurrentRow == null)
                {
                    MessageService.Warning(AppMessages.NoSelection);
                    return;
                }

                int id = Convert.ToInt32(dgvVoitures.CurrentRow.Cells["ID"].Value);

                string q = @"
                            UPDATE voitures SET
                                matricule = @mat,
                                marque = @marque,
                                modele = @modele,
                                categorie = @cat,
                                carburant = @carb,
                                boite = @boite,
                                kilometrage = @kilomet,
                                etat = @etat,
                                prix_jour = @pj,
                                prix_heure = @ph,
                                annee = @annee,
                                couleur = @coul,
                                image_url = @img,
                                nom_utilisateur = @user
                            WHERE voiture_id = @id";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@mat", txtImmatriculation.Text.Trim()),
                    new MySqlParameter("@marque", txtMarque.Text.Trim()),
                    new MySqlParameter("@modele", txtModele.Text.Trim()),
                    new MySqlParameter("@cat", cmbCategorie.Text),
                    new MySqlParameter("@carb", cmbTypeCarburant.Text),
                    new MySqlParameter("@boite", cmbBoiteVitesse.Text),
                    new MySqlParameter("@kilomet", txtKilometrage.Text.Trim()),
                    new MySqlParameter("@etat", cmbEtat.Text),
                    new MySqlParameter("@pj", txtPrixJour.Text.Trim()),
                    new MySqlParameter("@ph", txtPrixHeure.Text.Trim()),
                    new MySqlParameter("@annee", txtAnnee.Text.Trim()),
                    new MySqlParameter("@coul", txtCouleur.Text.Trim()),
                    new MySqlParameter("@img", imagePath),
                    new MySqlParameter("@user", Session.Username),
                    new MySqlParameter("@id", id)
                };

                Dbexec.ExecuteQuery(q, ps);

                LogHelper.AddLog("Modification voiture: " + txtImmatriculation.Text.Trim(), Session.Username);
                MessageService.Success(AppMessages.UpdateSuccess);

                LoadVoitures();
                clear();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture", "btnModifier_Click");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }

        private void btnSupprimer_Click_1(object sender, EventArgs e)
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

                int id = Convert.ToInt32(dgvVoitures.CurrentRow.Cells["ID"].Value);
                string matricule = dgvVoitures.CurrentRow.Cells["Matricule"].Value?.ToString();

                string q = "DELETE FROM voitures WHERE voiture_id = @id";

                MySqlParameter[] ps =
                {
                    new MySqlParameter("@id", id)
                };

                Dbexec.ExecuteQuery(q, ps);

                LogHelper.AddLog("Suppression voiture: " + matricule, Session.Username);
                MessageService.Success(AppMessages.DeleteSuccess);

                LoadVoitures();
                clear();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "voiture", "btnSupprimer_Click");
                MessageService.Error(AppMessages.UnexpectedError);
            }
        }



        void clear()
        {
            imagePath = "";
            pbVoiture.Image = null;

            txtAnnee.Clear();
            txtCouleur.Clear();
            txtImmatriculation.Clear();
            txtKilometrage.Clear();
            txtMarque.Clear();
            txtModele.Clear();
            txtPrixHeure.Clear();
            txtPrixJour.Clear();
            txtRecherche.Clear();

            cmbBoiteVitesse.SelectedIndex = -1;
            cmbCategorie.SelectedIndex = -1;
            cmbEtat.SelectedIndex = -1;
            cmbTypeCarburant.SelectedIndex = -1;

            txtImmatriculation.Focus();
        }
    }
}
