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

namespace venolocation.droit
{
    public partial class setting : Form
    {
        public setting()
        {
            InitializeComponent();
        }

        private void ChargerUtilisateurs()
        {
            try
            {
                string query = @"
                                SELECT 
                                    user_id AS 'ID',
                                    nom AS 'Nom',
                                    login AS 'Login',
                                    mot_de_passe AS 'MotDePasse',
                                    role AS 'Rôle',
                                    DATE_FORMAT(created_at, '%d/%m/%Y %H:%i:%s') AS 'Créé le'
                                FROM utilisateurs
                                ORDER BY user_id DESC
                                LIMIT 200;";

                dgvUsers.DataSource = Dbexec.GetData(query);

                GridStyleHelper_2.Apply(dgvUsers);

                if (dgvUsers.Columns.Count > 0)
                {
                    dgvUsers.Columns["ID"].FillWeight = 10;
                    dgvUsers.Columns["Nom"].FillWeight = 25;
                    dgvUsers.Columns["Login"].FillWeight = 20;
                    dgvUsers.Columns["Rôle"].FillWeight = 20;
                    dgvUsers.Columns["Créé le"].FillWeight = 25;

                    GridStyleHelper_2.HideColumn(dgvUsers, "MotDePasse");
                    GridStyleHelper_2.AlignLeft(dgvUsers, "Nom");
                    GridStyleHelper_2.AlignLeft(dgvUsers, "Login");
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "settings", "ChargerUtilisateurs");
                MessageService.Error("Erreur lors du chargement des utilisateurs.");
            }
        }

        private void CacherTousLesPanels()
        {
            cardLicence.Enabled = false;
            cardUpdate.Enabled = false;
            cardDatabase.Enabled = false;
            cardUsers.Enabled = false;
            cardGeneral.Enabled = false;
        }

        private void btnCopierBase_Click(object sender, EventArgs e)
        {

        }

        private void setting_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                ChargerUtilisateurs();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "settings", "settings_Load");
                MessageService.Error("Erreur lors du chargement du formulaire.");
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        private void btnMenuLicence_Click(object sender, EventArgs e)
        {
            CacherTousLesPanels();
            cardLicence.Enabled = true;
        }

        private void btnMenuUpdate_Click(object sender, EventArgs e)
        {
            CacherTousLesPanels();
            cardUpdate.Enabled = true;
        }

        private void btnMenuDatabase_Click(object sender, EventArgs e)
        {
            CacherTousLesPanels();
            cardDatabase.Enabled = true;
        }

        private void btnMenuUsers_Click(object sender, EventArgs e)
        {
            CacherTousLesPanels();
            cardUsers.Enabled = true;
        }

        private void btnMenuGeneral_Click(object sender, EventArgs e)
        {
            CacherTousLesPanels();
            cardGeneral.Enabled = true;
        }

        private void btnAjouterUser_Click(object sender, EventArgs e)
        {
            try
            {
                settin.utilisateur u = new settin.utilisateur();
                u.ShowDialog();

                ChargerUtilisateurs();
                //LogHelper.AddLog("Ouverture formulaire ajout utilisateur", Session.Username);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "settings", "btnAjouterUser_Click");
                MessageService.Error("Erreur lors de l'ouverture du formulaire d'ajout utilisateur.");
            }
        }

        private void btnModifierUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.CurrentRow == null)
                {
                    MessageService.Warning("Sélectionnez un utilisateur.");
                    return;
                }

                int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["ID"].Value);
                string nom = dgvUsers.CurrentRow.Cells["Nom"].Value?.ToString();
                string loginUser = dgvUsers.CurrentRow.Cells["Login"].Value?.ToString();
                string motDePasse = dgvUsers.CurrentRow.Cells["MotDePasse"].Value?.ToString();
                string role = dgvUsers.CurrentRow.Cells["Rôle"].Value?.ToString();

                settin.utilisateur frm = new settin.utilisateur(userId, nom, loginUser, motDePasse, role);
                frm.ShowDialog();

                ChargerUtilisateurs();
                LogHelper.AddLog("Ouverture formulaire modification utilisateur : " + loginUser, Session.Username);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "settings", "btnModifierUser_Click");
                MessageService.Error("Erreur lors de l'ouverture du formulaire de modification.");
            }
        }

        private void btnSupprimerUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsers.CurrentRow == null)
                {
                    MessageService.Warning("Sélectionnez un utilisateur.");
                    return;
                }

                int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["ID"].Value);
                string nom = dgvUsers.CurrentRow.Cells["Nom"].Value?.ToString();
                string loginUser = dgvUsers.CurrentRow.Cells["Login"].Value?.ToString();
                
                if (nom == Session.Username)
                {
                    MessageService.Warning("Vous ne pouvez pas supprimer l'utilisateur connecté.");
                    return;
                }

                if (MessageService.Confirm("Voulez-vous vraiment supprimer cet utilisateur ?") != DialogResult.Yes)
                {
                    return;
                }

                string query = "DELETE FROM utilisateurs WHERE user_id = @user_id";

                MySqlParameter[] ps =
                {
                        new MySqlParameter("@user_id", userId)
                };

                Dbexec.ExecuteQuery(query, ps);

                LogHelper.AddLog("Suppression utilisateur : " + loginUser, Session.Username);
                MessageService.Success("Utilisateur supprimé avec succès.");

                ChargerUtilisateurs();
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "settings", "btnSupprimerUser_Click");
                MessageService.Error("Erreur lors de la suppression de l'utilisateur.");
            }
        }
    }
}
