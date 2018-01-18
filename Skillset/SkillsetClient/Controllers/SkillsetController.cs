using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkillsetClient.Models;

namespace SkillsetClient.Controllers
{
    [Produces("application/json")]
    [Route("api/Skillset")]
    public class SkillsetController : Controller
    {
        private WebApiAccess _webApiAccess;
        public SkillsetController()
        {
            _webApiAccess = new WebApiAccess("Skills");
        }
        // GET: api/Skillset
        [Authorize (Roles = "Admin")]
        [HttpGet]
        public async Task<SS_Skillsets[]> Get()
        {
            _webApiAccess._apiToken = HttpContext.Session.GetString("apiToken");
            var skillsets = await _webApiAccess.GetRequest();
            return  JsonConvert.DeserializeObject<SS_Skillsets[]>(skillsets.ToString());
        }

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
