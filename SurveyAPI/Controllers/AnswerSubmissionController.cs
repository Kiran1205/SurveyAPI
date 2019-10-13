using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyAPI.Entities;
using SurveyAPI.Services.Interfaces;

namespace SurveyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AnswerSubmissionController : ControllerBase
    {
        private IAnswerSubmissionService _answerSubmissionService;

        public AnswerSubmissionController(IAnswerSubmissionService answerSubmissionService)
        {
            _answerSubmissionService = answerSubmissionService;

        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]AnswerSubmission questionOption)
        {
            if (questionOption == null)
                return BadRequest(new { message = "Bad request" });

            try
            {
                _answerSubmissionService.Create(questionOption);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
