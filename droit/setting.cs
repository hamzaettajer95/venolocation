using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.VisualBasic;

using MySql.Data.MySqlClient;

using venolocation.classee;
using venolocation.settin;


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

        private frmChoixTables OuvrirChoixTables(string titre, string[] tables, bool avecAnnee)
        {
            frmChoixTables f = new frmChoixTables(titre, tables, avecAnnee);

            if (f.ShowDialog() == DialogResult.OK)
                return f;

            return null;
        }

        private void btnSauvegarderDb_Click(object sender, EventArgs e)
        {
            try
            {
                frmChoixTables choix = OuvrirChoixTables(
                    "Tables à archiver",
                    new string[]
                    {
                            "contrats",
                            "reservations",
                            "depenses",
                            "recettes"
                    },

                        true
                );

                if (choix == null)
                    return;

                int annee = choix.AnneeSelectionnee;

                if (MessageService.Confirm("Confirmer l'archivage de l'année " + annee + " ?") != DialogResult.Yes)
                    return;

                foreach (string table in choix.TablesSelectionnees)
                {
                    if (table == "contrats")
                        DatabaseTools.ArchiverContrats(annee);

                    else if (table == "reservations")
                        DatabaseTools.ArchiverReservations(annee);

                    else if (table == "depenses")
                        DatabaseTools.ArchiverDepenses(annee);

                    else if (table == "recettes")
                        DatabaseTools.ArchiverRecettes_Type(annee);
                }

                LogHelper.AddLog("Archivage tables année " + annee + " : " + string.Join(", ", choix.TablesSelectionnees), Session.Username);
                MessageService.Success("Archivage terminé avec succès.");
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "setting", "btnArchiver_Click");
                MessageService.Error("Erreur lors de l'archivage : " + ex.Message);
            }
        }

        private void btnSupprimerDonnees_Click(object sender, EventArgs e)
        {
            try
            {
                frmChoixTables choix = OuvrirChoixTables(
                    "Tables à vider",
                    new string[]
                    {
                            "contrats",
                            "reservations",
                            "depenses",
                            "recettes",
                            "alerte",
                            "erreur",
                            "logs"
                    },
                    false
                );

                if (choix == null)
                    return;

                if (MessageService.Confirm("ATTENTION : Les données sélectionnées seront supprimées. Continuer ?") != DialogResult.Yes)
                    return;

                if (MessageService.Confirm("Dernière confirmation : supprimer définitivement ?") != DialogResult.Yes)
                    return;
                foreach (string table in choix.TablesSelectionnees)
                {
                    DatabaseTools.ViderTableAvecReset(table);
                }

                LogHelper.AddLog("Suppression données tables : " + string.Join(", ", choix.TablesSelectionnees), Session.Username);
                MessageService.Success("Données supprimées avec succès.");
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "setting", "btnSupprimerData_Click");
                MessageService.Error("Erreur suppression données : " + ex.Message);
            }
        }

        private void btnViderLogs_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageService.Confirm("Voulez-vous vraiment vider les logs ?") != DialogResult.Yes)
                    return;

                DatabaseTools.ViderLogs();

                MessageService.Success("Logs vidés avec succès.");
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "setting", "btnViderLogs_Click");
                MessageService.Error("Erreur vidage logs : " + ex.Message);
            }
        }

        private void btnCopierBase_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog f = new FolderBrowserDialog())
                {
                    f.Description = "Choisissez le dossier pour copier les logs";

                    if (f.ShowDialog() != DialogResult.OK)
                        return;

                    string file = DatabaseTools.CopierLogsTxt(f.SelectedPath);

                    LogHelper.AddLog("Copie logs fichier : " + file, Session.Username);
                    MessageService.Success("Logs copiés avec succès : " + file);
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "setting", "btnCopierLogs_Click");
                MessageService.Error("Erreur copie logs : " + ex.Message);
            }
        }

        private void btnRestaurerDb_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog f = new FolderBrowserDialog())
                {
                    f.Description = "Choisissez le dossier de sauvegarde";

                    if (f.ShowDialog() != DialogResult.OK)
                        return;

                    string file = DatabaseTools.BackupDatabase(f.SelectedPath);

                    LogHelper.AddLog("Backup base de données : " + file, Session.Username);
                    MessageService.Success("Backup créé avec succès.");
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "setting", "btnBackup_Click");
                MessageService.Error("Erreur backup : " + ex.Message);
            }
        }

        private void btnExporterDb_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog f = new FolderBrowserDialog())
                {
                    f.Description = "Choisissez le dossier d'export";

                    if (f.ShowDialog() != DialogResult.OK)
                        return;

                    string file = DatabaseTools.BackupDatabase(f.SelectedPath);

                    LogHelper.AddLog("Export base de données : " + file, Session.Username);
                    MessageService.Success("Base exportée avec succès.");
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "setting", "btnExporter_Click");
                MessageService.Error("Erreur export : " + ex.Message);
            }
        }

        private void btnImporterDb_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog op = new OpenFileDialog())
                {
                    op.Filter = "Fichier SQL|*.sql";
                    op.Title = "Choisissez le fichier SQL à importer";

                    if (op.ShowDialog() != DialogResult.OK)
                        return;

                    if (MessageService.Confirm("Attention, l'import peut modifier la base de données. Continuer ?") != DialogResult.Yes)
                        return;

                    DatabaseTools.ImportDatabase(op.FileName);

                    LogHelper.AddLog("Import base de données depuis : " + op.FileName, Session.Username);
                    MessageService.Success("Import terminé avec succès.");
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "setting", "btnImporter_Click");
                MessageService.Error("Erreur import : " + ex.Message);
            }
        }
    }
}
