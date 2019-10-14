using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.DTOS
{
    public class QuestionOptionDto
    {
        public int Id { get; set; }
        public string OptionDetail { get; set; }
        public string SelectedValue { get; set; }
        public int QuestionId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
