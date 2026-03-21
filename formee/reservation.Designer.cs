namespace venolocation.formee
{
    partial class reservation
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
        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblListeReservation = new System.Windows.Forms.Label();
            this.lblListeClients = new System.Windows.Forms.Label();
            this.lblListeVoiture = new System.Windows.Forms.Label();
            this.dgvReservation = new System.Windows.Forms.DataGridView();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.dgvVoitures = new System.Windows.Forms.DataGridView();
            this.lblClient = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblMatricule = new System.Windows.Forms.Label();
            this.txtMatricule = new System.Windows.Forms.TextBox();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.lblHeureDebut = new System.Windows.Forms.Label();
            this.dtpHeureDebut = new System.Windows.Forms.DateTimePicker();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.lblHeureFin = new System.Windows.Forms.Label();
            this.dtpHeureFin = new System.Windows.Forms.DateTimePicker();
            this.btnAfficherPeriode = new System.Windows.Forms.Button();
            this.btnTesterReservation = new System.Windows.Forms.Button();
            this.btnReserver = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnConfirmer = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoitures)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.BackColor = System.Drawing.Color.Transparent;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.Location = new System.Drawing.Point(26, 22);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(218, 50);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "reservation";
            // 
            // lblListeReservation
            // 
            this.lblListeReservation.AutoSize = true;
            this.lblListeReservation.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblListeReservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblListeReservation.Location = new System.Drawing.Point(32, 22);
            this.lblListeReservation.Name = "lblListeReservation";
            this.lblListeReservation.Size = new System.Drawing.Size(198, 32);
            this.lblListeReservation.TabIndex = 1;
            this.lblListeReservation.Text = "liste réservation";
            // 
            // lblListeClients
            // 
            this.lblListeClients.AutoSize = true;
            this.lblListeClients.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblListeClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblListeClients.Location = new System.Drawing.Point(778, 22);
            this.lblListeClients.Name = "lblListeClients";
            this.lblListeClients.Size = new System.Drawing.Size(142, 32);
            this.lblListeClients.TabIndex = 2;
            this.lblListeClients.Text = "liste clients";
            // 
            // lblListeVoiture
            // 
            this.lblListeVoiture.AutoSize = true;
            this.lblListeVoiture.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblListeVoiture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblListeVoiture.Location = new System.Drawing.Point(778, 356);
            this.lblListeVoiture.Name = "lblListeVoiture";
            this.lblListeVoiture.Size = new System.Drawing.Size(150, 32);
            this.lblListeVoiture.TabIndex = 3;
            this.lblListeVoiture.Text = "liste voiture";
            // 
            // dgvReservation
            // 
            this.dgvReservation.AllowUserToAddRows = false;
            this.dgvReservation.AllowUserToDeleteRows = false;
            this.dgvReservation.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservation.Location = new System.Drawing.Point(38, 64);
            this.dgvReservation.Name = "dgvReservation";
            this.dgvReservation.ReadOnly = true;
            this.dgvReservation.RowHeadersVisible = false;
            this.dgvReservation.RowHeadersWidth = 51;
            this.dgvReservation.RowTemplate.Height = 24;
            this.dgvReservation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservation.Size = new System.Drawing.Size(690, 230);
            this.dgvReservation.TabIndex = 4;
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.BackgroundColor = System.Drawing.Color.White;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Location = new System.Drawing.Point(784, 64);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.RowHeadersWidth = 51;
            this.dgvClients.RowTemplate.Height = 24;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(520, 230);
            this.dgvClients.TabIndex = 5;
            // 
            // dgvVoitures
            // 
            this.dgvVoitures.AllowUserToAddRows = false;
            this.dgvVoitures.AllowUserToDeleteRows = false;
            this.dgvVoitures.BackgroundColor = System.Drawing.Color.White;
            this.dgvVoitures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoitures.Location = new System.Drawing.Point(784, 398);
            this.dgvVoitures.Name = "dgvVoitures";
            this.dgvVoitures.ReadOnly = true;
            this.dgvVoitures.RowHeadersVisible = false;
            this.dgvVoitures.RowHeadersWidth = 51;
            this.dgvVoitures.RowTemplate.Height = 24;
            this.dgvVoitures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVoitures.Size = new System.Drawing.Size(520, 205);
            this.dgvVoitures.TabIndex = 6;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblClient.Location = new System.Drawing.Point(38, 330);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(80, 32);
            this.lblClient.TabIndex = 7;
            this.lblClient.Text = "Client";
            // 
            // cmbClient
            // 
            this.cmbClient.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(170, 326);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(350, 36);
            this.cmbClient.TabIndex = 8;
            // 
            // lblMatricule
            // 
            this.lblMatricule.AutoSize = true;
            this.lblMatricule.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMatricule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblMatricule.Location = new System.Drawing.Point(38, 388);
            this.lblMatricule.Name = "lblMatricule";
            this.lblMatricule.Size = new System.Drawing.Size(123, 32);
            this.lblMatricule.TabIndex = 9;
            this.lblMatricule.Text = "Matricule";
            // 
            // txtMatricule
            // 
            this.txtMatricule.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMatricule.Location = new System.Drawing.Point(170, 384);
            this.txtMatricule.Name = "txtMatricule";
            this.txtMatricule.Size = new System.Drawing.Size(350, 34);
            this.txtMatricule.TabIndex = 10;
            // 
            // lblDateDebut
            // 
            this.lblDateDebut.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDateDebut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblDateDebut.Location = new System.Drawing.Point(38, 478);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(161, 37);
            this.lblDateDebut.TabIndex = 11;
            this.lblDateDebut.Text = "Date début";
            // 
            // dtpDateDebut
            // 
            this.dtpDateDebut.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDebut.Location = new System.Drawing.Point(286, 480);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(210, 34);
            this.dtpDateDebut.TabIndex = 12;
            // 
            // lblHeureDebut
            // 
            this.lblHeureDebut.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeureDebut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblHeureDebut.Location = new System.Drawing.Point(38, 538);
            this.lblHeureDebut.Name = "lblHeureDebut";
            this.lblHeureDebut.Size = new System.Drawing.Size(178, 37);
            this.lblHeureDebut.TabIndex = 13;
            this.lblHeureDebut.Text = "Heure début";
            // 
            // dtpHeureDebut
            // 
            this.dtpHeureDebut.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHeureDebut.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHeureDebut.Location = new System.Drawing.Point(286, 540);
            this.dtpHeureDebut.Name = "dtpHeureDebut";
            this.dtpHeureDebut.ShowUpDown = true;
            this.dtpHeureDebut.Size = new System.Drawing.Size(116, 34);
            this.dtpHeureDebut.TabIndex = 14;
            // 
            // lblDateFin
            // 
            this.lblDateFin.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDateFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblDateFin.Location = new System.Drawing.Point(38, 628);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(119, 37);
            this.lblDateFin.TabIndex = 15;
            this.lblDateFin.Text = "Date fin";
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFin.Location = new System.Drawing.Point(286, 628);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(210, 34);
            this.dtpDateFin.TabIndex = 16;
            // 
            // lblHeureFin
            // 
            this.lblHeureFin.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHeureFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.lblHeureFin.Location = new System.Drawing.Point(38, 714);
            this.lblHeureFin.Name = "lblHeureFin";
            this.lblHeureFin.Size = new System.Drawing.Size(136, 37);
            this.lblHeureFin.TabIndex = 17;
            this.lblHeureFin.Text = "Heure fin";
            // 
            // dtpHeureFin
            // 
            this.dtpHeureFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpHeureFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHeureFin.Location = new System.Drawing.Point(286, 722);
            this.dtpHeureFin.Name = "dtpHeureFin";
            this.dtpHeureFin.ShowUpDown = true;
            this.dtpHeureFin.Size = new System.Drawing.Size(116, 34);
            this.dtpHeureFin.TabIndex = 18;
            // 
            // btnAfficherPeriode
            // 
            this.btnAfficherPeriode.BackColor = System.Drawing.Color.White;
            this.btnAfficherPeriode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficherPeriode.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnAfficherPeriode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.btnAfficherPeriode.Location = new System.Drawing.Point(569, 794);
            this.btnAfficherPeriode.Name = "btnAfficherPeriode";
            this.btnAfficherPeriode.Size = new System.Drawing.Size(240, 54);
            this.btnAfficherPeriode.TabIndex = 19;
            this.btnAfficherPeriode.Text = "Afficher période";
            this.btnAfficherPeriode.UseVisualStyleBackColor = false;
            // 
            // btnTesterReservation
            // 
            this.btnTesterReservation.BackColor = System.Drawing.Color.White;
            this.btnTesterReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTesterReservation.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnTesterReservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.btnTesterReservation.Location = new System.Drawing.Point(1050, 640);
            this.btnTesterReservation.Name = "btnTesterReservation";
            this.btnTesterReservation.Size = new System.Drawing.Size(254, 54);
            this.btnTesterReservation.TabIndex = 20;
            this.btnTesterReservation.Text = "Tester la réservation";
            this.btnTesterReservation.UseVisualStyleBackColor = false;
            // 
            // btnReserver
            // 
            this.btnReserver.BackColor = System.Drawing.Color.White;
            this.btnReserver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserver.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnReserver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.btnReserver.Location = new System.Drawing.Point(784, 714);
            this.btnReserver.Name = "btnReserver";
            this.btnReserver.Size = new System.Drawing.Size(180, 54);
            this.btnReserver.TabIndex = 21;
            this.btnReserver.Text = "Réserver";
            this.btnReserver.UseVisualStyleBackColor = false;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.White;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnAnnuler.ForeColor = System.Drawing.Color.Firebrick;
            this.btnAnnuler.Location = new System.Drawing.Point(980, 714);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(150, 54);
            this.btnAnnuler.TabIndex = 22;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            // 
            // btnConfirmer
            // 
            this.btnConfirmer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(184)))), ((int)(((byte)(210)))));
            this.btnConfirmer.FlatAppearance.BorderSize = 0;
            this.btnConfirmer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmer.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnConfirmer.ForeColor = System.Drawing.Color.White;
            this.btnConfirmer.Location = new System.Drawing.Point(1144, 714);
            this.btnConfirmer.Name = "btnConfirmer";
            this.btnConfirmer.Size = new System.Drawing.Size(160, 54);
            this.btnConfirmer.TabIndex = 23;
            this.btnConfirmer.Text = "Confirmer";
            this.btnConfirmer.UseVisualStyleBackColor = false;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(150)))), ((int)(((byte)(220)))));
            this.pnlTop.Controls.Add(this.lblTitre);
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1360, 100);
            this.pnlTop.TabIndex = 24;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMain.Controls.Add(this.lblListeReservation);
            this.pnlMain.Controls.Add(this.lblListeClients);
            this.pnlMain.Controls.Add(this.lblListeVoiture);
            this.pnlMain.Controls.Add(this.dgvReservation);
            this.pnlMain.Controls.Add(this.dgvClients);
            this.pnlMain.Controls.Add(this.dgvVoitures);
            this.pnlMain.Controls.Add(this.lblClient);
            this.pnlMain.Controls.Add(this.cmbClient);
            this.pnlMain.Controls.Add(this.lblMatricule);
            this.pnlMain.Controls.Add(this.txtMatricule);
            this.pnlMain.Controls.Add(this.lblDateDebut);
            this.pnlMain.Controls.Add(this.dtpDateDebut);
            this.pnlMain.Controls.Add(this.lblHeureDebut);
            this.pnlMain.Controls.Add(this.dtpHeureDebut);
            this.pnlMain.Controls.Add(this.lblDateFin);
            this.pnlMain.Controls.Add(this.dtpDateFin);
            this.pnlMain.Controls.Add(this.lblHeureFin);
            this.pnlMain.Controls.Add(this.dtpHeureFin);
            this.pnlMain.Controls.Add(this.btnAfficherPeriode);
            this.pnlMain.Controls.Add(this.btnTesterReservation);
            this.pnlMain.Controls.Add(this.btnReserver);
            this.pnlMain.Controls.Add(this.btnAnnuler);
            this.pnlMain.Controls.Add(this.btnConfirmer);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1580, 914);
            this.pnlMain.TabIndex = 25;
            this.pnlMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMain_Paint);
            // 
            // reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1580, 914);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.MaximizeBox = false;
            this.Name = "reservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reservation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoitures)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Label lblTitre;
            private System.Windows.Forms.Label lblListeReservation;
            private System.Windows.Forms.Label lblListeClients;
            private System.Windows.Forms.Label lblListeVoiture;
            private System.Windows.Forms.DataGridView dgvReservation;
            private System.Windows.Forms.DataGridView dgvClients;
            private System.Windows.Forms.DataGridView dgvVoitures;
            private System.Windows.Forms.Label lblClient;
            private System.Windows.Forms.ComboBox cmbClient;
            private System.Windows.Forms.Label lblMatricule;
            private System.Windows.Forms.TextBox txtMatricule;
            private System.Windows.Forms.Label lblDateDebut;
            private System.Windows.Forms.DateTimePicker dtpDateDebut;
            private System.Windows.Forms.Label lblHeureDebut;
            private System.Windows.Forms.DateTimePicker dtpHeureDebut;
            private System.Windows.Forms.Label lblDateFin;
            private System.Windows.Forms.DateTimePicker dtpDateFin;
            private System.Windows.Forms.Label lblHeureFin;
            private System.Windows.Forms.DateTimePicker dtpHeureFin;
            private System.Windows.Forms.Button btnAfficherPeriode;
            private System.Windows.Forms.Button btnTesterReservation;
            private System.Windows.Forms.Button btnReserver;
            private System.Windows.Forms.Button btnAnnuler;
            private System.Windows.Forms.Button btnConfirmer;
            private System.Windows.Forms.Panel pnlTop;
            private System.Windows.Forms.Panel pnlMain;
        
    }
}

