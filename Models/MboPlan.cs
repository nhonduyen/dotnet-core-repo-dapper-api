using System;
using System.Collections.Generic;

namespace mydapper.Models
{
    public partial class MboPlan
    {
        public int Id { get; set; }
        public string Cont { get; set; }
        public string ActionPlan { get; set; }
        public string Target { get; set; }
        public byte? Weight { get; set; }
        public string Lvl { get; set; }
        public string Action { get; set; }
        public string Result { get; set; }
        public int? ResultId { get; set; }
        public int? MboSelfRate { get; set; }
        public int? MboM1Rate { get; set; }
        public int? MboM2Rate { get; set; }
    }
}
