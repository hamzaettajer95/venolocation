namespace venolocation.dev
{
    partial class test_telegrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(test_telegrame));
            this.txtmessage = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRetourSimple = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // txtmessage
            // 
            this.txtmessage.BorderRadius = 14;
            this.txtmessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtmessage.DefaultText = "";
            this.txtmessage.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtmessage.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtmessage.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtmessage.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtmessage.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtmessage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmessage.ForeColor = System.Drawing.Color.Black;
            this.txtmessage.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtmessage.Location = new System.Drawing.Point(201, 41);
            this.txtmessage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtmessage.Multiline = true;
            this.txtmessage.Name = "txtmessage";
            this.txtmessage.PlaceholderText = "Message";
            this.txtmessage.SelectedText = "";
            this.txtmessage.Size = new System.Drawing.Size(570, 293);
            this.txtmessage.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 25);
            this.label5.TabIndex = 50;
            this.label5.Text = "Votre Message :";
            // 
            // btnRetourSimple
            // 
            this.btnRetourSimple.BorderRadius = 10;
            this.btnRetourSimple.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRetourSimple.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRetourSimple.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRetourSimple.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRetourSimple.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(177)))), ((int)(((byte)(89)))));
            this.btnRetourSimple.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetourSimple.ForeColor = System.Drawing.Color.White;
            this.btnRetourSimple.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(155)))), ((int)(((byte)(77)))));
            this.btnRetourSimple.Image = global::venolocation.Properties.Resources.check3;
            this.btnRetourSimple.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRetourSimple.ImageSize = new System.Drawing.Size(35, 35);
            this.btnRetourSimple.Location = new System.Drawing.Point(369, 382);
            this.btnRetourSimple.Name = "btnRetourSimple";
            this.btnRetourSimple.Size = new System.Drawing.Size(272, 60);
            this.btnRetourSimple.TabIndex = 51;
            this.btnRetourSimple.Text = "   Send Message";
            this.btnRetourSimple.Click += new System.EventHandler(this.btnRetourSimple_Click);
            // 
            // test_telegrame
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 454);
            this.Controls.Add(this.btnRetourSimple);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtmessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "test_telegrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Send message";
            this.Load += new System.EventHandler(this.test_telegrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtmessage;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnRetourSimple;
    }
}