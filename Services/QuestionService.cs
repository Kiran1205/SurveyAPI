using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAll();
        Question GetById(int id);
        Question Create(Question question);
        void Update(Question question);
        void Delete(int id);
    }

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
                throw new AppException("Question not found");
            
            question.QuestionTitle = questionParam.QuestionTitle;
            question.QuestionDetails = questionParam.QuestionDetails;

            _context.Questions.Update(question);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var question = _context.Questions.Find(id);
            if (question != null)
            {
                question.Deleted = true;
                _context.Questions.Update(question);
                _context.SaveChanges();
            }
        }

    }
}