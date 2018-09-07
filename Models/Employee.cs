using System;
using System.Collections.Generic;

namespace mydapper.Models
{
    public class Employee
    {
        public string Emp_Id { get; set; }
        public string Name { get; set; }
        public string Workgroup { get; set; }
        public DateTime? Enter_Date { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public byte? Eva_Group { get; set; }
    }
}
