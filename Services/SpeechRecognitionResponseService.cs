using System;
using System.Collections.Generic;
using netcore_blueview.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_blueview.Services
{
    public class SpeechRecognitionResponseService
    {
        public IEnumerable<SpeechRecognitionResponse> SearchResponses(DateTime? timeFrom, DateTime? timeTo, int pageSize = 0, int pageIndex = 0)
        {
            using (var db = new DAO())
            {
                var responses = from r in db.SpeechRecognitionResponses select r;

                if (timeFrom != null)
                {
                    responses.Where(r => r.StartTime >= timeFrom);
                }

                if (timeTo != null)
                {
                    responses.Where(r => r.StartTime <= timeTo);
                }

                if (pageSize != 0 && pageIndex != 0)
                {
                    responses.Skip(pageSize * pageIndex).Take(pageSize);
                }

                if (pageSize == 0 || pageIndex == 0)
                {
                    responses.Take(500);
                }

                    return responses.ToList();

            }
        }

        public SpeechRecognitionResponse GetResponseById(int id)
        {
            using(var db = new DAO())
            {
                return db.SpeechRecognitionResponses
                    .Include(res => res.SpeechRecognitionResults)
                    .Single(r => r.SpeechRecognitionResponseId == id);
            }
        }
    }
}
