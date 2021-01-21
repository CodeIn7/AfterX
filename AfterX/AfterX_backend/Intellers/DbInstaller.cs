using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfterX;
using AfterX.Installers;
using AfterX.Services;
using AfterX_backend.Services.Interfaces;
using AfterX_backend.Services.ServiceImplementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EciTimeSheetWebApi.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

            services.
                AddDbContext<DataContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<Role>()
                .AddEntityFrameworkStores<DataContext>();

            //services.AddDefaultIdentity<User>()
            // .AddEntityFrameworkStores<DataContext>()
            // .AddDefaultTokenProviders();

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IClubService, ClubService>();
            services.AddScoped<IDrinkService, DrinkService>();
            services.AddScoped<IDrinkTypesService, DrinkTypesService>();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<ITableTypeService, TableTypeService>();
            services.AddScoped<IDrinkClubService, DrinkClubService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IOrderDrinkService, OrderDrinkService>();


        }
    }
}
