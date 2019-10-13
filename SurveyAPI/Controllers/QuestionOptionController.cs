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
    public class QuestionOptionController : ControllerBase
    {
        private IQuestionOptionService _questionService;

        public QuestionOptionController(IQuestionOptionService questionService)
        {
            _questionService = questionService;

        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]QuestionOption questionOption)
        {
            if (questionOption == null)
                return BadRequest(new { message = "Bad request" });

            try
            {
                _questionService.Create(questionOption);
                return Ok();
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
            var questionOption = _questionService.GetAll();
            return Ok(questionOption);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var questionOption = _questionService.GetById(id);
            return Ok(questionOption);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]QuestionOption questionOption)
        {

            try
            {
                questionOption.Id = id;
                _questionService.Update(questionOption);
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
            _questionService.Delete(id);
            return Ok();
        }
    }
}
