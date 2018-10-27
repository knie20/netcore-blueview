using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_blueview.Models
{
    public class WordInfo
    {
        private double StartTime { get; set; }
        private double EndTime { get; set; }
        private string Word { get; set; }

        public WordInfo(double startTime, double endTime, string word)
        {
            StartTime = startTime;
            EndTime = endTime;
            Word = word ?? throw new ArgumentNullException(nameof(word));
        }
    }
}
