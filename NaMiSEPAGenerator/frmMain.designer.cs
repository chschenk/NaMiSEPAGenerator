namespace NaMiSEPAGenerator
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnGenerate = new System.Windows.Forms.Button();
            this.pbFortschritt = new System.Windows.Forms.ProgressBar();
            this.txtBeitrag1 = new System.Windows.Forms.TextBox();
            this.txtBeitrag2 = new System.Windows.Forms.TextBox();
            this.txtBeitrag3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIBAN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBIC = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtGlaeubigerID = new System.Windows.Forms.TextBox();
            this.dTExecutionDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(403, 236);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generieren";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // pbFortschritt
            // 
            this.pbFortschritt.Location = new System.Drawing.Point(12, 236);
            this.pbFortschritt.Name = "pbFortschritt";
            this.pbFortschritt.Size = new System.Drawing.Size(385, 23);
            this.pbFortschritt.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pbFortschritt.TabIndex = 1;
            this.pbFortschritt.Visible = false;
            // 
            // txtBeitrag1
            // 
            this.txtBeitrag1.Location = new System.Drawing.Point(197, 12);
            this.txtBeitrag1.Name = "txtBeitrag1";
            this.txtBeitrag1.Size = new System.Drawing.Size(48, 20);
            this.txtBeitrag1.TabIndex = 1;
            this.txtBeitrag1.Text = "32,00";
            // 
            // txtBeitrag2
            // 
            this.txtBeitrag2.Location = new System.Drawing.Point(197, 38);
            this.txtBeitrag2.Name = "txtBeitrag2";
            this.txtBeitrag2.Size = new System.Drawing.Size(48, 20);
            this.txtBeitrag2.TabIndex = 2;
            this.txtBeitrag2.Text = "27,00";
            // 
            // txtBeitrag3
            // 
            this.txtBeitrag3.Location = new System.Drawing.Point(197, 64);
            this.txtBeitrag3.Name = "txtBeitrag3";
            this.txtBeitrag3.Size = new System.Drawing.Size(48, 20);
            this.txtBeitrag3.TabIndex = 3;
            this.txtBeitrag3.Text = "22,00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Beiträge für 1 Mitglied einer Familie:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Beiträge für 2 Mitglieder einer Familie:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Beiträge ab 3 Mitglieder einer Familie:";
            // 
            // txtIBAN
            // 
            this.txtIBAN.Location = new System.Drawing.Point(197, 93);
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Size = new System.Drawing.Size(115, 20);
            this.txtIBAN.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "IBAN:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "BIC:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Gläubiger Identifikationsnummer:";
            // 
            // txtBIC
            // 
            this.txtBIC.Location = new System.Drawing.Point(197, 119);
            this.txtBIC.Name = "txtBIC";
            this.txtBIC.Size = new System.Drawing.Size(115, 20);
            this.txtBIC.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(197, 145);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(115, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtGlaeubigerID
            // 
            this.txtGlaeubigerID.Location = new System.Drawing.Point(197, 171);
            this.txtGlaeubigerID.Name = "txtGlaeubigerID";
            this.txtGlaeubigerID.Size = new System.Drawing.Size(115, 20);
            this.txtGlaeubigerID.TabIndex = 7;
            // 
            // dTExecutionDate
            // 
            this.dTExecutionDate.Location = new System.Drawing.Point(197, 197);
            this.dTExecutionDate.Name = "dTExecutionDate";
            this.dTExecutionDate.Size = new System.Drawing.Size(200, 20);
            this.dTExecutionDate.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Gewünschtes Ausführdatum:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 267);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(241, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Copyright © 2019 Christopher Schenk MIT Lizenz";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(421, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Version1.2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 289);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dTExecutionDate);
            this.Controls.Add(this.txtGlaeubigerID);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtBIC);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIBAN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBeitrag3);
            this.Controls.Add(this.txtBeitrag2);
            this.Controls.Add(this.txtBeitrag1);
            this.Controls.Add(this.pbFortschritt);
            this.Controls.Add(this.btnGenerate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "NaMi SEPA-XML Generator";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ProgressBar pbFortschritt;
        private System.Windows.Forms.TextBox txtBeitrag1;
        private System.Windows.Forms.TextBox txtBeitrag2;
        private System.Windows.Forms.TextBox txtBeitrag3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIBAN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBIC;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtGlaeubigerID;
        private System.Windows.Forms.DateTimePicker dTExecutionDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}

