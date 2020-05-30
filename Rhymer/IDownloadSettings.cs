using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhymer
{
    public interface IDownloadSettings
    {
        string BaseUrl { get; set; }

        string RhymeType { get; set; }

        string Word { get; set; }
    }
}
