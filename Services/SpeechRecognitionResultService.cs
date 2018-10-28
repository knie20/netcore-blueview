using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netcore_blueview.Models;

namespace netcore_blueview.Services
{
    public class SpeechRecognitionResultService
    {
        public IEnumerable<SpeechRecognitionResult> GetResults(IEnumerable<int> ResponseIds)
        {
            using (var db = new DAO())
            {
                return db.SpeechRecognitionResults
                    .Where(r => db.SpeechRecognitionResults.Any(res => res.SpeechRecognitionResultId == r.SpeechRecognitionResultId))
                    .ToList();
            }
        }
    }
}
