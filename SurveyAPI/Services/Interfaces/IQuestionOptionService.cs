using SurveyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services.Interfaces
{
    public interface IQuestionOptionService
    {
        IEnumerable<QuestionOption> GetAll();
        QuestionOption GetById(int id);
        QuestionOption Create(QuestionOption questionOption);
        void Update(QuestionOption questionOption);
        void Delete(int id);
    }
}
