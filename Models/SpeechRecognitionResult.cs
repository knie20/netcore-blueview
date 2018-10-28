using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace netcore_blueview.Models
{
    public class SpeechRecognitionResult
    {
        public int SpeechRecognitionResultId { get; set; }

        public int SpeechRecognitionResponseId { get; set; }
        public SpeechRecognitionResponse SpeechRecognitionResponse { get; set; }

        public List<Alternative> Alternatives { get; set; }
    }
}
