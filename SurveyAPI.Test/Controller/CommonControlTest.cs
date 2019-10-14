using AutoMapper;
using Microsoft.Extensions.Options;
using Moq;
using SurveyAPI.Helpers;
using SurveyAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyAPI.Test.Controller
{
    public class CommonControlTest
    {
        protected Mock<IUserService> _mockService;
        protected Mock<IMapper> __mockmapper;
        protected Mock<IOptions<AppSettings>> __mockappSettings;

        public CommonControlTest()
        {
            _mockService = new Mock<IUserService>();
            __mockmapper = new Mock<IMapper>();
            __mockappSettings = new Mock<IOptions<AppSettings>>();
        }
    }
}
