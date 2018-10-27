using System;
using netcore_blueview.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcore_blueview.Controllers
{
    

    [Route("api/speech/[controller]")]
    [ApiController]
    public class SpeechRecognitionsController : Controller
    {
        SpeechRecognitionsService service = new SpeechRecognitionsService();

        // POST: api/<controller>
        [HttpPost]
        public IActionResult AddSpeech([FromBody]string value)
        {
            try
            {
                service.addSpeech();
            } catch (Exception ex)
            {
                return NotFound();
            }
            return Ok(value);
        }



        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
