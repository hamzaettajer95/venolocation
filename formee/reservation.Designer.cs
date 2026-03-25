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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDateSection = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateFin = new System.Windows.Forms.DateTimePicker();
            this.lblDateFin = new System.Windows.Forms.Label();
            this.dtpDateDebut = new System.Windows.Forms.DateTimePicker();
            this.lblDateDebut = new System.Windows.Forms.Label();
            this.btnVerifierDate = new FontAwesome.Sharp.IconButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.cmbVoiture = new System.Windows.Forms.ComboBox();
            this.lblVoiture = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVoiture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateDebut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAnnuler = new FontAwesome.Sharp.IconButton();
            this.btnNouvelleReservation = new FontAwesome.Sharp.IconButton();
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
            // dtpDateFin
            // 
            this.dtpDateFin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFin.Location = new System.Drawing.Point(838, 81);
            this.dtpDateFin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateFin.Name = "dtpDateFin";
            this.dtpDateFin.Size = new System.Drawing.Size(230, 34);
            this.dtpDateFin.TabIndex = 30;
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
            // dtpDateDebut
            // 
            this.dtpDateDebut.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dtpDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDebut.Location = new System.Drawing.Point(183, 81);
            this.dtpDateDebut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateDebut.Name = "dtpDateDebut";
            this.dtpDateDebut.Size = new System.Drawing.Size(230, 34);
            this.dtpDateDebut.TabIndex = 28;
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
            this.btnVerifierDate.Location = new System.Drawing.Point(591, 158);
            this.btnVerifierDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVerifierDate.Name = "btnVerifierDate";
            this.btnVerifierDate.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnVerifierDate.Size = new System.Drawing.Size(255, 35);
            this.btnVerifierDate.TabIndex = 26;
            this.btnVerifierDate.Text = "Vérifier la Date";
            this.btnVerifierDate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerifierDate.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
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
            this.comboBox1.Location = new System.Drawing.Point(578, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 33);
            this.comboBox1.TabIndex = 36;
            // 
            // comboBox2
            // 
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
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
            this.comboBox2.Location = new System.Drawing.Point(1203, 82);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(107, 33);
            this.comboBox2.TabIndex = 37;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDateSection);
            this.panel1.Controls.Add(this.btnVerifierDate);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.lblDateDebut);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpDateDebut);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblDateFin);
            this.panel1.Controls.Add(this.dtpDateFin);
            this.panel1.Location = new System.Drawing.Point(12, 649);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1358, 201);
            this.panel1.TabIndex = 38;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.iconButton1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cmbClient);
            this.panel3.Controls.Add(this.lblClient);
            this.panel3.Controls.Add(this.cmbVoiture);
            this.panel3.Controls.Add(this.lblVoiture);
            this.panel3.Location = new System.Drawing.Point(12, 475);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1358, 168);
            this.panel3.TabIndex = 40;
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbClient.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(800, 58);
            this.cmbClient.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(510, 36);
            this.cmbClient.TabIndex = 7;
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
            // cmbVoiture
            // 
            this.cmbVoiture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoiture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbVoiture.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbVoiture.FormattingEnabled = true;
            this.cmbVoiture.Location = new System.Drawing.Point(125, 58);
            this.cmbVoiture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbVoiture.Name = "cmbVoiture";
            this.cmbVoiture.Size = new System.Drawing.Size(470, 36);
            this.cmbVoiture.TabIndex = 5;
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
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(194)))), ((int)(((byte)(202)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.iconButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(120)))));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.iconButton1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(120)))));
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 24;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(642, 120);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton1.Size = new System.Drawing.Size(153, 35);
            this.iconButton1.TabIndex = 38;
            this.iconButton1.Text = "    Validé";
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(140)))), ((int)(((byte)(170)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReservations.ColumnHeadersHeight = 48;
            this.dgvReservations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colVoiture,
            this.colClient,
            this.colDateDebut,
            this.colDateFin,
            this.colStatut});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(241)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReservations.DefaultCellStyle = dataGridViewCellStyle6;
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
            // 
            // colID
            // 
            this.colID.FillWeight = 55F;
            this.colID.HeaderText = "ID";
            this.colID.MinimumWidth = 6;
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            // 
            // colVoiture
            // 
            this.colVoiture.HeaderText = "Voiture";
            this.colVoiture.MinimumWidth = 6;
            this.colVoiture.Name = "colVoiture";
            this.colVoiture.ReadOnly = true;
            // 
            // colClient
            // 
            this.colClient.HeaderText = "Client";
            this.colClient.MinimumWidth = 6;
            this.colClient.Name = "colClient";
            this.colClient.ReadOnly = true;
            // 
            // colDateDebut
            // 
            this.colDateDebut.HeaderText = "Date Début";
            this.colDateDebut.MinimumWidth = 6;
            this.colDateDebut.Name = "colDateDebut";
            this.colDateDebut.ReadOnly = true;
            // 
            // colDateFin
            // 
            this.colDateFin.HeaderText = "Date Fin";
            this.colDateFin.MinimumWidth = 6;
            this.colDateFin.Name = "colDateFin";
            this.colDateFin.ReadOnly = true;
            // 
            // colStatut
            // 
            this.colStatut.HeaderText = "Statut";
            this.colStatut.MinimumWidth = 6;
            this.colStatut.Name = "colStatut";
            this.colStatut.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAnnuler);
            this.panel2.Controls.Add(this.btnNouvelleReservation);
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
            // 
            // btnNouvelleReservation
            // 
            this.btnNouvelleReservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(150)))), ((int)(((byte)(85)))));
            this.btnNouvelleReservation.FlatAppearance.BorderSize = 0;
            this.btnNouvelleReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouvelleReservation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnNouvelleReservation.ForeColor = System.Drawing.Color.White;
            this.btnNouvelleReservation.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.btnNouvelleReservation.IconColor = System.Drawing.Color.White;
            this.btnNouvelleReservation.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNouvelleReservation.IconSize = 32;
            this.btnNouvelleReservation.Location = new System.Drawing.Point(136, 27);
            this.btnNouvelleReservation.Margin = new System.Windows.Forms.Padding(3, 2, 28, 2);
            this.btnNouvelleReservation.Name = "btnNouvelleReservation";
            this.btnNouvelleReservation.Size = new System.Drawing.Size(190, 50);
            this.btnNouvelleReservation.TabIndex = 22;
            this.btnNouvelleReservation.Text = "    Nouvelle";
            this.btnNouvelleReservation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNouvelleReservation.UseVisualStyleBackColor = false;
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
            // 
            // reservation
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1382, 853);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvReservations);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
        private System.Windows.Forms.DateTimePicker dtpDateFin;
        private System.Windows.Forms.Label lblDateFin;
        private System.Windows.Forms.DateTimePicker dtpDateDebut;
        private System.Windows.Forms.Label lblDateDebut;
        private FontAwesome.Sharp.IconButton btnVerifierDate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbVoiture;
        private System.Windows.Forms.Label lblVoiture;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVoiture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateDebut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatut;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnAnnuler;
        private FontAwesome.Sharp.IconButton btnNouvelleReservation;
        private FontAwesome.Sharp.IconButton btnReserver;
        private FontAwesome.Sharp.IconButton btnConfirmer;
    }
}