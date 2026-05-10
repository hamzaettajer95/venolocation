namespace venolocation.settin
{
    partial class activation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(activation));
            this.cardLicence = new Guna.UI2.WinForms.Guna2Panel();
            this.btnActiver = new Guna.UI2.WinForms.Guna2Button();
            this.pnlLicenceStatus = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLicenceStatus = new System.Windows.Forms.Label();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.txtActivation = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cardLicence.SuspendLayout();
            this.pnlLicenceStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // cardLicence
            // 
            this.cardLicence.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.cardLicence.BorderRadius = 14;
            this.cardLicence.BorderThickness = 1;
            this.cardLicence.Controls.Add(this.btnActiver);
            this.cardLicence.Controls.Add(this.pnlLicenceStatus);
            this.cardLicence.Controls.Add(this.iconPictureBox3);
            this.cardLicence.Controls.Add(this.txtActivation);
            this.cardLicence.Controls.Add(this.label5);
            this.cardLicence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardLicence.FillColor = System.Drawing.Color.White;
            this.cardLicence.Location = new System.Drawing.Point(0, 0);
            this.cardLicence.Name = "cardLicence";
            this.cardLicence.Size = new System.Drawing.Size(717, 281);
            this.cardLicence.TabIndex = 1;
            this.cardLicence.Paint += new System.Windows.Forms.PaintEventHandler(this.cardLicence_Paint);
            // 
            // btnActiver
            // 
            this.btnActiver.BorderRadius = 8;
            this.btnActiver.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnActiver.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnActiver.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnActiver.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnActiver.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnActiver.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiver.ForeColor = System.Drawing.Color.White;
            this.btnActiver.Image = global::venolocation.Properties.Resources.check2;
            this.btnActiver.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnActiver.ImageSize = new System.Drawing.Size(30, 30);
            this.btnActiver.Location = new System.Drawing.Point(208, 194);
            this.btnActiver.Name = "btnActiver";
            this.btnActiver.Size = new System.Drawing.Size(228, 52);
            this.btnActiver.TabIndex = 9;
            this.btnActiver.Text = "   Activer";
            this.btnActiver.Click += new System.EventHandler(this.btnActiver_Click);
            // 
            // pnlLicenceStatus
            // 
            this.pnlLicenceStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(247)))), ((int)(((byte)(208)))));
            this.pnlLicenceStatus.BorderRadius = 8;
            this.pnlLicenceStatus.BorderThickness = 1;
            this.pnlLicenceStatus.Controls.Add(this.lblLicenceStatus);
            this.pnlLicenceStatus.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(253)))), ((int)(((byte)(244)))));
            this.pnlLicenceStatus.Location = new System.Drawing.Point(506, 106);
            this.pnlLicenceStatus.Name = "pnlLicenceStatus";
            this.pnlLicenceStatus.Size = new System.Drawing.Size(188, 42);
            this.pnlLicenceStatus.TabIndex = 8;
            // 
            // lblLicenceStatus
            // 
            this.lblLicenceStatus.AutoSize = true;
            this.lblLicenceStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblLicenceStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenceStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.lblLicenceStatus.Location = new System.Drawing.Point(14, 9);
            this.lblLicenceStatus.Name = "lblLicenceStatus";
            this.lblLicenceStatus.Size = new System.Drawing.Size(120, 23);
            this.lblLicenceStatus.TabIndex = 0;
            this.lblLicenceStatus.Text = "Licence active";
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.White;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconPictureBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.Location = new System.Drawing.Point(22, 18);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox3.TabIndex = 7;
            this.iconPictureBox3.TabStop = false;
            // 
            // txtActivation
            // 
            this.txtActivation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.txtActivation.BorderRadius = 8;
            this.txtActivation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActivation.DefaultText = "";
            this.txtActivation.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtActivation.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtActivation.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtActivation.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtActivation.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtActivation.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActivation.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtActivation.Location = new System.Drawing.Point(22, 106);
            this.txtActivation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtActivation.Name = "txtActivation";
            this.txtActivation.PlaceholderText = "Code d\'activation";
            this.txtActivation.SelectedText = "";
            this.txtActivation.Size = new System.Drawing.Size(461, 42);
            this.txtActivation.TabIndex = 1;
            this.txtActivation.TextChanged += new System.EventHandler(this.txtActivation_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(86)))), ((int)(((byte)(197)))));
            this.label5.Location = new System.Drawing.Point(60, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "Activation de l\'application";
            // 
            // activation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 281);
            this.Controls.Add(this.cardLicence);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "activation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "activation";
            this.Load += new System.EventHandler(this.activation_Load);
            this.cardLicence.ResumeLayout(false);
            this.cardLicence.PerformLayout();
            this.pnlLicenceStatus.ResumeLayout(false);
            this.pnlLicenceStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel cardLicence;
        private Guna.UI2.WinForms.Guna2Button btnActiver;
        private Guna.UI2.WinForms.Guna2Panel pnlLicenceStatus;
        private System.Windows.Forms.Label lblLicenceStatus;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private Guna.UI2.WinForms.Guna2TextBox txtActivation;
        private System.Windows.Forms.Label label5;
    }
}