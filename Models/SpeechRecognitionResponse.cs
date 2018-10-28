using System;
using System.Collections.Generic;

namespace netcore_blueview.Models
{
    public class SpeechRecognitionResponse
    {
        public int SpeechRecognitionResponseId { get; set; }

        public string AudioUrl { get; set; }
        public DateTime StartTime { get; set; }

        public List<SpeechRecognitionResult> SpeechRecognitionResults { get; set; }
    }
}
