﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace netcore_blueview.Models
{
    public class Alternative
    {
        public int AlternativeId { get; set; }

        public string Transcript { get; set; }
        public float Confidence { get; set; }
        public int Rank { get; set; }

        public int SpeechRecognitionResultId { get; set; }
        public SpeechRecognitionResult SpeechRecognitionResult { get; set; }

        public List<WordInfo> WordInfos { get; set; }
    }
}
