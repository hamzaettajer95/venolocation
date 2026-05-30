using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using MySqlConnector;

using venolocation.classee;
using venolocation.dev;

namespace venolocation.droit
{
    public partial class developpeur : Form
    {
        public developpeur()
        {
            InitializeComponent();
        }

        public bool mode_dev { get; private set; } = false;
        private int devClickCount = 0;
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

                ErrorReporter.SendError(ex, "developpeur", "TesterConnexion");
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "TesterConnexion");
                MessageBox.Show("Échec de connexion : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                server s = new dev.server();
                s.ShowDialog();

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
                ErrorReporter.SendError(ex, "developpeur", "ExporterLogs");
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "ExporterLogs");
                MessageBox.Show("Erreur export logs : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ErrorReporter.SendError(ex, "developpeur", "developpeur_Load");
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
                MessageBox.Show(
                    "Accès réservé au développeur.",
                    "Accès refusé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            //TesterConnexion();

            pro_seti_defaut p = new pro_seti_defaut();
            p.ShowDialog();
        }
        private void pnlJournalErreurs_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show(
                    "Accès réservé au développeur.",
                    "Accès refusé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            settin.affi_erreur er = new settin.affi_erreur();
            er.ShowDialog();
        }
        private void pnlExporterLogs_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show(
                    "Accès réservé au développeur.",
                    "Accès refusé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            Exportererreur();
        }
        private void pnlCopierConfiguration_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show(
                    "Accès réservé au développeur.",
                    "Accès refusé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
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

                    string connectionString = DbConfig.GetConnectionString();

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
                ErrorReporter.SendError(ex, "developpeur", "CopierConfiguration");
                dbErreur.AddLog(ex.Message, Session.Username, "developpeur", "CopierConfiguration");
                MessageBox.Show("Erreur copie configuration : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pnlModeDebug_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show(
                    "Accès réservé au développeur.",
                    "Accès refusé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            dev.debug de = new dev.debug();
            de.ShowDialog();
        }
        private void pnlOutilsBD_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show(
                    "Accès réservé au développeur.",
                    "Accès refusé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            server se = new server();
            se.ShowDialog();
        }
        private void pnlSauvegarderConfig_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show(
                    "Mode Développeur requis.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            try
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.Title = "Restaurer la configuration";
                    open.Filter = "Fichier configuration (*.txt)|*.txt";
                    open.Multiselect = false;

                    if (open.ShowDialog() != DialogResult.OK)
                        return;

                    string[] lignes = File.ReadAllLines(open.FileName, Encoding.UTF8);

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
                        MessageBox.Show(
                            "ConnectionString introuvable dans le fichier.",
                            "Erreur",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
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

                    App_Config.Instance.conx = connectionString;
                    App_Config.Save(App_Config.Instance);

                    LogHelper.AddLog(
                        "Restauration configuration base de données depuis fichier : " + open.FileName,
                        Session.Username
                    );

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
                ErrorReporter.SendError(ex, "developpeur","RestaurerConfiguration");

                dbErreur.AddLog(
                    ex.Message,
                    Session.Username,
                    "developpeur",
                    "RestaurerConfiguration"
                );

                MessageBox.Show(
                    "Erreur restauration configuration : " + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void pnlAPropos_Click(object sender, EventArgs e)
        {
            if (mode_dev == false)
            {
                MessageBox.Show(
                    "Accès réservé au développeur.",
                    "Accès refusé",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            TesterConnexion();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            devClickCount++;

            if (devClickCount >= 5)
            {
                devClickCount = 0;

                txtDevCode.Visible = true;
                txtDevCode.Clear();
                txtDevCode.Focus();

            }
        }

        private void OuvrirPanelSecretDeveloppeur()
        {
            txtDevCode.Visible = true;

            if (string.IsNullOrWhiteSpace(txtDevCode.Text))
                return;

            

            
            bool codeOk = txtDevCode.Text == "HAMZA_DEV_2026";

            if (codeOk)
            {
                mode_dev = true;
                Session.Username = "Développeur";

                MessageBox.Show(
                    "Accès développeur autorisé.",
                    "Développeur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                mode_dev = false;

                MessageBox.Show(
                    "Accès développeur refusé.",
                    "Sécurité",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void txtDevCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            
            VerifierCodeDeveloppeur();
        }

        private string Sha256(string text)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] hash = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
        private void VerifierCodeDeveloppeur()
        {
            string codeSaisi = txtDevCode.Text.Trim();

            if (string.IsNullOrWhiteSpace(codeSaisi))
                return;

            string hashCodeCorrect = "7e64b08cec1897f828ae51040afd75e53c5b1a28dbcb4fb9cd3d22c4acfdca56";

            bool codeOk = Sha256(codeSaisi) == hashCodeCorrect;

            if (codeOk)
            {
                mode_dev = true;
                Session.Username = "Développeur";

                txtDevCode.Visible = false;
                txtDevCode.Clear();

                MessageBox.Show(
                    "Accès développeur autorisé.",
                    "Développeur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                mode_dev = false;

                txtDevCode.Clear();
                txtDevCode.Focus();

                MessageBox.Show(
                    "Accès développeur refusé.",
                    "Sécurité",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnContacterDeveloppeur_Click(object sender, EventArgs e)
        {
            dev.test_telegrame t = new test_telegrame();
            t.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
