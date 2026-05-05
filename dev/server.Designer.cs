namespace venolocation.dev
{
    partial class server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(server));
            this.label11 = new System.Windows.Forms.Label();
            this.txtDatabase = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtServer = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnEnregistrer = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new Guna.UI2.WinForms.Guna2TextBox();
            this.iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTester = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(12, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 25);
            this.label11.TabIndex = 23;
            this.label11.Text = "Database :";
            // 
            // txtDatabase
            // 
            this.txtDatabase.BorderRadius = 9;
            this.txtDatabase.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDatabase.DefaultText = "";
            this.txtDatabase.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtDatabase.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtDatabase.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDatabase.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtDatabase.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDatabase.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDatabase.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtDatabase.Location = new System.Drawing.Point(173, 175);
            this.txtDatabase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.PlaceholderText = "DataBase";
            this.txtDatabase.SelectedText = "";
            this.txtDatabase.Size = new System.Drawing.Size(260, 38);
            this.txtDatabase.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(12, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 25);
            this.label9.TabIndex = 21;
            this.label9.Text = "Server :";
            // 
            // txtServer
            // 
            this.txtServer.BorderRadius = 9;
            this.txtServer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServer.DefaultText = "";
            this.txtServer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtServer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtServer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtServer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtServer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtServer.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtServer.Location = new System.Drawing.Point(173, 111);
            this.txtServer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtServer.Name = "txtServer";
            this.txtServer.PlaceholderText = "Server";
            this.txtServer.SelectedText = "";
            this.txtServer.Size = new System.Drawing.Size(260, 38);
            this.txtServer.TabIndex = 20;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BorderRadius = 8;
            this.btnEnregistrer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEnregistrer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEnregistrer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEnregistrer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEnregistrer.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnEnregistrer.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.Image = global::venolocation.Properties.Resources.save;
            this.btnEnregistrer.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEnregistrer.ImageSize = new System.Drawing.Size(30, 30);
            this.btnEnregistrer.Location = new System.Drawing.Point(26, 484);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(194, 45);
            this.btnEnregistrer.TabIndex = 24;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "Password :";
            // 
            // txtPassword
            // 
            this.txtPassword.BorderRadius = 9;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(173, 303);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(260, 38);
            this.txtPassword.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "User :";
            // 
            // txtUser
            // 
            this.txtUser.BorderRadius = 9;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.DefaultText = "";
            this.txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUser.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUser.Location = new System.Drawing.Point(173, 239);
            this.txtUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUser.Name = "txtUser";
            this.txtUser.PlaceholderText = "User";
            this.txtUser.SelectedText = "";
            this.txtUser.Size = new System.Drawing.Size(260, 38);
            this.txtUser.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 25);
            this.label3.TabIndex = 30;
            this.label3.Text = "Port :";
            // 
            // txtPort
            // 
            this.txtPort.BorderRadius = 9;
            this.txtPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPort.DefaultText = "";
            this.txtPort.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPort.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPort.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPort.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPort.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPort.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPort.Location = new System.Drawing.Point(173, 367);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPort.Name = "txtPort";
            this.txtPort.PlaceholderText = "Port";
            this.txtPort.SelectedText = "";
            this.txtPort.Size = new System.Drawing.Size(260, 38);
            this.txtPort.TabIndex = 29;
            // 
            // iconPictureBox6
            // 
            this.iconPictureBox6.BackColor = System.Drawing.Color.White;
            this.iconPictureBox6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.Server;
            this.iconPictureBox6.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox6.IconSize = 46;
            this.iconPictureBox6.Location = new System.Drawing.Point(22, 26);
            this.iconPictureBox6.Name = "iconPictureBox6";
            this.iconPictureBox6.Size = new System.Drawing.Size(46, 53);
            this.iconPictureBox6.TabIndex = 32;
            this.iconPictureBox6.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(86)))), ((int)(((byte)(197)))));
            this.label7.Location = new System.Drawing.Point(84, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(239, 31);
            this.label7.TabIndex = 31;
            this.label7.Text = "Paramètres de Server";
            // 
            // btnTester
            // 
            this.btnTester.BorderRadius = 10;
            this.btnTester.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTester.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTester.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTester.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTester.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnTester.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTester.ForeColor = System.Drawing.Color.White;
            this.btnTester.Image = global::venolocation.Properties.Resources.serveur;
            this.btnTester.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnTester.ImageSize = new System.Drawing.Size(30, 30);
            this.btnTester.Location = new System.Drawing.Point(286, 484);
            this.btnTester.Name = "btnTester";
            this.btnTester.Size = new System.Drawing.Size(193, 44);
            this.btnTester.TabIndex = 33;
            this.btnTester.Text = "   Tester";
            this.btnTester.Click += new System.EventHandler(this.btnTester_Click);
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 562);
            this.Controls.Add(this.btnTester);
            this.Controls.Add(this.iconPictureBox6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "server";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "server";
            this.Load += new System.EventHandler(this.server_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnEnregistrer;
        private System.Windows.Forms.Label label11;
        private Guna.UI2.WinForms.Guna2TextBox txtDatabase;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2TextBox txtServer;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtPort;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2Button btnTester;
    }
}