using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public string QuestionDetails { get; set; }
        public int SurveyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Deleted { get; set; }

    }
}
