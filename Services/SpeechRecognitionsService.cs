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
            SpeechRecognitionResponse sr_response = new SpeechRecognitionResponse();

            using (var db = new DAO())
            {

                var objects = JObject.Parse(value);
                IEnumerator<KeyValuePair<string, JToken>> objectsEnum = objects.GetEnumerator();
                foreach (JObject result in objectsEnum.Current.Value) {
                    SpeechRecognitionResult sr_result = new SpeechRecognitionResult();
                    sr_response.SpeechRecognitionResults.Add(sr_result);
                    IEnumerator<KeyValuePair<string, JToken>> resultEnum = result.GetEnumerator();
                    int rank = 0;
                    foreach (JObject alternative in resultEnum.Current.Value) {
                        Alternative sr_alternative = new Alternative();
                        sr_alternative.Transcript = (string) alternative["transcript"];
                        sr_alternative.Confidence = (float) alternative["confidence"];
                        sr_alternative.Rank = rank;
                        db.Alternatives.Add(sr_alternative);

                        rank++;
                    }
                    db.SpeechRecognitionResults.Add(sr_result);
                }

                objectsEnum.MoveNext();
                sr_response.AudioUrl = (string) objectsEnum.Current.Value;

                objectsEnum.MoveNext();
                sr_response.StartTime = (DateTime) objectsEnum.Current.Value;

                db.SpeechRecognitionResponses.Add(sr_response);

            }
        }
    }
}
