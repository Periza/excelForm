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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(129, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Promjena AppSettings";
            // 
            // kfServerPathLabel
            // 
            this.kfServerPathLabel.AutoSize = true;
            this.kfServerPathLabel.Location = new System.Drawing.Point(58, 112);
            this.kfServerPathLabel.Name = "kfServerPathLabel";
            this.kfServerPathLabel.Size = new System.Drawing.Size(69, 13);
            this.kfServerPathLabel.TabIndex = 1;
            this.kfServerPathLabel.Text = "kfServerPath";
            // 
            // sculptorPathLabel
            // 
            this.sculptorPathLabel.AutoSize = true;
            this.sculptorPathLabel.Location = new System.Drawing.Point(58, 149);
            this.sculptorPathLabel.Name = "sculptorPathLabel";
            this.sculptorPathLabel.Size = new System.Drawing.Size(66, 13);
            this.sculptorPathLabel.TabIndex = 2;
            this.sculptorPathLabel.Text = "sculptorPath";
            // 
            // projectPathLabel
            // 
            this.projectPathLabel.AutoSize = true;
            this.projectPathLabel.Location = new System.Drawing.Point(58, 186);
            this.projectPathLabel.Name = "projectPathLabel";
            this.projectPathLabel.Size = new System.Drawing.Size(61, 13);
            this.projectPathLabel.TabIndex = 3;
            this.projectPathLabel.Text = "projectPath";
            // 
            // tehnonPath
            // 
            this.tehnonPath.AutoSize = true;
            this.tehnonPath.Location = new System.Drawing.Point(58, 223);
            this.tehnonPath.Name = "tehnonPath";
            this.tehnonPath.Size = new System.Drawing.Size(62, 13);
            this.tehnonPath.TabIndex = 4;
            this.tehnonPath.Text = "tehnonPath";
            // 
            // kfServerPathTb
            // 
            this.kfServerPathTb.Location = new System.Drawing.Point(133, 109);
            this.kfServerPathTb.Name = "kfServerPathTb";
            this.kfServerPathTb.Size = new System.Drawing.Size(283, 20);
            this.kfServerPathTb.TabIndex = 5;
            // 
            // sculptorPathTb
            // 
            this.sculptorPathTb.Location = new System.Drawing.Point(133, 146);
            this.sculptorPathTb.Name = "sculptorPathTb";
            this.sculptorPathTb.Size = new System.Drawing.Size(283, 20);
            this.sculptorPathTb.TabIndex = 6;
            // 
            // projectPathTb
            // 
            this.projectPathTb.Location = new System.Drawing.Point(133, 183);
            this.projectPathTb.Name = "projectPathTb";
            this.projectPathTb.Size = new System.Drawing.Size(283, 20);
            this.projectPathTb.TabIndex = 7;
            // 
            // tehnonPathTb
            // 
            this.tehnonPathTb.Location = new System.Drawing.Point(133, 220);
            this.tehnonPathTb.Name = "tehnonPathTb";
            this.tehnonPathTb.Size = new System.Drawing.Size(283, 20);
            this.tehnonPathTb.TabIndex = 8;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(166, 282);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 34);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Spremi";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ChangeAppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 357);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tehnonPathTb);
            this.Controls.Add(this.projectPathTb);
            this.Controls.Add(this.sculptorPathTb);
            this.Controls.Add(this.kfServerPathTb);
            this.Controls.Add(this.tehnonPath);
            this.Controls.Add(this.projectPathLabel);
            this.Controls.Add(this.sculptorPathLabel);
            this.Controls.Add(this.kfServerPathLabel);
            this.Controls.Add(this.label1);
            this.Name = "ChangeAppSettings";
            this.Text = "ChangeAppSettings";
            this.Load += new System.EventHandler(this.ChangeAppSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}