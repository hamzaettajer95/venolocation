namespace venolocation.formee
{
    partial class liste_contrat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(liste_contrat));
            this.pnlVoiture = new System.Windows.Forms.Panel();
            this.txt_prix = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ancine_voiture = new System.Windows.Forms.TextBox();
            this.txt_contrat = new System.Windows.Forms.TextBox();
            this.cb_voiture = new System.Windows.Forms.ComboBox();
            this.txt_kilometrage_anciene = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemarques = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbHeureRetour = new System.Windows.Forms.ComboBox();
            this.dtDateDebut = new System.Windows.Forms.DateTimePicker();
            this.txt_kilometrage = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVoitureSection = new System.Windows.Forms.Label();
            this.btnEnregistrer = new FontAwesome.Sharp.IconButton();
            this.btnannuller = new FontAwesome.Sharp.IconButton();
            this.tnImprimer = new FontAwesome.Sharp.IconButton();
            this.pictureBoxEtatVoiture2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxEtatVoiture = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pnlVoiture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEtatVoiture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEtatVoiture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlVoiture
            // 
            this.pnlVoiture.BackColor = System.Drawing.Color.White;
            this.pnlVoiture.Controls.Add(this.pictureBoxEtatVoiture2);
            this.pnlVoiture.Controls.Add(this.txt_prix);
            this.pnlVoiture.Controls.Add(this.pictureBoxEtatVoiture);
            this.pnlVoiture.Controls.Add(this.label2);
            this.pnlVoiture.Controls.Add(this.pictureBoxLogo);
            this.pnlVoiture.Controls.Add(this.txt_ancine_voiture);
            this.pnlVoiture.Controls.Add(this.txt_contrat);
            this.pnlVoiture.Controls.Add(this.cb_voiture);
            this.pnlVoiture.Controls.Add(this.txt_kilometrage_anciene);
            this.pnlVoiture.Controls.Add(this.label1);
            this.pnlVoiture.Controls.Add(this.txtRemarques);
            this.pnlVoiture.Controls.Add(this.cbHeureRetour);
            this.pnlVoiture.Controls.Add(this.dtDateDebut);
            this.pnlVoiture.Controls.Add(this.txt_kilometrage);
            this.pnlVoiture.Controls.Add(this.label13);
            this.pnlVoiture.Controls.Add(this.label12);
            this.pnlVoiture.Controls.Add(this.label11);
            this.pnlVoiture.Controls.Add(this.label9);
            this.pnlVoiture.Controls.Add(this.label8);
            this.pnlVoiture.Controls.Add(this.label7);
            this.pnlVoiture.Controls.Add(this.label6);
            this.pnlVoiture.Controls.Add(this.lblVoitureSection);
            this.pnlVoiture.Location = new System.Drawing.Point(9, 12);
            this.pnlVoiture.Name = "pnlVoiture";
            this.pnlVoiture.Size = new System.Drawing.Size(631, 659);
            this.pnlVoiture.TabIndex = 3;
            this.pnlVoiture.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlVoiture_Paint);
            // 
            // txt_prix
            // 
            this.txt_prix.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_prix.Location = new System.Drawing.Point(244, 479);
            this.txt_prix.Name = "txt_prix";
            this.txt_prix.Size = new System.Drawing.Size(365, 34);
            this.txt_prix.TabIndex = 28;
            this.txt_prix.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(22, 486);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 28);
            this.label2.TabIndex = 27;
            this.label2.Text = "prix sup";
            // 
            // txt_ancine_voiture
            // 
            this.txt_ancine_voiture.Enabled = false;
            this.txt_ancine_voiture.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_ancine_voiture.Location = new System.Drawing.Point(244, 120);
            this.txt_ancine_voiture.Name = "txt_ancine_voiture";
            this.txt_ancine_voiture.Size = new System.Drawing.Size(365, 34);
            this.txt_ancine_voiture.TabIndex = 26;
            // 
            // txt_contrat
            // 
            this.txt_contrat.Enabled = false;
            this.txt_contrat.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_contrat.Location = new System.Drawing.Point(244, 64);
            this.txt_contrat.Name = "txt_contrat";
            this.txt_contrat.Size = new System.Drawing.Size(365, 34);
            this.txt_contrat.TabIndex = 25;
            // 
            // cb_voiture
            // 
            this.cb_voiture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_voiture.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cb_voiture.FormattingEnabled = true;
            this.cb_voiture.Location = new System.Drawing.Point(244, 234);
            this.cb_voiture.Name = "cb_voiture";
            this.cb_voiture.Size = new System.Drawing.Size(365, 36);
            this.cb_voiture.TabIndex = 24;
            this.cb_voiture.SelectedIndexChanged += new System.EventHandler(this.cb_voiture_SelectedIndexChanged_1);
            // 
            // txt_kilometrage_anciene
            // 
            this.txt_kilometrage_anciene.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_kilometrage_anciene.Location = new System.Drawing.Point(244, 177);
            this.txt_kilometrage_anciene.Name = "txt_kilometrage_anciene";
            this.txt_kilometrage_anciene.Size = new System.Drawing.Size(365, 34);
            this.txt_kilometrage_anciene.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(22, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 28);
            this.label1.TabIndex = 22;
            this.label1.Text = "kilometrage Anciene";
            // 
            // txtRemarques
            // 
            this.txtRemarques.BorderRadius = 10;
            this.txtRemarques.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarques.DefaultText = "";
            this.txtRemarques.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRemarques.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRemarques.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRemarques.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRemarques.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRemarques.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarques.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRemarques.Location = new System.Drawing.Point(230, 549);
            this.txtRemarques.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtRemarques.Multiline = true;
            this.txtRemarques.Name = "txtRemarques";
            this.txtRemarques.PlaceholderText = "Remarques / Notes (optionnel)";
            this.txtRemarques.SelectedText = "";
            this.txtRemarques.Size = new System.Drawing.Size(379, 94);
            this.txtRemarques.TabIndex = 20;
            // 
            // cbHeureRetour
            // 
            this.cbHeureRetour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHeureRetour.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbHeureRetour.FormattingEnabled = true;
            this.cbHeureRetour.Location = new System.Drawing.Point(244, 350);
            this.cbHeureRetour.Name = "cbHeureRetour";
            this.cbHeureRetour.Size = new System.Drawing.Size(365, 36);
            this.cbHeureRetour.TabIndex = 18;
            // 
            // dtDateDebut
            // 
            this.dtDateDebut.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtDateDebut.Location = new System.Drawing.Point(244, 293);
            this.dtDateDebut.Name = "dtDateDebut";
            this.dtDateDebut.Size = new System.Drawing.Size(365, 34);
            this.dtDateDebut.TabIndex = 17;
            // 
            // txt_kilometrage
            // 
            this.txt_kilometrage.Enabled = false;
            this.txt_kilometrage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txt_kilometrage.Location = new System.Drawing.Point(244, 413);
            this.txt_kilometrage.Name = "txt_kilometrage";
            this.txt_kilometrage.Size = new System.Drawing.Size(365, 34);
            this.txt_kilometrage.TabIndex = 16;
            this.txt_kilometrage.TextChanged += new System.EventHandler(this.txtPrixJour_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(22, 418);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(213, 28);
            this.label13.TabIndex = 15;
            this.label13.Text = "kilometrage nouvelle";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label12.Location = new System.Drawing.Point(22, 302);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(177, 28);
            this.label12.TabIndex = 13;
            this.label12.Text = "date changement";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label11.Location = new System.Drawing.Point(22, 361);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 28);
            this.label11.TabIndex = 11;
            this.label11.Text = "Heure changement";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(22, 242);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(172, 28);
            this.label9.TabIndex = 7;
            this.label9.Text = "Nouvelle Voiture";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(8, 564);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 28);
            this.label8.TabIndex = 5;
            this.label8.Text = "remarque";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(22, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 28);
            this.label7.TabIndex = 3;
            this.label7.Text = "Id contrats";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(22, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Ancienne Voiture";
            // 
            // lblVoitureSection
            // 
            this.lblVoitureSection.AutoSize = true;
            this.lblVoitureSection.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblVoitureSection.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblVoitureSection.Location = new System.Drawing.Point(20, 8);
            this.lblVoitureSection.Name = "lblVoitureSection";
            this.lblVoitureSection.Size = new System.Drawing.Size(182, 37);
            this.lblVoitureSection.TabIndex = 0;
            this.lblVoitureSection.Text = "Infos Voiture";
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEnregistrer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnEnregistrer.IconColor = System.Drawing.Color.White;
            this.btnEnregistrer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEnregistrer.IconSize = 38;
            this.btnEnregistrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnregistrer.Location = new System.Drawing.Point(9, 674);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(0);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(177, 62);
            this.btnEnregistrer.TabIndex = 10;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnannuller
            // 
            this.btnannuller.BackColor = System.Drawing.Color.Tomato;
            this.btnannuller.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnannuller.ForeColor = System.Drawing.Color.White;
            this.btnannuller.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.btnannuller.IconColor = System.Drawing.Color.White;
            this.btnannuller.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnannuller.IconSize = 38;
            this.btnannuller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnannuller.Location = new System.Drawing.Point(455, 674);
            this.btnannuller.Margin = new System.Windows.Forms.Padding(0);
            this.btnannuller.Name = "btnannuller";
            this.btnannuller.Size = new System.Drawing.Size(177, 62);
            this.btnannuller.TabIndex = 9;
            this.btnannuller.Text = "Anuller";
            this.btnannuller.UseVisualStyleBackColor = false;
            this.btnannuller.Click += new System.EventHandler(this.btnannuller_Click);
            // 
            // tnImprimer
            // 
            this.tnImprimer.BackColor = System.Drawing.Color.Blue;
            this.tnImprimer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tnImprimer.ForeColor = System.Drawing.Color.White;
            this.tnImprimer.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.tnImprimer.IconColor = System.Drawing.Color.White;
            this.tnImprimer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.tnImprimer.IconSize = 38;
            this.tnImprimer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tnImprimer.Location = new System.Drawing.Point(232, 674);
            this.tnImprimer.Margin = new System.Windows.Forms.Padding(0);
            this.tnImprimer.Name = "tnImprimer";
            this.tnImprimer.Size = new System.Drawing.Size(177, 62);
            this.tnImprimer.TabIndex = 15;
            this.tnImprimer.Text = "Imprimer";
            this.tnImprimer.UseVisualStyleBackColor = false;
            this.tnImprimer.Click += new System.EventHandler(this.tnImprimer_Click);
            // 
            // pictureBoxEtatVoiture2
            // 
            this.pictureBoxEtatVoiture2.Image = global::venolocation.Properties.Resources.images1;
            this.pictureBoxEtatVoiture2.Location = new System.Drawing.Point(341, 24);
            this.pictureBoxEtatVoiture2.Name = "pictureBoxEtatVoiture2";
            this.pictureBoxEtatVoiture2.Size = new System.Drawing.Size(24, 21);
            this.pictureBoxEtatVoiture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEtatVoiture2.TabIndex = 18;
            this.pictureBoxEtatVoiture2.TabStop = false;
            this.pictureBoxEtatVoiture2.Visible = false;
            // 
            // pictureBoxEtatVoiture
            // 
            this.pictureBoxEtatVoiture.Image = global::venolocation.Properties.Resources.images2;
            this.pictureBoxEtatVoiture.Location = new System.Drawing.Point(312, 20);
            this.pictureBoxEtatVoiture.Name = "pictureBoxEtatVoiture";
            this.pictureBoxEtatVoiture.Size = new System.Drawing.Size(23, 25);
            this.pictureBoxEtatVoiture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEtatVoiture.TabIndex = 17;
            this.pictureBoxEtatVoiture.TabStop = false;
            this.pictureBoxEtatVoiture.Visible = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::venolocation.Properties.Resources.certificate;
            this.pictureBoxLogo.Location = new System.Drawing.Point(244, 20);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(30, 25);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 16;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Visible = false;
            // 
            // liste_contrat
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(654, 745);
            this.Controls.Add(this.tnImprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnannuller);
            this.Controls.Add(this.pnlVoiture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "liste_contrat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Changement Voiture";
            this.Load += new System.EventHandler(this.liste_contrat_Load);
            this.pnlVoiture.ResumeLayout(false);
            this.pnlVoiture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEtatVoiture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEtatVoiture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVoiture;
        private System.Windows.Forms.TextBox txt_kilometrage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblVoitureSection;
        private FontAwesome.Sharp.IconButton btnEnregistrer;
        private FontAwesome.Sharp.IconButton btnannuller;
        private System.Windows.Forms.DateTimePicker dtDateDebut;
        private System.Windows.Forms.ComboBox cbHeureRetour;
        private Guna.UI2.WinForms.Guna2TextBox txtRemarques;
        private FontAwesome.Sharp.IconButton tnImprimer;
        private System.Windows.Forms.TextBox txt_kilometrage_anciene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_voiture;
        private System.Windows.Forms.TextBox txt_contrat;
        private System.Windows.Forms.TextBox txt_ancine_voiture;
        private System.Windows.Forms.TextBox txt_prix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxEtatVoiture2;
        private System.Windows.Forms.PictureBox pictureBoxEtatVoiture;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
    }
}