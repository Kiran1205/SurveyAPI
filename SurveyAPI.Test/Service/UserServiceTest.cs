using Microsoft.EntityFrameworkCore;
using Moq;
using SurveyAPI.Entities;
using SurveyAPI.Entities.Context;
using SurveyAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SurveyAPI.Test.Service
{
    public class UserServiceTest
    {
        [Fact]
        public void create_user_if_user_not_exist_with_same_user_id()
        {

            IQueryable<Users> users = new List<Users>
            {
                new Users
                {
                    Username = "kiran"
                },
                new Users
                {
                    Username = "varma"
                }

            }.AsQueryable();
            var mockSet = FakeDbSet.CreateDbSetMock<Users>(users);

            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var repository = new UserService(mockContext.Object);
            repository.Create(new Users() { Username= "kiran1205",FirstName ="kiran"}, "William Shakespeare");

            mockSet.Verify(m => m.Add(It.IsAny<Users>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void create_user_if_user_exist_throw_bad_request()
        {

            IQueryable<Users> users = new List<Users>
            {
                new Users
                {
                    Username = "kiran1205"
                },
                new Users
                {
                    Username = "varma"
                }

            }.AsQueryable();
            var mockSet = FakeDbSet.CreateDbSetMock<Users>(users);

            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var repository = new UserService(mockContext.Object);
                      
        }
    }
}
