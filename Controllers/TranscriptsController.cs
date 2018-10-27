using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netcore_blueview.Controllers
{
    [Route("api/transcript/[controller]")]
    [ApiController]
    public class TranscriptsController : Controller
    {
        // GET: /api/transcript/all
        public IActionResult Index()
        {
            return View();
        }
    }
}
