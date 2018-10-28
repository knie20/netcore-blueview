using System;
using System.Collections.Generic;
using netcore_blueview.Services;
using netcore_blueview.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcore_blueview.Controllers
{
    

    [Route("api/speech")]
    [ApiController]
    public class SpeechRecognitionsController : Controller
    {
        private SpeechRecognitionsService service = new SpeechRecognitionsService();
        private SpeechRecognitionResponseService SpeechRecognitionResponseService = new SpeechRecognitionResponseService();
        private SpeechRecognitionResultService SpeechRecognitionResultService = new SpeechRecognitionResultService();
        private AlternativeService AlternativeService = new AlternativeService();


        // POST: api/speech/
        [HttpPost]
        public IActionResult AddSpeech([FromBody]string value)
        {
            try
            {
                service.AddSpeech(value);
            } catch (Exception ex)
            {
                return NotFound();
            }
            return Ok("Successfully added Speech");
        }

        //GET: api/speech/:id
        [HttpGet("{id}")]
        public SpeechRecognitionResponse getResponseDetails(int id)
        {
            var response = SpeechRecognitionResponseService.GetResponseById(id);
            foreach (SpeechRecognitionResult result in response.SpeechRecognitionResults)
            {
                result.Alternatives = (List<Alternative>) AlternativeService.GetAlternativesByResult(result.SpeechRecognitionResultId);
            }

            return response;
        }


        // GET: api/speech/all
        [HttpGet("all")]
        public IEnumerable<SpeechRecognitionResponse> SearchResponses(
            [FromQuery]DateTime timeFrom, 
            [FromQuery]DateTime timeTo, 
            [FromQuery]string transcript, 
            [FromQuery]float minConfidence, 
            [FromQuery]int pageSize, 
            [FromQuery]int pageIndex
            )
        {
            var responses = SpeechRecognitionResponseService.SearchResponses(timeFrom, timeTo, pageSize, pageIndex);

            List<int> responseIds = new List<int>();
            foreach (SpeechRecognitionResponse response in responses)
            {
                responseIds.Add(response.SpeechRecognitionResponseId);
            }

            var results = SpeechRecognitionResultService.GetResults(responseIds);

            List<int> resultIds = new List<int>();
            foreach (SpeechRecognitionResult result in results)
            {
                resultIds.Add(result.SpeechRecognitionResultId);
            }

            var alternatives = AlternativeService.SearchAlternatives(transcript, resultIds, minConfidence);

            foreach (SpeechRecognitionResponse response in responses)
            {
                foreach (SpeechRecognitionResult result in results)
                {
                    if(response.SpeechRecognitionResponseId == result.SpeechRecognitionResponseId)
                    {
                        response.SpeechRecognitionResults.Add(result);
                        foreach (Alternative alternative in alternatives)
                        {
                            if(result.SpeechRecognitionResultId == alternative.SpeechRecognitionResultId)
                            {
                                result.Alternatives.Add(alternative);
                            }
                        }
                    }
                }
            }

            return responses;
        }

    }
}
