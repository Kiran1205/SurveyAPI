using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.DTOS
{
    public class QuestionsDto
    {
        public int Id { get; set; }
        public string Ques { get; set; }
        public int SurveyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string QuestionType { get; set; }
        public List<QuestionOptionDto> Qoptions { get; set; }
    }
}
