using SurveyAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyAPI.Services.Interfaces
{
    public interface IAnonymousUserService
    {
        AnonymousUser Create(AnonymousUser anonymousUser);
        int AnonymousCountBySurvey(int SurveyID);
    }
}
