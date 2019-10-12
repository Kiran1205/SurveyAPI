using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Dtos;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private IQuestionService _questionService;

        public QuestionController( IQuestionService questionService )
        {
            _questionService = questionService;
            
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]Question questions)
        {
            if (questions == null)
                return BadRequest(new { message = "Bad request" });

            try
            {
                _questionService.Create(questions);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            var questions =  _questionService.GetAll();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var questions = _questionService.GetById(id);
            return Ok(questions);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Question questions)
        {

            try 
            {
                questions.Id = id;
                _questionService.Update(questions);
                return Ok();
            } 
            catch(AppException ex)
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
