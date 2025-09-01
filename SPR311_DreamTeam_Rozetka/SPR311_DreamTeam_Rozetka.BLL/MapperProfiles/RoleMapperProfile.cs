using AutoMapper;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Role;
using SPR311_DreamTeam_Rozetka.DAL.Entities.Identity;


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
