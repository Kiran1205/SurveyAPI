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
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private IQuestionService _questionService;
        private IQuestionOptionService _optionservice;
        private IMapper _mapper;
        public QuestionController(IQuestionService questionService,
             IMapper mapper,
            IQuestionOptionService optionService)
        {
            _questionService = questionService;
            _mapper = mapper;
            _optionservice = optionService;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]QuestionsDto questionsdto)
        {
            if (questionsdto == null)
                return BadRequest(new { message = "Bad request" });

            try
            {
                // map dto to entity
                var question = _mapper.Map<Questions>(questionsdto);
                question.CreatedOn = DateTime.Now;
                _questionService.Create(question);
                var questionoptions = questionsdto.Qoptions;
                foreach (var item in questionoptions)
                {
                    var option = _mapper.Map<QuestionOption>(item);
                    option.CreatedOn = DateTime.Now;
                    option.QuestionId = question.Id;
                    _optionservice.Create(option);
                }
                
                var questionResult = _mapper.Map<QuestionsDto>(question);
                var options = _optionservice.GetByQuestionId(question.Id);
                List<QuestionOptionDto> questionoptdto = new List<QuestionOptionDto>();
                foreach (var questionopt in options)
                {
                    questionoptdto.Add(_mapper.Map<QuestionOptionDto>(questionopt));
                }
                questionResult.Qoptions = questionoptdto;
                return Ok(questionResult);
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
            var questions = _questionService.GetAll();
            return Ok(questions);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id)
        //{
        //    var questions = _questionService.GetById(id);
        //    return Ok(questions);
        //}
        [HttpGet("{id}")]
        public IActionResult GetBySurveyId(int id)
        {
            List<QuestionsDto> questiondtolist = new List<QuestionsDto>();
            var questionslist = _questionService.GetBySurveyId(id);
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

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]Questions questions)
        {

            try
            {
                questions.Id = id;
                _questionService.Update(questions);
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
