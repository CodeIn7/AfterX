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
        public static class TableTypes
        {
            public const string GetAll = Base + "/tableTypes";
            public const string Create = Base + "/tableTypes";
            public const string Update = Base + "/tableTypes/{tableTypesId}";
            public const string Delete = Base + "/tableTypes/{tableTypesId}";
            public const string Get = Base + "/tableTypes/{tableTypes}";
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
        public static class DrinkClubs
        {
            public const string GetAll = Base + "/drinkClubs";
            public const string Create = Base + "/drinkClubs";
            public const string Update = Base + "/drinkClubs/{drinkClubsId}";
            public const string Delete = Base + "/drinkClubs/{drinkClubsId}";
            public const string Get = Base + "/drinkClubs/{drinkClubsId}";
        }
        public static class Reservations
        {
            public const string GetAll = Base + "/reservations";
            public const string Create = Base + "/reservations";
            public const string Update = Base + "/reservations/{reservationId}";
            public const string Delete = Base + "/reservations/{reservationId}";
            public const string Get = Base + "/reservations/{reservationId}";
        }
        public static class Orders
        {
            public const string GetAll = Base + "/orders";
            public const string Create = Base + "/orders";
            public const string Update = Base + "/orders/{ordersId}";
            public const string Delete = Base + "/orders/{ordersId}";
            public const string Done = Base + "/orders/done/{orderId}";
            public const string Get = Base + "/orders/{ordersId}";
        }
        public static class Identity
        {
            public const string Register = Base + "/idnetity/register";
            public const string Login = Base + "/idnetity/login";
        }
    }
}
