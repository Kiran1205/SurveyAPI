using Microsoft.EntityFrameworkCore;
using Moq;
using SurveyAPI.Entities;
using SurveyAPI.Entities.Context;
using SurveyAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
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
            repository.Create(new Users() { Username = "kiran1205", FirstName = "kiran" }, "William Shakespeare");

            mockSet.Verify(m => m.Add(It.IsAny<Users>()), Times.Once);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);
        }

        [Fact]
        public void create_user_should_throw_exception_if_user_already_exists()
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

            var userservice = new UserService(mockContext.Object);

            Exception ex = Assert.Throws<Exception>(() => userservice.Create(new Users() { Username = "kiran1205" }, "kiran@1234"));
            Assert.Equal("Username \"kiran1205\" is already taken", ex.Message);

        }

        [Fact]
        public void create_user_should_throw_exception_if_password_is_null_or_white_space()
        {

            IQueryable<Users> users = new List<Users>
            {


            }.AsQueryable();
            var mockSet = FakeDbSet.CreateDbSetMock<Users>(users);

            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var userservice = new UserService(mockContext.Object);

            Exception ex = Assert.Throws<Exception>(() => userservice.Create(new Users() { Username = "kiran1205" }, ""));
            Assert.Equal("Password is required", ex.Message);

        }

        [Fact]
        public void delete_user_should_delete_the_record_from_users()
        {

            IQueryable<Users> users = new List<Users>
            {
                new Users
                {
                    Username = "kiran1205",
                    Id = 1,
                }
            }.AsQueryable();
            var mockSet = FakeDbSet.CreateDbSetMock<Users>(users);

            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => users.FirstOrDefault(d => d.Id == (int)ids[0]));

            var userservice = new UserService(mockContext.Object);
            userservice.Delete(1);
            mockContext.Verify(m => m.SaveChanges(), Times.Once);

        }
        [Fact]
        public void delete_user_should_not_throw_exception()
        {

            IQueryable<Users> users = new List<Users>
            {
                new Users
                {
                    Username = "kiran1205",
                    Id = 1,
                }
            }.AsQueryable();
            var mockSet = FakeDbSet.CreateDbSetMock<Users>(users);

            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            mockSet.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => users.FirstOrDefault(d => d.Id == (int)ids[0]));

            var userservice = new UserService(mockContext.Object);
            userservice.Delete(2);
            mockContext.Verify(m => m.SaveChanges(), Times.Never);

        }

        [Fact]
        public void get_all_user_should_return_propery()
        {

            IQueryable<Users> users = new List<Users>
                {
                    new Users
                    {
                        Username = "kiran1205",
                        Id = 1,
                    }
                }.AsQueryable();
            var mockSet = FakeDbSet.CreateDbSetMock<Users>(users);

            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);            

            var userservice = new UserService(mockContext.Object);
            var usercount = userservice.GetAll();
            Assert.True(usercount.Count()==1);

        }
     }
}
