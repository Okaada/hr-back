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
    public class BenefitsController : ControllerBase
    {
        private readonly IBenefitsTypeService _benefitsTypeService;
        public BenefitsController(IBenefitsTypeService benefitsTypeService)
        {
            _benefitsTypeService = benefitsTypeService;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateBenefits([FromBody] BenefitsTypeDTO benefitsType)
        {
            if (benefitsType == null)
                return BadRequest();

            try
            {
                _benefitsTypeService.CreateBenefit(benefitsType.Name);
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
        public async Task<IActionResult> GetBenefits()
        {

            var benefits = _benefitsTypeService.GetBenefits();

            if (benefits.Count == 0)
                return NoContent();
            
            return Ok(benefits);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (id == null)
                return BadRequest();

            try
            {
                _benefitsTypeService.DeleteBefenit(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBenefit([FromBody] BenefitsTypeDTO dto)
        {
            if (dto.Id == null)
                return BadRequest();

            try
            {
                _benefitsTypeService.UpdateBenefits(dto.Id, dto.Name);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
