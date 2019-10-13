using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Entities
{
    public class AnswerSubmission
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Answer { get; set; }

    }
}
