using SurveyAPI.Entities;
using SurveyAPI.Entities.Context;
using SurveyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services
{
    public class SurveyService : ISurveyService
    {
        private IDataContext _context;

        public SurveyService(IDataContext context)
        {
            _context = context;
        }


        public IEnumerable<Survey> GetAll(int userID)
        {
            return _context.Survey.Where(x => x.OwnerId == userID && x.Deleted == false).OrderByDescending(x => x.CreatedOn).ToList();
        }

        public Survey GetById(int id)
        {
            return _context.Survey.Find(id);
        }
        public Survey GetByUIId(Guid id)
        {
            return _context.Survey.Where(x => x.SurveyGuid == id && x.Deleted == false && x.ExpDate >= DateTime.Now && x.IsLive == true).FirstOrDefault();
        }
        public Survey GetBySurveyId(int id)
        {
            return _context.Survey.Where(x => x.Id == id && x.Deleted == false && x.ExpDate >= DateTime.Now && x.IsLive == true).FirstOrDefault();
        }

        public Survey Create(Survey survey)
        {
            _context.Survey.Add(survey);
            _context.SaveChanges();

            return survey;
        }

        public void Update(Survey surveyParam)
        {
            var survey = _context.Survey.Find(surveyParam.Id);

            if (survey == null)
                throw new Exception("Survey not found");

            survey.SurveyName = surveyParam.SurveyName;
            survey.SurveyDesc = surveyParam.SurveyDesc;

            _context.Survey.Update(survey);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var survey = _context.Survey.Find(id);
            if (survey != null)
            {
                survey.Deleted = true;
                _context.Survey.Update(survey);
                _context.SaveChanges();
            }
        }

    }
}
