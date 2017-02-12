using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class TimeRecord
    {
        public int TimeRecordID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Comments { get; set; }
    }
}
