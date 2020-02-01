using System;

namespace KeePassDPG
{
    /// <summary>
    /// Set of options that define how a dictionary password is generated.
    /// </summary>
    public class GeneratorOptions
    {
        /// <summary>
        /// Gets or sets the word length.
        /// </summary>
        public int WordLength { get; set; }

        /// <summary>
        /// Gets or sets whethr to substitute characters.
        /// </summary>
        public bool SubstituteCharacters { get; set; }

        /// <summary>
        /// Gets or sets the substitution list.
        /// </summary>
        public string SubstitutionList { get; set; }

        /// <summary>
        /// Gets or sets the capitalization type.
        /// </summary>
        public CapitalizationTypes CapitalizationType { get; set; }

        /// <summary>
        /// Initializes a new instance of DictionaryPasswordGeneratorProfile
        /// </summary>
        public GeneratorOptions()
        {
            WordLength = 8;
            SubstituteCharacters = false;
            SubstitutionList = string.Empty;
            CapitalizationType = CapitalizationTypes.None;
        }

        /// <summary>
        /// Initializes a new instance of DictionaryPasswordGeneratorProfile.
        /// </summary>
        /// <param name="optionString">The option string.</param>
        public GeneratorOptions(string optionString)
        {
            // Check if a string was passed.
            if (!string.IsNullOrEmpty(optionString))
            {
                // Parse the string.
                string[] options = optionString.Split('|');

                WordLength = Convert.ToInt32(options[0]);
                SubstituteCharacters = Boolean.Parse(options[1]);
                SubstitutionList = options[2];
                CapitalizationType = (CapitalizationTypes)Enum.Parse(typeof(CapitalizationTypes), options[3]);
            }
            else
            {
                WordLength = 8;
                SubstituteCharacters = false;
                SubstitutionList = string.Empty;
                CapitalizationType = CapitalizationTypes.None;
            }
        }

        /// <summary>
        /// Ouptut a string representation of the options.
        /// </summary>
        /// <returns>A string.</returns>
        public override string ToString() => $"{WordLength}|{SubstituteCharacters}|{SubstitutionList}|{CapitalizationType}";
    }
}
