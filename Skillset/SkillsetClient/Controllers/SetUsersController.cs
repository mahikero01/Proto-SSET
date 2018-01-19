using System;
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
    [Route("api/SetUsers")]
    public class SetUsersController : Controller
    {
        private ApiAccess _webApiAccess;

        public SetUsersController()
        {
            _webApiAccess = new ApiAccess("SetUsers");
        }

        // GET: api/SetUsers
        [HttpGet]
        public async Task<SetUser[]> Get()
        {
            _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
            var result = await _webApiAccess.GetRequest();
            return JsonConvert.DeserializeObject<SetUser[]>(result.ToString());
        }

        // GET: api/SetUsers/5
        [HttpGet("{id}")]
        public async Task<SetUser> Get(string id)
        {
            _webApiAccess.AssignAuthorization(HttpContext.Session.GetString("apiToken"));
            var result = await _webApiAccess.GetRequest();
            return JsonConvert.DeserializeObject<SetUser>(result.ToString());
        }
    }
}
