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
        static void Main(string[] args)
        {
            Console.WriteLine("Compressor for KeePass Dictionary Password Generator");
            Console.WriteLine();

            var wordLists = new List<WordList>();

            Console.WriteLine("Specify a source file location:");
            var sourceFileName = Console.ReadLine();
            Console.WriteLine($"Compressed files will be output to: {Path.GetDirectoryName(sourceFileName)}");

            if (!string.IsNullOrEmpty(sourceFileName))
            {
                if (File.Exists(sourceFileName))
                {
                    using (var reader = new StreamReader(sourceFileName))
                    {
                        Console.WriteLine("Reading file...");
                        Console.WriteLine();

                        // Read words
                        var fileData = reader.ReadToEnd();
                        var sourceWords = fileData.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        Array.ForEach(sourceWords, word => PutWord(word.Trim().ToLowerInvariant(), wordLists));
                    }

                    // Write files.
                    wordLists.ForEach(wordList =>
                    {
                        Console.WriteLine("Writing {0} letter word file.", wordList.WordLength);
                        Console.WriteLine();
                        WriteCompressedFile(wordList, sourceFileName);
                    });
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

        private static void WriteCompressedFile(WordList wordList, string sourceFile)
        {
            string filePath = Path.Combine(Path.GetDirectoryName(sourceFile)!, string.Format("words{0}.gz", wordList.WordLength));

            using var compressedFile = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            using var compressionStream = new GZipStream(compressedFile, CompressionMode.Compress);
            try
            {
                // Output new file
                var data = string.Join(" ", wordList.ToArray());
                var bytes = new byte[data.Length * sizeof(char)];
                Buffer.BlockCopy(data.ToCharArray(), 0, bytes, 0, bytes.Length);

                using var stream = new MemoryStream(bytes);
                stream.CopyTo(compressionStream);

                Console.WriteLine("{0} created.", Path.GetFileName(filePath));
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
            }
        }

        private static void PutWord(string word, List<WordList> wordLists)
        {
            if (string.IsNullOrEmpty(word))
                return;

            // Get existing word list
            var wordList = wordLists.SingleOrDefault(e => e.WordLength == word.Length);

            if (wordList == null)
            {
                // Word list not found, add new word list.
                wordList = new WordList { WordLength = word.Length };
                wordLists.Add(wordList);
            }

            // Add the word to the word list.
            wordList.Add(word);
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Usage: compressor [source] [destination]");
            Console.WriteLine();
        }
    }
}
