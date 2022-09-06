using Hahn.Application.Domain.Entities;
using Hahn.Application.Domain.Interfaces;
using Hahn.Application.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hahn.Application.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        readonly ILogger<CandidateController> _logger;
        readonly ICandidateService _candidateService;
        public CandidateController(ILogger<CandidateController> logger, ICandidateService candidateService)
        {
            _logger = logger;
            _candidateService = candidateService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Candidate>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCandidates()
        {
            try
            {
                var candidates = await _candidateService.GetCandidates();
                return Ok(candidates);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [Route("[action]/{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Candidate))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var candidate = await _candidateService.GetCandidate(id);
                if (candidate == null)
                    return BadRequest($"Could not find any candidate with provided Id");
                return Ok(candidate);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CandidateModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] CandidateModel candidateModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var createResult = await _candidateService.AddCandidate(candidateModel);
                return CreatedAtAction(nameof(Get), new { id = createResult.Id }, createResult);

            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(int id, [FromBody] Candidate candidate)
        {
            try
            {
                var updated = await _candidateService.UpdateCandidate(id, candidate);
                if (!updated)
                    return StatusCode((int)HttpStatusCode.Conflict, "Failed to save updates to candidate ");
                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var toDelete = await _candidateService.DeleteCandidate(id);
                if (!toDelete)
                    return StatusCode((int)HttpStatusCode.Conflict, $"Failed to delete candidate  ");
                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
}
