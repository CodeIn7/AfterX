using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX.Contracts.V1
{
    public class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Clubs
        {
            public const string GetAll = Base + "/clubs";
            public const string Create = Base + "/clubs";
            public const string Update = Base + "/clubs/{clubId}";
            public const string Delete = Base + "/clubs/{clubId}";
            public const string Get = Base + "/clubs/{clubId}";
        }
        public static class Cities
        {
            public const string GetAll = Base + "/cities";
            public const string Create = Base + "/cities";
            public const string Update = Base + "/cities/{cityId}";
            public const string Delete = Base + "/cities/{cityId}";
            public const string Get = Base + "/cities/{cityId}";
        }
        public static class Roles
        {
            public const string GetAll = Base + "/roles";
            public const string Create = Base + "/roles";
            public const string Update = Base + "/roles/{roleId}";
            public const string Delete = Base + "/roles/{roleId}";
            public const string Get = Base + "/roles/{roleId}";
        }

        public static class Drinks
        {
            public const string GetAll = Base + "/drinks";
            public const string Create = Base + "/drinks";
            public const string Update = Base + "/drinks/{drinkId}";
            public const string Delete = Base + "/drinks/{drinkId}";
            public const string Get = Base + "/drinks/{drinkId}";
        }
        public static class DrinkTypes
        {
            public const string GetAll = Base + "/drinkTypes";
            public const string Create = Base + "/drinkTypes";
            public const string Update = Base + "/drinkTypes/{drinkTypesId}";
            public const string Delete = Base + "/drinkTypes/{drinkTypesId}";
            public const string Get = Base + "/drinkTypes/{drinkTypesId}";
        }
        public static class Identity
        {
            public const string Register = Base + "/idnetity/register";
            public const string Login = Base + "/idnetity/login";
        }
    }
}
