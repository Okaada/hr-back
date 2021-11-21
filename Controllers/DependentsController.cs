using hr_system_v2.Application.DTOs;
using hr_system_v2.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace hr_system_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentsController : BaseController
    {
        private readonly IDependentService _service;
        public DependentsController(IDependentService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateDependent([FromBody] DependentDTO dependentDTO)
        {
            if (dependentDTO == null)
                return BadRequest();

            var dependent = await _service.AddDependent(dependentDTO);

            if (dependent == null)
                return BadRequest();

            return Ok();
        }

        [HttpDelete("remove/{id}")]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveDependent([FromQuery] Guid id)
        {

            try
            {
                _service.DeleteDependent(id);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDependents()
        {
            var dependents = await _service.GetDependents();
            if (dependents.Count == 0)
                return NoContent();

            return Ok(dependents);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDependentById(Guid id)
        {
            var dependents = await _service.GetDependentById(id);
            if (dependents == null)
                return NotFound();

            return Ok(dependents);
        }

        
    }
}
