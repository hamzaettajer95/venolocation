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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reservation));
            this.lblDateSection = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtDateFin = new System.Windows.Forms.DateTimePicker();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.dtDateDebut = new System.Windows.Forms.DateTimePicker();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.cbHeureDebut = new System.Windows.Forms.ComboBox();
            this.cbHeureFin = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVerifierDate = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnValider = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.cbVoiture = new System.Windows.Forms.ComboBox();
            this.lblVoiture = new System.Windows.Forms.Label();
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAnnuler = new FontAwesome.Sharp.IconButton();
            this.btnNouvelle = new FontAwesome.Sharp.IconButton();
            this.btnReserver = new FontAwesome.Sharp.IconButton();
            this.btnConfirmer = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDateSection
            // 
            this.lblDateSection.BackColor = System.Drawing.Color.Transparent;
            this.lblDateSection.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblDateSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.lblDateSection.Location = new System.Drawing.Point(3, 14);
            this.lblDateSection.Name = "lblDateSection";
            this.lblDateSection.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblDateSection.Size = new System.Drawing.Size(316, 40);
            this.lblDateSection.TabIndex = 35;
            this.lblDateSection.Text = "Sélectionner la Date :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(94)))), ((int)(((byte)(118)))));
            this.label2.Location = new System.Drawing.Point(1084, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 28);
            this.label2.TabIndex = 33;
            this.label2.Text = "Heur Fin :";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(94)))), ((int)(((byte)(118)))));
            this.label1.Location = new System.Drawing.Point(429, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 28);
            this.label1.TabIndex = 31;
            this.label1.Text = "Heur Début :";
            // 
            // dtDateFin
            // 
            this.dtDateFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateFin.Location = new System.Drawing.Point(838, 81);
            this.dtDateFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtDateFin.Name = "dtDateFin";
            this.dtDateFin.Size = new System.Drawing.Size(230, 34);
            this.dtDateFin.TabIndex = 30;
            // 
            // lblDateFin
            // 
            this.lblDateFin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDateFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(94)))), ((int)(((byte)(118)))));
            this.lblDateFin.Location = new System.Drawing.Point(720, 87);
            this.lblDateFin.Name = "lblDateFin";
            this.lblDateFin.Size = new System.Drawing.Size(102, 28);
            this.lblDateFin.TabIndex = 29;
            this.lblDateFin.Text = "Date Fin :";
            // 
            // dtDateDebut
            // 
            this.dtDateDebut.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateDebut.Location = new System.Drawing.Point(183, 81);
            this.dtDateDebut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtDateDebut.Name = "dtDateDebut";
            this.dtDateDebut.Size = new System.Drawing.Size(230, 34);
            this.dtDateDebut.TabIndex = 28;
            // 
            // lblDateDebut
            // 
            this.lblDateDebut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDateDebut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(94)))), ((int)(((byte)(118)))));
            this.lblDateDebut.Location = new System.Drawing.Point(35, 87);
            this.lblDateDebut.Name = "lblDateDebut";
            this.lblDateDebut.Size = new System.Drawing.Size(132, 28);
            this.lblDateDebut.TabIndex = 27;
            this.lblDateDebut.Text = "Date Début :";
            // 
            // cbHeureDebut
            // 
            this.cbHeureDebut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbHeureDebut.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHeureDebut.FormattingEnabled = true;
            this.cbHeureDebut.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cbHeureDebut.Location = new System.Drawing.Point(578, 82);
            this.cbHeureDebut.Name = "cbHeureDebut";
            this.cbHeureDebut.Size = new System.Drawing.Size(107, 33);
            this.cbHeureDebut.TabIndex = 36;
            // 
            // cbHeureFin
            // 
            this.cbHeureFin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbHeureFin.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHeureFin.FormattingEnabled = true;
            this.cbHeureFin.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cbHeureFin.Location = new System.Drawing.Point(1203, 82);
            this.cbHeureFin.Name = "cbHeureFin";
            this.cbHeureFin.Size = new System.Drawing.Size(107, 33);
            this.cbHeureFin.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblDateSection);
            this.panel1.Controls.Add(this.btnVerifierDate);
            this.panel1.Controls.Add(this.cbHeureFin);
            this.panel1.Controls.Add(this.cbHeureDebut);
            this.panel1.Controls.Add(this.lblDateDebut);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtDateDebut);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDateFin);
            this.panel1.Controls.Add(this.dtDateFin);
            this.panel1.Location = new System.Drawing.Point(12, 649);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1358, 201);
            this.panel1.TabIndex = 38;
            // 
            // btnVerifierDate
            // 
            this.btnVerifierDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnVerifierDate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(194)))), ((int)(((byte)(202)))));
            this.btnVerifierDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerifierDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnVerifierDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(120)))));
            this.btnVerifierDate.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.btnVerifierDate.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(120)))));
            this.btnVerifierDate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerifierDate.IconSize = 24;
            this.btnVerifierDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerifierDate.Location = new System.Drawing.Point(567, 146);
            this.btnVerifierDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerifierDate.Name = "btnVerifierDate";
            this.btnVerifierDate.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVerifierDate.Size = new System.Drawing.Size(255, 40);
            this.btnVerifierDate.TabIndex = 26;
            this.btnVerifierDate.Text = "Vérifier la Date";
            this.btnVerifierDate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerifierDate.UseVisualStyleBackColor = false;
            this.btnVerifierDate.Click += new System.EventHandler(this.btnVerifierDate_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnValider);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cbClient);
            this.panel3.Controls.Add(this.lblClient);
            this.panel3.Controls.Add(this.cbVoiture);
            this.panel3.Controls.Add(this.lblVoiture);
            this.panel3.Location = new System.Drawing.Point(12, 475);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1358, 168);
            this.panel3.TabIndex = 40;
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnValider.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(194)))), ((int)(((byte)(202)))));
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnValider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(120)))));
            this.btnValider.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.btnValider.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(120)))));
            this.btnValider.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnValider.IconSize = 24;
            this.btnValider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValider.Location = new System.Drawing.Point(625, 116);
            this.btnValider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValider.Name = "btnValider";
            this.btnValider.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnValider.Size = new System.Drawing.Size(153, 40);
            this.btnValider.TabIndex = 38;
            this.btnValider.Text = "    Validé";
            this.btnValider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(94)))), ((int)(((byte)(118)))));
            this.label4.Location = new System.Drawing.Point(949, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "Choisir la Client";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(94)))), ((int)(((byte)(118)))));
            this.label3.Location = new System.Drawing.Point(263, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Choisir la Voiture";
            // 
            // cbClient
            // 
            this.cbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbClient.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbClient.FormattingEnabled = true;
            this.cbClient.Location = new System.Drawing.Point(800, 58);
            this.cbClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbClient.Name = "cbClient";
            this.cbClient.Size = new System.Drawing.Size(510, 36);
            this.cbClient.TabIndex = 7;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(94)))), ((int)(((byte)(118)))));
            this.lblClient.Location = new System.Drawing.Point(680, 60);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(85, 30);
            this.lblClient.TabIndex = 6;
            this.lblClient.Text = "Client :";
            // 
            // cbVoiture
            // 
            this.cbVoiture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVoiture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbVoiture.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cbVoiture.FormattingEnabled = true;
            this.cbVoiture.Location = new System.Drawing.Point(125, 58);
            this.cbVoiture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbVoiture.Name = "cbVoiture";
            this.cbVoiture.Size = new System.Drawing.Size(470, 36);
            this.cbVoiture.TabIndex = 5;
            // 
            // lblVoiture
            // 
            this.lblVoiture.AutoSize = true;
            this.lblVoiture.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblVoiture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(94)))), ((int)(((byte)(118)))));
            this.lblVoiture.Location = new System.Drawing.Point(10, 60);
            this.lblVoiture.Name = "lblVoiture";
            this.lblVoiture.Size = new System.Drawing.Size(101, 30);
            this.lblVoiture.TabIndex = 4;
            this.lblVoiture.Text = "Voiture :";
            // 
            // dgvReservations
            // 
            this.dgvReservations.AllowUserToAddRows = false;
            this.dgvReservations.AllowUserToDeleteRows = false;
            this.dgvReservations.AllowUserToResizeColumns = false;
            this.dgvReservations.AllowUserToResizeRows = false;
            this.dgvReservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservations.BackgroundColor = System.Drawing.Color.White;
            this.dgvReservations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReservations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReservations.ColumnHeadersHeight = 48;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReservations.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReservations.EnableHeadersVisualStyles = false;
            this.dgvReservations.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(221)))), ((int)(((byte)(229)))));
            this.dgvReservations.Location = new System.Drawing.Point(12, 11);
            this.dgvReservations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReservations.MultiSelect = false;
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.RowHeadersVisible = false;
            this.dgvReservations.RowHeadersWidth = 51;
            this.dgvReservations.RowTemplate.Height = 42;
            this.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservations.Size = new System.Drawing.Size(1358, 344);
            this.dgvReservations.TabIndex = 41;
            this.dgvReservations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReservations_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnAnnuler);
            this.panel2.Controls.Add(this.btnNouvelle);
            this.panel2.Controls.Add(this.btnReserver);
            this.panel2.Controls.Add(this.btnConfirmer);
            this.panel2.Location = new System.Drawing.Point(12, 369);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1358, 100);
            this.panel2.TabIndex = 42;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btnAnnuler.IconColor = System.Drawing.Color.White;
            this.btnAnnuler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAnnuler.IconSize = 32;
            this.btnAnnuler.Location = new System.Drawing.Point(1045, 27);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(190, 50);
            this.btnAnnuler.TabIndex = 25;
            this.btnAnnuler.Text = "   Annuler";
            this.btnAnnuler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnNouvelle
            // 
            this.btnNouvelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.btnNouvelle.FlatAppearance.BorderSize = 0;
            this.btnNouvelle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouvelle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNouvelle.ForeColor = System.Drawing.Color.White;
            this.btnNouvelle.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.btnNouvelle.IconColor = System.Drawing.Color.White;
            this.btnNouvelle.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNouvelle.IconSize = 32;
            this.btnNouvelle.Location = new System.Drawing.Point(136, 27);
            this.btnNouvelle.Margin = new System.Windows.Forms.Padding(3, 2, 28, 2);
            this.btnNouvelle.Name = "btnNouvelle";
            this.btnNouvelle.Size = new System.Drawing.Size(190, 50);
            this.btnNouvelle.TabIndex = 22;
            this.btnNouvelle.Text = "    Nouvelle";
            this.btnNouvelle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNouvelle.UseVisualStyleBackColor = false;
            this.btnNouvelle.Click += new System.EventHandler(this.btnNouvelle_Click);
            // 
            // btnReserver
            // 
            this.btnReserver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnReserver.FlatAppearance.BorderSize = 0;
            this.btnReserver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserver.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReserver.ForeColor = System.Drawing.Color.White;
            this.btnReserver.IconChar = FontAwesome.Sharp.IconChar.CalendarPlus;
            this.btnReserver.IconColor = System.Drawing.Color.White;
            this.btnReserver.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnReserver.IconSize = 32;
            this.btnReserver.Location = new System.Drawing.Point(436, 27);
            this.btnReserver.Margin = new System.Windows.Forms.Padding(3, 2, 28, 2);
            this.btnReserver.Name = "btnReserver";
            this.btnReserver.Size = new System.Drawing.Size(190, 50);
            this.btnReserver.TabIndex = 23;
            this.btnReserver.Text = "   Réserver";
            this.btnReserver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReserver.UseVisualStyleBackColor = false;
            this.btnReserver.Click += new System.EventHandler(this.btnReserver_Click);
            // 
            // btnConfirmer
            // 
            this.btnConfirmer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(144)))), ((int)(((byte)(25)))));
            this.btnConfirmer.FlatAppearance.BorderSize = 0;
            this.btnConfirmer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnConfirmer.ForeColor = System.Drawing.Color.White;
            this.btnConfirmer.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
            this.btnConfirmer.IconColor = System.Drawing.Color.White;
            this.btnConfirmer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfirmer.IconSize = 32;
            this.btnConfirmer.Location = new System.Drawing.Point(766, 27);
            this.btnConfirmer.Margin = new System.Windows.Forms.Padding(3, 2, 28, 2);
            this.btnConfirmer.Name = "btnConfirmer";
            this.btnConfirmer.Size = new System.Drawing.Size(190, 50);
            this.btnConfirmer.TabIndex = 24;
            this.btnConfirmer.Text = "    Confirmer";
            this.btnConfirmer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmer.UseVisualStyleBackColor = false;
            this.btnConfirmer.Click += new System.EventHandler(this.btnConfirmer_Click);
            // 
            // reservation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1382, 853);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvReservations);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "reservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reservation";
            this.Load += new System.EventHandler(this.reservation_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDateSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtDateFin;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.DateTimePicker dtDateDebut;
        private System.Windows.Forms.Label lblDateDebut;
        private FontAwesome.Sharp.IconButton btnVerifierDate;
        private System.Windows.Forms.ComboBox cbHeureDebut;
        private System.Windows.Forms.ComboBox cbHeureFin;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btnValider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cbVoiture;
        private System.Windows.Forms.Label lblVoiture;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnAnnuler;
        private FontAwesome.Sharp.IconButton btnNouvelle;
        private FontAwesome.Sharp.IconButton btnReserver;
        private FontAwesome.Sharp.IconButton btnConfirmer;
    }
}