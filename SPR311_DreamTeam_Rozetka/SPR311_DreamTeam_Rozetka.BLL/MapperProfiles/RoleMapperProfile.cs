using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Role;
using SPR311_DreamTeam_Rozetka.DAL.Entities.Identity;
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
            CreateMap<CreateRoleDTO, AppRole>();

            //UpdateRoleDTO -> RoleEntity
            CreateMap<UpdateRoleDTO, AppRole>();

            //RoleEntity -> RoleDTO
            CreateMap<AppRole, RoleDTO>();
        }
    }
}
