namespace venolocation.droit
{
    partial class historique_contrats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(historique_contrats));
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp_fin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_debut = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_statut = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_voiture = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_client = new System.Windows.Forms.ComboBox();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tnImprimer = new FontAwesome.Sharp.IconButton();
            this.btnannuller = new FontAwesome.Sharp.IconButton();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panel1.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.ColumnHeadersHeight = 36;
            this.dgvHistory.Location = new System.Drawing.Point(12, 222);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 34;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(1419, 443);
            this.dgvHistory.TabIndex = 4;
            this.dgvHistory.SelectionChanged += new System.EventHandler(this.dgvHistory_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.dtp_fin);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtp_debut);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cb_statut);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cb_voiture);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cb_client);
            this.panel1.Location = new System.Drawing.Point(12, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1419, 130);
            this.panel1.TabIndex = 5;
            // 
            // dtp_fin
            // 
            this.dtp_fin.Checked = true;
            this.dtp_fin.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtp_fin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_fin.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtp_fin.Location = new System.Drawing.Point(699, 82);
            this.dtp_fin.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_fin.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_fin.Name = "dtp_fin";
            this.dtp_fin.Size = new System.Drawing.Size(200, 36);
            this.dtp_fin.TabIndex = 9;
            this.dtp_fin.Value = new System.DateTime(2026, 4, 10, 20, 13, 9, 779);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(586, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 28);
            this.label6.TabIndex = 8;
            this.label6.Text = "Date Fin :";
            // 
            // dtp_debut
            // 
            this.dtp_debut.Checked = true;
            this.dtp_debut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dtp_debut.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_debut.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtp_debut.Location = new System.Drawing.Point(241, 82);
            this.dtp_debut.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtp_debut.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtp_debut.Name = "dtp_debut";
            this.dtp_debut.Size = new System.Drawing.Size(200, 36);
            this.dtp_debut.TabIndex = 7;
            this.dtp_debut.Value = new System.DateTime(2026, 4, 10, 20, 13, 9, 779);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(100, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 28);
            this.label5.TabIndex = 6;
            this.label5.Text = "Date Début :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(834, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "Statut :";
            // 
            // cb_statut
            // 
            this.cb_statut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_statut.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_statut.FormattingEnabled = true;
            this.cb_statut.Items.AddRange(new object[] {
            "Tout",
            "En cours",
            "Terminé",
            "Annulé"});
            this.cb_statut.Location = new System.Drawing.Point(925, 13);
            this.cb_statut.Name = "cb_statut";
            this.cb_statut.Size = new System.Drawing.Size(198, 36);
            this.cb_statut.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(382, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Voiture :";
            // 
            // cb_voiture
            // 
            this.cb_voiture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_voiture.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_voiture.FormattingEnabled = true;
            this.cb_voiture.Location = new System.Drawing.Point(497, 13);
            this.cb_voiture.Name = "cb_voiture";
            this.cb_voiture.Size = new System.Drawing.Size(198, 36);
            this.cb_voiture.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Client :";
            // 
            // cb_client
            // 
            this.cb_client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_client.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_client.FormattingEnabled = true;
            this.cb_client.Location = new System.Drawing.Point(131, 13);
            this.cb_client.Name = "cb_client";
            this.cb_client.Size = new System.Drawing.Size(198, 36);
            this.cb_client.TabIndex = 0;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.label1);
            this.guna2GradientPanel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.White;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(1443, 80);
            this.guna2GradientPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(544, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Historique des contrats";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tnImprimer);
            this.panel2.Controls.Add(this.btnannuller);
            this.panel2.Location = new System.Drawing.Point(12, 671);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1419, 61);
            this.panel2.TabIndex = 7;
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
            this.tnImprimer.Location = new System.Drawing.Point(421, 0);
            this.tnImprimer.Margin = new System.Windows.Forms.Padding(0);
            this.tnImprimer.Name = "tnImprimer";
            this.tnImprimer.Size = new System.Drawing.Size(177, 55);
            this.tnImprimer.TabIndex = 10;
            this.tnImprimer.Text = "Imprimer";
            this.tnImprimer.UseVisualStyleBackColor = false;
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
            this.btnannuller.Location = new System.Drawing.Point(984, 0);
            this.btnannuller.Margin = new System.Windows.Forms.Padding(0);
            this.btnannuller.Name = "btnannuller";
            this.btnannuller.Size = new System.Drawing.Size(177, 55);
            this.btnannuller.TabIndex = 8;
            this.btnannuller.Text = "Anuller";
            this.btnannuller.UseVisualStyleBackColor = false;
            this.btnannuller.Click += new System.EventHandler(this.btnannuller_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox1.Image = global::venolocation.Properties.Resources.insurance;
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(1371, 12);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(60, 48);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2CirclePictureBox1.TabIndex = 0;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // iconButton1
            // 
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.SearchDollar;
            this.iconButton1.IconColor = System.Drawing.Color.Gray;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 34;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(939, 73);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(184, 45);
            this.iconButton1.TabIndex = 10;
            this.iconButton1.Text = "Rechercher";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // historique_contrats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1443, 732);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.guna2GradientPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "historique_contrats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "historique_contrats";
            this.Load += new System.EventHandler(this.historique_contrats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_statut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_voiture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_client;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_fin;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtp_debut;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnannuller;
        private FontAwesome.Sharp.IconButton tnImprimer;
    }
}