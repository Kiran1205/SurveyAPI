using SurveyAPI.Services;
using SurveyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SurveyAPI.Tests.Controller
{
    public class UseControllerTests
    {
        private readonly IUserService _userService;

        public UseControllerTests()
        {
            _userService = new UserService(null);
        }

        [Fact]
        public void IsAuthenticated_InputIsValid_ReturnTrue()
        {
            //var mockDependency = new Mock<IUserService>();

            //var sut = new HomeController(mockDependency.Object);

            // test code
        }
    }
}
