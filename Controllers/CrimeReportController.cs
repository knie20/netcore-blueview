using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace netcore_blueview.Controllers
{
    [Route("api/report/[controller]")]
    [ApiController]
    public class CrimeReportController : Controller
    {
        [HttpGet]
        [Route("/GetReportTable")]
        public void GetReportTable()
        {
            
        }

        [HttpGet]
        [Route("/GetReportDetail/{id}")]
        public void GetReportDetail(int id)
        {

        }
    }
}