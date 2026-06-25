namespace venolocation.droit
{
    partial class penalites
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(penalites));
            this.chkSeulementNon = new System.Windows.Forms.CheckBox();
            this.btnCharger = new Guna.UI2.WinForms.Guna2Button();
            this.btnPayer = new Guna.UI2.WinForms.Guna2Button();
            this.btnPayerTout = new Guna.UI2.WinForms.Guna2Button();
            this.cbModePaiement = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtRecherche = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblTotalReste = new System.Windows.Forms.Label();
            this.dgvPenalites = new System.Windows.Forms.DataGridView();
            this.txtMontantPaye = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSelection = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenalites)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSeulementNon
            // 
            this.chkSeulementNon.AutoSize = true;
            this.chkSeulementNon.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold);
            this.chkSeulementNon.Location = new System.Drawing.Point(1095, 26);
            this.chkSeulementNon.Name = "chkSeulementNon";
            this.chkSeulementNon.Size = new System.Drawing.Size(226, 29);
            this.chkSeulementNon.TabIndex = 3;
            this.chkSeulementNon.Text = "Seulement non payées";
            this.chkSeulementNon.UseVisualStyleBackColor = true;
            this.chkSeulementNon.CheckedChanged += new System.EventHandler(this.chkSeulementNon_CheckedChanged);
            // 
            // btnCharger
            // 
            this.btnCharger.BorderRadius = 10;
            this.btnCharger.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCharger.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCharger.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCharger.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCharger.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCharger.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharger.ForeColor = System.Drawing.Color.White;
            this.btnCharger.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(155)))), ((int)(((byte)(77)))));
            this.btnCharger.Image = global::venolocation.Properties.Resources.refresh_data__1_;
            this.btnCharger.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCharger.ImageSize = new System.Drawing.Size(35, 35);
            this.btnCharger.Location = new System.Drawing.Point(124, 658);
            this.btnCharger.Name = "btnCharger";
            this.btnCharger.Size = new System.Drawing.Size(272, 60);
            this.btnCharger.TabIndex = 50;
            this.btnCharger.Text = "Charger";
            this.btnCharger.Click += new System.EventHandler(this.btnCharger_Click);
            // 
            // btnPayer
            // 
            this.btnPayer.BorderRadius = 10;
            this.btnPayer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPayer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPayer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPayer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPayer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnPayer.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayer.ForeColor = System.Drawing.Color.White;
            this.btnPayer.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(155)))), ((int)(((byte)(77)))));
            this.btnPayer.Image = global::venolocation.Properties.Resources.shield;
            this.btnPayer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPayer.ImageSize = new System.Drawing.Size(35, 35);
            this.btnPayer.Location = new System.Drawing.Point(532, 658);
            this.btnPayer.Name = "btnPayer";
            this.btnPayer.Size = new System.Drawing.Size(272, 60);
            this.btnPayer.TabIndex = 51;
            this.btnPayer.Text = "Payer";
            this.btnPayer.Click += new System.EventHandler(this.btnPayer_Click);
            // 
            // btnPayerTout
            // 
            this.btnPayerTout.BorderRadius = 10;
            this.btnPayerTout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPayerTout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPayerTout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPayerTout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPayerTout.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPayerTout.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayerTout.ForeColor = System.Drawing.Color.White;
            this.btnPayerTout.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(155)))), ((int)(((byte)(77)))));
            this.btnPayerTout.Image = global::venolocation.Properties.Resources.insurance;
            this.btnPayerTout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPayerTout.ImageSize = new System.Drawing.Size(35, 35);
            this.btnPayerTout.Location = new System.Drawing.Point(962, 658);
            this.btnPayerTout.Name = "btnPayerTout";
            this.btnPayerTout.Size = new System.Drawing.Size(272, 60);
            this.btnPayerTout.TabIndex = 52;
            this.btnPayerTout.Text = "Payer tout";
            this.btnPayerTout.Click += new System.EventHandler(this.btnPayerTout_Click);
            // 
            // cbModePaiement
            // 
            this.cbModePaiement.BackColor = System.Drawing.Color.Transparent;
            this.cbModePaiement.BorderRadius = 8;
            this.cbModePaiement.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbModePaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModePaiement.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbModePaiement.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbModePaiement.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbModePaiement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbModePaiement.ItemHeight = 30;
            this.cbModePaiement.Location = new System.Drawing.Point(694, 548);
            this.cbModePaiement.Name = "cbModePaiement";
            this.cbModePaiement.Size = new System.Drawing.Size(286, 36);
            this.cbModePaiement.TabIndex = 53;
            // 
            // txtRecherche
            // 
            this.txtRecherche.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txtRecherche.BorderRadius = 8;
            this.txtRecherche.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRecherche.DefaultText = "";
            this.txtRecherche.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRecherche.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRecherche.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRecherche.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRecherche.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRecherche.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.txtRecherche.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRecherche.Location = new System.Drawing.Point(91, 24);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRecherche.Multiline = true;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.PlaceholderText = "Recherche";
            this.txtRecherche.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRecherche.SelectedText = "";
            this.txtRecherche.Size = new System.Drawing.Size(372, 41);
            this.txtRecherche.TabIndex = 54;
            this.txtRecherche.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalReste
            // 
            this.lblTotalReste.AutoSize = true;
            this.lblTotalReste.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalReste.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTotalReste.Location = new System.Drawing.Point(1008, 559);
            this.lblTotalReste.Name = "lblTotalReste";
            this.lblTotalReste.Size = new System.Drawing.Size(122, 25);
            this.lblTotalReste.TabIndex = 55;
            this.lblTotalReste.Text = "lblTotalReste";
            // 
            // dgvPenalites
            // 
            this.dgvPenalites.AllowUserToAddRows = false;
            this.dgvPenalites.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.dgvPenalites.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPenalites.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPenalites.BackgroundColor = System.Drawing.Color.White;
            this.dgvPenalites.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPenalites.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(52)))), ((int)(((byte)(71)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPenalites.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPenalites.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPenalites.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPenalites.GridColor = System.Drawing.Color.LightGray;
            this.dgvPenalites.Location = new System.Drawing.Point(12, 73);
            this.dgvPenalites.Name = "dgvPenalites";
            this.dgvPenalites.ReadOnly = true;
            this.dgvPenalites.RowHeadersVisible = false;
            this.dgvPenalites.RowHeadersWidth = 51;
            this.dgvPenalites.RowTemplate.Height = 24;
            this.dgvPenalites.Size = new System.Drawing.Size(1331, 372);
            this.dgvPenalites.TabIndex = 56;
            this.dgvPenalites.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPenalites_CellClick);
            // 
            // txtMontantPaye
            // 
            this.txtMontantPaye.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txtMontantPaye.BorderRadius = 8;
            this.txtMontantPaye.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMontantPaye.DefaultText = "0";
            this.txtMontantPaye.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMontantPaye.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMontantPaye.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMontantPaye.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMontantPaye.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMontantPaye.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.txtMontantPaye.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMontantPaye.Location = new System.Drawing.Point(142, 543);
            this.txtMontantPaye.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMontantPaye.Multiline = true;
            this.txtMontantPaye.Name = "txtMontantPaye";
            this.txtMontantPaye.PlaceholderText = "";
            this.txtMontantPaye.SelectedText = "";
            this.txtMontantPaye.SelectionStart = 1;
            this.txtMontantPaye.Size = new System.Drawing.Size(298, 41);
            this.txtMontantPaye.TabIndex = 57;
            this.txtMontantPaye.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSelection
            // 
            this.lblSelection.AutoSize = true;
            this.lblSelection.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSelection.Location = new System.Drawing.Point(33, 458);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(175, 25);
            this.lblSelection.TabIndex = 58;
            this.lblSelection.Text = "Type d\'opération :*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(33, 554);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 59;
            this.label1.Text = "Montant";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.label2.Location = new System.Drawing.Point(508, 554);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 60;
            this.label2.Text = "Type de payment";
            // 
            // penalites
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1365, 770);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSelection);
            this.Controls.Add(this.txtMontantPaye);
            this.Controls.Add(this.dgvPenalites);
            this.Controls.Add(this.lblTotalReste);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.cbModePaiement);
            this.Controls.Add(this.btnPayerTout);
            this.Controls.Add(this.btnPayer);
            this.Controls.Add(this.btnCharger);
            this.Controls.Add(this.chkSeulementNon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "penalites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "penalites";
            this.Load += new System.EventHandler(this.penalites_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenalites)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkSeulementNon;
        private Guna.UI2.WinForms.Guna2Button btnCharger;
        private Guna.UI2.WinForms.Guna2Button btnPayer;
        private Guna.UI2.WinForms.Guna2Button btnPayerTout;
        private Guna.UI2.WinForms.Guna2ComboBox cbModePaiement;
        private Guna.UI2.WinForms.Guna2TextBox txtRecherche;
        private System.Windows.Forms.Label lblTotalReste;
        private System.Windows.Forms.DataGridView dgvPenalites;
        private Guna.UI2.WinForms.Guna2TextBox txtMontantPaye;
        private System.Windows.Forms.Label lblSelection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}