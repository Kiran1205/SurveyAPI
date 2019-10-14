using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using SurveyAPI.Controllers;
using SurveyAPI.DTOS;
using SurveyAPI.Entities;
using SurveyAPI.Helpers;
using SurveyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SurveyAPI.Test.Controller
{
    public class UserControllerTest : CommonControlTest
    {
       
        public UserControllerTest()
        {
           
        }

        [Fact]
        public void if_user_send_null_info_reponse_should_be_badrequest()
        {
            var userController = new UserController(_mockService.Object, __mockmapper.Object, __mockappSettings.Object);

            var result = userController.Authenticate(null);

            Assert.Equal(typeof(BadRequestResult), result.GetType());
        }
        [Fact]
        public void if_user_send_proper_info_reponse_should_be_userinformation_with_token()
        {
           
            var userController = new UserController(_mockService.Object, __mockmapper.Object, __mockappSettings.Object);
            UserDto uTest = new UserDto() {  Username = "kiran1205", Password= "kiran@1234" };
            Users testuser = new Users()
            {
                Username ="kiran1205",
                Id = 1
            };
            _mockService.Setup(_ => _.Authenticate("kiran1205", "kiran@1234")).Returns(testuser);              

           
        }

    }
}
