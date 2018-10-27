using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_blueview.Models
{
    public class SpeechRecognition
    {
        private SpeechRecognitionAlternative[] Alternatives { get; }
        private string AudioUrl { get; set; }

        public SpeechRecognition(SpeechRecognitionAlternative[] alternatives, string audioUrl)
        {
            Alternatives = alternatives ?? throw new ArgumentNullException(nameof(alternatives));
            AudioUrl = audioUrl ?? throw new ArgumentNullException(nameof(audioUrl));
        }

        public SpeechRecognitionAlternative getAlternative(int rank)
        {
            return this.Alternatives[rank];
        }
    }
}
