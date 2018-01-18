using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillsetAPI.Models;
using SkillsetAPI.Services;

namespace SkillsetAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/SetUsers")]
    public class SetUsersController : Controller
    {
        private ISkillSetRepository _skillSetRepository;

        public SetUsersController(ISkillSetRepository skillSetRepository)
        {
            _skillSetRepository = skillSetRepository;        }

        // GET: api/SetUsers
        [HttpGet()]
        public IActionResult GetSetUsers()
        {
            var setUsersEntities = _skillSetRepository.GetSetUsers();
            var results = Mapper.Map<IEnumerable<SetUserDTO>>(setUsersEntities);

            return Ok(results);
        }

        
    }
}
