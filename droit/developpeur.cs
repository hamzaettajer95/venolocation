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
    public partial class developpeur : Form
    {
        public developpeur()
        {
            InitializeComponent();
        }

        public bool mode_dev { get; private set; } = false;
        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MakePanelClickable(Panel pnl, EventHandler clickEvent)
        {
            pnl.Cursor = Cursors.Hand;
            pnl.Click += clickEvent;

            foreach (Control c in pnl.Controls)
            {
                c.Cursor = Cursors.Hand;
                c.Click += clickEvent;
            }
        }

        private void TesterConnexion()
        {
            try
            {
                using (MySqlConnection cn = Dbexec.GetConnection())
                {
                    cn.Open();
                }

                lblDerniereVerification.Text = "Dernière vérification : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

               // LogHelper.AddLog("Test connexion base de données réussi", Session.Username);
                MessageBox.Show("Connexion réussie.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "TesterConnexion");
                MessageBox.Show("Échec de connexion : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void Exportererreur()
        {
            try
            {
                using (FolderBrowserDialog f = new FolderBrowserDialog())
                {
                    f.Description = "Choisissez le dossier pour exporter les erreur";

                    if (f.ShowDialog() != DialogResult.OK)
                        return;

                    string file = DatabaseTools.CopierErreurTxt(f.SelectedPath);

                    LogHelper.AddLog("Export erreur développeur : " + file, Session.Username);
                    MessageBox.Show("Logs exportés avec succès :\n" + file, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "ExporterLogs");
                MessageBox.Show("Erreur export logs : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopierConfiguration()
        {
            try
            {
                MySqlConnectionStringBuilder b = new MySqlConnectionStringBuilder(Properties.Settings.Default.conx);

                string config =
                    "Application : VenoLocation" + Environment.NewLine +
                   
                    "Serveur : " + b.Server + Environment.NewLine +
                    "Base de données : " + b.Database + Environment.NewLine +
                    "Utilisateur DB : " + b.UserID + Environment.NewLine +
                    "Utilisateur session : " + Session.Username + Environment.NewLine +
                    "Date : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                Clipboard.SetText(config);

                LogHelper.AddLog("Copie configuration développeur", Session.Username);
                MessageBox.Show("Configuration copiée dans le presse-papiers.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "CopierConfiguration");
                MessageBox.Show("Erreur copie configuration : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void OutilsBD()
        {
            try
            {
                string msg =
                    "Outils base de données disponibles :" + Environment.NewLine +
                    "- Tester connexion" + Environment.NewLine +
                    "- Exporter logs" + Environment.NewLine +
                    "- Backup depuis paramètres" + Environment.NewLine +
                    "- Import/Export depuis paramètres";

                //LogHelper.AddLog("Ouverture outils BD développeur", Session.Username);
                MessageBox.Show(msg, "Outils BD", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "OutilsBD");
                MessageBox.Show("Erreur outils BD : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SauvegarderConfig()
        {
            try
            {
                Properties.Settings.Default.Save();

                LogHelper.AddLog("Sauvegarde configuration développeur", Session.Username);
                MessageBox.Show("Configuration sauvegardée.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "SauvegarderConfig");
                MessageBox.Show("Erreur sauvegarde configuration : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void APropos()
        {
            try
            {
                //string msg =
                //    "VenoLocation" + Environment.NewLine +
                //    "Gestion de location de voitures" + Environment.NewLine +
                //    "Version : " + txtVersionDev.Text + Environment.NewLine +
                //    "Développeur : " + txtNomDev.Text + Environment.NewLine +
                //    "Téléphone : " + txtTelephoneDev.Text + Environment.NewLine +
                //    "Email : " + txtEmailDev.Text + Environment.NewLine +
                //    "© 2026 VenoLocation";

                //MessageBox.Show(msg, "À propos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "APropos");
                MessageBox.Show("Erreur à propos : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void developpeur_Load(object sender, EventArgs e)
        {
            try
            {
                MakePanelClickable(pnlTesterConnexion, pnlTesterConnexion_Click);
                MakePanelClickable(pnlJournalErreurs, pnlJournalErreurs_Click);
                MakePanelClickable(pnlExporterLogs, pnlExporterLogs_Click);
                MakePanelClickable(pnlCopierConfiguration, pnlCopierConfiguration_Click);

                MakePanelClickable(pnlModeDebug, pnlModeDebug_Click);
                MakePanelClickable(pnlOutilsBD, pnlOutilsBD_Click);
                MakePanelClickable(pnlSauvegarderConfig, pnlSauvegarderConfig_Click);
                MakePanelClickable(pnlAPropos, pnlAPropos_Click);

                lblDerniereVerification.Text = "Dernière vérification : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "developpeur_Load");
                MessageBox.Show("Erreur chargement développeur : " + ex.Message);
            }
        }

        private void pnlTesterConnexion_Paint(object sender, PaintEventArgs e)
        {
            
        }

        

        // panel teste conx
        private void pnlTesterConnexion_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show("Mode Développeur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TesterConnexion();
        }
        private void pnlJournalErreurs_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show("Mode Développeur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            settin.affi_erreur er = new settin.affi_erreur();
            er.ShowDialog();
        }
        private void pnlExporterLogs_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show("Mode Développeur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Exportererreur();
        }
        private void pnlCopierConfiguration_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show("Mode Développeur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                using (SaveFileDialog save = new SaveFileDialog())
                {
                    save.Title = "Sauvegarder la configuration";
                    save.Filter = "Fichier configuration (*.txt)|*.txt";
                    save.FileName = "configuration_venolocation_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

                    if (save.ShowDialog() != DialogResult.OK)
                        return;

                    string connectionString = Properties.Settings.Default.conx;

                    string contenu =
                        "Application|VenoLocation" + Environment.NewLine +
                        "Date| " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine +
                        "Utilisateur| " + Session.Username + Environment.NewLine +
                        "ConnectionString| " + connectionString + Environment.NewLine;

                    System.IO.File.WriteAllText(save.FileName, contenu, System.Text.Encoding.UTF8);

                    Clipboard.SetText(connectionString);

                    LogHelper.AddLog("Copie configuration base de données dans fichier : " + save.FileName, Session.Username);

                    MessageBox.Show(
                        "Configuration sauvegardée avec succès.\n\n" +
                        "Fichier : " + save.FileName + "\n\n" +
                        "ConnectionString copiée aussi dans le presse-papiers.",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "CopierConfiguration");
                MessageBox.Show("Erreur copie configuration : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pnlModeDebug_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show("Mode Développeur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dev.debug de = new dev.debug();
            de.ShowDialog();
        }
        private void pnlOutilsBD_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show("Mode Développeur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string connectionString = Properties.Settings.Default.conx;

                Clipboard.SetText(connectionString);

                MessageBox.Show(
                    "ConnectionString actuelle :\n\n" +
                    connectionString + "\n\n" +
                    "Elle a été copiée dans le presse-papiers.",
                    "Configuration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "AfficherConfiguration");
                MessageBox.Show("Erreur affichage configuration : " + ex.Message);
            }
        }
        private void pnlSauvegarderConfig_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show("Mode Développeur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.Title = "Restaurer la configuration";
                    open.Filter = "Fichier configuration (*.txt)|*.txt";

                    if (open.ShowDialog() != DialogResult.OK)
                        return;

                    string[] lignes = System.IO.File.ReadAllLines(open.FileName, System.Text.Encoding.UTF8);

                    string connectionString = "";

                    foreach (string ligne in lignes)
                    {
                        if (ligne.StartsWith("ConnectionString|"))
                        {
                            connectionString = ligne.Substring("ConnectionString|".Length).Trim();
                            break;
                        }
                    }

                    if (string.IsNullOrWhiteSpace(connectionString))
                    {
                        MessageBox.Show("ConnectionString introuvable dans le fichier.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult rep = MessageBox.Show(
                        "Voulez-vous vraiment restaurer cette configuration ?\n\n" +
                        connectionString,
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (rep != DialogResult.Yes)
                        return;

                    Properties.Settings.Default.conx = connectionString;
                    Properties.Settings.Default.Save();

                    LogHelper.AddLog("Restauration configuration base de données depuis fichier : " + open.FileName, Session.Username);

                    MessageBox.Show(
                        "Configuration restaurée avec succès.\n\nRedémarrez l'application pour appliquer la nouvelle connexion.",
                        "Succès",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "RestaurerConfiguration");
                MessageBox.Show("Erreur restauration configuration : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pnlAPropos_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show("Mode Développeur", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vous etes déja un Développeur", "Développeur", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //textBox1.Visible = true;
                //button1.Visible = true;
                //label5.Visible = true;

                mode_dev = true;
                Session.Username = "Développeur";
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }
    }
}
