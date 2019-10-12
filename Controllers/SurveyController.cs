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
    public class SurveyController : ControllerBase
    {
        private ISurveyService _surveyService;

        public SurveyController( ISurveyService surveyService )
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
                _surveyService.Create(survey);
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
            var survey =  _surveyService.GetAll();
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
            catch(AppException ex)
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
