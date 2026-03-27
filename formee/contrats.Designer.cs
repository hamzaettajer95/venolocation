namespace venolocation.formee
{
    partial class contrats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(contrats));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPermis = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboClient = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClientSection = new System.Windows.Forms.Label();
            this.pnlVoiture = new System.Windows.Forms.Panel();
            this.txtPrixJour = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtKilometrage = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboCategorie = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboPuissance = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboCarburant = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboModele = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMarque = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboImmatriculation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblVoitureSection = new System.Windows.Forms.Label();
            this.pnlPeriode = new System.Windows.Forms.Panel();
            this.txtNombreJours = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.lblPeriodeSection = new System.Windows.Forms.Label();
            this.pnlPaiement = new System.Windows.Forms.Panel();
            this.cboModePaiement = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtResteAPayer = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.nudAvance = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPrixTotal = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblPaiementSection = new System.Windows.Forms.Label();
            this.pnlRemarques = new System.Windows.Forms.Panel();
            this.txtRemarques = new System.Windows.Forms.TextBox();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.tnImprimer = new FontAwesome.Sharp.IconButton();
            this.btnEnregistrer = new FontAwesome.Sharp.IconButton();
            this.btnannuller = new FontAwesome.Sharp.IconButton();
            this.btncalculer = new FontAwesome.Sharp.IconButton();
            this.btnNouveau = new FontAwesome.Sharp.IconButton();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblFooterTotal = new System.Windows.Forms.Label();
            this.lblDureeValue = new System.Windows.Forms.Label();
            this.lblFooterDuree = new System.Windows.Forms.Label();
            this.lblContratValue = new System.Windows.Forms.Label();
            this.lblFooterContrat = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlClient.SuspendLayout();
            this.pnlVoiture.SuspendLayout();
            this.pnlPeriode.SuspendLayout();
            this.pnlPaiement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvance)).BeginInit();
            this.pnlRemarques.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Location = new System.Drawing.Point(12, 12);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1260, 71);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(38, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(414, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Gestion des Contrats";
            // 
            // pnlClient
            // 
            this.pnlClient.BackColor = System.Drawing.Color.White;
            this.pnlClient.Controls.Add(this.txtAdresse);
            this.pnlClient.Controls.Add(this.label5);
            this.pnlClient.Controls.Add(this.txtPermis);
            this.pnlClient.Controls.Add(this.label4);
            this.pnlClient.Controls.Add(this.txtTelephone);
            this.pnlClient.Controls.Add(this.label3);
            this.pnlClient.Controls.Add(this.txtNom);
            this.pnlClient.Controls.Add(this.label2);
            this.pnlClient.Controls.Add(this.cboClient);
            this.pnlClient.Controls.Add(this.label1);
            this.pnlClient.Controls.Add(this.lblClientSection);
            this.pnlClient.Location = new System.Drawing.Point(12, 93);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(610, 312);
            this.pnlClient.TabIndex = 1;
            // 
            // txtAdresse
            // 
            this.txtAdresse.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtAdresse.Location = new System.Drawing.Point(166, 235);
            this.txtAdresse.Multiline = true;
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(325, 44);
            this.txtAdresse.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(22, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Adresse";
            // 
            // txtPermis
            // 
            this.txtPermis.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPermis.Location = new System.Drawing.Point(166, 191);
            this.txtPermis.Name = "txtPermis";
            this.txtPermis.Size = new System.Drawing.Size(325, 34);
            this.txtPermis.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label4.Location = new System.Drawing.Point(22, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Permis";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtTelephone.Location = new System.Drawing.Point(166, 147);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(325, 34);
            this.txtTelephone.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(22, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Téléphone";
            // 
            // txtNom
            // 
            this.txtNom.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNom.Location = new System.Drawing.Point(166, 103);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(325, 34);
            this.txtNom.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(22, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nom";
            // 
            // cboClient
            // 
            this.cboClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClient.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboClient.FormattingEnabled = true;
            this.cboClient.Location = new System.Drawing.Point(166, 59);
            this.cboClient.Name = "cboClient";
            this.cboClient.Size = new System.Drawing.Size(325, 36);
            this.cboClient.TabIndex = 2;
            this.cboClient.SelectedIndexChanged += new System.EventHandler(this.cboClient_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(22, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client";
            // 
            // lblClientSection
            // 
            this.lblClientSection.AutoSize = true;
            this.lblClientSection.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblClientSection.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblClientSection.Location = new System.Drawing.Point(20, 9);
            this.lblClientSection.Name = "lblClientSection";
            this.lblClientSection.Size = new System.Drawing.Size(163, 37);
            this.lblClientSection.TabIndex = 0;
            this.lblClientSection.Text = "Infos Client";
            // 
            // pnlVoiture
            // 
            this.pnlVoiture.BackColor = System.Drawing.Color.White;
            this.pnlVoiture.Controls.Add(this.txtPrixJour);
            this.pnlVoiture.Controls.Add(this.label13);
            this.pnlVoiture.Controls.Add(this.txtKilometrage);
            this.pnlVoiture.Controls.Add(this.label12);
            this.pnlVoiture.Controls.Add(this.cboCategorie);
            this.pnlVoiture.Controls.Add(this.label11);
            this.pnlVoiture.Controls.Add(this.cboPuissance);
            this.pnlVoiture.Controls.Add(this.label10);
            this.pnlVoiture.Controls.Add(this.cboCarburant);
            this.pnlVoiture.Controls.Add(this.label9);
            this.pnlVoiture.Controls.Add(this.cboModele);
            this.pnlVoiture.Controls.Add(this.label8);
            this.pnlVoiture.Controls.Add(this.cboMarque);
            this.pnlVoiture.Controls.Add(this.label7);
            this.pnlVoiture.Controls.Add(this.cboImmatriculation);
            this.pnlVoiture.Controls.Add(this.label6);
            this.pnlVoiture.Controls.Add(this.lblVoitureSection);
            this.pnlVoiture.Location = new System.Drawing.Point(662, 93);
            this.pnlVoiture.Name = "pnlVoiture";
            this.pnlVoiture.Size = new System.Drawing.Size(610, 312);
            this.pnlVoiture.TabIndex = 2;
            // 
            // txtPrixJour
            // 
            this.txtPrixJour.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrixJour.Location = new System.Drawing.Point(435, 235);
            this.txtPrixJour.Name = "txtPrixJour";
            this.txtPrixJour.Size = new System.Drawing.Size(138, 34);
            this.txtPrixJour.TabIndex = 16;
            this.txtPrixJour.TextChanged += new System.EventHandler(this.txtPrixJour_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label13.Location = new System.Drawing.Point(324, 238);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 28);
            this.label13.TabIndex = 15;
            this.label13.Text = "Prix /Jour";
            // 
            // txtKilometrage
            // 
            this.txtKilometrage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtKilometrage.Location = new System.Drawing.Point(435, 191);
            this.txtKilometrage.Name = "txtKilometrage";
            this.txtKilometrage.Size = new System.Drawing.Size(138, 34);
            this.txtKilometrage.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label12.Location = new System.Drawing.Point(295, 194);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 28);
            this.label12.TabIndex = 13;
            this.label12.Text = "Kilométrage";
            // 
            // cboCategorie
            // 
            this.cboCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategorie.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboCategorie.FormattingEnabled = true;
            this.cboCategorie.Location = new System.Drawing.Point(142, 235);
            this.cboCategorie.Name = "cboCategorie";
            this.cboCategorie.Size = new System.Drawing.Size(133, 36);
            this.cboCategorie.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label11.Location = new System.Drawing.Point(24, 238);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 28);
            this.label11.TabIndex = 11;
            this.label11.Text = "Catégorie";
            // 
            // cboPuissance
            // 
            this.cboPuissance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPuissance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboPuissance.FormattingEnabled = true;
            this.cboPuissance.Location = new System.Drawing.Point(142, 191);
            this.cboPuissance.Name = "cboPuissance";
            this.cboPuissance.Size = new System.Drawing.Size(133, 36);
            this.cboPuissance.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label10.Location = new System.Drawing.Point(24, 194);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 28);
            this.label10.TabIndex = 9;
            this.label10.Text = "Puissance";
            // 
            // cboCarburant
            // 
            this.cboCarburant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCarburant.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboCarburant.FormattingEnabled = true;
            this.cboCarburant.Location = new System.Drawing.Point(142, 147);
            this.cboCarburant.Name = "cboCarburant";
            this.cboCarburant.Size = new System.Drawing.Size(431, 36);
            this.cboCarburant.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(24, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 28);
            this.label9.TabIndex = 7;
            this.label9.Text = "Carburant";
            // 
            // cboModele
            // 
            this.cboModele.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModele.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboModele.FormattingEnabled = true;
            this.cboModele.Location = new System.Drawing.Point(435, 103);
            this.cboModele.Name = "cboModele";
            this.cboModele.Size = new System.Drawing.Size(138, 36);
            this.cboModele.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(340, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 28);
            this.label8.TabIndex = 5;
            this.label8.Text = "Modèle";
            // 
            // cboMarque
            // 
            this.cboMarque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarque.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboMarque.FormattingEnabled = true;
            this.cboMarque.Location = new System.Drawing.Point(142, 103);
            this.cboMarque.Name = "cboMarque";
            this.cboMarque.Size = new System.Drawing.Size(133, 36);
            this.cboMarque.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(24, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 28);
            this.label7.TabIndex = 3;
            this.label7.Text = "Marque";
            // 
            // cboImmatriculation
            // 
            this.cboImmatriculation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboImmatriculation.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboImmatriculation.FormattingEnabled = true;
            this.cboImmatriculation.Location = new System.Drawing.Point(221, 59);
            this.cboImmatriculation.Name = "cboImmatriculation";
            this.cboImmatriculation.Size = new System.Drawing.Size(352, 36);
            this.cboImmatriculation.TabIndex = 2;
            this.cboImmatriculation.SelectedIndexChanged += new System.EventHandler(this.cboImmatriculation_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label6.Location = new System.Drawing.Point(24, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(164, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Immatriculation";
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
            // pnlPeriode
            // 
            this.pnlPeriode.BackColor = System.Drawing.Color.White;
            this.pnlPeriode.Controls.Add(this.txtNombreJours);
            this.pnlPeriode.Controls.Add(this.label16);
            this.pnlPeriode.Controls.Add(this.dtpDateFin);
            this.pnlPeriode.Controls.Add(this.label15);
            this.pnlPeriode.Controls.Add(this.dtpDateDebut);
            this.pnlPeriode.Controls.Add(this.label14);
            this.pnlPeriode.Controls.Add(this.lblPeriodeSection);
            this.pnlPeriode.Location = new System.Drawing.Point(12, 411);
            this.pnlPeriode.Name = "pnlPeriode";
            this.pnlPeriode.Size = new System.Drawing.Size(610, 243);
            this.pnlPeriode.TabIndex = 3;
            // 
            // txtNombreJours
            // 
            this.txtNombreJours.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtNombreJours.Location = new System.Drawing.Point(234, 193);
            this.txtNombreJours.Name = "txtNombreJours";
            this.txtNombreJours.ReadOnly = true;
            this.txtNombreJours.Size = new System.Drawing.Size(269, 34);
            this.txtNombreJours.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label16.Location = new System.Drawing.Point(32, 196);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(171, 28);
            this.label16.TabIndex = 5;
            this.label16.Text = "Nombre de jours";
            // 
            // dtpDateFin
            // 
            this.dtpDateFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDateFin.Location = new System.Drawing.Point(200, 122);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(303, 34);
            this.dtpDateFin.TabIndex = 4;
            this.dtpDateFin.ValueChanged += new System.EventHandler(this.dtpDateFin_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label15.Location = new System.Drawing.Point(32, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 28);
            this.label15.TabIndex = 3;
            this.label15.Text = "Date Fin";
            // 
            // dtpDateDebut
            // 
            this.dtpDateDebut.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDateDebut.Location = new System.Drawing.Point(200, 72);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(303, 34);
            this.dtpDateDebut.TabIndex = 2;
            this.dtpDateDebut.ValueChanged += new System.EventHandler(this.dtpDateDebut_ValueChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label14.Location = new System.Drawing.Point(32, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 28);
            this.label14.TabIndex = 1;
            this.label14.Text = "Date Début";
            // 
            // lblPeriodeSection
            // 
            this.lblPeriodeSection.AutoSize = true;
            this.lblPeriodeSection.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPeriodeSection.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPeriodeSection.Location = new System.Drawing.Point(20, 12);
            this.lblPeriodeSection.Name = "lblPeriodeSection";
            this.lblPeriodeSection.Size = new System.Drawing.Size(267, 37);
            this.lblPeriodeSection.TabIndex = 0;
            this.lblPeriodeSection.Text = "Période de location";
            // 
            // pnlPaiement
            // 
            this.pnlPaiement.BackColor = System.Drawing.Color.White;
            this.pnlPaiement.Controls.Add(this.cboModePaiement);
            this.pnlPaiement.Controls.Add(this.label20);
            this.pnlPaiement.Controls.Add(this.txtResteAPayer);
            this.pnlPaiement.Controls.Add(this.label19);
            this.pnlPaiement.Controls.Add(this.nudAvance);
            this.pnlPaiement.Controls.Add(this.label18);
            this.pnlPaiement.Controls.Add(this.txtPrixTotal);
            this.pnlPaiement.Controls.Add(this.label17);
            this.pnlPaiement.Controls.Add(this.lblPaiementSection);
            this.pnlPaiement.Location = new System.Drawing.Point(662, 411);
            this.pnlPaiement.Name = "pnlPaiement";
            this.pnlPaiement.Size = new System.Drawing.Size(610, 243);
            this.pnlPaiement.TabIndex = 4;
            // 
            // cboModePaiement
            // 
            this.cboModePaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModePaiement.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cboModePaiement.FormattingEnabled = true;
            this.cboModePaiement.Location = new System.Drawing.Point(235, 175);
            this.cboModePaiement.Name = "cboModePaiement";
            this.cboModePaiement.Size = new System.Drawing.Size(303, 36);
            this.cboModePaiement.TabIndex = 8;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label20.Location = new System.Drawing.Point(48, 178);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(161, 28);
            this.label20.TabIndex = 7;
            this.label20.Text = "Mode paiement";
            // 
            // txtResteAPayer
            // 
            this.txtResteAPayer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtResteAPayer.Location = new System.Drawing.Point(235, 125);
            this.txtResteAPayer.Name = "txtResteAPayer";
            this.txtResteAPayer.ReadOnly = true;
            this.txtResteAPayer.Size = new System.Drawing.Size(303, 34);
            this.txtResteAPayer.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label19.Location = new System.Drawing.Point(48, 128);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(140, 28);
            this.label19.TabIndex = 5;
            this.label19.Text = "Reste à payer";
            // 
            // nudAvance
            // 
            this.nudAvance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.nudAvance.Location = new System.Drawing.Point(235, 75);
            this.nudAvance.Name = "nudAvance";
            this.nudAvance.Size = new System.Drawing.Size(140, 34);
            this.nudAvance.TabIndex = 4;
            this.nudAvance.ValueChanged += new System.EventHandler(this.nudAvance_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label18.Location = new System.Drawing.Point(48, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 28);
            this.label18.TabIndex = 3;
            this.label18.Text = "Avance";
            // 
            // txtPrixTotal
            // 
            this.txtPrixTotal.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPrixTotal.Location = new System.Drawing.Point(435, 75);
            this.txtPrixTotal.Name = "txtPrixTotal";
            this.txtPrixTotal.ReadOnly = true;
            this.txtPrixTotal.Size = new System.Drawing.Size(103, 34);
            this.txtPrixTotal.TabIndex = 2;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label17.Location = new System.Drawing.Point(390, 78);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(38, 28);
            this.label17.TabIndex = 1;
            this.label17.Text = "Ttl";
            // 
            // lblPaiementSection
            // 
            this.lblPaiementSection.AutoSize = true;
            this.lblPaiementSection.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPaiementSection.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblPaiementSection.Location = new System.Drawing.Point(20, 11);
            this.lblPaiementSection.Name = "lblPaiementSection";
            this.lblPaiementSection.Size = new System.Drawing.Size(138, 37);
            this.lblPaiementSection.TabIndex = 0;
            this.lblPaiementSection.Text = "Paiement";
            // 
            // pnlRemarques
            // 
            this.pnlRemarques.BackColor = System.Drawing.Color.White;
            this.pnlRemarques.Controls.Add(this.txtRemarques);
            this.pnlRemarques.Location = new System.Drawing.Point(12, 670);
            this.pnlRemarques.Name = "pnlRemarques";
            this.pnlRemarques.Size = new System.Drawing.Size(610, 120);
            this.pnlRemarques.TabIndex = 5;
            // 
            // txtRemarques
            // 
            this.txtRemarques.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtRemarques.Location = new System.Drawing.Point(14, 21);
            this.txtRemarques.Multiline = true;
            this.txtRemarques.Name = "txtRemarques";
            this.txtRemarques.Size = new System.Drawing.Size(580, 73);
            this.txtRemarques.TabIndex = 0;
            this.txtRemarques.Text = "Remarques / Notes (optionnel)";
            // 
            // pnlActions
            // 
            this.pnlActions.BackColor = System.Drawing.Color.White;
            this.pnlActions.Controls.Add(this.tnImprimer);
            this.pnlActions.Controls.Add(this.btnEnregistrer);
            this.pnlActions.Controls.Add(this.btnannuller);
            this.pnlActions.Controls.Add(this.btncalculer);
            this.pnlActions.Controls.Add(this.btnNouveau);
            this.pnlActions.Location = new System.Drawing.Point(662, 670);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(610, 120);
            this.pnlActions.TabIndex = 6;
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
            this.tnImprimer.Location = new System.Drawing.Point(328, 65);
            this.tnImprimer.Margin = new System.Windows.Forms.Padding(0);
            this.tnImprimer.Name = "tnImprimer";
            this.tnImprimer.Size = new System.Drawing.Size(177, 42);
            this.tnImprimer.TabIndex = 9;
            this.tnImprimer.Text = "Imprimer";
            this.tnImprimer.UseVisualStyleBackColor = false;
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
            this.btnEnregistrer.Location = new System.Drawing.Point(67, 65);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(0);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(177, 42);
            this.btnEnregistrer.TabIndex = 8;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click_1);
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
            this.btnannuller.Location = new System.Drawing.Point(417, 17);
            this.btnannuller.Margin = new System.Windows.Forms.Padding(0);
            this.btnannuller.Name = "btnannuller";
            this.btnannuller.Size = new System.Drawing.Size(177, 42);
            this.btnannuller.TabIndex = 7;
            this.btnannuller.Text = "Anuller";
            this.btnannuller.UseVisualStyleBackColor = false;
            this.btnannuller.Click += new System.EventHandler(this.btnannuller_Click);
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
            this.btncalculer.Location = new System.Drawing.Point(220, 17);
            this.btncalculer.Margin = new System.Windows.Forms.Padding(0);
            this.btncalculer.Name = "btncalculer";
            this.btncalculer.Size = new System.Drawing.Size(177, 42);
            this.btncalculer.TabIndex = 6;
            this.btncalculer.Text = "Calculer";
            this.btncalculer.UseVisualStyleBackColor = false;
            this.btncalculer.Click += new System.EventHandler(this.btncalculer_Click_1);
            // 
            // btnNouveau
            // 
            this.btnNouveau.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNouveau.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveau.ForeColor = System.Drawing.Color.White;
            this.btnNouveau.IconChar = FontAwesome.Sharp.IconChar.MagicWandSparkles;
            this.btnNouveau.IconColor = System.Drawing.Color.White;
            this.btnNouveau.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNouveau.IconSize = 38;
            this.btnNouveau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNouveau.Location = new System.Drawing.Point(12, 17);
            this.btnNouveau.Margin = new System.Windows.Forms.Padding(0);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(177, 42);
            this.btnNouveau.TabIndex = 1;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = false;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click_1);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.AliceBlue;
            this.pnlFooter.Controls.Add(this.lblTotalValue);
            this.pnlFooter.Controls.Add(this.lblFooterTotal);
            this.pnlFooter.Controls.Add(this.lblDureeValue);
            this.pnlFooter.Controls.Add(this.lblFooterDuree);
            this.pnlFooter.Controls.Add(this.lblContratValue);
            this.pnlFooter.Controls.Add(this.lblFooterContrat);
            this.pnlFooter.Location = new System.Drawing.Point(12, 806);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1260, 60);
            this.pnlFooter.TabIndex = 7;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalValue.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTotalValue.Location = new System.Drawing.Point(1047, 17);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(77, 25);
            this.lblTotalValue.TabIndex = 5;
            this.lblTotalValue.Text = "0,00 DH";
            // 
            // lblFooterTotal
            // 
            this.lblFooterTotal.AutoSize = true;
            this.lblFooterTotal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFooterTotal.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblFooterTotal.Location = new System.Drawing.Point(978, 17);
            this.lblFooterTotal.Name = "lblFooterTotal";
            this.lblFooterTotal.Size = new System.Drawing.Size(60, 25);
            this.lblFooterTotal.TabIndex = 4;
            this.lblFooterTotal.Text = "Total:";
            // 
            // lblDureeValue
            // 
            this.lblDureeValue.AutoSize = true;
            this.lblDureeValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDureeValue.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDureeValue.Location = new System.Drawing.Point(688, 17);
            this.lblDureeValue.Name = "lblDureeValue";
            this.lblDureeValue.Size = new System.Drawing.Size(61, 25);
            this.lblDureeValue.TabIndex = 3;
            this.lblDureeValue.Text = "1 jour";
            // 
            // lblFooterDuree
            // 
            this.lblFooterDuree.AutoSize = true;
            this.lblFooterDuree.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFooterDuree.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblFooterDuree.Location = new System.Drawing.Point(611, 17);
            this.lblFooterDuree.Name = "lblFooterDuree";
            this.lblFooterDuree.Size = new System.Drawing.Size(71, 25);
            this.lblFooterDuree.TabIndex = 2;
            this.lblFooterDuree.Text = "Durée:";
            // 
            // lblContratValue
            // 
            this.lblContratValue.AutoSize = true;
            this.lblContratValue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblContratValue.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblContratValue.Location = new System.Drawing.Point(164, 17);
            this.lblContratValue.Name = "lblContratValue";
            this.lblContratValue.Size = new System.Drawing.Size(93, 25);
            this.lblContratValue.TabIndex = 1;
            this.lblContratValue.Text = "CTR-0001";
            // 
            // lblFooterContrat
            // 
            this.lblFooterContrat.AutoSize = true;
            this.lblFooterContrat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFooterContrat.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblFooterContrat.Location = new System.Drawing.Point(34, 17);
            this.lblFooterContrat.Name = "lblFooterContrat";
            this.lblFooterContrat.Size = new System.Drawing.Size(117, 25);
            this.lblFooterContrat.TabIndex = 0;
            this.lblFooterContrat.Text = "Contrat N° :";
            // 
            // contrats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1284, 881);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlRemarques);
            this.Controls.Add(this.pnlPaiement);
            this.Controls.Add(this.pnlPeriode);
            this.Controls.Add(this.pnlVoiture);
            this.Controls.Add(this.pnlClient);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "contrats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "contrats";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            this.pnlVoiture.ResumeLayout(false);
            this.pnlVoiture.PerformLayout();
            this.pnlPeriode.ResumeLayout(false);
            this.pnlPeriode.PerformLayout();
            this.pnlPaiement.ResumeLayout(false);
            this.pnlPaiement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAvance)).EndInit();
            this.pnlRemarques.ResumeLayout(false);
            this.pnlRemarques.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.Panel pnlHeader;
            private System.Windows.Forms.Label lblTitle;

            private System.Windows.Forms.Panel pnlClient;
            private System.Windows.Forms.Label lblClientSection;
            private System.Windows.Forms.Label label1;
            private System.Windows.Forms.ComboBox cboClient;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.TextBox txtNom;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.TextBox txtTelephone;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.TextBox txtPermis;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.TextBox txtAdresse;

            private System.Windows.Forms.Panel pnlVoiture;
            private System.Windows.Forms.Label lblVoitureSection;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.ComboBox cboImmatriculation;
            private System.Windows.Forms.Label label7;
            private System.Windows.Forms.ComboBox cboMarque;
            private System.Windows.Forms.Label label8;
            private System.Windows.Forms.ComboBox cboModele;
            private System.Windows.Forms.Label label9;
            private System.Windows.Forms.ComboBox cboCarburant;
            private System.Windows.Forms.Label label10;
            private System.Windows.Forms.ComboBox cboPuissance;
            private System.Windows.Forms.Label label11;
            private System.Windows.Forms.ComboBox cboCategorie;
            private System.Windows.Forms.Label label12;
            private System.Windows.Forms.TextBox txtKilometrage;
            private System.Windows.Forms.Label label13;
            private System.Windows.Forms.TextBox txtPrixJour;

            private System.Windows.Forms.Panel pnlPeriode;
            private System.Windows.Forms.Label lblPeriodeSection;
            private System.Windows.Forms.Label label14;
            private System.Windows.Forms.DateTimePicker dtpDateDebut;
            private System.Windows.Forms.Label label15;
            private System.Windows.Forms.DateTimePicker dtpDateFin;
            private System.Windows.Forms.Label label16;
            private System.Windows.Forms.TextBox txtNombreJours;

            private System.Windows.Forms.Panel pnlPaiement;
            private System.Windows.Forms.Label lblPaiementSection;
            private System.Windows.Forms.Label label17;
            private System.Windows.Forms.TextBox txtPrixTotal;
            private System.Windows.Forms.Label label18;
            private System.Windows.Forms.NumericUpDown nudAvance;
            private System.Windows.Forms.Label label19;
            private System.Windows.Forms.TextBox txtResteAPayer;
            private System.Windows.Forms.Label label20;
            private System.Windows.Forms.ComboBox cboModePaiement;

            private System.Windows.Forms.Panel pnlRemarques;
            private System.Windows.Forms.TextBox txtRemarques;

            private System.Windows.Forms.Panel pnlActions;

            private System.Windows.Forms.Panel pnlFooter;
            private System.Windows.Forms.Label lblFooterContrat;
            private System.Windows.Forms.Label lblContratValue;
            private System.Windows.Forms.Label lblFooterDuree;
            private System.Windows.Forms.Label lblDureeValue;
            private System.Windows.Forms.Label lblFooterTotal;
            private System.Windows.Forms.Label lblTotalValue;
        private FontAwesome.Sharp.IconButton btnNouveau;
        private FontAwesome.Sharp.IconButton btnannuller;
        private FontAwesome.Sharp.IconButton btncalculer;
        private FontAwesome.Sharp.IconButton btnEnregistrer;
        private FontAwesome.Sharp.IconButton tnImprimer;
    }
}
