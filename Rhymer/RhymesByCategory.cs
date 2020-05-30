using System;
using System.Collections.Generic;
using System.Text;

namespace Rhymer
{
    public class RhymesByCategory
    {
        public RhymesByCategory()
        {
            AllRhymes = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> AllRhymes;
    }
}
