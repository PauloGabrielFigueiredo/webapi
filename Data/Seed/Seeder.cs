using webapi.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace webapi.Data;

public class Seeder
{
    #region Seeder Development
    public static async Task Seed(UserManager<AppUser> userManager, DataContext _context)
    {
        await SeedUsers(userManager, _context);

        // await Seed_Tables<WarningTypeAction>(_context, _context.DB_Warning_Type_Action, "Data/Seed/Warning_Type_Action/Warning_Type_Action.data.json");
    }

    public static async Task Seed_Tables<T>(DataContext _context, DbSet<T> Table, string FilePath) where T : class
    {
        if (await Table.AnyAsync()) return;
        var Data = await System.IO.File.ReadAllTextAsync(FilePath);
        var Data_Extended = JsonSerializer.Deserialize<List<T>>(Data);
        if (Data_Extended == null) return;
        foreach (var x in Data_Extended)
        {
            Table.Add(x);
        }
        await _context.SaveChangesAsync();
    }
    
    public static async Task SeedUsers(UserManager<AppUser> userManager, DataContext _context)
    {
        if (await userManager.Users.AnyAsync()) return;

        var userData = await System.IO.File.ReadAllTextAsync("Data/Seed/User/User.data.json");
        var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
        if (users == null) return;
        var i = 0;
        foreach (var user in users)
        {
            i++;
            user.UserName = user.UserName.ToLower();
            await userManager.CreateAsync(user, "Pa$$w0rd");
            //if (user.UserName == "admin")
            //    await userManager.AddToRoleAsync(user, "Admin");
            //if (user.UserName != "admin")
            //    await userManager.AddToRoleAsync(user, "Member");
        }
    }
    #endregion
}