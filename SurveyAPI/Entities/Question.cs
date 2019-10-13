using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string Ques { get; set; }
        public int SurveyId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Deleted { get; set; }
        public int TypeId { get; set; }

    }
}
