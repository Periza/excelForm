﻿namespace ExcelForm
{
    partial class Form1
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
            this.button_GenerirajExcelDat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_GenerirajPDF = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button_odaberiBazu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_GenerirajExcelDat
            // 
            this.button_GenerirajExcelDat.Location = new System.Drawing.Point(50, 233);
            this.button_GenerirajExcelDat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_GenerirajExcelDat.Name = "button_GenerirajExcelDat";
            this.button_GenerirajExcelDat.Size = new System.Drawing.Size(110, 51);
            this.button_GenerirajExcelDat.TabIndex = 0;
            this.button_GenerirajExcelDat.Text = "Generiraj excel datoteku";
            this.button_GenerirajExcelDat.UseVisualStyleBackColor = true;
            this.button_GenerirajExcelDat.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 243);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // button_GenerirajPDF
            // 
            this.button_GenerirajPDF.Location = new System.Drawing.Point(50, 113);
            this.button_GenerirajPDF.Name = "button_GenerirajPDF";
            this.button_GenerirajPDF.Size = new System.Drawing.Size(110, 51);
            this.button_GenerirajPDF.TabIndex = 2;
            this.button_GenerirajPDF.Text = "Generiraj PDF-ove";
            this.button_GenerirajPDF.UseVisualStyleBackColor = true;
            this.button_GenerirajPDF.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baza nije odabrana";
            // 
            // button_odaberiBazu
            // 
            this.button_odaberiBazu.Location = new System.Drawing.Point(387, 37);
            this.button_odaberiBazu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_odaberiBazu.Name = "button_odaberiBazu";
            this.button_odaberiBazu.Size = new System.Drawing.Size(134, 25);
            this.button_odaberiBazu.TabIndex = 4;
            this.button_odaberiBazu.Text = "Odaberi bazu";
            this.button_odaberiBazu.UseVisualStyleBackColor = true;
            this.button_odaberiBazu.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 396);
            this.Controls.Add(this.button_odaberiBazu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_GenerirajPDF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_GenerirajExcelDat);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Generiraj PDF i excel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_GenerirajExcelDat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_GenerirajPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_odaberiBazu;
    }
}

