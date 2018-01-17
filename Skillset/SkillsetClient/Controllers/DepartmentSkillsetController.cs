using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkillsetClient.Controllers
{
    [Produces("application/json")]
    [Route("api/DepartmentSkillset")]
    public class DepartmentSkillsetController : Controller
    {
        // GET: api/DepartmentSkillset
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/DepartmentSkillset/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/DepartmentSkillset
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/DepartmentSkillset/5
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
