using AutoMapper;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.User;
using SPR311_DreamTeam_Rozetka.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR311_DreamTeam_Rozetka.BLL.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            // CreateUserDTO -> AppUser
            CreateMap<CreateUserDTO, AppUser>()
                .ForMember(dest => dest.UserName,
                           opt => opt.MapFrom((src, dest) =>
                               src.Email.Contains('@') ? src.Email.Split('@')[0] : src.Email))
                .ForMember(dest => dest.Image, opt => opt.Ignore());

            // UpdateUserDTO -> AppUser
            CreateMap<UpdateUserDTO, AppUser>()
                .ForMember(dest => dest.UserName,
                           opt => opt.MapFrom((src, dest) =>
                               src.Email.Contains('@') ? src.Email.Split('@')[0] : src.Email))
                .ForMember(dest => dest.Image, opt => opt.Ignore());

            // AppUser -> UserDTO
            CreateMap<AppUser, UserDTO>();
        }
    }
}
