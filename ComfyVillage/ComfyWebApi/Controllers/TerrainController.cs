using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComfyWebApi.Models;
using AgentUtitilies;
using TerrainUtilities;
using Microsoft.EntityFrameworkCore;

namespace ComfyWebApi.Controllers
{
    [Route("terrain/[controller]")]
    [ApiController]
    public class TerrainController : ControllerBase
    {

        private readonly VillageContext _context;

        public TerrainController(VillageContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<Terrain> Get()
        {
            return _context.Terrain.FirstOrDefault();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
