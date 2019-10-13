using SurveyAPI.Entities;
using SurveyAPI.Entities.Context;
using SurveyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services
{
    public class QuestionOptionService : IQuestionOptionService
    {
        private DataContext _context;

        public QuestionOptionService(DataContext context)
        {
            _context = context;
        }


        public IEnumerable<QuestionOption> GetAll()
        {
            return _context.QuestionOptions;
        }

        public QuestionOption GetById(int id)
        {
            return _context.QuestionOptions.Find(id);
        }
        public IEnumerable<QuestionOption> GetByQuestionId(int id)
        {
            return _context.QuestionOptions.Where(x => x.QuestionId == id).ToList();
        }

        public QuestionOption Create(QuestionOption question)
        {
            _context.QuestionOptions.Add(question);
            _context.SaveChanges();

            return question;
        }

        public void Update(QuestionOption questionOptionParam)
        {
            var questionOption = _context.QuestionOptions.Find(questionOptionParam.Id);

            if (questionOption == null)
                throw new Exception("QuestionOption not found");

            questionOption.OptionDetail = questionOptionParam.OptionDetail;
            questionOption.QuestionId = questionOptionParam.QuestionId;

            _context.QuestionOptions.Update(questionOption);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var question = _context.QuestionOptions.Find(id);
            if (question != null)
            {
                _context.QuestionOptions.Remove(question);
                _context.SaveChanges();
            }
        }

    }
}
