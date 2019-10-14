using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Entities
{
    public class AnonymousUser
    {
        public int Id { get; set; }
        public int SurveyID { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
