namespace ExcelForm
{
    partial class ChangeAppSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.kfServerPathLabel = new System.Windows.Forms.Label();
            this.sculptorPathLabel = new System.Windows.Forms.Label();
            this.projectPathLabel = new System.Windows.Forms.Label();
            this.tehnonPath = new System.Windows.Forms.Label();
            this.kfServerPathTb = new System.Windows.Forms.TextBox();
            this.sculptorPathTb = new System.Windows.Forms.TextBox();
            this.projectPathTb = new System.Windows.Forms.TextBox();
            this.tehnonPathTb = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(98, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 15, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Promjena AppSettings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kfServerPathLabel
            // 
            this.kfServerPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kfServerPathLabel.AutoSize = true;
            this.kfServerPathLabel.Location = new System.Drawing.Point(65, 62);
            this.kfServerPathLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 0);
            this.kfServerPathLabel.Name = "kfServerPathLabel";
            this.kfServerPathLabel.Size = new System.Drawing.Size(69, 13);
            this.kfServerPathLabel.TabIndex = 1;
            this.kfServerPathLabel.Text = "kfServerPath";
            // 
            // sculptorPathLabel
            // 
            this.sculptorPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sculptorPathLabel.AutoSize = true;
            this.sculptorPathLabel.Location = new System.Drawing.Point(68, 116);
            this.sculptorPathLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 0);
            this.sculptorPathLabel.Name = "sculptorPathLabel";
            this.sculptorPathLabel.Size = new System.Drawing.Size(66, 13);
            this.sculptorPathLabel.TabIndex = 2;
            this.sculptorPathLabel.Text = "sculptorPath";
            // 
            // projectPathLabel
            // 
            this.projectPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.projectPathLabel.AutoSize = true;
            this.projectPathLabel.Location = new System.Drawing.Point(73, 170);
            this.projectPathLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 0);
            this.projectPathLabel.Name = "projectPathLabel";
            this.projectPathLabel.Size = new System.Drawing.Size(61, 13);
            this.projectPathLabel.TabIndex = 3;
            this.projectPathLabel.Text = "projectPath";
            // 
            // tehnonPath
            // 
            this.tehnonPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tehnonPath.AutoSize = true;
            this.tehnonPath.Location = new System.Drawing.Point(72, 224);
            this.tehnonPath.Margin = new System.Windows.Forms.Padding(3, 8, 8, 0);
            this.tehnonPath.Name = "tehnonPath";
            this.tehnonPath.Size = new System.Drawing.Size(62, 13);
            this.tehnonPath.TabIndex = 4;
            this.tehnonPath.Text = "tehnonPath";
            // 
            // kfServerPathTb
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.kfServerPathTb, 2);
            this.kfServerPathTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kfServerPathTb.Location = new System.Drawing.Point(145, 57);
            this.kfServerPathTb.Name = "kfServerPathTb";
            this.kfServerPathTb.Size = new System.Drawing.Size(237, 20);
            this.kfServerPathTb.TabIndex = 5;
            // 
            // sculptorPathTb
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.sculptorPathTb, 2);
            this.sculptorPathTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sculptorPathTb.Location = new System.Drawing.Point(145, 111);
            this.sculptorPathTb.Name = "sculptorPathTb";
            this.sculptorPathTb.Size = new System.Drawing.Size(237, 20);
            this.sculptorPathTb.TabIndex = 6;
            // 
            // projectPathTb
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.projectPathTb, 2);
            this.projectPathTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectPathTb.Location = new System.Drawing.Point(145, 165);
            this.projectPathTb.Name = "projectPathTb";
            this.projectPathTb.Size = new System.Drawing.Size(237, 20);
            this.projectPathTb.TabIndex = 7;
            // 
            // tehnonPathTb
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tehnonPathTb, 2);
            this.tehnonPathTb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tehnonPathTb.Location = new System.Drawing.Point(145, 219);
            this.tehnonPathTb.Name = "tehnonPathTb";
            this.tehnonPathTb.Size = new System.Drawing.Size(237, 20);
            this.tehnonPathTb.TabIndex = 8;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tableLayoutPanel1.SetColumnSpan(this.saveButton, 3);
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(142, 273);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 34);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Spremi";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.95652F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.34783F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.695652F));
            this.tableLayoutPanel1.Controls.Add(this.kfServerPathTb, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.sculptorPathTb, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.projectPathTb, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tehnonPathTb, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.saveButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.kfServerPathLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sculptorPathLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.projectPathLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tehnonPath, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 8, 8, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 327);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // ChangeAppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 327);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(250, 250);
            this.Name = "ChangeAppSettings";
            this.Text = "ChangeAppSettings";
            this.Load += new System.EventHandler(this.ChangeAppSettings_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label kfServerPathLabel;
        private System.Windows.Forms.Label sculptorPathLabel;
        private System.Windows.Forms.Label projectPathLabel;
        private System.Windows.Forms.Label tehnonPath;
        private System.Windows.Forms.TextBox kfServerPathTb;
        private System.Windows.Forms.TextBox sculptorPathTb;
        private System.Windows.Forms.TextBox projectPathTb;
        private System.Windows.Forms.TextBox tehnonPathTb;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}