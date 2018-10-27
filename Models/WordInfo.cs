using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_blueview.Models
{
    public class WordInfo
    {
        public int WordInfoId { get; set; }
        private double StartTime { get; set; }
        private double EndTime { get; set; }
        private string Word { get; set; }

        public int SpeechRecognitionAlternativeId { get; set; }
        public SpeechRecognitionAlternative SpeechRecognitionAlternative { get; set; }
    }
}
