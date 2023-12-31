using CommandLine;
using KeePassDPG.Compressor;
using System.IO.Compression;

Parser.Default.ParseArguments<Options>(args)
    .WithParsed(RunOptions);

void RunOptions(Options options)
{
    var wordLists = new List<WordList>();

    options.Output ??= Path.GetDirectoryName(options.Source);
    Console.WriteLine($"Compressed files will be output to {options.Output}.");

    if (File.Exists(options.Source))
    {
        using (var reader = new StreamReader(options.Source))
        {
            Console.WriteLine($"Reading {options.Source}...");

            // Read words
            var fileData = reader.ReadToEnd();
            var sourceWords = fileData.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Array.ForEach(sourceWords, word => PutWord(word.Trim().ToLowerInvariant(), wordLists));
        }

        // Write files.
        wordLists.ForEach(wordList =>
        {
            Console.WriteLine($"Writing {wordList.WordLength} letter word file...");
            WriteCompressedFile(wordList, options.Output!);
        });
    }
    else
    {
        Console.WriteLine($"Source file {options.Source} is not a valid file name.");
    }
}

void PutWord(string word, List<WordList> wordLists)
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

void WriteCompressedFile(WordList wordList, string outputPath)
{
    string filePath = Path.Combine(outputPath, $"words{wordList.WordLength}.gz");

    using var compressedFile = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
    using var compressionStream = new GZipStream(compressedFile, CompressionMode.Compress);
    try
    {
        // Convert string data to byte array
        var data = string.Join(" ", [.. wordList]);
        var bytes = new byte[data.Length * sizeof(char)];
        Buffer.BlockCopy(data.ToCharArray(), 0, bytes, 0, bytes.Length);

        // Copy array to compression stream
        using var stream = new MemoryStream(bytes);
        stream.CopyTo(compressionStream);

        Console.WriteLine($"File {filePath} created.");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        Console.WriteLine(ex.StackTrace);
        Console.WriteLine();
    }
}