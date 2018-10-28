using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netcore_blueview.Models;
using Newtonsoft.Json.Linq;

namespace netcore_blueview.Services
{
    public class SpeechRecognitionsService
    {
        public void AddSpeech(string value) {
            SpeechRecognitionResponse _response = new SpeechRecognitionResponse();
            _response.SpeechRecognitionResults = new List<SpeechRecognitionResult>();
            SpeechRecognitionResult _result;
            Alternative _alternative;

            using (var db = new DAO())
            {
                int rank = 1;

                var response = JObject.Parse(value);
                JArray results = response.Value<JArray>("results");
                foreach (JObject result in results) {
                    _result = new SpeechRecognitionResult();
                    _result.Alternatives = new List<Alternative>();
                    JArray alternatives = result.Value<JArray>("alternatives");
                    foreach (JObject alternative in alternatives) {
                        _alternative = new Alternative();
                        _alternative.Transcript = (string) alternative["transcript"];
                        _alternative.Confidence = (float) alternative["confidence"];
                        _alternative.Rank = rank;
                        db.Alternatives.Add(_alternative);
                        _result.Alternatives.Add(_alternative);

                        rank++;
                    }
                    db.SpeechRecognitionResults.Add(_result);
                    _response.SpeechRecognitionResults.Add(_result);
                }
                
                if(String.IsNullOrEmpty(response["timeStamp"].ToString())){
                    _response.StartTime = response.Value<DateTime>("timeStamp");
                }
                
                if(String.IsNullOrEmpty(response["audioUrl"].ToString())){
                    _response.AudioUrl = response.Value<string>("audioUrl");
                }

                db.SpeechRecognitionResponses.Add(_response);

                db.SaveChanges();
            }
        }
    }
}
