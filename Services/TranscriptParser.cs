using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netcore_blueview.Services
{
    public class TranscriptData {
        public string code;
        public string location;
    }

    public class TranscriptParser
    {
        public TranscriptData Parse(String transcript) {
            TranscriptData data = new TranscriptData();
            string transcriptNoCase = transcript.ToLower();
            string[] words = transcriptNoCase.Split(new char[] { ' ', '-', ':' });
            for (int i = 0; i < words.Length; i++) {
                if(words[i].Equals("10") || words[i].Equals("ten") && i != words.Length - 1)
                {
                    switch (words[i + 1]) {
                        case "32":
                            data.code = "";
                            break;
                        default:
                            break;
                    }
                }
            }
            return data;
        }

    }
}
