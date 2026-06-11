namespace venolocation.formee
{
    partial class prolongation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(prolongation));
            this.pnlVoiture = new System.Windows.Forms.Panel();
            this.cbImmatriculation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVoitureSection = new System.Windows.Forms.Label();
            this.btnEnregistrer = new FontAwesome.Sharp.IconButton();
            this.txtNombreJours = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtDateFin = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cbHeureRetour = new System.Windows.Forms.ComboBox();
            this.numAvance = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTtl = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cbModePaiement = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtRestePayer = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tnImprimer = new FontAwesome.Sharp.IconButton();
            this.btncalculer = new FontAwesome.Sharp.IconButton();
            this.pnlVoiture.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlVoiture
            // 
            this.pnlVoiture.BackColor = System.Drawing.Color.White;
            this.pnlVoiture.Controls.Add(this.cbModePaiement);
            this.pnlVoiture.Controls.Add(this.label20);
            this.pnlVoiture.Controls.Add(this.txtRestePayer);
            this.pnlVoiture.Controls.Add(this.label19);
            this.pnlVoiture.Controls.Add(this.numAvance);
            this.pnlVoiture.Controls.Add(this.label18);
            this.pnlVoiture.Controls.Add(this.txtTtl);
            this.pnlVoiture.Controls.Add(this.label17);
            this.pnlVoiture.Controls.Add(this.label29);
            this.pnlVoiture.Controls.Add(this.cbHeureRetour);
            this.pnlVoiture.Controls.Add(this.txtNombreJours);
            this.pnlVoiture.Controls.Add(this.label16);
            this.pnlVoiture.Controls.Add(this.dtDateFin);
            this.pnlVoiture.Controls.Add(this.label15);
            this.pnlVoiture.Controls.Add(this.cbImmatriculation);
            this.pnlVoiture.Controls.Add(this.label6);
            this.pnlVoiture.Controls.Add(this.lblVoitureSection);
            this.pnlVoiture.Location = new System.Drawing.Point(12, 23);
            this.pnlVoiture.Name = "pnlVoiture";
            this.pnlVoiture.Size = new System.Drawing.Size(620, 563);
            this.pnlVoiture.TabIndex = 11;
            // 
            // cbImmatriculation
            // 
            this.cbImmatriculation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImmatriculation.Enabled = false;
            this.cbImmatriculation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbImmatriculation.FormattingEnabled = true;
            this.cbImmatriculation.Location = new System.Drawing.Point(221, 59);
            this.cbImmatriculation.Name = "cbImmatriculation";
            this.cbImmatriculation.Size = new System.Drawing.Size(299, 36);
            this.cbImmatriculation.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(22, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "ID contrats";
            // 
            // lblVoitureSection
            // 
            this.lblVoitureSection.AutoSize = true;
            this.lblVoitureSection.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblVoitureSection.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblVoitureSection.Location = new System.Drawing.Point(20, 8);
            this.lblVoitureSection.Name = "lblVoitureSection";
            this.lblVoitureSection.Size = new System.Drawing.Size(300, 37);
            this.lblVoitureSection.TabIndex = 0;
            this.lblVoitureSection.Text = "Prolongation contrats";
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
            this.btnEnregistrer.Location = new System.Drawing.Point(233, 615);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(0);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(177, 62);
            this.btnEnregistrer.TabIndex = 13;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            // 
            // txtNombreJours
            // 
            this.txtNombreJours.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNombreJours.Location = new System.Drawing.Point(221, 247);
            this.txtNombreJours.Name = "txtNombreJours";
            this.txtNombreJours.ReadOnly = true;
            this.txtNombreJours.Size = new System.Drawing.Size(299, 34);
            this.txtNombreJours.TabIndex = 10;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label16.Location = new System.Drawing.Point(22, 253);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(171, 28);
            this.label16.TabIndex = 9;
            this.label16.Text = "Nombre de jours";
            // 
            // dtDateFin
            // 
            this.dtDateFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtDateFin.Location = new System.Drawing.Point(221, 123);
            this.dtDateFin.Name = "dtDateFin";
            this.dtDateFin.Size = new System.Drawing.Size(299, 34);
            this.dtDateFin.TabIndex = 8;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label15.Location = new System.Drawing.Point(22, 129);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 28);
            this.label15.TabIndex = 7;
            this.label15.Text = "Date Fin";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label29.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label29.Location = new System.Drawing.Point(22, 191);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(82, 28);
            this.label29.TabIndex = 18;
            this.label29.Text = "L\'heure";
            // 
            // cbHeureRetour
            // 
            this.cbHeureRetour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHeureRetour.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbHeureRetour.FormattingEnabled = true;
            this.cbHeureRetour.Location = new System.Drawing.Point(221, 183);
            this.cbHeureRetour.Name = "cbHeureRetour";
            this.cbHeureRetour.Size = new System.Drawing.Size(299, 36);
            this.cbHeureRetour.TabIndex = 17;
            // 
            // numAvance
            // 
            this.numAvance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.numAvance.Location = new System.Drawing.Point(221, 373);
            this.numAvance.Name = "numAvance";
            this.numAvance.Size = new System.Drawing.Size(299, 34);
            this.numAvance.TabIndex = 22;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label18.Location = new System.Drawing.Point(22, 377);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 28);
            this.label18.TabIndex = 21;
            this.label18.Text = "Avance";
            // 
            // txtTtl
            // 
            this.txtTtl.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTtl.Location = new System.Drawing.Point(221, 311);
            this.txtTtl.Name = "txtTtl";
            this.txtTtl.ReadOnly = true;
            this.txtTtl.Size = new System.Drawing.Size(299, 34);
            this.txtTtl.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label17.Location = new System.Drawing.Point(22, 315);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 28);
            this.label17.TabIndex = 19;
            this.label17.Text = "Totale";
            // 
            // cbModePaiement
            // 
            this.cbModePaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModePaiement.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbModePaiement.FormattingEnabled = true;
            this.cbModePaiement.Location = new System.Drawing.Point(221, 497);
            this.cbModePaiement.Name = "cbModePaiement";
            this.cbModePaiement.Size = new System.Drawing.Size(299, 36);
            this.cbModePaiement.TabIndex = 26;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label20.Location = new System.Drawing.Point(22, 501);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(161, 28);
            this.label20.TabIndex = 25;
            this.label20.Text = "Mode paiement";
            // 
            // txtRestePayer
            // 
            this.txtRestePayer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRestePayer.Location = new System.Drawing.Point(221, 435);
            this.txtRestePayer.Name = "txtRestePayer";
            this.txtRestePayer.ReadOnly = true;
            this.txtRestePayer.Size = new System.Drawing.Size(299, 34);
            this.txtRestePayer.TabIndex = 24;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label19.Location = new System.Drawing.Point(22, 439);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(140, 28);
            this.label19.TabIndex = 23;
            this.label19.Text = "Reste à payer";
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
            this.tnImprimer.Location = new System.Drawing.Point(454, 615);
            this.tnImprimer.Margin = new System.Windows.Forms.Padding(0);
            this.tnImprimer.Name = "tnImprimer";
            this.tnImprimer.Size = new System.Drawing.Size(177, 62);
            this.tnImprimer.TabIndex = 14;
            this.tnImprimer.Text = "Imprimer";
            this.tnImprimer.UseVisualStyleBackColor = false;
            // 
            // btncalculer
            // 
            this.btncalculer.BackColor = System.Drawing.Color.Orange;
            this.btncalculer.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncalculer.ForeColor = System.Drawing.Color.White;
            this.btncalculer.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            this.btncalculer.IconColor = System.Drawing.Color.White;
            this.btncalculer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncalculer.IconSize = 38;
            this.btncalculer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncalculer.Location = new System.Drawing.Point(12, 615);
            this.btncalculer.Margin = new System.Windows.Forms.Padding(0);
            this.btncalculer.Name = "btncalculer";
            this.btncalculer.Size = new System.Drawing.Size(177, 62);
            this.btncalculer.TabIndex = 15;
            this.btncalculer.Text = "Calculer";
            this.btncalculer.UseVisualStyleBackColor = false;
            // 
            // prolongation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(644, 686);
            this.Controls.Add(this.btncalculer);
            this.Controls.Add(this.tnImprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.pnlVoiture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "prolongation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prolongation";
            this.Load += new System.EventHandler(this.prolongation_Load);
            this.pnlVoiture.ResumeLayout(false);
            this.pnlVoiture.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnEnregistrer;
        private System.Windows.Forms.Panel pnlVoiture;
        private System.Windows.Forms.ComboBox cbImmatriculation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblVoitureSection;
        private System.Windows.Forms.TextBox txtNombreJours;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtDateFin;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cbHeureRetour;
        private System.Windows.Forms.TextBox numAvance;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTtl;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cbModePaiement;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtRestePayer;
        private System.Windows.Forms.Label label19;
        private FontAwesome.Sharp.IconButton tnImprimer;
        private FontAwesome.Sharp.IconButton btncalculer;
    }
}