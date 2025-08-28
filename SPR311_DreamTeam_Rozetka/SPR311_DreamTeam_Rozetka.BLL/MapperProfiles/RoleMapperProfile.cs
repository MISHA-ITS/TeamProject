using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR311_DreamTeam_Rozetka.BLL.MapperProfiles
{
    class RoleMapperProfile : Profile
    {
        public RoleMapperProfile()
        {
            //CreateRoleDTO -> RoleEntity
            CreateMap<CreateRoleDTO, IdentityRole>();

            //UpdateRoleDTO -> RoleEntity
            CreateMap<UpdateRoleDTO, IdentityRole>();

            //RoleEntity -> RoleDTO
            CreateMap<IdentityRole, RoleDTO>();
        }
    }
}
