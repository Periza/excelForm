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
            this.settingsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_GenerirajExcelDat
            // 
            this.button_GenerirajExcelDat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_GenerirajExcelDat.Location = new System.Drawing.Point(6, 274);
            this.button_GenerirajExcelDat.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.button_GenerirajExcelDat.Name = "button_GenerirajExcelDat";
            this.button_GenerirajExcelDat.Size = new System.Drawing.Size(135, 92);
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
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // button_GenerirajPDF
            // 
            this.button_GenerirajPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_GenerirajPDF.Location = new System.Drawing.Point(6, 133);
            this.button_GenerirajPDF.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.button_GenerirajPDF.Name = "button_GenerirajPDF";
            this.button_GenerirajPDF.Size = new System.Drawing.Size(132, 79);
            this.button_GenerirajPDF.TabIndex = 2;
            this.button_GenerirajPDF.Text = "Generiraj PDF-ove";
            this.button_GenerirajPDF.UseVisualStyleBackColor = true;
            this.button_GenerirajPDF.Click += new System.EventHandler(this.generatePdf_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 4);
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(10, 20, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baza nije odabrana";
            // 
            // button_OdaberiBazu
            // 
            this.button_OdaberiBazu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_OdaberiBazu.Location = new System.Drawing.Point(468, 71);
            this.button_OdaberiBazu.Name = "button_OdaberiBazu";
            this.button_OdaberiBazu.Size = new System.Drawing.Size(134, 51);
            this.button_OdaberiBazu.TabIndex = 4;
            this.button_OdaberiBazu.Text = "Odaberi bazu";
            this.button_OdaberiBazu.UseVisualStyleBackColor = true;
            this.button_OdaberiBazu.Click += new System.EventHandler(this.button3_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Image = global::ExcelForm.Properties.Resources.setting__2_;
            this.settingsButton.Location = new System.Drawing.Point(558, 3);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(44, 34);
            this.settingsButton.TabIndex = 5;
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.83333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.83333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.83334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.58333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.91667F));
            this.tableLayoutPanel1.Controls.Add(this.settingsButton, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_GenerirajPDF, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_GenerirajExcelDat, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_OdaberiBazu, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.70217F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.9901F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.12583F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.43298F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.88773F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.861187F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 413);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 413);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(350, 350);
            this.Name = "Form1";
            this.Text = "Generiraj PDF i excel";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_GenerirajExcelDat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_GenerirajPDF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_OdaberiBazu;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

