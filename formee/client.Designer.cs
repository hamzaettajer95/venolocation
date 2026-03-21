using System.Windows.Forms;

namespace venolocation.formee
{
    partial class client
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private Label lblTitle;

        private GroupBox gbListeClients;
        private TextBox txtRecherche;
        private ComboBox cmbRecherche;
        private Button btnSearchTop;
        private DataGridView dgvClients;

        private GroupBox gbActions;
        private Button btnAjouter;
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnRechercher;
        private Button btnClear;
        private Button btnRetour;

        private GroupBox gbInfoGauche;
        private Label lblCinClient;
        private Label lblNomClient;
        private Label lblPrenomClient;
        private Label lblTelephone;
        private Label lblDateNaissance;

        private TextBox txtCinClient;
        private TextBox txtNomClient;
        private TextBox txtPrenomClient;
        private TextBox txtTelephone;
        private DateTimePicker dtpDateNaissance;

        private GroupBox gbInfoDroite;
        private Label lblPermisClient;
        private Label lblDelivreLe;
        private Label lblVilleClient;
        private Label lblAdresseClient;

        private TextBox txtPermisClient;
        private DateTimePicker dtpDelivreLe;
        private ComboBox cmbVilleClient;
        private TextBox txtAdresseClient;
        private void InitializeComponent()
        {


           
       
                this.lblTitle = new System.Windows.Forms.Label();
                this.gbListeClients = new System.Windows.Forms.GroupBox();
                this.txtRecherche = new System.Windows.Forms.TextBox();
                this.cmbRecherche = new System.Windows.Forms.ComboBox();
                this.btnSearchTop = new System.Windows.Forms.Button();
                this.dgvClients = new System.Windows.Forms.DataGridView();
                this.gbActions = new System.Windows.Forms.GroupBox();
                this.btnAjouter = new System.Windows.Forms.Button();
                this.btnModifier = new System.Windows.Forms.Button();
                this.btnSupprimer = new System.Windows.Forms.Button();
                this.btnRechercher = new System.Windows.Forms.Button();
                this.btnClear = new System.Windows.Forms.Button();
                this.btnRetour = new System.Windows.Forms.Button();
                this.gbInfoGauche = new System.Windows.Forms.GroupBox();
                this.lblCinClient = new System.Windows.Forms.Label();
                this.txtCinClient = new System.Windows.Forms.TextBox();
                this.lblNomClient = new System.Windows.Forms.Label();
                this.txtNomClient = new System.Windows.Forms.TextBox();
                this.lblPrenomClient = new System.Windows.Forms.Label();
                this.txtPrenomClient = new System.Windows.Forms.TextBox();
                this.lblTelephone = new System.Windows.Forms.Label();
                this.txtTelephone = new System.Windows.Forms.TextBox();
                this.lblDateNaissance = new System.Windows.Forms.Label();
                this.dtpDateNaissance = new System.Windows.Forms.DateTimePicker();
                this.gbInfoDroite = new System.Windows.Forms.GroupBox();
                this.lblPermisClient = new System.Windows.Forms.Label();
                this.txtPermisClient = new System.Windows.Forms.TextBox();
                this.lblDelivreLe = new System.Windows.Forms.Label();
                this.dtpDelivreLe = new System.Windows.Forms.DateTimePicker();
                this.lblVilleClient = new System.Windows.Forms.Label();
                this.cmbVilleClient = new System.Windows.Forms.ComboBox();
                this.lblAdresseClient = new System.Windows.Forms.Label();
                this.txtAdresseClient = new System.Windows.Forms.TextBox();
                this.gbListeClients.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
                this.gbActions.SuspendLayout();
                this.gbInfoGauche.SuspendLayout();
                this.gbInfoDroite.SuspendLayout();
                this.SuspendLayout();
                // 
                // lblTitle
                // 
                this.lblTitle.AutoSize = true;
                this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
                this.lblTitle.Location = new System.Drawing.Point(35, 20);
                this.lblTitle.Name = "lblTitle";
                this.lblTitle.Size = new System.Drawing.Size(345, 50);
                this.lblTitle.TabIndex = 0;
                this.lblTitle.Text = "Gestion des clients";
                // 
                // gbListeClients
                // 
                this.gbListeClients.Controls.Add(this.txtRecherche);
                this.gbListeClients.Controls.Add(this.cmbRecherche);
                this.gbListeClients.Controls.Add(this.btnSearchTop);
                this.gbListeClients.Controls.Add(this.dgvClients);
                this.gbListeClients.Font = new System.Drawing.Font("Segoe UI", 11F);
                this.gbListeClients.Location = new System.Drawing.Point(35, 85);
                this.gbListeClients.Name = "gbListeClients";
                this.gbListeClients.Size = new System.Drawing.Size(1318, 355);
                this.gbListeClients.TabIndex = 1;
                this.gbListeClients.TabStop = false;
                this.gbListeClients.Text = "Liste des clients";
                // 
                // txtRecherche
                // 
                this.txtRecherche.Location = new System.Drawing.Point(18, 42);
                this.txtRecherche.Name = "txtRecherche";
                this.txtRecherche.Size = new System.Drawing.Size(1086, 32);
                this.txtRecherche.TabIndex = 0;
                // 
                // cmbRecherche
                // 
                this.cmbRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cmbRecherche.Items.AddRange(new object[] {
            "CIN",
            "Nom",
            "Prénom",
            "Téléphone",
            "Ville"});
                this.cmbRecherche.Location = new System.Drawing.Point(1110, 41);
                this.cmbRecherche.Name = "cmbRecherche";
                this.cmbRecherche.Size = new System.Drawing.Size(127, 33);
                this.cmbRecherche.TabIndex = 1;
                // 
                // btnSearchTop
                // 
                this.btnSearchTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(147)))), ((int)(((byte)(33)))));
                this.btnSearchTop.FlatAppearance.BorderSize = 0;
                this.btnSearchTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnSearchTop.Font = new System.Drawing.Font("Segoe UI Emoji", 14F, System.Drawing.FontStyle.Bold);
                this.btnSearchTop.ForeColor = System.Drawing.Color.White;
                this.btnSearchTop.Location = new System.Drawing.Point(1243, 41);
                this.btnSearchTop.Name = "btnSearchTop";
                this.btnSearchTop.Size = new System.Drawing.Size(45, 34);
                this.btnSearchTop.TabIndex = 2;
                this.btnSearchTop.Text = "🔍";
                this.btnSearchTop.UseVisualStyleBackColor = false;
                // 
                // dgvClients
                // 
                this.dgvClients.AllowUserToAddRows = false;
                this.dgvClients.AllowUserToDeleteRows = false;
                this.dgvClients.AllowUserToResizeRows = false;
                this.dgvClients.BackgroundColor = System.Drawing.Color.White;
                this.dgvClients.ColumnHeadersHeight = 36;
                this.dgvClients.Location = new System.Drawing.Point(18, 90);
                this.dgvClients.MultiSelect = false;
                this.dgvClients.Name = "dgvClients";
                this.dgvClients.RowHeadersVisible = false;
                this.dgvClients.RowHeadersWidth = 51;
                this.dgvClients.RowTemplate.Height = 34;
                this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                this.dgvClients.Size = new System.Drawing.Size(1270, 240);
                this.dgvClients.TabIndex = 3;
                // 
                // gbActions
                // 
                this.gbActions.Controls.Add(this.btnAjouter);
                this.gbActions.Controls.Add(this.btnModifier);
                this.gbActions.Controls.Add(this.btnSupprimer);
                this.gbActions.Controls.Add(this.btnRechercher);
                this.gbActions.Controls.Add(this.btnClear);
                this.gbActions.Controls.Add(this.btnRetour);
                this.gbActions.Font = new System.Drawing.Font("Segoe UI", 11F);
                this.gbActions.Location = new System.Drawing.Point(35, 455);
                this.gbActions.Name = "gbActions";
                this.gbActions.Size = new System.Drawing.Size(1295, 120);
                this.gbActions.TabIndex = 2;
                this.gbActions.TabStop = false;
                this.gbActions.Text = "Actions";
                // 
                // btnAjouter
                // 
                this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(177)))), ((int)(((byte)(77)))));
                this.btnAjouter.FlatAppearance.BorderSize = 0;
                this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.btnAjouter.ForeColor = System.Drawing.Color.White;
                this.btnAjouter.Location = new System.Drawing.Point(18, 42);
                this.btnAjouter.Name = "btnAjouter";
                this.btnAjouter.Size = new System.Drawing.Size(195, 48);
                this.btnAjouter.TabIndex = 0;
                this.btnAjouter.Text = "✚ Ajouter";
                this.btnAjouter.UseVisualStyleBackColor = false;
                //this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
                // 
                // btnModifier
                // 
                this.btnModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(128)))), ((int)(((byte)(194)))));
                this.btnModifier.FlatAppearance.BorderSize = 0;
                this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.btnModifier.ForeColor = System.Drawing.Color.White;
                this.btnModifier.Location = new System.Drawing.Point(228, 42);
                this.btnModifier.Name = "btnModifier";
                this.btnModifier.Size = new System.Drawing.Size(195, 48);
                this.btnModifier.TabIndex = 1;
                this.btnModifier.Text = "↻    Modifier";
                this.btnModifier.UseVisualStyleBackColor = false;
                // 
                // btnSupprimer
                // 
                this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(72)))), ((int)(((byte)(64)))));
                this.btnSupprimer.FlatAppearance.BorderSize = 0;
                this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.btnSupprimer.ForeColor = System.Drawing.Color.White;
                this.btnSupprimer.Location = new System.Drawing.Point(438, 42);
                this.btnSupprimer.Name = "btnSupprimer";
                this.btnSupprimer.Size = new System.Drawing.Size(195, 48);
                this.btnSupprimer.TabIndex = 2;
                this.btnSupprimer.Text = "🗑 Supprimer";
                this.btnSupprimer.UseVisualStyleBackColor = false;
                // 
                // btnRechercher
                // 
                this.btnRechercher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(145)))), ((int)(((byte)(31)))));
                this.btnRechercher.FlatAppearance.BorderSize = 0;
                this.btnRechercher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnRechercher.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.btnRechercher.ForeColor = System.Drawing.Color.White;
                this.btnRechercher.Location = new System.Drawing.Point(648, 42);
                this.btnRechercher.Name = "btnRechercher";
                this.btnRechercher.Size = new System.Drawing.Size(195, 48);
                this.btnRechercher.TabIndex = 3;
                this.btnRechercher.Text = "🔍 Rechercher";
                this.btnRechercher.UseVisualStyleBackColor = false;
                // 
                // btnClear
                // 
                this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
                this.btnClear.FlatAppearance.BorderSize = 0;
                this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.btnClear.ForeColor = System.Drawing.Color.White;
                this.btnClear.Location = new System.Drawing.Point(858, 42);
                this.btnClear.Name = "btnClear";
                this.btnClear.Size = new System.Drawing.Size(160, 48);
                this.btnClear.TabIndex = 4;
                this.btnClear.Text = "⊗ Clear";
                this.btnClear.UseVisualStyleBackColor = false;
                // 
                // btnRetour
                // 
                this.btnRetour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
                this.btnRetour.FlatAppearance.BorderSize = 0;
                this.btnRetour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                this.btnRetour.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.btnRetour.ForeColor = System.Drawing.Color.White;
                this.btnRetour.Location = new System.Drawing.Point(1030, 42);
                this.btnRetour.Name = "btnRetour";
                this.btnRetour.Size = new System.Drawing.Size(270, 48);
                this.btnRetour.TabIndex = 5;
                this.btnRetour.Text = "↻ Retour";
                this.btnRetour.UseVisualStyleBackColor = false;
                // 
                // gbInfoGauche
                // 
                this.gbInfoGauche.Controls.Add(this.lblCinClient);
                this.gbInfoGauche.Controls.Add(this.txtCinClient);
                this.gbInfoGauche.Controls.Add(this.lblNomClient);
                this.gbInfoGauche.Controls.Add(this.txtNomClient);
                this.gbInfoGauche.Controls.Add(this.lblPrenomClient);
                this.gbInfoGauche.Controls.Add(this.txtPrenomClient);
                this.gbInfoGauche.Controls.Add(this.lblTelephone);
                this.gbInfoGauche.Controls.Add(this.txtTelephone);
                this.gbInfoGauche.Controls.Add(this.lblDateNaissance);
                this.gbInfoGauche.Controls.Add(this.dtpDateNaissance);
                this.gbInfoGauche.Font = new System.Drawing.Font("Segoe UI", 11F);
                this.gbInfoGauche.Location = new System.Drawing.Point(35, 595);
                this.gbInfoGauche.Name = "gbInfoGauche";
                this.gbInfoGauche.Size = new System.Drawing.Size(645, 270);
                this.gbInfoGauche.TabIndex = 3;
                this.gbInfoGauche.TabStop = false;
                this.gbInfoGauche.Text = "Informations client";
                // 
                // lblCinClient
                // 
                this.lblCinClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.lblCinClient.Location = new System.Drawing.Point(18, 45);
                this.lblCinClient.Name = "lblCinClient";
                this.lblCinClient.Size = new System.Drawing.Size(170, 32);
                this.lblCinClient.TabIndex = 0;
                this.lblCinClient.Text = "CIN Client";
                // 
                // txtCinClient
                // 
                this.txtCinClient.Location = new System.Drawing.Point(215, 42);
                this.txtCinClient.Name = "txtCinClient";
                this.txtCinClient.Size = new System.Drawing.Size(280, 32);
                this.txtCinClient.TabIndex = 1;
                // 
                // lblNomClient
                // 
                this.lblNomClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.lblNomClient.Location = new System.Drawing.Point(18, 88);
                this.lblNomClient.Name = "lblNomClient";
                this.lblNomClient.Size = new System.Drawing.Size(170, 32);
                this.lblNomClient.TabIndex = 2;
                this.lblNomClient.Text = "Nom Client";
                // 
                // txtNomClient
                // 
                this.txtNomClient.Location = new System.Drawing.Point(215, 85);
                this.txtNomClient.Name = "txtNomClient";
                this.txtNomClient.Size = new System.Drawing.Size(280, 32);
                this.txtNomClient.TabIndex = 3;
                // 
                // lblPrenomClient
                // 
                this.lblPrenomClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.lblPrenomClient.Location = new System.Drawing.Point(18, 131);
                this.lblPrenomClient.Name = "lblPrenomClient";
                this.lblPrenomClient.Size = new System.Drawing.Size(170, 32);
                this.lblPrenomClient.TabIndex = 4;
                this.lblPrenomClient.Text = "Prénom Client";
                // 
                // txtPrenomClient
                // 
                this.txtPrenomClient.Location = new System.Drawing.Point(215, 128);
                this.txtPrenomClient.Name = "txtPrenomClient";
                this.txtPrenomClient.Size = new System.Drawing.Size(280, 32);
                this.txtPrenomClient.TabIndex = 5;
                // 
                // lblTelephone
                // 
                this.lblTelephone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.lblTelephone.Location = new System.Drawing.Point(18, 174);
                this.lblTelephone.Name = "lblTelephone";
                this.lblTelephone.Size = new System.Drawing.Size(170, 32);
                this.lblTelephone.TabIndex = 6;
                this.lblTelephone.Text = "Téléphone";
                // 
                // txtTelephone
                // 
                this.txtTelephone.Location = new System.Drawing.Point(215, 171);
                this.txtTelephone.Name = "txtTelephone";
                this.txtTelephone.Size = new System.Drawing.Size(280, 32);
                this.txtTelephone.TabIndex = 7;
                // 
                // lblDateNaissance
                // 
                this.lblDateNaissance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.lblDateNaissance.Location = new System.Drawing.Point(18, 217);
                this.lblDateNaissance.Name = "lblDateNaissance";
                this.lblDateNaissance.Size = new System.Drawing.Size(170, 32);
                this.lblDateNaissance.TabIndex = 8;
                this.lblDateNaissance.Text = "Date naissance";
                // 
                // dtpDateNaissance
                // 
                this.dtpDateNaissance.Location = new System.Drawing.Point(215, 214);
                this.dtpDateNaissance.Name = "dtpDateNaissance";
                this.dtpDateNaissance.Size = new System.Drawing.Size(280, 32);
                this.dtpDateNaissance.TabIndex = 9;
                this.dtpDateNaissance.Value = new System.DateTime(2026, 2, 5, 0, 0, 0, 0);
                // 
                // gbInfoDroite
                // 
                this.gbInfoDroite.Controls.Add(this.lblPermisClient);
                this.gbInfoDroite.Controls.Add(this.txtPermisClient);
                this.gbInfoDroite.Controls.Add(this.lblDelivreLe);
                this.gbInfoDroite.Controls.Add(this.dtpDelivreLe);
                this.gbInfoDroite.Controls.Add(this.lblVilleClient);
                this.gbInfoDroite.Controls.Add(this.cmbVilleClient);
                this.gbInfoDroite.Controls.Add(this.lblAdresseClient);
                this.gbInfoDroite.Controls.Add(this.txtAdresseClient);
                this.gbInfoDroite.Font = new System.Drawing.Font("Segoe UI", 11F);
                this.gbInfoDroite.Location = new System.Drawing.Point(700, 595);
                this.gbInfoDroite.Name = "gbInfoDroite";
                this.gbInfoDroite.Size = new System.Drawing.Size(630, 270);
                this.gbInfoDroite.TabIndex = 4;
                this.gbInfoDroite.TabStop = false;
                this.gbInfoDroite.Text = "Informations client";
                // 
                // lblPermisClient
                // 
                this.lblPermisClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.lblPermisClient.Location = new System.Drawing.Point(22, 45);
                this.lblPermisClient.Name = "lblPermisClient";
                this.lblPermisClient.Size = new System.Drawing.Size(170, 32);
                this.lblPermisClient.TabIndex = 0;
                this.lblPermisClient.Text = "Permis Client";
                // 
                // txtPermisClient
                // 
                this.txtPermisClient.Location = new System.Drawing.Point(220, 42);
                this.txtPermisClient.Name = "txtPermisClient";
                this.txtPermisClient.Size = new System.Drawing.Size(280, 32);
                this.txtPermisClient.TabIndex = 1;
                // 
                // lblDelivreLe
                // 
                this.lblDelivreLe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.lblDelivreLe.Location = new System.Drawing.Point(22, 88);
                this.lblDelivreLe.Name = "lblDelivreLe";
                this.lblDelivreLe.Size = new System.Drawing.Size(170, 32);
                this.lblDelivreLe.TabIndex = 2;
                this.lblDelivreLe.Text = "Délivré le";
                // 
                // dtpDelivreLe
                // 
                this.dtpDelivreLe.Location = new System.Drawing.Point(220, 85);
                this.dtpDelivreLe.Name = "dtpDelivreLe";
                this.dtpDelivreLe.Size = new System.Drawing.Size(280, 32);
                this.dtpDelivreLe.TabIndex = 3;
                this.dtpDelivreLe.Value = new System.DateTime(2025, 3, 10, 0, 0, 0, 0);
                // 
                // lblVilleClient
                // 
                this.lblVilleClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.lblVilleClient.Location = new System.Drawing.Point(22, 131);
                this.lblVilleClient.Name = "lblVilleClient";
                this.lblVilleClient.Size = new System.Drawing.Size(170, 32);
                this.lblVilleClient.TabIndex = 4;
                this.lblVilleClient.Text = "Ville Client";
                // 
                // cmbVilleClient
                // 
                this.cmbVilleClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cmbVilleClient.Location = new System.Drawing.Point(220, 128);
                this.cmbVilleClient.Name = "cmbVilleClient";
                this.cmbVilleClient.Size = new System.Drawing.Size(280, 33);
                this.cmbVilleClient.TabIndex = 5;
                // 
                // lblAdresseClient
                // 
                this.lblAdresseClient.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
                this.lblAdresseClient.Location = new System.Drawing.Point(22, 174);
                this.lblAdresseClient.Name = "lblAdresseClient";
                this.lblAdresseClient.Size = new System.Drawing.Size(170, 32);
                this.lblAdresseClient.TabIndex = 6;
                this.lblAdresseClient.Text = "Adresse client";
                // 
                // txtAdresseClient
                // 
                this.txtAdresseClient.Location = new System.Drawing.Point(220, 171);
                this.txtAdresseClient.Multiline = true;
                this.txtAdresseClient.Name = "txtAdresseClient";
                this.txtAdresseClient.Size = new System.Drawing.Size(395, 78);
                this.txtAdresseClient.TabIndex = 7;
                // 
                // Client
                // 
                this.BackColor = System.Drawing.Color.White;
                this.ClientSize = new System.Drawing.Size(1365, 910);
                this.Controls.Add(this.lblTitle);
                this.Controls.Add(this.gbListeClients);
                this.Controls.Add(this.gbActions);
                this.Controls.Add(this.gbInfoGauche);
                this.Controls.Add(this.gbInfoDroite);
                this.Font = new System.Drawing.Font("Segoe UI", 10F);
                this.Name = "Client";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Gestion des clients";
                //this.Load += new System.EventHandler(this.Client_Load);
                this.gbListeClients.ResumeLayout(false);
                this.gbListeClients.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
                this.gbActions.ResumeLayout(false);
                this.gbInfoGauche.ResumeLayout(false);
                this.gbInfoGauche.PerformLayout();
                this.gbInfoDroite.ResumeLayout(false);
                this.gbInfoDroite.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

            
        }
    }
}

        #endregion
