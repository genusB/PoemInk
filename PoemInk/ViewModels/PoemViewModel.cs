using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoemInk.ViewModels
{
    public class PoemViewModel
    {
        public string Title { get; set; }
        public bool PostToInspire { get; set; }
        public string Body { get; set; }
    }
}
