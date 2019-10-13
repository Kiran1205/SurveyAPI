using SurveyAPI.Entities;
using SurveyAPI.Entities.Context;
using SurveyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services
{
    public class AnswerSubmissionService : IAnswerSubmissionService
    {
        private DataContext _context;

        public AnswerSubmissionService(DataContext context)
        {
            _context = context;
        }


        public AnswerSubmission Create(AnswerSubmission submission)
        {
            _context.AnswerSubmissions.Add(submission);
            _context.SaveChanges();

            return submission;
        }

    }
}
