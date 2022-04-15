using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using webapi.Data;
using webapi.Interfaces;
using webapi.Models;
using webapi.Services;
using webapi.Helpers;

namespace webapi.Extensions;

public static class IdentityServiceExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
        services=AddInterfacesScopes(services);
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        services.AddSwagger();
        services.AddIdentityCore<AppUser>(opt =>
        {
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireDigit = true;
                opt.User.RequireUniqueEmail = true;
                opt.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
        })
            .AddSignInManager<SignInManager<AppUser>>()
            .AddEntityFrameworkStores<DataContext>();


        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
                  {
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuerSigningKey = true,
                          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                          ValidateIssuer = false,
                          ValidateAudience = false,
                      };
                  });

        services.AddAuthorization();

        return services;
    }
    public static IServiceCollection AddInterfacesScopes(this IServiceCollection Services)
    {
        //? Services.AddScoped<Interface Class,Main Class>();
        Services.AddScoped<ITokenService, TokenService>();

        return Services;
    }
}