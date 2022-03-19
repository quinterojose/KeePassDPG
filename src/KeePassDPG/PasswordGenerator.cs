using KeePassLib;
using KeePassLib.Cryptography;
using KeePassLib.Cryptography.PasswordGenerator;
using KeePassLib.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace KeePassDPG
{
    /// <summary>
    /// Defines the various capitalization types.
    /// </summary>
    public enum CapitalizationTypes
    {
        /// <summary>
        /// No capitalization.
        /// </summary>
        None,

        /// <summary>
        /// Only the first letter will be capitalized.
        /// </summary>
        FirstLetter,

        /// <summary>
        /// A random letter will be capitalized.
        /// </summary>
        Random
    }

    /// <summary>
    /// Custom implementation of a password generator to generate random dictionary passwords.
    /// </summary>
    public class PasswordGenerator : CustomPwGenerator
    {
        private int _currentWordLength;

        private List<string> _wordDictionary;

        /// <summary>
        /// Maps a word length to the appropriate word dictionary.
        /// </summary>
        /// <remarks>
        /// Word dictionaries are stored as embedded resources and are files created using the KeePassDPG.Compressor tool.
        /// The tool will generate one dictionary file for each word length and then will compress it using a GZipStream.
        /// The output is then added as a resource to the assembly. When a file dictionary is used, it is decompressed and then
        /// read by the plugin.
        /// </remarks>
        internal static readonly List<WordDictionaryMapItem> WordDictionaryMap = new List<WordDictionaryMapItem>
        {
            new WordDictionaryMapItem{ Length = 6, Data= Properties.Resources.words6, Description = "6 letters" },
            new WordDictionaryMapItem{ Length = 7, Data= Properties.Resources.words7, Description = "7 letters" },
            new WordDictionaryMapItem{ Length = 8, Data= Properties.Resources.words8, Description = "8 letters" },
            new WordDictionaryMapItem{ Length = 9, Data= Properties.Resources.words9, Description = "9 letters" },
            new WordDictionaryMapItem{ Length = 10, Data= Properties.Resources.words10, Description = "10 letters" },
            new WordDictionaryMapItem{ Length = 11, Data= Properties.Resources.words11, Description = "11 letters" },
            new WordDictionaryMapItem{ Length = 12, Data= Properties.Resources.words12, Description = "12 letters" },
            new WordDictionaryMapItem{ Length = 13, Data= Properties.Resources.words13, Description = "13 letters" },
            new WordDictionaryMapItem{ Length = 14, Data= Properties.Resources.words14, Description = "14 letters" },
            new WordDictionaryMapItem{ Length = 15, Data= Properties.Resources.words15, Description = "15 letters" },
            new WordDictionaryMapItem{ Length = 16, Data= Properties.Resources.words16, Description = "16 letters" },
            new WordDictionaryMapItem{ Length = 17, Data= Properties.Resources.words17, Description = "17 letters" },
            new WordDictionaryMapItem{ Length = 18, Data= Properties.Resources.words18, Description = "18 letters" },
            new WordDictionaryMapItem{ Length = 19, Data= Properties.Resources.words19, Description = "19 letters" },
            new WordDictionaryMapItem{ Length = 20, Data= Properties.Resources.words20, Description = "20 letters" },
            new WordDictionaryMapItem{ Length = 21, Data= Properties.Resources.words21, Description = "21 letters" },
            new WordDictionaryMapItem{ Length = 22, Data= Properties.Resources.words22, Description = "22 letters" },
            new WordDictionaryMapItem{ Length = 23, Data= Properties.Resources.words23, Description = "23 letters" },
            new WordDictionaryMapItem{ Length = 24, Data= Properties.Resources.words24, Description = "24 letters" },
            new WordDictionaryMapItem{ Length = 25, Data= Properties.Resources.words25, Description = "25 letters" },
            new WordDictionaryMapItem{ Length = 27, Data= Properties.Resources.words27, Description = "27 letters" },
            new WordDictionaryMapItem{ Length = 28, Data= Properties.Resources.words28, Description = "28 letters" }
        };

        /// <summary>
        /// Gets the custom password generator name.
        /// </summary>
        public override string Name
        {
            get
            {
                return Properties.Resources.PluginName;
            }
        }

        /// <summary>
        /// Gets the custom password generator unique ID.
        /// </summary>
        public override PwUuid Uuid
        {
            get
            {
                return new PwUuid(new Guid(Properties.Resources.UUID).ToByteArray());
            }
        }

        /// <summary>
        /// Gets whether the password generator supports options
        /// </summary>
        public override bool SupportsOptions
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Generate a random dictionary password.
        /// </summary>
        /// <param name="prf">The password profile to use.</param>
        /// <param name="crsRandomSource">The cryptographic stream.</param>
        /// <returns>A generated ProtectedString password.</returns>
        public override ProtectedString Generate(PwProfile prf, CryptoRandomStream crsRandomSource)
        {
            // Get the generator options.
            var options = new GeneratorOptions(prf.CustomAlgorithmOptions);

            // Check if a word dictionary has already been loaded, if not, load it.
            if (_wordDictionary == null || _currentWordLength != options.WordLength)
            {
                _wordDictionary = ExtractWordDictionary(options.WordLength);
                _currentWordLength = options.WordLength;
            }

            // Get a random word from the dictionary
            var randomNumber = new RandomNumber(crsRandomSource);
            string password = _wordDictionary.Count > 0 ? _wordDictionary[randomNumber.Next(_wordDictionary.Count)] : string.Empty;
            _wordDictionary.Remove(password);

            // Substitute characters if specified.
            if (options.SubstituteCharacters && !string.IsNullOrEmpty(options.SubstitutionList))
                password = SubstituteCharacters(password, options.SubstitutionList);

            // Capitalize if necessary
            if (options.CapitalizationType != CapitalizationTypes.None)
                password = CapitalizePassword(password, options.CapitalizationType, randomNumber);

            return new ProtectedString(false, password);
        }

        /// <summary>
        /// Returns a set of options associated with this generator.
        /// </summary>
        /// <param name="strCurrentOptions">The set of current options.</param>
        /// <returns>The set of new options.</returns>
        public override string GetOptions(string strCurrentOptions)
        {
            var options = new GeneratorOptions(strCurrentOptions);

            // Open the option dialog to generate new options.
            var optionsDialog = new OptionDialog();
            options = optionsDialog.GetOptions(options);
            optionsDialog.Dispose();

            return options.ToString();
        }

        private static List<string> ExtractWordDictionary(int wordLength)
        {
            // Get compressed file
            var compressedFile = WordDictionaryMap.Where(item => item.Length == wordLength).First().Data;

            // Decompress the file
            using (var compressedStream = new MemoryStream(compressedFile))
            {
                using (var decompressedStream = new MemoryStream())
                {
                    using (var decompressionStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                    {
                        var buffer = new byte[4096];
                        var read = 0;
                        while ((read = decompressionStream.Read(buffer, 0, buffer.Length)) > 0)
                            decompressedStream.Write(buffer, 0, read);

                        var bytes = decompressedStream.ToArray();

                        // Extract words from file
                        var chars = new char[bytes.Length / sizeof(char)];
                        Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
                        string wordsString = new string(chars);

                        return new List<string>(wordsString.Split(' '));
                    }
                }
            }
        }

        private static string SubstituteCharacters(string password, string substitutionList)
        {
            var replacementList = GetSubstitutionList(substitutionList);

            var passwordChars = password.ToCharArray();

            for (int i = 0; i < passwordChars.Length; i++)
            {
                if (replacementList.ContainsKey(passwordChars[i]))
                    passwordChars[i] = replacementList[passwordChars[i]];
            }

            return new string(passwordChars);
        }

        private static Dictionary<char, char> GetSubstitutionList(string substitutionList)
        {
            var replacementDictionary = new Dictionary<char, char>();

            var replacementElements = substitutionList.Split(';');

            foreach (string replacementElement in replacementElements)
            {
                var elementMembers = replacementElement.Split(new char[] { '=' });
                replacementDictionary.Add(elementMembers[0][0], elementMembers[1][0]);
            }

            return replacementDictionary;
        }

        private static string CapitalizePassword(string password, CapitalizationTypes capitalizationType, RandomNumber randomNumber)
        {
            if (capitalizationType == CapitalizationTypes.None)
                return password;

            var passwordChars = password.ToCharArray();

            if (capitalizationType == CapitalizationTypes.FirstLetter)
            {
                // Loop through charactes and make the first letter upercase.
                for (int i = 0; i < passwordChars.Length; i++)
                {
                    if (char.IsLetter(passwordChars[i]) && char.IsLower(passwordChars[i]))
                    {
                        passwordChars[i] = char.ToUpper(passwordChars[i]);
                        break;
                    }
                }
            }
            else
            {
                // First let's make sure this can be applied to the current string
                var hasLetter = false;
                for (int i = 0; i < passwordChars.Length; i++)
                {
                    if (char.IsLetter(passwordChars[i]))
                    {
                        hasLetter = true;
                        break;
                    }
                }

                // Get a random letter from the password and make it uppercase
                if (hasLetter)
                {
                    while (true)
                    {
                        int i = randomNumber.Next(passwordChars.Length);
                        if (char.IsLetter(passwordChars[i]) && char.IsLower(passwordChars[i]))
                        {
                            passwordChars[i] = char.ToUpper(passwordChars[i]);
                            break;
                        }
                    }
                }
            }

            return new string(passwordChars);
        }
    }
}
