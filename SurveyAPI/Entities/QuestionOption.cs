using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Entities
{
    public class QuestionOption
    {
        public int Id { get; set; }
        public string OptionDetail { get; set; }
        public int QuestionId { get; set; }
        public DateTime CreatedOn { get; set; }
        

    }
}
