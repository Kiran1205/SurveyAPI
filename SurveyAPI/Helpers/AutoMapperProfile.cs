using AutoMapper;
using SurveyAPI.DTOS;
using SurveyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, UserDto>();
            CreateMap<UserDto, Users>();

            CreateMap<Survey, SurveyDto>();
            CreateMap<SurveyDto, Survey>();

            CreateMap<Survey, SurveyDto>();
            CreateMap<SurveyDto, Survey>();

            CreateMap<Questions, QuestionsDto>();
            CreateMap<QuestionsDto, Questions>();

            CreateMap<QuestionOption, QuestionOptionDto>();
            CreateMap<QuestionOptionDto, QuestionOption>();
        }
    }
}
