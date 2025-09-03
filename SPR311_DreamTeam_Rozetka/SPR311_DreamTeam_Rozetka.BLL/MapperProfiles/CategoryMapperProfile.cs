using AutoMapper;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Category;
using SPR311_DreamTeam_Rozetka.DAL.Entities;

namespace SPR311_DreamTeam_Rozetka.BLL.MapperProfiles
{
    public class CategoryMapperProfile : Profile
    {
        public CategoryMapperProfile()
        {
            //CreateCategoryDTO -> CategoryEntity
            CreateMap<CreateCategoryDto, CategoryEntity>();

            //UpdateCategoryDTO -> CategoryEntity
            CreateMap<UpdateCategoryDto, CategoryEntity>();

            //CategoryEntity -> CategoryDTO
            CreateMap<CategoryEntity, CategoryDto>();
        }
    }
}
