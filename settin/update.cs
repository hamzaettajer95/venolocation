using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using venolocation.classee;

namespace venolocation.settin
{
    public partial class update : Form
    {
        private UpdateInfo _updateInfo;

        public update(UpdateInfo updateInfo)
        {
            InitializeComponent();
            _updateInfo = updateInfo;
        }

        

        public bool UpdateInstalled { get; private set; } = false;


        private void btnVerifierUpdate_Click(object sender, EventArgs e)
        {
            UpdateInstalled = false;
            this.Close();
        }

        private void update_Load(object sender, EventArgs e)
        {
            lblVersionActuelle.Text = "Version actuelle : " + _updateInfo.CurrentVersion;
            lblNouvelleVersion.Text = "Nouvelle version : " + _updateInfo.LatestVersion;
            txtDescription.Text = _updateInfo.Description;

            progressBar1.Value = 0;

            if (_updateInfo.Obligatoire)
            {
                label6.Text = "Cette mise à jour est obligatoire.";
                btnIgnorer.Enabled = false;
            }
            else
            {
                btnIgnorer.Enabled = true;
            }
        }

        private void btnTelecharger_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_updateInfo.Url))
                {
                    MessageBox.Show(
                        "Lien de téléchargement introuvable.",
                        "Mise à jour",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                string tempPath = Path.Combine(Path.GetTempPath(), "venolocation_update.exe");

                if (File.Exists(tempPath))
                    File.Delete(tempPath);

                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;

                    btnTelecharger.Enabled = false;
                    btnIgnorer.Enabled = false;

                    wc.DownloadFileAsync(new Uri(_updateInfo.Url), tempPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur téléchargement mise à jour : " + ex.Message,
                    "Mise à jour",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                btnTelecharger.Enabled = true;

                if (!_updateInfo.Obligatoire)
                    btnIgnorer.Enabled = true;
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(
                    "Erreur téléchargement : " + e.Error.Message,
                    "Mise à jour",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                btnTelecharger.Enabled = true;

                if (!_updateInfo.Obligatoire)
                    btnIgnorer.Enabled = true;

                return;
            }

            string tempPath = Path.Combine(Path.GetTempPath(), "venolocation_update.exe");

            if (!File.Exists(tempPath))
            {
                MessageBox.Show(
                    "Fichier de mise à jour introuvable après téléchargement.",
                    "Mise à jour",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                btnTelecharger.Enabled = true;

                if (!_updateInfo.Obligatoire)
                    btnIgnorer.Enabled = true;

                return;
            }

            MessageBox.Show(
                "Mise à jour téléchargée avec succès. L'installation va démarrer.",
                "Mise à jour",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            UpdateInstalled = true;

            Process.Start(tempPath);
            Application.Exit();
        }
    }
}
