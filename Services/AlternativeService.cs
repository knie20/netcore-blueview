using System;
using System.Collections.Generic;
using netcore_blueview.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace netcore_blueview.Services
{
    public class AlternativeService
    {
        public IEnumerable<Alternative> SearchAlternatives(string transcript, IList<int> resultIds, float minCconfidence = -1)
        {
            using (var db = new DAO())
            {
                var alts = from a in db.Alternatives select a;

                if (!String.IsNullOrEmpty(transcript))
                {
                    alts.Where(a => a.Transcript.Contains(transcript));
                }

                if (minCconfidence > 1 && minCconfidence < 0)
                {
                    alts.Where(a => a.Confidence >= minCconfidence);
                }

                if (resultIds.Count() != 0)
                {
                    alts
                    .Where(a => db.Alternatives.Any(alt => alt.AlternativeId == a.AlternativeId));
                }

                return alts.ToList();

            }
        }

        public IEnumerable<Alternative> GetAlternativesByResult(int resultId)
        {
            using (var db = new DAO())
            {
                return db.Alternatives
                    .Include(a => a.WordInfos)
                    .Where(a => a.SpeechRecognitionResultId == resultId).ToList();
            }
        }


        public Alternative GetAlternativeById(int id)
        {
            using (var db = new DAO())
            {
                return db.Alternatives.Single(r => r.AlternativeId == id);
            }
        }
    }
}
