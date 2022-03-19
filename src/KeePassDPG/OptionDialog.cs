using KeePass.UI;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KeePassDPG
{
    public partial class OptionDialog : Form
    {
        public OptionDialog()
        {
            InitializeComponent();
            InitializePasswordLengthComboBox();
        }

        public GeneratorOptions GetOptions(GeneratorOptions defaults)
        {
            PasswordLengthComboBox.SelectedItem = PasswordGenerator.WordDictionaryMap.Where(item => item.Length == defaults.WordLength).First();
            SubsituteCheckBox.Checked = defaults.SubstituteCharacters;
            SubstitutionComboBox.Text = defaults.SubstitutionList;
            CapitalizationComboBox.SelectedIndex = (int)defaults.CapitalizationType;

            if (ShowDialog() != DialogResult.OK) return defaults;

            var options = new GeneratorOptions
            {
                WordLength = ((WordDictionaryMapItem)PasswordLengthComboBox.SelectedItem).Length,
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

        private void OptionDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            GlobalWindowManager.RemoveWindow(this);
        }

        private void InitializePasswordLengthComboBox()
        {
            PasswordLengthComboBox.DisplayMember = "Description";
            PasswordLengthComboBox.ValueMember = "Length";
            PasswordLengthComboBox.DataSource = PasswordGenerator.WordDictionaryMap;            
        }
    }
}
