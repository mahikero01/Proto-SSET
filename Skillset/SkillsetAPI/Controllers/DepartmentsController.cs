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
    [Route("api/Departments")]
    public class DepartmentsController : Controller
    {
        private ISkillSetRepository _skillSetRepository;

        public DepartmentsController(ISkillSetRepository skillSetRepository)
        {
            _skillSetRepository = skillSetRepository;
        }

        // GET: api/Departments
        [HttpGet()]
        public IActionResult GetDepartments()
        {
            var departmentsResult = _skillSetRepository.ReadDepartments();

            return Ok(departmentsResult);
        }

        //GET: api/Departments/{id}
        [HttpGet("{id}", Name = "GetDepartment")]
        public IActionResult GetDepartment(int id)
        {
            var DepartResult = _skillSetRepository.ReadDepartment(id);

            if (DepartResult == null)
            {
                return NotFound();
            }

            return Ok(DepartResult);
        }

        //POST: api/Departments
        [HttpPost()]
        public IActionResult PostDepartment([FromBody] DepartmentForCreateDTO department)
        {
            if (department == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDepartmentEntity = Mapper.Map<Entities.Department>(department);

            newDepartmentEntity.IsActive = true;
            _skillSetRepository.CreateDepartment(newDepartmentEntity);

            if (!_skillSetRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return CreatedAtRoute("GetDepartment",
                    new { id = newDepartmentEntity.DepartmentId }, newDepartmentEntity);
        }

        //PUT: api/Departments
        [HttpPut("{id}")]
        public IActionResult PutDepartment(int id, [FromBody] DepartmentForUpdateDTO department)
        {
            if (department == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var departmentEntity = _skillSetRepository.ReadDepartment(id);
            if (departmentEntity == null)
            {
                return NotFound();
            }

            Mapper.Map(department, departmentEntity);

            if (!_skillSetRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }

        //DELETE: api/Departments/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var departmentEntity = _skillSetRepository.ReadDepartment(id);
            if (departmentEntity == null)
            {
                return NotFound();
            }

            _skillSetRepository.DeleteDepartment(departmentEntity);

            if (!_skillSetRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}