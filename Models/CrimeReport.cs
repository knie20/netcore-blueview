using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_blueview.Models
{
    public class CrimeReport
    {
        public int CrimeReportId { get; set; }
        
        public string CrimeCode { get; set; }
        public string Location { get; set; }

        public int SpeechRecognitionId { get; set; }
        public SpeechRecognition SpeechRecognition { get; set; }
    }
}
