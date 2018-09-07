using System;
using System.Collections.Generic;

namespace mydapper.Models
{
    public partial class EmpApprover
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Approver { get; set; }
        public byte? Role { get; set; }
    }
}
