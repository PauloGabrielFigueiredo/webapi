using System;
using System.Linq;
using webapi.DTOs;
using webapi.Models;
using webapi.Extensions;
using AutoMapper;

namespace webapi.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();
            
        }
    }
}