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
        public UseControllerTests()
        {
            var test = new MockDBContect();
            _userService = new UserService(test);
        }

        [Fact]
        public void IsAuthenticated_InputIsValid_ReturnTrue()
        {

            var result = true;
            Assert.True(result, "1 should not be prime");

            //var mockDependency = new Mock<IUserService>();

            //var sut = new HomeController(mockDependency.Object);

            // test code
        }
    }
}
