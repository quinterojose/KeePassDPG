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
            this.PasswordLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SubstitutionComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SubsituteCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.CapitalizationComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BannerImage)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordLengthNumericUpDown)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // AcceptBtn
            // 
            this.AcceptBtn.Location = new System.Drawing.Point(247, 366);
            this.AcceptBtn.Margin = new System.Windows.Forms.Padding(4);
            this.AcceptBtn.Name = "AcceptBtn";
            this.AcceptBtn.Size = new System.Drawing.Size(100, 28);
            this.AcceptBtn.TabIndex = 0;
            this.AcceptBtn.Text = "Accept";
            this.AcceptBtn.UseVisualStyleBackColor = true;
            this.AcceptBtn.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(355, 366);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(100, 28);
            this.CancelBtn.TabIndex = 1;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // BannerImage
            // 
            this.BannerImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.BannerImage.Location = new System.Drawing.Point(0, 0);
            this.BannerImage.Margin = new System.Windows.Forms.Padding(4);
            this.BannerImage.Name = "BannerImage";
            this.BannerImage.Size = new System.Drawing.Size(471, 74);
            this.BannerImage.TabIndex = 12;
            this.BannerImage.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 81);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(439, 274);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.PasswordLengthNumericUpDown);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(431, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dictionary";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Length of generated password:";
            // 
            // PasswordLengthNumericUpDown
            // 
            this.PasswordLengthNumericUpDown.Location = new System.Drawing.Point(225, 7);
            this.PasswordLengthNumericUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordLengthNumericUpDown.Maximum = new decimal(new int[] {
            28,
            0,
            0,
            0});
            this.PasswordLengthNumericUpDown.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.PasswordLengthNumericUpDown.Name = "PasswordLengthNumericUpDown";
            this.PasswordLengthNumericUpDown.Size = new System.Drawing.Size(100, 22);
            this.PasswordLengthNumericUpDown.TabIndex = 17;
            this.PasswordLengthNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.PasswordLengthNumericUpDown.ValueChanged += new System.EventHandler(this.PasswordLengthNumericUpDown_ValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.SubstitutionComboBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.SubsituteCheckBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(431, 245);
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
            this.SubstitutionComboBox.Location = new System.Drawing.Point(12, 52);
            this.SubstitutionComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.SubstitutionComboBox.Name = "SubstitutionComboBox";
            this.SubstitutionComboBox.Size = new System.Drawing.Size(407, 24);
            this.SubstitutionComboBox.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 159);
            this.label3.TabIndex = 3;
            this.label3.Text = "Indicate whether certain characters in the word can be substituted.\r\n\r\nFor exampl" +
    "e, substitute all \"S\" with \"5\" (S=5), or all \"A\" with \"4\" (A=4), etc.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Substitution List";
            // 
            // SubsituteCheckBox
            // 
            this.SubsituteCheckBox.AutoSize = true;
            this.SubsituteCheckBox.Location = new System.Drawing.Point(8, 7);
            this.SubsituteCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.SubsituteCheckBox.Name = "SubsituteCheckBox";
            this.SubsituteCheckBox.Size = new System.Drawing.Size(166, 21);
            this.SubsituteCheckBox.TabIndex = 0;
            this.SubsituteCheckBox.Text = "Substitute Characters";
            this.SubsituteCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.CapitalizationComboBox);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(431, 245);
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
            this.CapitalizationComboBox.Location = new System.Drawing.Point(8, 15);
            this.CapitalizationComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.CapitalizationComboBox.Name = "CapitalizationComboBox";
            this.CapitalizationComboBox.Size = new System.Drawing.Size(407, 24);
            this.CapitalizationComboBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 44);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(408, 198);
            this.label4.TabIndex = 1;
            this.label4.Text = "Specify how capitalization of the word should be done.";
            // 
            // OptionDialog
            // 
            this.AcceptButton = this.AcceptBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelBtn;
            this.ClientSize = new System.Drawing.Size(471, 409);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.BannerImage);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.AcceptBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
            ((System.ComponentModel.ISupportInitialize)(this.PasswordLengthNumericUpDown)).EndInit();
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
        private System.Windows.Forms.NumericUpDown PasswordLengthNumericUpDown;

    }
}