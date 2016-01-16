using System.Collections.Generic;

namespace KeePassDPG.Compressor
{
    /// <summary>
    /// A list of words of a specific length.
    /// </summary>
    public class WordList : List<string>
    {
        /// <summary>
        /// Gets or sets the word length.
        /// </summary>
        public int WordLength { get; set; }
    }
}
