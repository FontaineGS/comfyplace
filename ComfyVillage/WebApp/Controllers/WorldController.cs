using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    public class WorldController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "world";
        }

    }
}
