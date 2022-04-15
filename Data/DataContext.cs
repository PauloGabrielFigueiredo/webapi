using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class DataContext : IdentityDbContext<
                                      AppUser,
                                      AppRole, int,
                                      IdentityUserClaim<int>,
                                      IdentityUserRole<int>,
                                      IdentityUserLogin<int>,
                                      IdentityRoleClaim<int>,
                                      IdentityUserToken<int>>

    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region AppUser
            //Config
            builder.Entity<AppUser>()
               .HasOne(e => e.config)
               .WithOne(c => c.user)
               .OnDelete(DeleteBehavior.Cascade);
// FK
            
        builder.Entity<AppUserConfig>()
            .HasOne(e => e.user)
            .WithOne(c => c.config)
            .HasForeignKey<AppUserConfig>(b => b.user_id);



            builder.Entity<AppUser>()
               .HasMany(e => e.UserRoles)
               .WithOne(c => c.User)
               .HasForeignKey(b => b.UserId)
               .IsRequired();
// FK
            
        builder.Entity<AppRole>()
            .HasMany(e => e.UsersRoles)
            .WithOne(c => c.Role)
            .HasForeignKey(b => b.RoleId)
            .IsRequired();

        }

        #endregion
        public DbSet<AppUser> Db_AppUser { get; set; }

    }



}