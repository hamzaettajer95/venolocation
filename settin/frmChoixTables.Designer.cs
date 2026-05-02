namespace venolocation.settin
{
    partial class frmChoixTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChoixTables));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAnnee = new System.Windows.Forms.Label();
            this.txtAnnee = new System.Windows.Forms.TextBox();
            this.clbTables = new System.Windows.Forms.CheckedListBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(122)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(227, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Sélectionnez les tables";
            // 
            // lblAnnee
            // 
            this.lblAnnee.AutoSize = true;
            this.lblAnnee.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnnee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(61)))), ((int)(((byte)(122)))));
            this.lblAnnee.Location = new System.Drawing.Point(20, 55);
            this.lblAnnee.Name = "lblAnnee";
            this.lblAnnee.Size = new System.Drawing.Size(75, 23);
            this.lblAnnee.TabIndex = 1;
            this.lblAnnee.Text = " Année :";
            // 
            // txtAnnee
            // 
            this.txtAnnee.Location = new System.Drawing.Point(96, 57);
            this.txtAnnee.Name = "txtAnnee";
            this.txtAnnee.Size = new System.Drawing.Size(120, 22);
            this.txtAnnee.TabIndex = 2;
            this.txtAnnee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAnnee_KeyPress);
            // 
            // clbTables
            // 
            this.clbTables.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbTables.FormattingEnabled = true;
            this.clbTables.Location = new System.Drawing.Point(20, 95);
            this.clbTables.Name = "clbTables";
            this.clbTables.Size = new System.Drawing.Size(360, 204);
            this.clbTables.TabIndex = 3;
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(86)))), ((int)(((byte)(197)))));
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.ForeColor = System.Drawing.Color.White;
            this.btnValider.Location = new System.Drawing.Point(95, 335);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(110, 38);
            this.btnValider.TabIndex = 4;
            this.btnValider.Text = "Validé";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValide_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.Location = new System.Drawing.Point(220, 335);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(110, 38);
            this.btnAnnuler.TabIndex = 5;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // frmChoixTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 383);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.clbTables);
            this.Controls.Add(this.txtAnnee);
            this.Controls.Add(this.lblAnnee);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChoixTables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sélection des tables";
            this.Load += new System.EventHandler(this.frmChoixTables_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAnnee;
        private System.Windows.Forms.TextBox txtAnnee;
        private System.Windows.Forms.CheckedListBox clbTables;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
    }
}