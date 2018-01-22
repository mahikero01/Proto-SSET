﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkillsetAPI.Entities;
using SkillsetAPI.Models;
using SkillsetAPI.Services;

namespace SkillsetAPI.Controllers
{
    //[Authorize]
    [EnableCors("AllowWebClient")]
    [Produces("application/json")]
    [Route("api/Associates")]
    public class AssociatesController : Controller
    {
        private ISkillSetRepository _skillSetRepository;

        public AssociatesController(ISkillSetRepository skillSetRepository)
        {
            _skillSetRepository = skillSetRepository;
        }

        // GET: api/Associates
        [HttpGet()]
        public IActionResult GetAssociates()
        {
            var associatesResult = _skillSetRepository.ReadAssociates();

            return Ok(associatesResult);
        }

        //GET: api/Associates/{id}
        [HttpGet("{id}", Name = "GetAssociate")]
        public IActionResult GetAssociate(int id)
        {
            var associateResult = _skillSetRepository.ReadAssociate(id);

            if (associateResult == null)
            {
                return NotFound();
            }

            return Ok(associateResult);
        }

        //POST: api/Associates
        [HttpPost()]
        public IActionResult PostAssociate([FromBody] AssociateForCreateDTO associate)
        {
            if (associate == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAssociateEntity = Mapper.Map<Entities.Associate> (associate);

            _skillSetRepository.CreateAssociate(newAssociateEntity);

            if (!_skillSetRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return CreatedAtRoute("GetAssociate",
                    new { id = newAssociateEntity.AssociateID }, newAssociateEntity);
        }

        //PUT: api/Associates
        [HttpPut("{id}")]
        public IActionResult PutAssociate(int id, [FromBody] AssociateForUpdateDTO associate)
        {
            if (associate == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var associateEntity = _skillSetRepository.ReadAssociate(id);
            if (associateEntity == null)
            {
                return NotFound();
            }

            Mapper.Map(associate, associateEntity);

            if (!_skillSetRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        //DELETE: api/Associates/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAssociate(int id)
        {
            var associateEntity = _skillSetRepository.ReadAssociate(id);
            if (associateEntity == null)
            {
                return NotFound();
            }

            _skillSetRepository.DeleteAssociate(associateEntity);

            if (!_skillSetRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}