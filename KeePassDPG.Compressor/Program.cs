using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;

namespace KeePassDPG.Compressor
{
    class Program
    {
        /// <summary>
        /// The lists of words.
        /// </summary>
        private static List<WordList> _wordLists;

        /// <summary>
        /// The source file location.
        /// </summary>
        private static string _sourceFile;

        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("Compressor for KeePass Dictionary Password Generator v{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            Console.WriteLine();

            // Open source file
            _sourceFile = args[0];

            if (!string.IsNullOrEmpty(_sourceFile))
            {
                if (File.Exists(_sourceFile))
                {
                    using (StreamReader reader = new StreamReader(_sourceFile))
                    {
                        Console.WriteLine("Reading file...");
                        Console.WriteLine();

                        // Read words
                        string fileData = reader.ReadToEnd();
                        string[] sourceWords = fileData.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (string word in sourceWords)
                        {
                            PutWord(word.Trim().ToLowerInvariant());
                        }
                    }

                    // Write files.
                    foreach (WordList wordList in _wordLists)
                    {
                        Console.WriteLine("Writing {0} letter word file.", wordList.WordLength);
                        Console.WriteLine();
                        WriteCompressedFile(wordList);
                    }
                }
                else
                {
                    Console.WriteLine("A valid source file must be specified.");
                    Console.WriteLine();
                    ShowHelp();
                }
            }
            else
            {
                ShowHelp();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        /// <summary>
        /// Write the specified list of words to a compressed file.
        /// </summary>
        /// <param name="wordList"></param>
        private static void WriteCompressedFile(WordList wordList)
        {
            string filePath = Path.Combine(Path.GetDirectoryName(_sourceFile), string.Format("words{0}.gz", wordList.WordLength));

            using (FileStream compressedFile = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (GZipStream compressionStream = new GZipStream(compressedFile, CompressionMode.Compress))
                {
                    try
                    {
                        // Output new file
                        string data = String.Join(" ", wordList.ToArray());
                        byte[] bytes = new byte[data.Length * sizeof(char)];
                        Buffer.BlockCopy(data.ToCharArray(), 0, bytes, 0, bytes.Length);

                        using (MemoryStream stream = new MemoryStream(bytes))
                        {
                            stream.CopyTo(compressionStream);

                            Console.WriteLine("{0} created.", Path.GetFileName(filePath));
                            Console.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                        Console.WriteLine();
                    }
                }
            }
        }

        /// <summary>
        /// Adds the specified word to the appropriate word list.
        /// </summary>
        /// <param name="word">The word to add.</param>
        private static void PutWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                return;

            if (_wordLists == null)
                _wordLists = new List<WordList>();

            WordList wordList = _wordLists.SingleOrDefault(e => e.WordLength == word.Length);

            if (wordList == null)
            {
                wordList = new WordList { WordLength = word.Length };
                _wordLists.Add(wordList);
            }

            wordList.Add(word);
        }

        /// <summary>
        /// Show usage information.
        /// </summary>
        private static void ShowHelp()
        {
            Console.WriteLine("Usage: compressor [source] [destination]");
            Console.WriteLine();
        }
    }
}
