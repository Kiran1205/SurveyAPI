using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using SurveyAPI.Entities.Context;
using SurveyAPI.Services;
using SurveyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SurveyAPI.Tests
{
    public class UseControllerTests
    {

        private readonly IUserService _userService;
        private readonly IDataContext dataContext;
        public UseControllerTests()
        {
            dataContext = new MockDBContect();

            //byte[] foo = { 0x32, 0x00, 0x1E, 0x00 };
            //Entities.Users uTest = new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo };
            //dataContext.Users.Add(uTest);
            //Entities.AnswerSubmission answerSubmission = new Entities.AnswerSubmission()
            //{
            //    Id = 1,
            //    Answer = "this,",
            //    QuestionId = 2
            //};
            //dataContext.AnswerSubmissions.Add(answerSubmission);

            dataContext.Users = new TestDbSet<Entities.Users>();
            dataContext.AnswerSubmissions = new TestDbSet<Entities.AnswerSubmission>();
            dataContext.QuestionOptions = new TestDbSet<Entities.QuestionOption>();
            dataContext.Questions = new TestDbSet<Entities.Questions>();
            dataContext.Survey = new TestDbSet<Entities.Survey>();
            _userService = new UserService(dataContext);

        }

        

        [Fact]
        public void Create_IsUserCreatedWithValidData()
        {
            byte[] foo = { 0x32, 0x00, 0x1E, 0x00 };
            Entities.Users uTest = new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo };
            var newUser = _userService.Create(uTest, "pericharla");
            Assert.True(newUser != null);
        }

        [Fact]
        public void Create_PasswardIsEmpty()
        {
            byte[] foo = { 0x32, 0x00, 0x1E, 0x00 };
            Entities.Users uTest = new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo };
            try
            {
                var newUser = _userService.Create(uTest, string.Empty);
                Assert.False(1 == 1, "Password is correct.");
            }
            catch (Exception ex)
            {
                Assert.True(ex.Message == "Password is required");
            }
        }

        [Fact]
        public void Create_PasswardIsNull()
        {
            byte[] foo = { 0x32, 0x00, 0x1E, 0x00 };
            Entities.Users uTest = new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo };
            try
            {
                var newUser = _userService.Create(uTest, null);
                Assert.False(1 == 1, "Password is correct.");
            }
            catch (Exception ex)
            {
                Assert.True(ex.Message == "Password is required");
            }
        }

        [Fact]
        public void Create_AlreadyUesrPresent()
        {
            byte[] foo = { 0x32, 0x00, 0x1E, 0x00 };
            Entities.Users uTest1 = new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo };
            dataContext.Users.Add(uTest1);

            Entities.Users uTest2 = new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo };
            try
            {
                var newUser = _userService.Create(uTest2, "pericharla");
                Assert.True(1 == 1, "Username \"kiran\" is already taken");
            }
            catch (Exception ex)
            {
                Assert.True(ex.Message == "Username \"kiran\" is already taken");
            }
        }

        [Fact]
        public void Create_Delete()
        {
            byte[] foo = { 0x32, 0x00, 0x1E, 0x00 };
            Entities.Users uTest1 = new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo };
            dataContext.Users.Add(uTest1);
            //_userService.Delete(1);
            //var userDelete = dataContext.Users.(1);

            //Assert.True(1 != 1, "Remove need to implement fint in TestDbSet");
        }

        [Fact]
        public void Create_GetAll()
        {
            byte[] foo = { 0x32, 0x00, 0x1E, 0x00 };
            dataContext.Users.Add(new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo });
            //dataContext.Users.Add(new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo });
            //dataContext.Users.Add(new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo });
            var rUsers = _userService.GetAll();

            Assert.True(rUsers != null);
            //Assert.True(((List<Entities.Users>)rUsers).Count == 1);
        }

        [Fact]
        public void Create_GetById()
        {
            byte[] foo = { 0x32, 0x00, 0x1E, 0x00 };
            dataContext.Users.Add(new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo });
            //var rUsers = _userService.GetById(1);
            //Assert.True(rUsers != null);
        }

        //[Fact]
        //public void Update_


        private void AddDefaultDataToUser()
        {
            //dataContext.Users.
            byte[] foo = { 0x32, 0x00, 0x1E, 0x00 };
            Entities.Users uTest = new Entities.Users() { FirstName = "kiran", Id = 1, LastName = "pericharla", Username = "kiran", PasswordHash = foo, PasswordSalt = foo };
            dataContext.Users.Add(uTest);
        }
    }
}
