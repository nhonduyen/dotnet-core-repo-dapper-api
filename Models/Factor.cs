using System;
using System.Collections.Generic;

namespace mydapper.Models
{
    public partial class Factor
    {
        public int Id { get; set; }
        public string FactorName { get; set; }
        public int? ElementId { get; set; }
        public double? Weight { get; set; }
    }
}
