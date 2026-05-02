namespace venolocation.formee
{
    partial class voiture_echeance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(voiture_echeance));
            this.pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.cardInfo = new Guna.UI2.WinForms.Guna2Panel();
            this.dtDateDebut = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtMontant = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemarque = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbTypeEcheance = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVoiture = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.dtDateFin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumeroDocument = new Guna.UI2.WinForms.Guna2TextBox();
            this.cbStatut = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnNouveau = new Guna.UI2.WinForms.Guna2Button();
            this.btnSupprimer = new Guna.UI2.WinForms.Guna2Button();
            this.btnModifier = new Guna.UI2.WinForms.Guna2Button();
            this.btnAjouter = new Guna.UI2.WinForms.Guna2Button();
            this.dgvEcheances = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.cardInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcheances)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderRadius = 16;
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Controls.Add(this.iconPictureBox1);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.guna2CirclePictureBox1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(136)))), ((int)(((byte)(232)))));
            this.pnlHeader.FillColor2 = System.Drawing.Color.White;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1263, 91);
            this.pnlHeader.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(86, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(519, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Assurance, visite technique, vignette et documents des véhicules";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(82, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(579, 50);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestion des échéances véhicules";
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(136)))), ((int)(((byte)(232)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.List;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 55;
            this.iconPictureBox1.Location = new System.Drawing.Point(21, 18);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(55, 55);
            this.iconPictureBox1.TabIndex = 2;
            this.iconPictureBox1.TabStop = false;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::venolocation.Properties.Resources.insurance;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(1159, 8);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(80, 74);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 0;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // cardInfo
            // 
            this.cardInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardInfo.BorderRadius = 14;
            this.cardInfo.BorderThickness = 1;
            this.cardInfo.Controls.Add(this.cbStatut);
            this.cardInfo.Controls.Add(this.txtNumeroDocument);
            this.cardInfo.Controls.Add(this.label11);
            this.cardInfo.Controls.Add(this.label10);
            this.cardInfo.Controls.Add(this.dtDateFin);
            this.cardInfo.Controls.Add(this.label7);
            this.cardInfo.Controls.Add(this.dtDateDebut);
            this.cardInfo.Controls.Add(this.txtMontant);
            this.cardInfo.Controls.Add(this.label8);
            this.cardInfo.Controls.Add(this.label9);
            this.cardInfo.Controls.Add(this.txtRemarque);
            this.cardInfo.Controls.Add(this.label6);
            this.cardInfo.Controls.Add(this.cbTypeEcheance);
            this.cardInfo.Controls.Add(this.label5);
            this.cardInfo.Controls.Add(this.cbVoiture);
            this.cardInfo.Controls.Add(this.label4);
            this.cardInfo.Controls.Add(this.label3);
            this.cardInfo.Controls.Add(this.iconPictureBox2);
            this.cardInfo.Location = new System.Drawing.Point(0, 97);
            this.cardInfo.Name = "cardInfo";
            this.cardInfo.Size = new System.Drawing.Size(1258, 315);
            this.cardInfo.TabIndex = 4;
            this.cardInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.cardInfo_Paint);
            // 
            // dtDateDebut
            // 
            this.dtDateDebut.BorderRadius = 8;
            this.dtDateDebut.Checked = true;
            this.dtDateDebut.FillColor = System.Drawing.Color.White;
            this.dtDateDebut.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateDebut.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtDateDebut.Location = new System.Drawing.Point(515, 167);
            this.dtDateDebut.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDateDebut.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDateDebut.Name = "dtDateDebut";
            this.dtDateDebut.Size = new System.Drawing.Size(245, 36);
            this.dtDateDebut.TabIndex = 15;
            this.dtDateDebut.Value = new System.DateTime(2026, 4, 22, 14, 36, 56, 972);
            // 
            // txtMontant
            // 
            this.txtMontant.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txtMontant.BorderRadius = 8;
            this.txtMontant.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMontant.DefaultText = "";
            this.txtMontant.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMontant.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMontant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMontant.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMontant.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMontant.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.txtMontant.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMontant.Location = new System.Drawing.Point(513, 82);
            this.txtMontant.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMontant.Multiline = true;
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.PlaceholderText = "0,00";
            this.txtMontant.SelectedText = "";
            this.txtMontant.Size = new System.Drawing.Size(247, 41);
            this.txtMontant.TabIndex = 14;
            this.txtMontant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMontant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontant_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label8.Location = new System.Drawing.Point(510, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 25);
            this.label8.TabIndex = 12;
            this.label8.Text = "Date début :*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label9.Location = new System.Drawing.Point(508, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Montant (DH) :*";
            // 
            // txtRemarque
            // 
            this.txtRemarque.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txtRemarque.BorderRadius = 8;
            this.txtRemarque.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarque.DefaultText = "";
            this.txtRemarque.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRemarque.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRemarque.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRemarque.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRemarque.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRemarque.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.txtRemarque.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRemarque.Location = new System.Drawing.Point(830, 82);
            this.txtRemarque.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRemarque.Multiline = true;
            this.txtRemarque.Name = "txtRemarque";
            this.txtRemarque.PlaceholderText = "Décrivez la réparation ou le problème constaté";
            this.txtRemarque.SelectedText = "";
            this.txtRemarque.Size = new System.Drawing.Size(389, 96);
            this.txtRemarque.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label6.Location = new System.Drawing.Point(52, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 25);
            this.label6.TabIndex = 9;
            this.label6.Text = "Numéro document :*";
            // 
            // cbTypeEcheance
            // 
            this.cbTypeEcheance.BackColor = System.Drawing.Color.Transparent;
            this.cbTypeEcheance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.cbTypeEcheance.BorderRadius = 8;
            this.cbTypeEcheance.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbTypeEcheance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeEcheance.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTypeEcheance.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbTypeEcheance.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.cbTypeEcheance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbTypeEcheance.ItemHeight = 30;
            this.cbTypeEcheance.Items.AddRange(new object[] {
            "assurance",
            "visite technique",
            "vignette"});
            this.cbTypeEcheance.Location = new System.Drawing.Point(50, 167);
            this.cbTypeEcheance.Name = "cbTypeEcheance";
            this.cbTypeEcheance.Size = new System.Drawing.Size(415, 36);
            this.cbTypeEcheance.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label5.Location = new System.Drawing.Point(52, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Type d\'échéance :*";
            // 
            // cbVoiture
            // 
            this.cbVoiture.BackColor = System.Drawing.Color.Transparent;
            this.cbVoiture.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.cbVoiture.BorderRadius = 8;
            this.cbVoiture.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbVoiture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVoiture.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbVoiture.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbVoiture.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVoiture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbVoiture.ItemHeight = 30;
            this.cbVoiture.Location = new System.Drawing.Point(50, 84);
            this.cbVoiture.Name = "cbVoiture";
            this.cbVoiture.Size = new System.Drawing.Size(415, 36);
            this.cbVoiture.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label4.Location = new System.Drawing.Point(52, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Véhicule :*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(122)))));
            this.label3.Location = new System.Drawing.Point(50, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(372, 38);
            this.label3.TabIndex = 4;
            this.label3.Text = "Informations de l\'échéance";
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.White;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.Location = new System.Drawing.Point(12, 12);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox2.TabIndex = 3;
            this.iconPictureBox2.TabStop = false;
            // 
            // dtDateFin
            // 
            this.dtDateFin.BorderRadius = 8;
            this.dtDateFin.Checked = true;
            this.dtDateFin.FillColor = System.Drawing.Color.White;
            this.dtDateFin.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtDateFin.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtDateFin.Location = new System.Drawing.Point(515, 255);
            this.dtDateFin.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDateFin.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDateFin.Name = "dtDateFin";
            this.dtDateFin.Size = new System.Drawing.Size(245, 36);
            this.dtDateFin.TabIndex = 17;
            this.dtDateFin.Value = new System.DateTime(2026, 4, 22, 14, 36, 56, 972);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label7.Location = new System.Drawing.Point(510, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Date fin :*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label10.Location = new System.Drawing.Point(810, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 25);
            this.label10.TabIndex = 18;
            this.label10.Text = "Remarque :*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label11.Location = new System.Drawing.Point(810, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 25);
            this.label11.TabIndex = 19;
            this.label11.Text = "Statut :*";
            // 
            // txtNumeroDocument
            // 
            this.txtNumeroDocument.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txtNumeroDocument.BorderRadius = 8;
            this.txtNumeroDocument.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumeroDocument.DefaultText = "";
            this.txtNumeroDocument.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNumeroDocument.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNumeroDocument.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumeroDocument.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumeroDocument.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumeroDocument.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.txtNumeroDocument.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumeroDocument.Location = new System.Drawing.Point(50, 250);
            this.txtNumeroDocument.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumeroDocument.Multiline = true;
            this.txtNumeroDocument.Name = "txtNumeroDocument";
            this.txtNumeroDocument.PlaceholderText = "";
            this.txtNumeroDocument.SelectedText = "";
            this.txtNumeroDocument.Size = new System.Drawing.Size(415, 41);
            this.txtNumeroDocument.TabIndex = 20;
            // 
            // cbStatut
            // 
            this.cbStatut.BackColor = System.Drawing.Color.Transparent;
            this.cbStatut.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.cbStatut.BorderRadius = 8;
            this.cbStatut.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatut.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbStatut.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbStatut.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.cbStatut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbStatut.ItemHeight = 30;
            this.cbStatut.Items.AddRange(new object[] {
            "Active",
            "Expirée",
            "À renouveler"});
            this.cbStatut.Location = new System.Drawing.Point(830, 255);
            this.cbStatut.Name = "cbStatut";
            this.cbStatut.Size = new System.Drawing.Size(389, 36);
            this.cbStatut.TabIndex = 21;
            // 
            // btnNouveau
            // 
            this.btnNouveau.BorderRadius = 8;
            this.btnNouveau.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNouveau.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNouveau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNouveau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNouveau.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnNouveau.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveau.ForeColor = System.Drawing.Color.White;
            this.btnNouveau.Image = global::venolocation.Properties.Resources.insurance__1_;
            this.btnNouveau.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnNouveau.ImageSize = new System.Drawing.Size(30, 30);
            this.btnNouveau.Location = new System.Drawing.Point(1018, 418);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(194, 45);
            this.btnNouveau.TabIndex = 8;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BorderRadius = 8;
            this.btnSupprimer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSupprimer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSupprimer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSupprimer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSupprimer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Image = global::venolocation.Properties.Resources.delete;
            this.btnSupprimer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSupprimer.ImageSize = new System.Drawing.Size(30, 30);
            this.btnSupprimer.Location = new System.Drawing.Point(690, 418);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(194, 45);
            this.btnSupprimer.TabIndex = 7;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BorderRadius = 8;
            this.btnModifier.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnModifier.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnModifier.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnModifier.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnModifier.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Image = global::venolocation.Properties.Resources.edit;
            this.btnModifier.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnModifier.ImageSize = new System.Drawing.Size(30, 30);
            this.btnModifier.Location = new System.Drawing.Point(353, 418);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(194, 45);
            this.btnModifier.TabIndex = 6;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnAjouter
            // 
            this.btnAjouter.BorderRadius = 8;
            this.btnAjouter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAjouter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAjouter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAjouter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAjouter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Image = global::venolocation.Properties.Resources.save;
            this.btnAjouter.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAjouter.ImageSize = new System.Drawing.Size(30, 30);
            this.btnAjouter.Location = new System.Drawing.Point(48, 418);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(194, 45);
            this.btnAjouter.TabIndex = 5;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // dgvEcheances
            // 
            this.dgvEcheances.AllowUserToAddRows = false;
            this.dgvEcheances.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvEcheances.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEcheances.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEcheances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEcheances.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEcheances.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEcheances.Location = new System.Drawing.Point(21, 469);
            this.dgvEcheances.Name = "dgvEcheances";
            this.dgvEcheances.ReadOnly = true;
            this.dgvEcheances.RowHeadersVisible = false;
            this.dgvEcheances.RowHeadersWidth = 51;
            this.dgvEcheances.RowTemplate.Height = 24;
            this.dgvEcheances.Size = new System.Drawing.Size(1237, 319);
            this.dgvEcheances.TabIndex = 9;
            this.dgvEcheances.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEcheances.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvEcheances.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvEcheances.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvEcheances.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvEcheances.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvEcheances.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEcheances.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvEcheances.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEcheances.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEcheances.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvEcheances.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEcheances.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvEcheances.ThemeStyle.ReadOnly = true;
            this.dgvEcheances.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvEcheances.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEcheances.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEcheances.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEcheances.ThemeStyle.RowsStyle.Height = 24;
            this.dgvEcheances.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvEcheances.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvEcheances.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEcheances_CellClick);
            // 
            // voiture_echeance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1263, 800);
            this.Controls.Add(this.dgvEcheances);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.cardInfo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "voiture_echeance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des échéances véhicules";
            this.Load += new System.EventHandler(this.voiture_echeance_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.cardInfo.ResumeLayout(false);
            this.cardInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcheances)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2Panel cardInfo;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtDateFin;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtDateDebut;
        private Guna.UI2.WinForms.Guna2TextBox txtMontant;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtRemarque;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cbTypeEcheance;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2ComboBox cbVoiture;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Guna.UI2.WinForms.Guna2TextBox txtNumeroDocument;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2ComboBox cbStatut;
        private Guna.UI2.WinForms.Guna2Button btnNouveau;
        private Guna.UI2.WinForms.Guna2Button btnSupprimer;
        private Guna.UI2.WinForms.Guna2Button btnModifier;
        private Guna.UI2.WinForms.Guna2Button btnAjouter;
        private Guna.UI2.WinForms.Guna2DataGridView dgvEcheances;
    }
}