namespace venolocation.settin
{
    partial class update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(update));
            this.cardUpdate = new Guna.UI2.WinForms.Guna2Panel();
            this.btnIgnorer = new Guna.UI2.WinForms.Guna2Button();
            this.lblNouvelleVersion = new System.Windows.Forms.Label();
            this.lblVersionActuelle = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTelecharger = new Guna.UI2.WinForms.Guna2Button();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.txtDescription = new Guna.UI2.WinForms.Guna2TextBox();
            this.progressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.cardUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // cardUpdate
            // 
            this.cardUpdate.BackColor = System.Drawing.Color.White;
            this.cardUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardUpdate.BorderRadius = 14;
            this.cardUpdate.BorderThickness = 1;
            this.cardUpdate.Controls.Add(this.progressBar1);
            this.cardUpdate.Controls.Add(this.txtDescription);
            this.cardUpdate.Controls.Add(this.btnTelecharger);
            this.cardUpdate.Controls.Add(this.btnIgnorer);
            this.cardUpdate.Controls.Add(this.lblNouvelleVersion);
            this.cardUpdate.Controls.Add(this.lblVersionActuelle);
            this.cardUpdate.Controls.Add(this.iconPictureBox2);
            this.cardUpdate.Controls.Add(this.label6);
            this.cardUpdate.FillColor = System.Drawing.Color.White;
            this.cardUpdate.Location = new System.Drawing.Point(0, 3);
            this.cardUpdate.Name = "cardUpdate";
            this.cardUpdate.Size = new System.Drawing.Size(741, 406);
            this.cardUpdate.TabIndex = 2;
            // 
            // btnIgnorer
            // 
            this.btnIgnorer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnIgnorer.BorderRadius = 10;
            this.btnIgnorer.BorderThickness = 1;
            this.btnIgnorer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnIgnorer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnIgnorer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnIgnorer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnIgnorer.FillColor = System.Drawing.Color.White;
            this.btnIgnorer.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIgnorer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            this.btnIgnorer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnIgnorer.ImageSize = new System.Drawing.Size(30, 30);
            this.btnIgnorer.Location = new System.Drawing.Point(520, 337);
            this.btnIgnorer.Name = "btnIgnorer";
            this.btnIgnorer.Size = new System.Drawing.Size(181, 45);
            this.btnIgnorer.TabIndex = 12;
            this.btnIgnorer.Text = "ignoré";
            this.btnIgnorer.Click += new System.EventHandler(this.btnVerifierUpdate_Click);
            // 
            // lblNouvelleVersion
            // 
            this.lblNouvelleVersion.AutoSize = true;
            this.lblNouvelleVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblNouvelleVersion.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNouvelleVersion.ForeColor = System.Drawing.Color.Black;
            this.lblNouvelleVersion.Location = new System.Drawing.Point(58, 116);
            this.lblNouvelleVersion.Name = "lblNouvelleVersion";
            this.lblNouvelleVersion.Size = new System.Drawing.Size(206, 25);
            this.lblNouvelleVersion.TabIndex = 11;
            this.lblNouvelleVersion.Text = "Dernière version : 1.1.0.2";
            // 
            // lblVersionActuelle
            // 
            this.lblVersionActuelle.AutoSize = true;
            this.lblVersionActuelle.BackColor = System.Drawing.Color.Transparent;
            this.lblVersionActuelle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersionActuelle.ForeColor = System.Drawing.Color.Black;
            this.lblVersionActuelle.Location = new System.Drawing.Point(58, 75);
            this.lblVersionActuelle.Name = "lblVersionActuelle";
            this.lblVersionActuelle.Size = new System.Drawing.Size(200, 25);
            this.lblVersionActuelle.TabIndex = 10;
            this.lblVersionActuelle.Text = "Version actuelle : 1.0.0.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(86)))), ((int)(((byte)(197)))));
            this.label6.Location = new System.Drawing.Point(57, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 31);
            this.label6.TabIndex = 8;
            this.label6.Text = "Mise à jour";
            // 
            // btnTelecharger
            // 
            this.btnTelecharger.BorderRadius = 8;
            this.btnTelecharger.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTelecharger.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTelecharger.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTelecharger.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTelecharger.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnTelecharger.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTelecharger.ForeColor = System.Drawing.Color.White;
            this.btnTelecharger.Image = global::venolocation.Properties.Resources.cloud_computing;
            this.btnTelecharger.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTelecharger.ImageSize = new System.Drawing.Size(30, 30);
            this.btnTelecharger.Location = new System.Drawing.Point(63, 337);
            this.btnTelecharger.Name = "btnTelecharger";
            this.btnTelecharger.Size = new System.Drawing.Size(224, 45);
            this.btnTelecharger.TabIndex = 13;
            this.btnTelecharger.Text = "Télécharger";
            this.btnTelecharger.Click += new System.EventHandler(this.btnTelecharger_Click);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.Color.White;
            this.iconPictureBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.iconPictureBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.Location = new System.Drawing.Point(19, 15);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox2.TabIndex = 9;
            this.iconPictureBox2.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderRadius = 8;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.DefaultText = "";
            this.txtDescription.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDescription.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDescription.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDescription.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDescription.Location = new System.Drawing.Point(63, 170);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Description";
            this.txtDescription.SelectedText = "";
            this.txtDescription.Size = new System.Drawing.Size(642, 67);
            this.txtDescription.TabIndex = 14;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(77, 287);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(624, 30);
            this.progressBar1.TabIndex = 15;
            this.progressBar1.Text = "guna2ProgressBar1";
            this.progressBar1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 421);
            this.Controls.Add(this.cardUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "update";
            this.Load += new System.EventHandler(this.update_Load);
            this.cardUpdate.ResumeLayout(false);
            this.cardUpdate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel cardUpdate;
        private Guna.UI2.WinForms.Guna2Button btnTelecharger;
        private Guna.UI2.WinForms.Guna2Button btnIgnorer;
        private System.Windows.Forms.Label lblNouvelleVersion;
        private System.Windows.Forms.Label lblVersionActuelle;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox txtDescription;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar1;
    }
}