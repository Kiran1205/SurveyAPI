using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Entities
{
    public class AnswerSubmission
    {
        public int Id { get; set; }
        public string OptionDetail { get; set; }
        public string SelectedValue { get; set; }
        public int QuestionId { get; set; }
        public int AnonymouseUserID { get; set; }       
    }
}
