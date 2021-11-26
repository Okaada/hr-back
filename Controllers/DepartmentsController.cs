using hr_system_v2.Application.DTOs;
using hr_system_v2.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hr_system_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;
        public DepartmentsController(IDepartmentService service)
        {
            _service = service;
        }


        [HttpPost("create")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            if (departmentDTO == null)
                return BadRequest();

            var department = _service.AddDepartment(departmentDTO);

            return Ok(department);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            try
            {
                _service.UpdateDepartment(departmentDTO, departmentDTO.Id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                _service.DeleteDepartment(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var departments = _service.GetDepartments();
                return Ok(departments);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
