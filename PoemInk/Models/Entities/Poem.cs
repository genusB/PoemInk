using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoemInk.Models.Entities
{
    public class Poem
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Poet Poet { get; set; }
    }
}
