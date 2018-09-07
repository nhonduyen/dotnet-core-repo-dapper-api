using System;
using System.Collections.Generic;

namespace mydapper.Models
{
    public partial class MboResult
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string PeriodId { get; set; }
        public string Result { get; set; }
        public double? MboSelfScore { get; set; }
        public double? MboM1Score { get; set; }
        public double? MboM2Score { get; set; }
        public double? MboFinalScore { get; set; }
        public double? CapM1 { get; set; }
        public double? CapM2 { get; set; }
        public double? CapFinalScore { get; set; }
        public double? TotalScore { get; set; }
        public string Grade { get; set; }
        public byte? Status { get; set; }
        public byte? PlanStatus { get; set; }
        public byte? M1FinalScore { get; set; }
        public string M1Grade { get; set; }
        public string FinalGrade { get; set; }
        public string Reason { get; set; }
        public string Remark { get; set; }
    }
}
