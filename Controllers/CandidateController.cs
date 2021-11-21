using hr_system_v2.Application.DTOs;
using hr_system_v2.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class CandidateController : BaseController
    {
        private readonly ICandidateService _service;

        public CandidateController(ICandidateService service)
        {
            _service = service;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCandidate([FromBody] CanditateDTO model)
        {
            if (model.Equals(null))
                return BadRequest();

            var candidate = await _service.CreateCandidate(model);

            return Ok(candidate);
        }

        [HttpGet]
        [Route("candidates")]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCandidates()
        {

            var candidates = await _service.GetCandidates();
            if (candidates.Count == 0)
                return NotFound();
            
            return Ok(candidates);
        }

        [HttpGet]
        [Route("candidate/{id}")]
        [ProducesResponseType(typeof(StatusCodeResult), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCandidateById([FromQuery] Guid id)
        {
            var candidate = await _service.GetCandidateDetail(id);
            if (candidate.Equals(null))
                return NotFound();

            return Ok(candidate);
        }
    }
}
