using SurveyAPI.Entities;
using SurveyAPI.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services.Interfaces
{
    public class AnonymousUserService : IAnonymousUserService
    {
        private IDataContext _context;

        public AnonymousUserService(IDataContext context)
        {
            _context = context;
        }


        public AnonymousUser Create(AnonymousUser submission)
        {
            _context.AnonymousUser.Add(submission);
            _context.SaveChanges();
            return submission;
        }

        public int AnonymousCountBySurvey(int SurveyID)
        {
            return _context.AnonymousUser.Where(x => x.SurveyID == SurveyID).Count();
            
        }
    }
}
