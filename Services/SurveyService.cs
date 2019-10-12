using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface ISurveyService
    {
        IEnumerable<Survey> GetAll();
        Survey GetById(int id);
        Survey Create(Survey survey);
        void Update(Survey survey);
        void Delete(int id);
    }

    public class SurveyService : ISurveyService
    {
        private DataContext _context;

        public SurveyService(DataContext context)
        {
            _context = context;
        }

        
        public IEnumerable<Survey> GetAll()
        {
            return _context.Survey;
        }

        public Survey GetById(int id)
        {
            return _context.Survey.Find(id);
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
                throw new AppException("Survey not found");
            
            survey.SurveyName = surveyParam.SurveyName;
            survey.SurveyDesc = surveyParam.SurveyName;

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