using System;
using System.Collections.Generic;
using System.Text;

namespace stockManagement.Data.Models
{
    public class Employee : Entity
    {
        public string Cin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Function { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        //public int IdAssignment { get; set; }
        public List<Assignment> Assignment { get; set; }
    }
}
