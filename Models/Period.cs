using System;
using System.Collections.Generic;

namespace mydapper.Models
{
    public partial class Period
    {
        public string EvaTime { get; set; }
        public DateTime? EvaStart { get; set; }
        public DateTime? EvaEnd { get; set; }
        public byte? Status { get; set; }
        public byte? SetMbo { get; set; }
    }
}
