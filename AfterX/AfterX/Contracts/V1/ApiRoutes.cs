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
    }
}
