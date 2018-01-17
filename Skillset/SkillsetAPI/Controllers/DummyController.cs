using Microsoft.AspNetCore.Mvc;
using SkillsetAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsetAPI.Controllers
{
    //Use this controller only for creating databse via migration and testing
    public class DummyController : Controller
    {
        private SkillSetContext _ctx;

        public DummyController(SkillSetContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testctx")]
        public IActionResult TestCTX()
        {
            return Ok();
        }
    }
}
