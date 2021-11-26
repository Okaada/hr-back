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
        //private readonly IContractBene _benefitsTypeService;
        public BenefitsController(IBenefitsTypeService benefitsTypeService)
        {
            _benefitsTypeService = benefitsTypeService;
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateBenefits([FromBody] string benefitName)
        {
            if (benefitName == null)
                return BadRequest();

            try
            {
                _benefitsTypeService.CreateBenefit(benefitName);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpDelete("delete/{id}")]
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
        public async Task<IActionResult> DeleteDepartment(int id, [FromBody] string newName)
        {
            if (id == null)
                return BadRequest();

            try
            {
                _benefitsTypeService.UpdateBenefits(id, newName);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

    }
}
