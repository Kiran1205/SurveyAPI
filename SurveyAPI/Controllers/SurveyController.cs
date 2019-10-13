using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyAPI.DTOS;
using SurveyAPI.Entities;
using SurveyAPI.Repositories;
using SurveyAPI.Services.Interfaces;

namespace SurveyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
        private ISurveyService _surveyService;
        private IMapper _mapper;
        private CommonRepository _commonRepository;
        public SurveyController(ISurveyService surveyService, IMapper mapper,
            CommonRepository commonRepository)
        {
            _surveyService = surveyService;
            _mapper = mapper;
            _commonRepository = commonRepository;
        }

        [HttpGet("GetSurveyLink")]
        public IActionResult GetSurveyLink(int id)
        {
            var survey = _surveyService.GetById(id);
            survey.IsLive = true;
            _surveyService.Update(survey);
            return Ok(_mapper.Map<SurveyDto>(survey));
        }
        
        [HttpGet("GetStatistics")]
        public IActionResult GetStatistics(int userid)
        {
            var data = _commonRepository.getStatisticsData(userid);
            return Ok(data);
        }
        [HttpGet("GetSurveyByID")]
        public IActionResult GetSurveyByID(int surveyid)
        {
            var data = _surveyService.GetById(surveyid);
            return Ok(_mapper.Map<SurveyDto>(data));
        }
        [HttpGet("GetLastTwoSurvey")]
        public IActionResult GetLastTwoSurvey(int userid)
        {
            var data = _surveyService.GetAll(userid).Take(2);
            return Ok(data);
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody]SurveyDto surveyDto)
        {
            if (surveyDto == null)
                return BadRequest(new { message = "Bad request" });

            try
            {
                var survey = _mapper.Map<Survey>(surveyDto);
                survey.CreatedOn = DateTime.Now;
                survey.SurveyGuid = Guid.NewGuid();
                _surveyService.Create(survey);
                return Ok(_mapper.Map<SurveyDto>(survey));
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("{id}")]
        [HttpGet("GetUserAllSurvey")]
        public IActionResult GetUserAllSurvey(int userid)
        {
            var survey = _surveyService.GetAll(userid);
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
