using System;
using System.Collections.Generic;

namespace mydapper.Models
{
    public partial class Element
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public string ElementName { get; set; }
    }
}
