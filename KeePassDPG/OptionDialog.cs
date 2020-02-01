using KeePass.UI;
using System;
using System.Windows.Forms;

namespace KeePassDPG
{
    public partial class OptionDialog : Form
    {
        public OptionDialog()
        {
            InitializeComponent();
        }

        public GeneratorOptions GetOptions(GeneratorOptions defaults)
        {
            PasswordLengthNumericUpDown.Value = defaults.WordLength;
            SubsituteCheckBox.Checked = defaults.SubstituteCharacters;
            SubstitutionComboBox.Text = defaults.SubstitutionList;
            CapitalizationComboBox.SelectedIndex = (int)defaults.CapitalizationType;

            if (this.ShowDialog() != DialogResult.OK) return defaults;

            GeneratorOptions options = new GeneratorOptions
            {
                WordLength = Convert.ToInt32(PasswordLengthNumericUpDown.Value),
                SubstituteCharacters = SubsituteCheckBox.Checked,
                SubstitutionList = SubstitutionComboBox.Text,
                CapitalizationType = (CapitalizationTypes)CapitalizationComboBox.SelectedIndex
            };

            return options;
        }

        private void OptionDialog_Load(object sender, EventArgs e)
        {
            GlobalWindowManager.AddWindow(this);
            BannerImage.Image = BannerFactory.CreateBanner(BannerImage.Width, BannerImage.Height, BannerStyle.Default, Properties.Resources.kgpg_info, "Generator Options", string.Empty);
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OptionDialog_FormClosed(object sender, FormClosedEventArgs e) => GlobalWindowManager.RemoveWindow(this);

        private void PasswordLengthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (PasswordLengthNumericUpDown.Value == 26)
                PasswordLengthNumericUpDown.Value++;
        }
    }
}
