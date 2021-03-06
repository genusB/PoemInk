﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PoemInk.Models.Entities
{
    public class Poem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool PostToInspire { get; set; }
        public string Body { get; set; }
        public Poet Poet { get; set; }
    }
}
