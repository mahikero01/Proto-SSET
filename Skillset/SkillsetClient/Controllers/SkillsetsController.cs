﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkillsetClient.Models;

namespace SkillsetClient.Controllers
{
    [Produces("application/json")]
    [Route("api/Skillsets")]
    public class SkillsetsController : Controller
    {
        // GET: api/Skillsets
        private WebApiAccess _webApiAccess;
        public SkillsetsController()
        {
            _webApiAccess = new WebApiAccess("Skills");
        }
        // GET: api/Skillset
        [HttpGet]
        public async Task<SS_Skillsets[]> Get()
        {
            _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
            var skillsets = await _webApiAccess.GetRequest();
            return JsonConvert.DeserializeObject<SS_Skillsets[]>(skillsets.ToString());
        }

        // GET: api/Skillset/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<SS_Skillsets> Get(int id)
        {
            _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
            var skillsets = await _webApiAccess.GetRequest();
            return JsonConvert.DeserializeObject<SS_Skillsets>(skillsets.ToString());
        }

        // POST: api/Skillset
        [HttpPost]
        public async Task<SS_Skillsets> Post([FromBody]SS_Skillsets skillset)
        {
            _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
            var content = JsonConvert.SerializeObject(skillset);

            var skillsets = await _webApiAccess.PostRequest(content);
            return JsonConvert.DeserializeObject<SS_Skillsets>(skillsets.ToString());
        }

        // PUT: api/Skillset/5
        [HttpPut("{id}")]
        public async Task<SS_Skillsets> Put(int id, [FromBody]SS_Skillsets skillset)
        {
            _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
            var content = JsonConvert.SerializeObject(skillset);

            var skillsets = await _webApiAccess.PutRequest(id.ToString(), content);
            return JsonConvert.DeserializeObject<SS_Skillsets>(skillsets.ToString());
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));

            var skillsets = await _webApiAccess.DeleteRequest(id.ToString());
            return skillsets;
        }
    }
}
