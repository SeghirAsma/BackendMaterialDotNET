using System;
using System.Collections.Generic;
using System.Text;

namespace stockManagement.Data.Models
{
    public class Assignment : Entity
    { 
        public int IdEmployee { get; set; }
        public Employee Employee { get; set; }
        public int IdMaterial { get; set; }
        public Materials Materials { get; set; } 

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
