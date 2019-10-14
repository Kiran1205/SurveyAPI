using Microsoft.EntityFrameworkCore;
using SurveyAPI.Entities;
using SurveyAPI.Entities.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyAPI.Tests
{
    class MockDBContect : IDataContext
    {
        public MockDBContect()
        {
            //Users.Add(new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran" });
            //Users.Add(new Entities.Users() { FirstName = "Ritesh", Id = 2, LastName = "pericharla", Username = "rpericharla" });
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<AnswerSubmission> AnswerSubmissions { get; set; }
        public DbSet<AnonymousUser> AnonymousUser { get; set; }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
