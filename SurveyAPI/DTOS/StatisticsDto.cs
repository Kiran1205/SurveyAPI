using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.DTOS
{
    public class StatisticsDto
    {
        public int OpenSurveys { get; set; }

        public int ClosedSurveys { get; set; }

        public int DraftSurveys { get; set; }

        public int TotalResponse { get; set; }
    }
}
