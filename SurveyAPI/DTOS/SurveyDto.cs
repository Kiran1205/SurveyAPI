using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.DTOS
{
    public class SurveyDto
    {
        public int Id { get; set; }
        public string SurveyName { get; set; }
        public string SurveyDesc { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreatedOn { get; set; }        
        public DateTime ExpDate { get; set; }
        public bool Deleted { get; set; }
        public Guid SurveyGuid { get; set; }
        public bool IsLive { get; set; }
    }
}
