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


        public IEnumerable<Question> GetAll()
        {
            return _context.Questions;
        }

        public Question GetById(int id)
        {
            return _context.Questions.Find(id);
        }

        public Question Create(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();

            return question;
        }

        public void Update(Question questionParam)
        {
            var question = _context.Questions.Find(questionParam.Id);

            if (question == null)
                throw new Exception("Question not found");

            question.Ques = questionParam.Ques;
            question.TypeId = questionParam.TypeId;
            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }

    }
}
