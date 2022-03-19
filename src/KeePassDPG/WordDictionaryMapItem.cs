using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeePassDPG
{
    internal class WordDictionaryMapItem
    {
        internal int Length { get; set; }
        internal byte[] Data { get; set; }
        public string Description { get; set; }
    }
}
