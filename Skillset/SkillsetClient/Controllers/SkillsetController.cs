using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillsetClient.Models;

namespace SkillsetClient.Controllers
{
    [Produces("application/json")]
    [Route("api/Skillset")]
    public class SkillsetController : Controller
    {
        // GET: api/Skillset
        //[HttpGet]
        //public IEnumerable<SS_Skillsets> Get()
        //{
        //    return ;
        //}

        // GET: api/Skillset/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Skillset
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Skillset/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
