﻿using System;
using System.Collections.Generic;

namespace netcore_blueview.Models
{
    public class CrimeReport
    {
        public int CrimeReportId { get; set; }
        
        public string CrimeCode { get; set; }
        public string Location { get; set; }

        public int SpeechRecognitionResponseId { get; set; }
        public SpeechRecognitionResponse SpeechRecognitionResponse { get; set; }
    }
}
