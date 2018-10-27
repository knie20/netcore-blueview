using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_blueview.Models
{
    public class CrimeReport
    {
        public int ReportID { get; set; }
        public DateTime StartTime { get; set; }
        public string CrimeCode { get; set; }
        public string Location { get; set; }
        public string AudioUrl { get; set; }
        public string Transcript { get; set; }
    }
}
