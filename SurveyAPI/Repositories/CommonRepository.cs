using SurveyAPI.DTOS;
using SurveyAPI.Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SurveyAPI.Repositories
{
    public class CommonRepository
    {

        private readonly DataContext _context;

        public CommonRepository(DataContext context)
        {
            _context = context;
        }
        public StatisticsDto getStatisticsData(int userid)
        {
            using(var command = _context.Database.GetDbConnection().CreateCommand())
            {
                StatisticsDto data = new StatisticsDto();
                command.CommandText = "exec sp_getcountodisplay " + userid;
                _context.Database.OpenConnection();
                using(var reader =  command.ExecuteReader())
                {
                    var opensurveycount = reader.GetOrdinal("opensurvey");
                    var closedcount = reader.GetOrdinal("closedsurvey");
                    var draft = reader.GetOrdinal("draft");
                    var totalresponse = reader.GetOrdinal("totalresponse");
                    while (reader.Read())
                    {
                        data =  new StatisticsDto()
                            {
                                OpenSurveys = reader.GetInt32(opensurveycount),
                                ClosedSurveys = reader.GetInt32(closedcount),
                                DraftSurveys = reader.GetInt32(draft),
                                TotalResponse = reader.GetInt32(totalresponse)
                            };
                    }
                }
                return data;
            }
        }
    }
}
