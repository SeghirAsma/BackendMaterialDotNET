using System;
using System.Collections.Generic;
using System.Text;

namespace stockManagement.Data.Models
{
    public class Materials : Entity
    {
        public string Label { get; set; }
        public decimal PurchasePrice { get; set; } //prix d achat
        public DateTime PurchaseDate { get; set; }
        public string Mark { get; set; }
        public string Reference { get; set; }
        public bool IsTaken { get; set; }

        //public int IdAssignment { get; set; }
        public List<Assignment> Assignment { get; set; }

    }
}
