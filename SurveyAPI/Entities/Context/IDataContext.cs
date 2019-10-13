using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Entities.Context
{
    public interface IDataContext
    {
         DbSet<Users> Users { get; set; }
         DbSet<Survey> Survey { get; set; }
         DbSet<Questions> Questions { get; set; }
         DbSet<QuestionOption> QuestionOptions { get; set; }
         DbSet<AnswerSubmission> AnswerSubmissions { get; set; }

        /// <summary>
        /// SaveChanges
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
    }
}
