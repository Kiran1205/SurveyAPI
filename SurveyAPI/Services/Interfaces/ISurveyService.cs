using SurveyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services.Interfaces
{
    public interface ISurveyService
    {
        IEnumerable<Survey> GetAll(int userid);
        Survey GetById(int id);
        Survey Create(Survey survey);
        void Update(Survey survey);
        void Delete(int id);
        Survey GetByUIId(Guid id);
    }
}
