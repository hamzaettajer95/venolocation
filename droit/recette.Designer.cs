namespace venolocation.droit
{
    partial class recette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(recette));
            this.lbl_totale = new System.Windows.Forms.Label();
            this.dgvRecette = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_suprimmer = new FontAwesome.Sharp.IconButton();
            this.btn_modifier = new FontAwesome.Sharp.IconButton();
            this.btn_ajouter = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_filtrer = new FontAwesome.Sharp.IconButton();
            this.cb_jour = new System.Windows.Forms.ComboBox();
            this.cb_mois = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_annee = new System.Windows.Forms.ComboBox();
            this.txt_type = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_montant = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecette)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_totale
            // 
            this.lbl_totale.AutoSize = true;
            this.lbl_totale.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totale.Location = new System.Drawing.Point(12, 637);
            this.lbl_totale.Name = "lbl_totale";
            this.lbl_totale.Size = new System.Drawing.Size(155, 28);
            this.lbl_totale.TabIndex = 7;
            this.lbl_totale.Text = "Totale recettes: ";
            // 
            // dgvRecette
            // 
            this.dgvRecette.AllowUserToAddRows = false;
            this.dgvRecette.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvRecette.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecette.BackgroundColor = System.Drawing.Color.White;
            this.dgvRecette.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecette.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecette.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecette.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvRecette.EnableHeadersVisualStyles = false;
            this.dgvRecette.Location = new System.Drawing.Point(12, 95);
            this.dgvRecette.Name = "dgvRecette";
            this.dgvRecette.ReadOnly = true;
            this.dgvRecette.RowHeadersWidth = 51;
            this.dgvRecette.RowTemplate.Height = 24;
            this.dgvRecette.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecette.Size = new System.Drawing.Size(833, 460);
            this.dgvRecette.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_suprimmer);
            this.panel1.Controls.Add(this.btn_modifier);
            this.panel1.Controls.Add(this.btn_ajouter);
            this.panel1.Location = new System.Drawing.Point(12, 561);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 65);
            this.panel1.TabIndex = 8;
            // 
            // btn_suprimmer
            // 
            this.btn_suprimmer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btn_suprimmer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_suprimmer.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_suprimmer.ForeColor = System.Drawing.Color.White;
            this.btn_suprimmer.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btn_suprimmer.IconColor = System.Drawing.Color.White;
            this.btn_suprimmer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_suprimmer.IconSize = 40;
            this.btn_suprimmer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_suprimmer.Location = new System.Drawing.Point(589, 3);
            this.btn_suprimmer.Name = "btn_suprimmer";
            this.btn_suprimmer.Size = new System.Drawing.Size(198, 57);
            this.btn_suprimmer.TabIndex = 2;
            this.btn_suprimmer.Text = "Supprimer";
            this.btn_suprimmer.UseVisualStyleBackColor = false;
            this.btn_suprimmer.Click += new System.EventHandler(this.btn_suprimmer_Click);
            // 
            // btn_modifier
            // 
            this.btn_modifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btn_modifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_modifier.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_modifier.ForeColor = System.Drawing.Color.White;
            this.btn_modifier.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.btn_modifier.IconColor = System.Drawing.Color.White;
            this.btn_modifier.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_modifier.IconSize = 40;
            this.btn_modifier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_modifier.Location = new System.Drawing.Point(309, 3);
            this.btn_modifier.Name = "btn_modifier";
            this.btn_modifier.Size = new System.Drawing.Size(198, 57);
            this.btn_modifier.TabIndex = 1;
            this.btn_modifier.Text = "Modifier";
            this.btn_modifier.UseVisualStyleBackColor = false;
            // 
            // btn_ajouter
            // 
            this.btn_ajouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btn_ajouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ajouter.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ajouter.ForeColor = System.Drawing.Color.White;
            this.btn_ajouter.IconChar = FontAwesome.Sharp.IconChar.CircleChevronDown;
            this.btn_ajouter.IconColor = System.Drawing.Color.White;
            this.btn_ajouter.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_ajouter.IconSize = 40;
            this.btn_ajouter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ajouter.Location = new System.Drawing.Point(21, 3);
            this.btn_ajouter.Name = "btn_ajouter";
            this.btn_ajouter.Size = new System.Drawing.Size(198, 57);
            this.btn_ajouter.TabIndex = 0;
            this.btn_ajouter.Text = "Ajouter";
            this.btn_ajouter.UseVisualStyleBackColor = false;
            this.btn_ajouter.Click += new System.EventHandler(this.btn_ajouter_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txt_montant);
            this.panel3.Controls.Add(this.txt_type);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 677);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(833, 68);
            this.panel3.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(431, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Montant :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Le Type :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btn_filtrer);
            this.panel2.Controls.Add(this.cb_jour);
            this.panel2.Controls.Add(this.cb_mois);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cb_annee);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(833, 77);
            this.panel2.TabIndex = 11;
            // 
            // btn_filtrer
            // 
            this.btn_filtrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.btn_filtrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filtrer.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filtrer.ForeColor = System.Drawing.Color.White;
            this.btn_filtrer.IconChar = FontAwesome.Sharp.IconChar.SearchDollar;
            this.btn_filtrer.IconColor = System.Drawing.Color.White;
            this.btn_filtrer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btn_filtrer.IconSize = 40;
            this.btn_filtrer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_filtrer.Location = new System.Drawing.Point(589, 19);
            this.btn_filtrer.Name = "btn_filtrer";
            this.btn_filtrer.Size = new System.Drawing.Size(198, 41);
            this.btn_filtrer.TabIndex = 3;
            this.btn_filtrer.Text = "Rechercher";
            this.btn_filtrer.UseVisualStyleBackColor = false;
            this.btn_filtrer.Click += new System.EventHandler(this.btn_filtrer_Click);
            // 
            // cb_jour
            // 
            this.cb_jour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_jour.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_jour.FormattingEnabled = true;
            this.cb_jour.Location = new System.Drawing.Point(411, 28);
            this.cb_jour.Name = "cb_jour";
            this.cb_jour.Size = new System.Drawing.Size(121, 31);
            this.cb_jour.TabIndex = 3;
            this.cb_jour.Text = "Jour";
            // 
            // cb_mois
            // 
            this.cb_mois.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_mois.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_mois.FormattingEnabled = true;
            this.cb_mois.Location = new System.Drawing.Point(272, 28);
            this.cb_mois.Name = "cb_mois";
            this.cb_mois.Size = new System.Drawing.Size(121, 31);
            this.cb_mois.TabIndex = 2;
            this.cb_mois.Text = "Mois";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtrer par :";
            // 
            // cb_annee
            // 
            this.cb_annee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_annee.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_annee.FormattingEnabled = true;
            this.cb_annee.Location = new System.Drawing.Point(133, 28);
            this.cb_annee.Name = "cb_annee";
            this.cb_annee.Size = new System.Drawing.Size(121, 31);
            this.cb_annee.TabIndex = 0;
            this.cb_annee.Text = "Année";
            // 
            // txt_type
            // 
            this.txt_type.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txt_type.BorderRadius = 8;
            this.txt_type.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_type.DefaultText = "";
            this.txt_type.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_type.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_type.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_type.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_type.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_type.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.txt_type.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_type.Location = new System.Drawing.Point(116, 12);
            this.txt_type.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_type.Multiline = true;
            this.txt_type.Name = "txt_type";
            this.txt_type.PlaceholderText = "Type de recette";
            this.txt_type.SelectedText = "";
            this.txt_type.Size = new System.Drawing.Size(291, 41);
            this.txt_type.TabIndex = 20;
            // 
            // txt_montant
            // 
            this.txt_montant.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txt_montant.BorderRadius = 8;
            this.txt_montant.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_montant.DefaultText = "";
            this.txt_montant.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_montant.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_montant.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_montant.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_montant.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_montant.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.txt_montant.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_montant.Location = new System.Drawing.Point(540, 12);
            this.txt_montant.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_montant.Multiline = true;
            this.txt_montant.Name = "txt_montant";
            this.txt_montant.PlaceholderText = "0,00";
            this.txt_montant.SelectedText = "";
            this.txt_montant.Size = new System.Drawing.Size(247, 41);
            this.txt_montant.TabIndex = 19;
            this.txt_montant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // recette
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(847, 750);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_totale);
            this.Controls.Add(this.dgvRecette);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "recette";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "recette";
            this.Load += new System.EventHandler(this.recette_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecette)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_totale;
        private System.Windows.Forms.DataGridView dgvRecette;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btn_suprimmer;
        private FontAwesome.Sharp.IconButton btn_modifier;
        private FontAwesome.Sharp.IconButton btn_ajouter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btn_filtrer;
        private System.Windows.Forms.ComboBox cb_jour;
        private System.Windows.Forms.ComboBox cb_mois;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_annee;
        private Guna.UI2.WinForms.Guna2TextBox txt_montant;
        private Guna.UI2.WinForms.Guna2TextBox txt_type;
    }
}