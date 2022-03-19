namespace KeePassDPG
{
    partial class OptionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionDialog));
            this.AcceptBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.BannerImage = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SubstitutionComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SubsituteCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CapitalizationComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PasswordLengthComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.BannerImage)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(370, 572);
            this.AcceptBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(150, 44);
            this.AcceptBtn.TabIndex = 0;
            this.AcceptBtn.Text = "Accept";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(532, 572);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(150, 44);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // BannerImage
            // 
            this.BannerImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.BannerImage.Location = new System.Drawing.Point(0, 0);
            this.BannerImage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BannerImage.Name = "BannerImage";
            this.BannerImage.Size = new System.Drawing.Size(706, 116);
            this.BannerImage.TabIndex = 12;
            this.BannerImage.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(24, 127);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(658, 428);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PasswordLengthComboBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(8, 39);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage1.Size = new System.Drawing.Size(642, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dictionary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Word Dictionary";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SubstitutionComboBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.SubsituteCheckBox);
            this.tabPage2.Location = new System.Drawing.Point(8, 39);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage2.Size = new System.Drawing.Size(642, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Substitution";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // SubstitutionComboBox
            // 
            this.SubstitutionComboBox.FormattingEnabled = true;
            this.SubstitutionComboBox.Items.AddRange(new object[] {
            "a=4;e=3;i=1;o=0;s=5",
            "a=@;i=!;s=$"});
            this.SubstitutionComboBox.Location = new System.Drawing.Point(18, 81);
            this.SubstitutionComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SubstitutionComboBox.Name = "SubstitutionComboBox";
            this.SubstitutionComboBox.Size = new System.Drawing.Size(608, 33);
            this.SubstitutionComboBox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(618, 248);
            this.label3.TabIndex = 3;
            this.label3.Text = "Indicate whether certain characters in the word can be substituted.\r\n\r\nFor exampl" +
    "e, substitute all \"S\" with \"5\" (S=5), or all \"A\" with \"4\" (A=4), etc.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Substitution List";
            // 
            // SubsituteCheckBox
            // 
            this.SubsituteCheckBox.AutoSize = true;
            this.SubsituteCheckBox.Location = new System.Drawing.Point(12, 11);
            this.SubsituteCheckBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.SubsituteCheckBox.Name = "SubsituteCheckBox";
            this.SubsituteCheckBox.Size = new System.Drawing.Size(251, 29);
            this.SubsituteCheckBox.TabIndex = 0;
            this.SubsituteCheckBox.Text = "Substitute Characters";
            this.SubsituteCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.CapitalizationComboBox);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(8, 39);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(642, 381);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Capitalization";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // CapitalizationComboBox
            // 
            this.CapitalizationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CapitalizationComboBox.FormattingEnabled = true;
            this.CapitalizationComboBox.Items.AddRange(new object[] {
            "None",
            "First Letter",
            "Random"});
            this.CapitalizationComboBox.Location = new System.Drawing.Point(12, 23);
            this.CapitalizationComboBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.CapitalizationComboBox.Name = "CapitalizationComboBox";
            this.CapitalizationComboBox.Size = new System.Drawing.Size(608, 33);
            this.CapitalizationComboBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(612, 309);
            this.label4.TabIndex = 1;
            this.label4.Text = "Specify how capitalization of the word should be done.";
            // 
            // PasswordLengthComboBox
            // 
            this.PasswordLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PasswordLengthComboBox.FormattingEnabled = true;
            this.PasswordLengthComboBox.Location = new System.Drawing.Point(186, 13);
            this.PasswordLengthComboBox.Name = "PasswordLengthComboBox";
            this.PasswordLengthComboBox.Size = new System.Drawing.Size(179, 33);
            this.PasswordLengthComboBox.TabIndex = 19;
            // 
            // OptionDialog
            // 
            this.AcceptButton = this.AcceptBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(706, 639);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BannerImage);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AcceptBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dictionary Password Generator Options";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OptionDialog_FormClosed);
            this.Load += new System.EventHandler(this.OptionDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BannerImage)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AcceptBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.PictureBox BannerImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox SubsituteCheckBox;
        private System.Windows.Forms.ComboBox SubstitutionComboBox;
        private System.Windows.Forms.ComboBox CapitalizationComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox PasswordLengthComboBox;
    }
}