using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhymer.Parser
{
    public class RhymerSettings : IDownloadSettings
    {
        public RhymerSettings(string word, string type)
        {
            Word = word;
            RhymeType = type;
        }

        public string BaseUrl { get; set; } = "https://rhymer.com/";

        public string RhymeType { get; set; }

        public string Word { get; set; }
    }
}
