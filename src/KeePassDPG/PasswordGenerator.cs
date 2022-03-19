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
            new WordDictionaryMapItem{ Length = 6, Data= Properties.Resources.words6, Description = "6 words" },
            new WordDictionaryMapItem{ Length = 7, Data= Properties.Resources.words7, Description = "7 words" },
            new WordDictionaryMapItem{ Length = 8, Data= Properties.Resources.words8, Description = "8 words" },
            new WordDictionaryMapItem{ Length = 9, Data= Properties.Resources.words9, Description = "9 words" },
            new WordDictionaryMapItem{ Length = 10, Data= Properties.Resources.words10, Description = "10 words" },
            new WordDictionaryMapItem{ Length = 11, Data= Properties.Resources.words11, Description = "11 words" },
            new WordDictionaryMapItem{ Length = 12, Data= Properties.Resources.words12, Description = "12 words" },
            new WordDictionaryMapItem{ Length = 13, Data= Properties.Resources.words13, Description = "13 words" },
            new WordDictionaryMapItem{ Length = 14, Data= Properties.Resources.words14, Description = "14 words" },
            new WordDictionaryMapItem{ Length = 15, Data= Properties.Resources.words15, Description = "15 words" },
            new WordDictionaryMapItem{ Length = 16, Data= Properties.Resources.words16, Description = "16 words" },
            new WordDictionaryMapItem{ Length = 17, Data= Properties.Resources.words17, Description = "17 words" },
            new WordDictionaryMapItem{ Length = 18, Data= Properties.Resources.words18, Description = "18 words" },
            new WordDictionaryMapItem{ Length = 19, Data= Properties.Resources.words19, Description = "19 words" },
            new WordDictionaryMapItem{ Length = 20, Data= Properties.Resources.words20, Description = "20 words" },
            new WordDictionaryMapItem{ Length = 21, Data= Properties.Resources.words21, Description = "21 words" },
            new WordDictionaryMapItem{ Length = 22, Data= Properties.Resources.words22, Description = "22 words" },
            new WordDictionaryMapItem{ Length = 23, Data= Properties.Resources.words23, Description = "23 words" },
            new WordDictionaryMapItem{ Length = 24, Data= Properties.Resources.words24, Description = "24 words" },
            new WordDictionaryMapItem{ Length = 25, Data= Properties.Resources.words25, Description = "25 words" },
            new WordDictionaryMapItem{ Length = 27, Data= Properties.Resources.words27, Description = "27 words" },
            new WordDictionaryMapItem{ Length = 28, Data= Properties.Resources.words28, Description = "28 words" }
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
            GeneratorOptions options = new GeneratorOptions(prf.CustomAlgorithmOptions);

            // Check if a word dictionary has already been loaded, if not, load it.
            if (_wordDictionary == null || _currentWordLength != options.WordLength)
            {
                _wordDictionary = ExtractWordDictionary(options.WordLength);
                _currentWordLength = options.WordLength;
            }

            // Get a random word from the dictionary
            RandomNumber randomNumber = new RandomNumber(crsRandomSource);
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
            GeneratorOptions options = new GeneratorOptions(strCurrentOptions);

            // Open the option dialog to generate new options.
            OptionDialog optionsDialog = new OptionDialog();
            options = optionsDialog.GetOptions(options);
            optionsDialog.Dispose();

            return options.ToString();
        }

        private static List<string> ExtractWordDictionary(int wordLength)
        {
            // Get compressed file
            byte[] compressedFile = WordDictionaryMap.Where(item => item.Length == wordLength).First().Data;

            // Decompress the file
            using (MemoryStream compressedStream = new MemoryStream(compressedFile))
            {
                using (MemoryStream decompressedStream = new MemoryStream())
                {
                    using (GZipStream decompressionStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                    {
                        byte[] buffer = new byte[4096];
                        int read;
                        while ((read = decompressionStream.Read(buffer, 0, buffer.Length)) > 0)
                            decompressedStream.Write(buffer, 0, read);

                        byte[] bytes = decompressedStream.ToArray();

                        // Extract words from file
                        char[] chars = new char[bytes.Length / sizeof(char)];
                        Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
                        string wordsString = new string(chars);

                        return new List<string>(wordsString.Split(' '));
                    }
                }
            }
        }

        private static string SubstituteCharacters(string password, string substitutionList)
        {
            Dictionary<char, char> replacementList = GetSubstitutionList(substitutionList);

            char[] passwordChars = password.ToCharArray();

            for (int i = 0; i < passwordChars.Length; i++)
            {
                if (replacementList.ContainsKey(passwordChars[i]))
                    passwordChars[i] = replacementList[passwordChars[i]];
            }

            return new string(passwordChars);
        }

        private static Dictionary<char, char> GetSubstitutionList(string substitutionList)
        {
            Dictionary<char, char> replacementDictionary = new Dictionary<char, char>();

            string[] replacementElements = substitutionList.Split(';');

            foreach (string replacementElement in replacementElements)
            {
                string[] elementMembers = replacementElement.Split(new char[] { '=' });
                replacementDictionary.Add(elementMembers[0][0], elementMembers[1][0]);
            }

            return replacementDictionary;
        }

        private static string CapitalizePassword(string password, CapitalizationTypes capitalizationType, RandomNumber randomNumber)
        {
            if (capitalizationType == CapitalizationTypes.None)
                return password;

            char[] passwordChars = password.ToCharArray();

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
                bool hasLetter = false;
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
