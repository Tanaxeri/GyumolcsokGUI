namespace GyumolcsokGUI
{
    partial class GyumolcsGUI
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
            this.Gyumolcsok = new System.Windows.Forms.ListBox();
            this.GyumAdat = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IdText = new System.Windows.Forms.TextBox();
            this.NevText = new System.Windows.Forms.TextBox();
            this.EgysegArText = new System.Windows.Forms.TextBox();
            this.MennyisegText = new System.Windows.Forms.TextBox();
            this.UjGyumolcs = new System.Windows.Forms.Button();
            this.GyumAdat.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gyumolcsok
            // 
            this.Gyumolcsok.Dock = System.Windows.Forms.DockStyle.Left;
            this.Gyumolcsok.FormattingEnabled = true;
            this.Gyumolcsok.Location = new System.Drawing.Point(0, 0);
            this.Gyumolcsok.Name = "Gyumolcsok";
            this.Gyumolcsok.Size = new System.Drawing.Size(120, 450);
            this.Gyumolcsok.TabIndex = 0;
            // 
            // GyumAdat
            // 
            this.GyumAdat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GyumAdat.Controls.Add(this.UjGyumolcs);
            this.GyumAdat.Controls.Add(this.MennyisegText);
            this.GyumAdat.Controls.Add(this.EgysegArText);
            this.GyumAdat.Controls.Add(this.NevText);
            this.GyumAdat.Controls.Add(this.IdText);
            this.GyumAdat.Controls.Add(this.label4);
            this.GyumAdat.Controls.Add(this.label3);
            this.GyumAdat.Controls.Add(this.label2);
            this.GyumAdat.Controls.Add(this.label1);
            this.GyumAdat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GyumAdat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GyumAdat.Location = new System.Drawing.Point(120, 0);
            this.GyumAdat.Name = "GyumAdat";
            this.GyumAdat.Size = new System.Drawing.Size(680, 450);
            this.GyumAdat.TabIndex = 1;
            this.GyumAdat.TabStop = false;
            this.GyumAdat.Text = "Gyümölcsök Adat Megadása";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Név:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Egységár:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mennyiség:";
            // 
            // IdText
            // 
            this.IdText.Location = new System.Drawing.Point(101, 28);
            this.IdText.Name = "IdText";
            this.IdText.ReadOnly = true;
            this.IdText.Size = new System.Drawing.Size(100, 26);
            this.IdText.TabIndex = 4;
            // 
            // NevText
            // 
            this.NevText.Location = new System.Drawing.Point(101, 64);
            this.NevText.Name = "NevText";
            this.NevText.Size = new System.Drawing.Size(100, 26);
            this.NevText.TabIndex = 5;
            // 
            // EgysegArText
            // 
            this.EgysegArText.Location = new System.Drawing.Point(101, 94);
            this.EgysegArText.Name = "EgysegArText";
            this.EgysegArText.Size = new System.Drawing.Size(100, 26);
            this.EgysegArText.TabIndex = 6;
            // 
            // MennyisegText
            // 
            this.MennyisegText.Location = new System.Drawing.Point(101, 133);
            this.MennyisegText.Name = "MennyisegText";
            this.MennyisegText.Size = new System.Drawing.Size(100, 26);
            this.MennyisegText.TabIndex = 7;
            // 
            // UjGyumolcs
            // 
            this.UjGyumolcs.Location = new System.Drawing.Point(10, 194);
            this.UjGyumolcs.Name = "UjGyumolcs";
            this.UjGyumolcs.Size = new System.Drawing.Size(108, 40);
            this.UjGyumolcs.TabIndex = 8;
            this.UjGyumolcs.Text = "Új Gyümölcs";
            this.UjGyumolcs.UseVisualStyleBackColor = true;
            this.UjGyumolcs.Click += new System.EventHandler(this.UjGyumolcs_Click);
            // 
            // GyumolcsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GyumAdat);
            this.Controls.Add(this.Gyumolcsok);
            this.Name = "GyumolcsGUI";
            this.Text = "Gyumolcs";
            this.Load += new System.EventHandler(this.GyumolcsGUI_Load);
            this.GyumAdat.ResumeLayout(false);
            this.GyumAdat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox Gyumolcsok;
        private System.Windows.Forms.GroupBox GyumAdat;
        private System.Windows.Forms.TextBox MennyisegText;
        private System.Windows.Forms.TextBox EgysegArText;
        private System.Windows.Forms.TextBox NevText;
        private System.Windows.Forms.TextBox IdText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UjGyumolcs;
    }
}

