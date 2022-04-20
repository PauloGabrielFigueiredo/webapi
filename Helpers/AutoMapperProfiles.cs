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
                // .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => 
                //     src.Photos.FirstOrDefault(x => x.IsMain).Url))
               
          //  CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();
            
        }
    }
}