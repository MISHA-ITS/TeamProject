using AutoMapper;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Product;
using SPR311_DreamTeam_Rozetka.DAL.Entities;

namespace SPR311_DreamTeam_Rozetka.BLL.MapperProfiles
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile() 
        {
            //CreateProductDto => ProductEntity
            CreateMap<CreateProductDto, ProductEntity>();

            //UpdateProductDto => ProductEntity
            CreateMap<UpdateProductDto, ProductEntity>();

            //ProductEntity => ProductDto
            CreateMap<ProductEntity, ProductDto>();
        }
    }
}
