using SurveyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<Questions> GetAll();
        Questions GetById(int id);
        Questions Create(Questions question);
        void Update(Questions question);
        void Delete(int id);
        IEnumerable<Questions> GetBySurveyId(int id);
        int QuestionCountBySurvey(int surveyId);
    }
}
