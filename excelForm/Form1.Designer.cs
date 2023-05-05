namespace ExcelForm
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
            this.button_OdaberiBazu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_GenerirajExcelDat
            // 
            this.button_GenerirajExcelDat.Location = new System.Drawing.Point(75, 358);
            this.button_GenerirajExcelDat.Name = "button_GenerirajExcelDat";
            this.button_GenerirajExcelDat.Size = new System.Drawing.Size(165, 78);
            this.button_GenerirajExcelDat.TabIndex = 0;
            this.button_GenerirajExcelDat.Text = "Generiraj excel datoteku";
            this.button_GenerirajExcelDat.UseVisualStyleBackColor = true;
            this.button_GenerirajExcelDat.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(440, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 1;
            // 
            // button_GenerirajPDF
            // 
            this.button_GenerirajPDF.Location = new System.Drawing.Point(75, 136);
            this.button_GenerirajPDF.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.button_GenerirajPDF.Name = "button_GenerirajPDF";
            this.button_GenerirajPDF.Size = new System.Drawing.Size(158, 111);
            this.button_GenerirajPDF.TabIndex = 2;
            this.button_GenerirajPDF.Text = "Generiraj PDF-ove";
            this.button_GenerirajPDF.UseVisualStyleBackColor = true;
            this.button_GenerirajPDF.Click += new System.EventHandler(this.generatePdf_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baza nije odabrana";
            // 
            // button_OdaberiBazu
            // 
            this.button_OdaberiBazu.Location = new System.Drawing.Point(580, 57);
            this.button_OdaberiBazu.Name = "button_OdaberiBazu";
            this.button_OdaberiBazu.Size = new System.Drawing.Size(201, 38);
            this.button_OdaberiBazu.TabIndex = 4;
            this.button_OdaberiBazu.Text = "Odaberi bazu";
            this.button_OdaberiBazu.UseVisualStyleBackColor = true;
            this.button_OdaberiBazu.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 609);
            this.Controls.Add(this.button_OdaberiBazu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_GenerirajPDF);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_GenerirajExcelDat);
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
        private System.Windows.Forms.Button button_OdaberiBazu;
    }
}

