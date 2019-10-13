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
    public class SurveyController : ControllerBase
    {
        private ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;

        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]Survey survey)
        {
            if (survey == null)
                return BadRequest(new { message = "Bad request" });

            try
            {
                survey.CreatedOn = DateTime.Now;
                survey.SurveyGuid = Guid.NewGuid();
                var createdsurey = _surveyService.Create(survey);
                return Ok(createdsurey);
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var survey = _surveyService.GetAll();
            return Ok(survey);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var survey = _surveyService.GetById(id);
            return Ok(survey);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Survey survey)
        {

            try
            {
                survey.Id = id;
                _surveyService.Update(survey);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _surveyService.Delete(id);
            return Ok();
        }
    }
}
