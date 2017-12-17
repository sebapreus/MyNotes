﻿using MyNotes.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Models
{
    public class Note : GenericModel
    {
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
