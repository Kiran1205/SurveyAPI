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
        private IAnonymousUserService _anonymousUserService;
        private IAnswerSubmissionService _answerSubmissionService;
        private IMapper _mapper;
        public AnonymousController(IQuestionService questionService,
             IMapper mapper,
            IQuestionOptionService optionService,
            ISurveyService surveyService,
            IAnonymousUserService anonymousUserService,
            IAnswerSubmissionService answerSubmissionService
            )
        {
            _questionService = questionService;
            _mapper = mapper;
            _optionservice = optionService;
            _surveyService = surveyService;
            _anonymousUserService = anonymousUserService;
            _answerSubmissionService = answerSubmissionService;
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

        [HttpPost("SaveSurvey")]
        public IActionResult Save([FromBody] List<QuestionsDto> ListQuestionsDto)
        {
            if (ListQuestionsDto == null)
                return BadRequest();

            var anonymousUser = _anonymousUserService.Create(new AnonymousUser()
            {
                SurveyID = ListQuestionsDto[0].SurveyId,
                CreatedOn = DateTime.Now
            });

            foreach (var questionsubmitted in ListQuestionsDto)
            {
                foreach (var item in questionsubmitted.Qoptions)
                {
                    var answersubmitted = _mapper.Map<AnswerSubmission>(item);
                    answersubmitted.AnonymouseUserID = anonymousUser.Id;
                    _answerSubmissionService.Create(answersubmitted);
                }
               
            }
            return Ok();
        }
    }
}
