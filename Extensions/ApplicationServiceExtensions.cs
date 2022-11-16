using webapi.Data;
using webapi.Helpers;
using webapi.Interfaces;
using webapi.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace webapi.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection Services, IConfiguration config)
    {
        Services = AddInterfacesScopes(Services);
        Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        

        Services.AddControllers().AddNewtonsoftJson(o => 
        {   
            o.SerializerSettings.ReferenceLoopHandling  = ReferenceLoopHandling.Ignore;
            o.SerializerSettings.NullValueHandling      = NullValueHandling.Ignore;
            o.SerializerSettings.MissingMemberHandling  = MissingMemberHandling.Ignore;
            //o.SerializerSettings.DefaultValueHandling    = DefaultValueHandling.Ignore;
        });
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        Services.AddLogging();
        //Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(config.GetConnectionString("SqlServer")));
        //Services.AddDbContext<DataContext>(opt => opt.UseMySql(config.GetConnectionString("MySql"),Microsoft.EntityFrameworkCore.ServerVersion));
        Services.AddDbContext<DataContext>(opt => opt.UseMySql(config.GetConnectionString("MySql"),serverVersion));

        //Services.AddDbContext<DataContext>(opt => opt.UseNpgsql(config.GetConnectionString("Heroku")));
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        return Services;
        
    }

    public static IServiceCollection AddInterfacesScopes(this IServiceCollection Services)
    {
        //? Services.AddScoped<Interface Class,Main Class>();
        Services.AddScoped<IUserRepository, UserRepository>();

        
        return Services;
    }
}