using System.Collections.Generic;
using System.Threading.Tasks;
using webapi.DTOs;
using webapi.Models;
using webapi.Helpers;

namespace webapi.Interfaces
{
    public interface IUserRepository
    {
        Task<AppUser?> GetAppUserAsync(string username);
        Task<MemberDto?> GetMemberAsync(string username);

        Task<AppUser> GetAppUserByEmailAsync(string email);
        Task<MemberDto> GetMemberByEmailAsync(string email);

        void Update(AppUser user);

        void Delete(AppUser user);

        Task<bool> Save();

        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        Task<string> GetUserGender(string username);
    }
}