using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillsetAPI.Models;
using SkillsetAPI.Services;

namespace SkillsetAPI.Controllers
{
    [Authorize]
    [EnableCors("AllowWebClient")]
    [Produces("application/json")]
    [Route("api/SetGroups")]
    public class SetGroupsController : Controller
    {
        private ISkillSetRepository _skillSetRepository;

        public SetGroupsController(ISkillSetRepository skillSetRepository)
        {
            _skillSetRepository = skillSetRepository;
        }

        // GET: api/SetGroups
        [HttpGet()]
        public IActionResult GetSetGroups()
        {
            var setGroupsEntities = _skillSetRepository.ReadSetGroups();
            var results = Mapper.Map<IEnumerable<SetGroupDTO>>(setGroupsEntities);

            return Ok(results);
        }

        //GET: api/SetGroups/{id}
        [HttpGet("{id}")]
        public IActionResult GetSetGroup(string id)
        {
            var setGroup = _skillSetRepository.ReadSetGroup(id);

            if (setGroup == null)
            {
                return NotFound();
            }

            var setGroupResult = Mapper.Map<SetGroupDTO>(setGroup);

            return Ok(setGroupResult);
        }
    }
}