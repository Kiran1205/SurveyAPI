using SurveyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services.Interfaces
{
    public interface IAnswerSubmissionService
    {
        
        AnswerSubmission Create(AnswerSubmission answerSubmission);
        
    }
}
