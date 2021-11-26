using hr_system_v2.Application.DTOs;
using hr_system_v2.Application.Services.Interfaces;
using hr_system_v2.Infrastructure.Models;
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
    public class EmployeesController : BaseController
    {
        private readonly IContractService _contractService;
        private readonly IPersonService _personService;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IContractService contractService, IPersonService personService, IEmployeeService employeeService)
        {
            _contractService = contractService ?? throw new ArgumentNullException(nameof(contractService));
            _personService = personService ?? throw new ArgumentNullException(nameof(personService));
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(employeeService));
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateEmployee([FromBody] NewEmployeeDTO newEmployeeDTO)
        {
            if (newEmployeeDTO.PersonDTO == null || newEmployeeDTO.ContractDTO == null)
                return BadRequest();

            var person = await _personService.CreatePerson(newEmployeeDTO.PersonDTO);
            var contract = await _contractService.CreateContract(newEmployeeDTO.ContractDTO);
            var employee = await _employeeService.CreateEmployee(contract, person);

            if (employee == null)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();

            if (employees == null)
                return NoContent();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetEmployees(Guid id)
        {
            var employee = await _employeeService.GetEmployeesById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPut("desactivate/{id}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DesactivateEmployee(Guid id)
        {
            try
            {
                _employeeService.DesactivateEmployee(id);
                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
