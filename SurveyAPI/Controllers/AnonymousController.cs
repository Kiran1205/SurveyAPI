using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SurveyAPI.DTOS;
using SurveyAPI.Entities;
using SurveyAPI.Services.Interfaces;

namespace SurveyAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class AnonymousController : ControllerBase
    {

        private IQuestionService _questionService;
        private ISurveyService _surveyService;
        private IQuestionOptionService _optionservice;
        private IMapper _mapper;
        public AnonymousController(IQuestionService questionService,
             IMapper mapper,
            IQuestionOptionService optionService,
            ISurveyService surveyService
            )
        {
            _questionService = questionService;
            _mapper = mapper;
            _optionservice = optionService;
            _surveyService = surveyService;
        }
        [HttpGet("GetSurveInfo")]
        public IActionResult GetSurveInfo(Guid id)
        {
            var survey = _surveyService.GetByUIId(id);
            if (survey == null)
                return BadRequest();

            return Ok(_mapper.Map<SurveyDto>(survey));
        }

        [HttpGet("GetBySurveyQuestionsUID")]
        public IActionResult GetBySurveyQuestionsUID(Guid id)
        {
            List<QuestionsDto> questiondtolist = new List<QuestionsDto>();
            var survey = _surveyService.GetByUIId(id);
            if (survey == null)
                return BadRequest();

            var questionslist = _questionService.GetBySurveyId(survey.Id);
            foreach (var item in questionslist)
            {
                var question = _mapper.Map<QuestionsDto>(item);
                var options = _optionservice.GetByQuestionId(question.Id);
                List<QuestionOptionDto> questionoptdto = new List<QuestionOptionDto>();
                foreach (var questionopt in options)
                {
                    questionoptdto.Add(_mapper.Map<QuestionOptionDto>(questionopt));
                }
                question.Qoptions = questionoptdto;
                questiondtolist.Add(question);
            }
            return Ok(questiondtolist);
        }
    }
}
