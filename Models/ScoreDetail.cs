using System;
using System.Collections.Generic;

namespace mydapper.Models
{
    public partial class ScoreDetail
    {
        public int Id { get; set; }
        public int? ResultId { get; set; }
        public int? FactorId { get; set; }
        public double? M1Score { get; set; }
        public double? M2Score { get; set; }
    }
}
