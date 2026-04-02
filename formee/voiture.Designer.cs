namespace venolocation.formee
{
    partial class voiture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(voiture));
            this.lblTitre = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.gbListe = new System.Windows.Forms.GroupBox();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.cmbRecherche = new System.Windows.Forms.ComboBox();
            this.dgvVoitures = new System.Windows.Forms.DataGridView();
            this.gbInfoGauche = new System.Windows.Forms.GroupBox();
            this.btnChoisirImage = new System.Windows.Forms.Button();
            this.pbVoiture = new System.Windows.Forms.PictureBox();
            this.txtKilometrage = new System.Windows.Forms.TextBox();
            this.cmbBoiteVitesse = new System.Windows.Forms.ComboBox();
            this.cmbTypeCarburant = new System.Windows.Forms.ComboBox();
            this.cmbCategorie = new System.Windows.Forms.ComboBox();
            this.txtModele = new System.Windows.Forms.TextBox();
            this.txtMarque = new System.Windows.Forms.TextBox();
            this.txtImmatriculation = new System.Windows.Forms.TextBox();
            this.lblKilometrage = new System.Windows.Forms.Label();
            this.lblBoiteVitesse = new System.Windows.Forms.Label();
            this.lblTypeCarburant = new System.Windows.Forms.Label();
            this.lblCategorie = new System.Windows.Forms.Label();
            this.lblModele = new System.Windows.Forms.Label();
            this.lblMarque = new System.Windows.Forms.Label();
            this.lblImmatriculation = new System.Windows.Forms.Label();
            this.gbInfoDroite = new System.Windows.Forms.GroupBox();
            this.btnRechercheBas = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtCouleur = new System.Windows.Forms.TextBox();
            this.txtAnnee = new System.Windows.Forms.TextBox();
            this.txtPrixHeure = new System.Windows.Forms.TextBox();
            this.txtPrixJour = new System.Windows.Forms.TextBox();
            this.cmbEtat = new System.Windows.Forms.ComboBox();
            this.dtpFinAssurance = new System.Windows.Forms.DateTimePicker();
            this.dtpFinVidange = new System.Windows.Forms.DateTimePicker();
            this.lblCouleur = new System.Windows.Forms.Label();
            this.lblAnnee = new System.Windows.Forms.Label();
            this.lblPrixHeure = new System.Windows.Forms.Label();
            this.lblPrixJour = new System.Windows.Forms.Label();
            this.lblEtat = new System.Windows.Forms.Label();
            this.lblFinAssurance = new System.Windows.Forms.Label();
            this.lblFinVidange = new System.Windows.Forms.Label();
            this.gbListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoitures)).BeginInit();
            this.gbInfoGauche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoiture)).BeginInit();
            this.gbInfoDroite.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(65)))));
            this.lblTitre.Location = new System.Drawing.Point(31, 20);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(273, 45);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Gestion voitures";
            // 
            // btnAjouter
            // 
            this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(170)))), ((int)(((byte)(86)))));
            this.btnAjouter.FlatAppearance.BorderSize = 0;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(132, 405);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(228, 54);
            this.btnAjouter.TabIndex = 1;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(123)))), ((int)(((byte)(232)))));
            this.btnModifier.FlatAppearance.BorderSize = 0;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(491, 405);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(228, 54);
            this.btnModifier.TabIndex = 2;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(72)))), ((int)(((byte)(72)))));
            this.btnSupprimer.FlatAppearance.BorderSize = 0;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(857, 405);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(228, 54);
            this.btnSupprimer.TabIndex = 3;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // gbListe
            // 
            this.gbListe.Controls.Add(this.btnRecherche);
            this.gbListe.Controls.Add(this.txtRecherche);
            this.gbListe.Controls.Add(this.cmbRecherche);
            this.gbListe.Controls.Add(this.dgvVoitures);
            this.gbListe.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.gbListe.Location = new System.Drawing.Point(39, 68);
            this.gbListe.Name = "gbListe";
            this.gbListe.Size = new System.Drawing.Size(1293, 316);
            this.gbListe.TabIndex = 4;
            this.gbListe.TabStop = false;
            this.gbListe.Text = "Affichage voiture";
            // 
            // btnRecherche
            // 
            this.btnRecherche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(151)))), ((int)(((byte)(49)))));
            this.btnRecherche.FlatAppearance.BorderSize = 0;
            this.btnRecherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecherche.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnRecherche.ForeColor = System.Drawing.Color.White;
            this.btnRecherche.Location = new System.Drawing.Point(1157, 34);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(105, 35);
            this.btnRecherche.TabIndex = 3;
            this.btnRecherche.Text = "🔍";
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(277, 36);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(874, 31);
            this.txtRecherche.TabIndex = 2;
            // 
            // cmbRecherche
            // 
            this.cmbRecherche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecherche.FormattingEnabled = true;
            this.cmbRecherche.Items.AddRange(new object[] {
            "Immatriculation",
            "Marque",
            "Modèle",
            "Etat",
            "Couleur"});
            this.cmbRecherche.Location = new System.Drawing.Point(22, 35);
            this.cmbRecherche.Name = "cmbRecherche";
            this.cmbRecherche.Size = new System.Drawing.Size(241, 33);
            this.cmbRecherche.TabIndex = 1;
            // 
            // dgvVoitures
            // 
            this.dgvVoitures.AllowUserToAddRows = false;
            this.dgvVoitures.AllowUserToDeleteRows = false;
            this.dgvVoitures.AllowUserToResizeRows = false;
            this.dgvVoitures.BackgroundColor = System.Drawing.Color.White;
            this.dgvVoitures.ColumnHeadersHeight = 35;
            this.dgvVoitures.Location = new System.Drawing.Point(22, 82);
            this.dgvVoitures.MultiSelect = false;
            this.dgvVoitures.Name = "dgvVoitures";
            this.dgvVoitures.RowHeadersVisible = false;
            this.dgvVoitures.RowHeadersWidth = 51;
            this.dgvVoitures.RowTemplate.Height = 30;
            this.dgvVoitures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVoitures.Size = new System.Drawing.Size(1240, 214);
            this.dgvVoitures.TabIndex = 0;
            this.dgvVoitures.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoitures_CellClick);
            // 
            // gbInfoGauche
            // 
            this.gbInfoGauche.Controls.Add(this.btnChoisirImage);
            this.gbInfoGauche.Controls.Add(this.pbVoiture);
            this.gbInfoGauche.Controls.Add(this.txtKilometrage);
            this.gbInfoGauche.Controls.Add(this.cmbBoiteVitesse);
            this.gbInfoGauche.Controls.Add(this.cmbTypeCarburant);
            this.gbInfoGauche.Controls.Add(this.cmbCategorie);
            this.gbInfoGauche.Controls.Add(this.txtModele);
            this.gbInfoGauche.Controls.Add(this.txtMarque);
            this.gbInfoGauche.Controls.Add(this.txtImmatriculation);
            this.gbInfoGauche.Controls.Add(this.lblKilometrage);
            this.gbInfoGauche.Controls.Add(this.lblBoiteVitesse);
            this.gbInfoGauche.Controls.Add(this.lblTypeCarburant);
            this.gbInfoGauche.Controls.Add(this.lblCategorie);
            this.gbInfoGauche.Controls.Add(this.lblModele);
            this.gbInfoGauche.Controls.Add(this.lblMarque);
            this.gbInfoGauche.Controls.Add(this.lblImmatriculation);
            this.gbInfoGauche.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.gbInfoGauche.Location = new System.Drawing.Point(39, 490);
            this.gbInfoGauche.Name = "gbInfoGauche";
            this.gbInfoGauche.Size = new System.Drawing.Size(620, 342);
            this.gbInfoGauche.TabIndex = 5;
            this.gbInfoGauche.TabStop = false;
            this.gbInfoGauche.Text = "Informations voiture";
            // 
            // btnChoisirImage
            // 
            this.btnChoisirImage.BackColor = System.Drawing.Color.Gainsboro;
            this.btnChoisirImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoisirImage.Location = new System.Drawing.Point(427, 245);
            this.btnChoisirImage.Name = "btnChoisirImage";
            this.btnChoisirImage.Size = new System.Drawing.Size(165, 38);
            this.btnChoisirImage.TabIndex = 15;
            this.btnChoisirImage.Text = "Choisir image";
            this.btnChoisirImage.UseVisualStyleBackColor = false;
            this.btnChoisirImage.Click += new System.EventHandler(this.btnChoisirImage_Click);
            // 
            // pbVoiture
            // 
            this.pbVoiture.BackColor = System.Drawing.Color.White;
            this.pbVoiture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbVoiture.Location = new System.Drawing.Point(427, 50);
            this.pbVoiture.Name = "pbVoiture";
            this.pbVoiture.Size = new System.Drawing.Size(165, 180);
            this.pbVoiture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVoiture.TabIndex = 14;
            this.pbVoiture.TabStop = false;
            // 
            // txtKilometrage
            // 
            this.txtKilometrage.Location = new System.Drawing.Point(182, 282);
            this.txtKilometrage.Name = "txtKilometrage";
            this.txtKilometrage.Size = new System.Drawing.Size(210, 31);
            this.txtKilometrage.TabIndex = 13;
            // 
            // cmbBoiteVitesse
            // 
            this.cmbBoiteVitesse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoiteVitesse.FormattingEnabled = true;
            this.cmbBoiteVitesse.Items.AddRange(new object[] {
            "Manuelle",
            "Automatique"});
            this.cmbBoiteVitesse.Location = new System.Drawing.Point(182, 241);
            this.cmbBoiteVitesse.Name = "cmbBoiteVitesse";
            this.cmbBoiteVitesse.Size = new System.Drawing.Size(210, 33);
            this.cmbBoiteVitesse.TabIndex = 12;
            // 
            // cmbTypeCarburant
            // 
            this.cmbTypeCarburant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeCarburant.FormattingEnabled = true;
            this.cmbTypeCarburant.Items.AddRange(new object[] {
            "Diesel",
            "Essence",
            "Hybride",
            "Electrique"});
            this.cmbTypeCarburant.Location = new System.Drawing.Point(182, 200);
            this.cmbTypeCarburant.Name = "cmbTypeCarburant";
            this.cmbTypeCarburant.Size = new System.Drawing.Size(210, 33);
            this.cmbTypeCarburant.TabIndex = 11;
            // 
            // cmbCategorie
            // 
            this.cmbCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategorie.FormattingEnabled = true;
            this.cmbCategorie.Items.AddRange(new object[] {
            "Citadine",
            "SUV",
            "Berline",
            "Utilitaire",
            "Luxe"});
            this.cmbCategorie.Location = new System.Drawing.Point(182, 159);
            this.cmbCategorie.Name = "cmbCategorie";
            this.cmbCategorie.Size = new System.Drawing.Size(210, 33);
            this.cmbCategorie.TabIndex = 10;
            // 
            // txtModele
            // 
            this.txtModele.Location = new System.Drawing.Point(182, 118);
            this.txtModele.Name = "txtModele";
            this.txtModele.Size = new System.Drawing.Size(210, 31);
            this.txtModele.TabIndex = 9;
            // 
            // txtMarque
            // 
            this.txtMarque.Location = new System.Drawing.Point(182, 77);
            this.txtMarque.Name = "txtMarque";
            this.txtMarque.Size = new System.Drawing.Size(210, 31);
            this.txtMarque.TabIndex = 8;
            // 
            // txtImmatriculation
            // 
            this.txtImmatriculation.Location = new System.Drawing.Point(182, 36);
            this.txtImmatriculation.Name = "txtImmatriculation";
            this.txtImmatriculation.Size = new System.Drawing.Size(210, 31);
            this.txtImmatriculation.TabIndex = 7;
            // 
            // lblKilometrage
            // 
            this.lblKilometrage.AutoSize = true;
            this.lblKilometrage.Location = new System.Drawing.Point(18, 285);
            this.lblKilometrage.Name = "lblKilometrage";
            this.lblKilometrage.Size = new System.Drawing.Size(116, 25);
            this.lblKilometrage.TabIndex = 6;
            this.lblKilometrage.Text = "Kilométrage";
            // 
            // lblBoiteVitesse
            // 
            this.lblBoiteVitesse.AutoSize = true;
            this.lblBoiteVitesse.Location = new System.Drawing.Point(18, 244);
            this.lblBoiteVitesse.Name = "lblBoiteVitesse";
            this.lblBoiteVitesse.Size = new System.Drawing.Size(120, 25);
            this.lblBoiteVitesse.TabIndex = 5;
            this.lblBoiteVitesse.Text = "Boite vitesse";
            // 
            // lblTypeCarburant
            // 
            this.lblTypeCarburant.AutoSize = true;
            this.lblTypeCarburant.Location = new System.Drawing.Point(18, 203);
            this.lblTypeCarburant.Name = "lblTypeCarburant";
            this.lblTypeCarburant.Size = new System.Drawing.Size(141, 25);
            this.lblTypeCarburant.TabIndex = 4;
            this.lblTypeCarburant.Text = "Type carburant";
            // 
            // lblCategorie
            // 
            this.lblCategorie.AutoSize = true;
            this.lblCategorie.Location = new System.Drawing.Point(18, 162);
            this.lblCategorie.Name = "lblCategorie";
            this.lblCategorie.Size = new System.Drawing.Size(94, 25);
            this.lblCategorie.TabIndex = 3;
            this.lblCategorie.Text = "Catégorie";
            // 
            // lblModele
            // 
            this.lblModele.AutoSize = true;
            this.lblModele.Location = new System.Drawing.Point(18, 121);
            this.lblModele.Name = "lblModele";
            this.lblModele.Size = new System.Drawing.Size(76, 25);
            this.lblModele.TabIndex = 2;
            this.lblModele.Text = "Modèle";
            // 
            // lblMarque
            // 
            this.lblMarque.AutoSize = true;
            this.lblMarque.Location = new System.Drawing.Point(18, 80);
            this.lblMarque.Name = "lblMarque";
            this.lblMarque.Size = new System.Drawing.Size(78, 25);
            this.lblMarque.TabIndex = 1;
            this.lblMarque.Text = "Marque";
            // 
            // lblImmatriculation
            // 
            this.lblImmatriculation.AutoSize = true;
            this.lblImmatriculation.Location = new System.Drawing.Point(18, 39);
            this.lblImmatriculation.Name = "lblImmatriculation";
            this.lblImmatriculation.Size = new System.Drawing.Size(148, 25);
            this.lblImmatriculation.TabIndex = 0;
            this.lblImmatriculation.Text = "Immatriculation";
            // 
            // gbInfoDroite
            // 
            this.gbInfoDroite.Controls.Add(this.btnRechercheBas);
            this.gbInfoDroite.Controls.Add(this.btnClear);
            this.gbInfoDroite.Controls.Add(this.txtCouleur);
            this.gbInfoDroite.Controls.Add(this.txtAnnee);
            this.gbInfoDroite.Controls.Add(this.txtPrixHeure);
            this.gbInfoDroite.Controls.Add(this.txtPrixJour);
            this.gbInfoDroite.Controls.Add(this.cmbEtat);
            this.gbInfoDroite.Controls.Add(this.dtpFinAssurance);
            this.gbInfoDroite.Controls.Add(this.dtpFinVidange);
            this.gbInfoDroite.Controls.Add(this.lblCouleur);
            this.gbInfoDroite.Controls.Add(this.lblAnnee);
            this.gbInfoDroite.Controls.Add(this.lblPrixHeure);
            this.gbInfoDroite.Controls.Add(this.lblPrixJour);
            this.gbInfoDroite.Controls.Add(this.lblEtat);
            this.gbInfoDroite.Controls.Add(this.lblFinAssurance);
            this.gbInfoDroite.Controls.Add(this.lblFinVidange);
            this.gbInfoDroite.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.gbInfoDroite.Location = new System.Drawing.Point(712, 490);
            this.gbInfoDroite.Name = "gbInfoDroite";
            this.gbInfoDroite.Size = new System.Drawing.Size(620, 342);
            this.gbInfoDroite.TabIndex = 6;
            this.gbInfoDroite.TabStop = false;
            this.gbInfoDroite.Text = "Détails location";
            // 
            // btnRechercheBas
            // 
            this.btnRechercheBas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(151)))), ((int)(((byte)(49)))));
            this.btnRechercheBas.FlatAppearance.BorderSize = 0;
            this.btnRechercheBas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechercheBas.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRechercheBas.ForeColor = System.Drawing.Color.White;
            this.btnRechercheBas.Location = new System.Drawing.Point(451, 289);
            this.btnRechercheBas.Name = "btnRechercheBas";
            this.btnRechercheBas.Size = new System.Drawing.Size(140, 40);
            this.btnRechercheBas.TabIndex = 15;
            this.btnRechercheBas.Text = "Rechercher";
            this.btnRechercheBas.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(451, 242);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 40);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtCouleur
            // 
            this.txtCouleur.Location = new System.Drawing.Point(182, 282);
            this.txtCouleur.Name = "txtCouleur";
            this.txtCouleur.Size = new System.Drawing.Size(230, 31);
            this.txtCouleur.TabIndex = 13;
            // 
            // txtAnnee
            // 
            this.txtAnnee.Location = new System.Drawing.Point(182, 241);
            this.txtAnnee.Name = "txtAnnee";
            this.txtAnnee.Size = new System.Drawing.Size(230, 31);
            this.txtAnnee.TabIndex = 12;
            // 
            // txtPrixHeure
            // 
            this.txtPrixHeure.Location = new System.Drawing.Point(182, 200);
            this.txtPrixHeure.Name = "txtPrixHeure";
            this.txtPrixHeure.Size = new System.Drawing.Size(230, 31);
            this.txtPrixHeure.TabIndex = 11;
            // 
            // txtPrixJour
            // 
            this.txtPrixJour.Location = new System.Drawing.Point(182, 159);
            this.txtPrixJour.Name = "txtPrixJour";
            this.txtPrixJour.Size = new System.Drawing.Size(230, 31);
            this.txtPrixJour.TabIndex = 10;
            // 
            // cmbEtat
            // 
            this.cmbEtat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEtat.FormattingEnabled = true;
            this.cmbEtat.Items.AddRange(new object[] {
            "Disponible",
            "Louée",
            "Maintenance"});
            this.cmbEtat.Location = new System.Drawing.Point(182, 118);
            this.cmbEtat.Name = "cmbEtat";
            this.cmbEtat.Size = new System.Drawing.Size(230, 33);
            this.cmbEtat.TabIndex = 9;
            // 
            // dtpFinAssurance
            // 
            this.dtpFinAssurance.Location = new System.Drawing.Point(182, 78);
            this.dtpFinAssurance.Name = "dtpFinAssurance";
            this.dtpFinAssurance.Size = new System.Drawing.Size(306, 31);
            this.dtpFinAssurance.TabIndex = 8;
            // 
            // dtpFinVidange
            // 
            this.dtpFinVidange.Location = new System.Drawing.Point(182, 37);
            this.dtpFinVidange.Name = "dtpFinVidange";
            this.dtpFinVidange.Size = new System.Drawing.Size(306, 31);
            this.dtpFinVidange.TabIndex = 7;
            // 
            // lblCouleur
            // 
            this.lblCouleur.AutoSize = true;
            this.lblCouleur.Location = new System.Drawing.Point(21, 285);
            this.lblCouleur.Name = "lblCouleur";
            this.lblCouleur.Size = new System.Drawing.Size(78, 25);
            this.lblCouleur.TabIndex = 6;
            this.lblCouleur.Text = "Couleur";
            // 
            // lblAnnee
            // 
            this.lblAnnee.AutoSize = true;
            this.lblAnnee.Location = new System.Drawing.Point(21, 244);
            this.lblAnnee.Name = "lblAnnee";
            this.lblAnnee.Size = new System.Drawing.Size(67, 25);
            this.lblAnnee.TabIndex = 5;
            this.lblAnnee.Text = "Année";
            // 
            // lblPrixHeure
            // 
            this.lblPrixHeure.AutoSize = true;
            this.lblPrixHeure.Location = new System.Drawing.Point(21, 203);
            this.lblPrixHeure.Name = "lblPrixHeure";
            this.lblPrixHeure.Size = new System.Drawing.Size(99, 25);
            this.lblPrixHeure.TabIndex = 4;
            this.lblPrixHeure.Text = "Prix heure";
            // 
            // lblPrixJour
            // 
            this.lblPrixJour.AutoSize = true;
            this.lblPrixJour.Location = new System.Drawing.Point(21, 162);
            this.lblPrixJour.Name = "lblPrixJour";
            this.lblPrixJour.Size = new System.Drawing.Size(84, 25);
            this.lblPrixJour.TabIndex = 3;
            this.lblPrixJour.Text = "Prix jour";
            // 
            // lblEtat
            // 
            this.lblEtat.AutoSize = true;
            this.lblEtat.Location = new System.Drawing.Point(21, 121);
            this.lblEtat.Name = "lblEtat";
            this.lblEtat.Size = new System.Drawing.Size(46, 25);
            this.lblEtat.TabIndex = 2;
            this.lblEtat.Text = "Etat";
            // 
            // lblFinAssurance
            // 
            this.lblFinAssurance.AutoSize = true;
            this.lblFinAssurance.Location = new System.Drawing.Point(21, 80);
            this.lblFinAssurance.Name = "lblFinAssurance";
            this.lblFinAssurance.Size = new System.Drawing.Size(126, 25);
            this.lblFinAssurance.TabIndex = 1;
            this.lblFinAssurance.Text = "Fin assurance";
            // 
            // lblFinVidange
            // 
            this.lblFinVidange.AutoSize = true;
            this.lblFinVidange.Location = new System.Drawing.Point(21, 39);
            this.lblFinVidange.Name = "lblFinVidange";
            this.lblFinVidange.Size = new System.Drawing.Size(110, 25);
            this.lblFinVidange.TabIndex = 0;
            this.lblFinVidange.Text = "Fin vidange";
            // 
            // voiture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(1370, 860);
            this.Controls.Add(this.gbInfoDroite);
            this.Controls.Add(this.gbInfoGauche);
            this.Controls.Add(this.gbListe);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.lblTitre);
            this.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "voiture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "voituree";
            this.Load += new System.EventHandler(this.voiture_Load);
            this.gbListe.ResumeLayout(false);
            this.gbListe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoitures)).EndInit();
            this.gbInfoGauche.ResumeLayout(false);
            this.gbInfoGauche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVoiture)).EndInit();
            this.gbInfoDroite.ResumeLayout(false);
            this.gbInfoDroite.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Label lblTitre;
            private System.Windows.Forms.Button btnAjouter;
            private System.Windows.Forms.Button btnModifier;
            private System.Windows.Forms.Button btnSupprimer;
            private System.Windows.Forms.GroupBox gbListe;
            private System.Windows.Forms.Button btnRecherche;
            private System.Windows.Forms.TextBox txtRecherche;
            private System.Windows.Forms.ComboBox cmbRecherche;
            private System.Windows.Forms.DataGridView dgvVoitures;
            private System.Windows.Forms.GroupBox gbInfoGauche;
            private System.Windows.Forms.Button btnChoisirImage;
            private System.Windows.Forms.PictureBox pbVoiture;
            private System.Windows.Forms.TextBox txtKilometrage;
            private System.Windows.Forms.ComboBox cmbBoiteVitesse;
            private System.Windows.Forms.ComboBox cmbTypeCarburant;
            private System.Windows.Forms.ComboBox cmbCategorie;
            private System.Windows.Forms.TextBox txtModele;
            private System.Windows.Forms.TextBox txtMarque;
            private System.Windows.Forms.TextBox txtImmatriculation;
            private System.Windows.Forms.Label lblKilometrage;
            private System.Windows.Forms.Label lblBoiteVitesse;
            private System.Windows.Forms.Label lblTypeCarburant;
            private System.Windows.Forms.Label lblCategorie;
            private System.Windows.Forms.Label lblModele;
            private System.Windows.Forms.Label lblMarque;
            private System.Windows.Forms.Label lblImmatriculation;
            private System.Windows.Forms.GroupBox gbInfoDroite;
            private System.Windows.Forms.Button btnRechercheBas;
            private System.Windows.Forms.Button btnClear;
            private System.Windows.Forms.TextBox txtCouleur;
            private System.Windows.Forms.TextBox txtAnnee;
            private System.Windows.Forms.TextBox txtPrixHeure;
            private System.Windows.Forms.TextBox txtPrixJour;
            private System.Windows.Forms.ComboBox cmbEtat;
            private System.Windows.Forms.DateTimePicker dtpFinAssurance;
            private System.Windows.Forms.DateTimePicker dtpFinVidange;
            private System.Windows.Forms.Label lblCouleur;
            private System.Windows.Forms.Label lblAnnee;
            private System.Windows.Forms.Label lblPrixHeure;
            private System.Windows.Forms.Label lblPrixJour;
            private System.Windows.Forms.Label lblEtat;
            private System.Windows.Forms.Label lblFinAssurance;
            private System.Windows.Forms.Label lblFinVidange;
        
    }
}

    