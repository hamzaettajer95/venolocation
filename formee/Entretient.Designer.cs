namespace venolocation.formee
{
    partial class Entretient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Entretient));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTypeEntretien = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnValider = new FontAwesome.Sharp.IconButton();
            this.btnAnnuler = new FontAwesome.Sharp.IconButton();
            this.cbVoiture = new System.Windows.Forms.ComboBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtDateEntretien = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.txtKilometrage = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtProchainKilometrage = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPrix = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtprocheEntretien = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 78);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(182, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ajouter Entretien";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnAnnuler);
            this.panel2.Controls.Add(this.btnValider);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 655);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 100);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dtprocheEntretien);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtPrix);
            this.panel3.Controls.Add(this.txtProchainKilometrage);
            this.panel3.Controls.Add(this.txtKilometrage);
            this.panel3.Controls.Add(this.dtDateEntretien);
            this.panel3.Controls.Add(this.txtDescription);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbTypeEntretien);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cbVoiture);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 78);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(727, 577);
            this.panel3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 28);
            this.label4.TabIndex = 4;
            this.label4.Text = "Description";
            // 
            // cbTypeEntretien
            // 
            this.cbTypeEntretien.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbTypeEntretien.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTypeEntretien.FormattingEnabled = true;
            this.cbTypeEntretien.Location = new System.Drawing.Point(260, 75);
            this.cbTypeEntretien.Name = "cbTypeEntretien";
            this.cbTypeEntretien.Size = new System.Drawing.Size(424, 36);
            this.cbTypeEntretien.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type Entretien";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Voiture";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 28);
            this.label5.TabIndex = 6;
            this.label5.Text = "Date d\'Entretien";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 28);
            this.label6.TabIndex = 7;
            this.label6.Text = "Kilometrage";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 448);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 28);
            this.label7.TabIndex = 10;
            this.label7.Text = "Prochain kilometrage";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 521);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 28);
            this.label8.TabIndex = 12;
            this.label8.Text = "Prix d\'Entretien";
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnValider.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(194)))), ((int)(((byte)(202)))));
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnValider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(120)))));
            this.btnValider.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnValider.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(120)))));
            this.btnValider.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnValider.IconSize = 24;
            this.btnValider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnValider.Location = new System.Drawing.Point(383, 32);
            this.btnValider.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnValider.Name = "btnValider";
            this.btnValider.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnValider.Size = new System.Drawing.Size(185, 40);
            this.btnValider.TabIndex = 39;
            this.btnValider.Text = "    Validé";
            this.btnValider.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(226)))), ((int)(((byte)(232)))));
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(194)))), ((int)(((byte)(202)))));
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnAnnuler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(120)))));
            this.btnAnnuler.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.btnAnnuler.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(102)))), ((int)(((byte)(120)))));
            this.btnAnnuler.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAnnuler.IconSize = 24;
            this.btnAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnnuler.Location = new System.Drawing.Point(75, 32);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnAnnuler.Size = new System.Drawing.Size(185, 40);
            this.btnAnnuler.TabIndex = 40;
            this.btnAnnuler.Text = "    Annuller";
            this.btnAnnuler.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // cbVoiture
            // 
            this.cbVoiture.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbVoiture.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVoiture.FormattingEnabled = true;
            this.cbVoiture.Location = new System.Drawing.Point(260, 17);
            this.cbVoiture.Name = "cbVoiture";
            this.cbVoiture.Size = new System.Drawing.Size(424, 36);
            this.cbVoiture.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Location = new System.Drawing.Point(260, 134);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Description d\'entretien";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(424, 120);
            this.txtDescription.TabIndex = 14;
            this.txtDescription.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // dtDateEntretien
            // 
            this.dtDateEntretien.Checked = true;
            this.dtDateEntretien.FillColor = System.Drawing.Color.White;
            this.dtDateEntretien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtDateEntretien.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtDateEntretien.Location = new System.Drawing.Point(260, 263);
            this.dtDateEntretien.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtDateEntretien.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtDateEntretien.Name = "dtDateEntretien";
            this.dtDateEntretien.Size = new System.Drawing.Size(424, 36);
            this.dtDateEntretien.TabIndex = 15;
            this.dtDateEntretien.Value = new System.DateTime(2026, 4, 2, 19, 41, 42, 577);
            // 
            // txtKilometrage
            // 
            this.txtKilometrage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKilometrage.DefaultText = "";
            this.txtKilometrage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKilometrage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKilometrage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKilometrage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKilometrage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKilometrage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtKilometrage.ForeColor = System.Drawing.Color.Black;
            this.txtKilometrage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKilometrage.Location = new System.Drawing.Point(260, 375);
            this.txtKilometrage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtKilometrage.Name = "txtKilometrage";
            this.txtKilometrage.PlaceholderText = "Kilometrage";
            this.txtKilometrage.SelectedText = "";
            this.txtKilometrage.Size = new System.Drawing.Size(424, 49);
            this.txtKilometrage.TabIndex = 16;
            this.txtKilometrage.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged);
            this.txtKilometrage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKilometrage_KeyPress);
            // 
            // txtProchainKilometrage
            // 
            this.txtProchainKilometrage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProchainKilometrage.DefaultText = "";
            this.txtProchainKilometrage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtProchainKilometrage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtProchainKilometrage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProchainKilometrage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtProchainKilometrage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProchainKilometrage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtProchainKilometrage.ForeColor = System.Drawing.Color.Black;
            this.txtProchainKilometrage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtProchainKilometrage.Location = new System.Drawing.Point(260, 436);
            this.txtProchainKilometrage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtProchainKilometrage.Name = "txtProchainKilometrage";
            this.txtProchainKilometrage.PlaceholderText = "Prochain Kilometrage";
            this.txtProchainKilometrage.SelectedText = "";
            this.txtProchainKilometrage.Size = new System.Drawing.Size(424, 49);
            this.txtProchainKilometrage.TabIndex = 17;
            this.txtProchainKilometrage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProchainKilometrage_KeyPress);
            // 
            // txtPrix
            // 
            this.txtPrix.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPrix.DefaultText = "";
            this.txtPrix.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPrix.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPrix.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrix.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPrix.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrix.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.txtPrix.ForeColor = System.Drawing.Color.Black;
            this.txtPrix.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPrix.Location = new System.Drawing.Point(260, 500);
            this.txtPrix.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.PlaceholderText = "Prix d\'entretien";
            this.txtPrix.SelectedText = "";
            this.txtPrix.Size = new System.Drawing.Size(424, 49);
            this.txtPrix.TabIndex = 18;
            this.txtPrix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrix_KeyPress);
            // 
            // dtprocheEntretien
            // 
            this.dtprocheEntretien.Checked = true;
            this.dtprocheEntretien.FillColor = System.Drawing.Color.White;
            this.dtprocheEntretien.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtprocheEntretien.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtprocheEntretien.Location = new System.Drawing.Point(260, 319);
            this.dtprocheEntretien.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtprocheEntretien.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtprocheEntretien.Name = "dtprocheEntretien";
            this.dtprocheEntretien.Size = new System.Drawing.Size(424, 36);
            this.dtprocheEntretien.TabIndex = 20;
            this.dtprocheEntretien.Value = new System.DateTime(2026, 4, 2, 19, 41, 42, 577);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(28, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(196, 28);
            this.label9.TabIndex = 19;
            this.label9.Text = "Prochain d\'Entretien";
            // 
            // Entretient
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(727, 755);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Entretient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entretient";
            this.Load += new System.EventHandler(this.Entretient_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTypeEntretien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton btnAnnuler;
        private FontAwesome.Sharp.IconButton btnValider;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private System.Windows.Forms.ComboBox cbVoiture;
        private Guna.UI2.WinForms.Guna2TextBox txtKilometrage;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtDateEntretien;
        private Guna.UI2.WinForms.Guna2TextBox txtPrix;
        private Guna.UI2.WinForms.Guna2TextBox txtProchainKilometrage;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtprocheEntretien;
        private System.Windows.Forms.Label label9;
    }
}