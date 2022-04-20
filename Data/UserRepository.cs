using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using webapi.DTOs;
using webapi.Helpers;
using webapi.Interfaces;
using webapi.Models;

namespace webapi.Data;

public class UserRepository : IUserRepository
{ 
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    public UserRepository(DataContext context, IMapper mapper, UserManager<AppUser> userManager)
    {
        _userManager = userManager;
        _mapper = mapper;
        _context = context;
    }

    public async Task<AppUser?> GetAppUserAsync(string username)
    {
        return await _userManager.Users
            .Where(x=>x.NormalizedUserName == username.ToUpper())
            .SingleOrDefaultAsync();
    }


    public async Task<MemberDto?> GetMemberAsync(string username)
    {
        return await _userManager.Users
            .Where(x=>x.NormalizedUserName == username.ToUpper())
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }

    public async Task<AppUser> GetAppUserByEmailAsync(string email)
    {
         return await _userManager.Users
            .Where(x=>x.Email == email)
            .SingleAsync();
    }
    public async Task<MemberDto> GetMemberByEmailAsync(string email)
    {
            return await _userManager.Users
            .Where(x=>x.Email == email)
            .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
            .SingleAsync();
    }
    public Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams)
    {
        throw new NotImplementedException();
    }

    public Task<AppUser> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<AppUser> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserGender(string username)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        throw new NotImplementedException();
    }

    public void Update(AppUser user)
    {
        throw new NotImplementedException();
    }
}