//global using File = webapi.Models.Attachment;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webapi;
using webapi.Data;
using webapi.Models;
using webapi.Helpers;

var host = CreateHostBuilder(args).Build();//.Run();
using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    var environment = services.GetRequiredService<IWebHostEnvironment>();
    var context = services.GetRequiredService<DataContext>();
    var UserManager = services.GetRequiredService<UserManager<AppUser>>();
    //var RoleManager = services.GetRequiredService<RoleManager<AppRole>>();
    await context.Database.MigrateAsync();
    if(environment.IsDevelopment()){
        logger.LogInformation("Running in development mode!");
        await Seeder.Seed(UserManager, context);
    }else{
        logger.LogInformation("Running in production mode!");
    }

}
catch (Exception ex)
{
    logger.LogError(ex, "An error occurred durring migration");
}
await host.RunAsync();

IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });