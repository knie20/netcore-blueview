using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_blueview.Models
{
    public class SpeechRecognitionAlternative
    {
        private string Transcript { get; set; }
        private float Confidence { get; set; }
        private WordInfo[] Words { get; }

        public SpeechRecognitionAlternative(string transcript, float confidence, WordInfo[] words)
        {
            Transcript = transcript ?? throw new ArgumentNullException(nameof(transcript));
            Confidence = confidence;
            Words = words ?? throw new ArgumentNullException(nameof(words));
        }
    }
}
