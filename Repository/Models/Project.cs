using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string CustomerName { get; set; }
        public int CustomerID { get; set; }
        public decimal CostPerHour { get; set; } // Decimal decause it is Money/Price
    }
}
