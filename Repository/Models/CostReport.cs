using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class CostReport
    {
        public string CustomerName { get; set; }
        public string ProjectName { get; set; }
        public int TotalHours { get; set; }
        public decimal TotalCost { get; set; }
    }
}
