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
    public class JobOptionController : ControllerBase
    {
        readonly ILogger<JobOptionController> _logger;

        readonly IJobOptionService _jobOptionService;
        public JobOptionController(ILogger<JobOptionController> logger, IJobOptionService jobOptionService)
        {
            _logger = logger;
            _jobOptionService = jobOptionService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<JobOption>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJobOptions()
        {
            try
            {
                var jobOptions = await _jobOptionService.GetJobOptions();
                return Ok(jobOptions);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        [Route("[action]/{id}")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobOption))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetType(int id)
        {
            try
            {
                var jobOption = await _jobOptionService.GetJobOption(id);
                if (jobOption == null)
                    return BadRequest($"Could not find any candidate type with provided Id");
                return Ok(jobOption);
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(JobOption))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] JobOptionModel jobOptionModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var createResult = await _jobOptionService.AddJobOption(jobOptionModel);
                return CreatedAtAction(nameof(GetType), new { id = createResult.Id }, createResult);

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
        public async Task<IActionResult> Put(int id, [FromBody] JobOption jobOption)
        {
            try
            {
                var updated = await _jobOptionService.UpdateJobOption(id, jobOption);
                if (!updated)
                {
                    return StatusCode((int)HttpStatusCode.Conflict, "Failed to save updates to candidate type");

                }

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
                var toDelete = await _jobOptionService.DeleteJobOption(id);
                if (!toDelete)
                    return StatusCode((int)HttpStatusCode.Conflict, $"Failed to delete applicant ");
                return NoContent();
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }
    }
}
