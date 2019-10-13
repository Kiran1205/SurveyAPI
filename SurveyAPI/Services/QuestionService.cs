using SurveyAPI.Entities;
using SurveyAPI.Entities.Context;
using SurveyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services
{
    public class QuestionService : IQuestionService
    {
        private DataContext _context;

        public QuestionService(DataContext context)
        {
            _context = context;
        }


        public IEnumerable<Questions> GetAll()
        {
            return _context.Questions;
        }

        public Questions GetById(int id)
        {
            return _context.Questions.Find(id);
        }
        public IEnumerable<Questions> GetBySurveyId(int id)
        {
            return _context.Questions.Where(x => x.SurveyId == id).ToList();
        }

        public Questions Create(Questions question)
        {
            _context.Questions.Add(question);          
            _context.SaveChanges();

            return question;
        }

        public void Update(Questions questionParam)
        {
            var question = _context.Questions.Find(questionParam.Id);

            if (question == null)
                throw new Exception("Question not found");

            question.Ques = questionParam.Ques;
            question.QuestionType = questionParam.QuestionType;
            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                var options = _context.QuestionOptions.Where(x => x.QuestionId == id).ToList();
                foreach (var item in options)
                {
                    _context.QuestionOptions.Remove(item);
                }
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }

    }
}
