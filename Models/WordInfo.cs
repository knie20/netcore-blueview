using System;
using System.Collections.Generic;

namespace netcore_blueview.Models
{
    public class WordInfo
    {
        public int WordInfoId { get; set; }

        private double StartTime { get; set; }
        private double EndTime { get; set; }
        private string Word { get; set; }

        public int AlternativeId { get; set; }
        public Alternative Alternative { get; set; }
    }
}
