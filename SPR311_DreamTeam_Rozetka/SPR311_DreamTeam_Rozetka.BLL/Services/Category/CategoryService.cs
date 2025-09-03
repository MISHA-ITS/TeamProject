using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SPR311_DreamTeam_Rozetka.BLL.DTOs.Category;
using SPR311_DreamTeam_Rozetka.DAL.Entities;
using SPR311_DreamTeam_Rozetka.DAL.Repositories.Category;

namespace SPR311_DreamTeam_Rozetka.BLL.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse> CreateAsync(CreateCategoryDto dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            if (!_categoryRepository.IsUniqueName(entity))
            {
                return ServiceResponse.Error($"Категорія з іменем {entity.Name} вже існує");
            }

            bool result = await _categoryRepository.CreateAsync(entity);

            if (result)
            {
                return ServiceResponse.Success($"Категорію {entity.Name} успішно доданг");
            }

            return ServiceResponse.Error($"Не вдалося створити категорію");
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            var entity = await _categoryRepository
                .GetByIdAsync(id);

            if (entity == null)
            {
                return ServiceResponse.Error($"Категорію з id {id} не знайдено");
            }

            bool result = await _categoryRepository.DeleteAsync(entity);

            if (result)
            {
                return ServiceResponse.Success($"Категорію {entity.Name} успішно видалено");
            }

            return ServiceResponse.Error($"Не вдалося видалити категорію");
        }

        public async Task<ServiceResponse> GetAllAsync()
        {
            var entities = await _categoryRepository
                .GetAll()
                .ToListAsync();

            var dtos = _mapper.Map<List<CategoryDto>>(entities);

            return ServiceResponse.Success("Категорії отримано", dtos);
        }

        public async Task<ServiceResponse> GetByIdAsync(Guid id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);

            if (entity != null)
            {
                var dto = _mapper.Map<CategoryDto>(entity);
                return ServiceResponse.Success($"Категорію {entity.Name} отримано", dto);
            }

            return ServiceResponse.Error("Категорію не знайдено");
        }

        public async Task<ServiceResponse> GetByNameAsync(Guid name)
        {
            var entity = await _categoryRepository.GetByIdAsync(name);

            if (entity != null)
            {
                var dto = _mapper.Map<CategoryDto>(entity);
                return ServiceResponse.Success($"Категорію {entity.Name} отримано", dto);
            }

            return ServiceResponse.Error($"Категорію {name} не знайдено");
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateCategoryDto dto)
        {
            var entity = _mapper.Map<CategoryEntity>(dto);
            var result = await _categoryRepository.UpdateAsync(entity);
            if (result)
            {
                return ServiceResponse.Success("Продукт оновлено успішно");
            }
            return ServiceResponse.Error("Продукт не оновлено");
        }
    }
}
