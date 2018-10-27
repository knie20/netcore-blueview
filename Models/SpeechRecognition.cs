using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_blueview.Models
{
    public class SpeechRecognition
    {
        public int SpeechRecognitionId { get; set; }
        public string AudioUrl { get; set; }
        public DateTime StartTime { get; set; }

        public List<SpeechRecognitionAlternative> SpeechRecognitionAlternatives { get; set; }
    }
}
