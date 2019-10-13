using SurveyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<Question> GetAll();
        Question GetById(int id);
        Question Create(Question question);
        void Update(Question question);
        void Delete(int id);
    }
}
