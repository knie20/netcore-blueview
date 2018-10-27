using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_blueview.Models
{
    public class SpeechRecognitionAlternative
    {
        public int SpeechRecognitionAlternativeId { get; set; }
        public string Transcript { get; set; }
        private float Confidence { get; set; }

        public int SpeechRecognitionId { get; set; }
        public SpeechRecognition SpeechRecognition { get; set; }

        public List<WordInfo> WordInfos { get; set; }
    }
}
