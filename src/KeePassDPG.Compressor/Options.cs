using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeePassDPG.Compressor
{
    internal class Options
    {
        [Option('s', "source", Required = true, HelpText = "Source file name.")]
        public string? Source { get; set; }

        [Option('o', "output", Required = false, HelpText = "Output path.")]
        public string? Output { get; set; }
    }
}
