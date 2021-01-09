using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AfterX;
using AfterX.Data;
using AfterX.Installers;
using AfterX.Services;
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
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DataContext>();

            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IRoleService, RoleService>();
        }
    }
}
