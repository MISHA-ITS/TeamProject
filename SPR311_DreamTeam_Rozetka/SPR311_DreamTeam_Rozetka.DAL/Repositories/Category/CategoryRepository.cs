using SPR311_DreamTeam_Rozetka.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace SPR311_DreamTeam_Rozetka.DAL.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(CategoryEntity entity)
        {
            _context.Categories.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public async Task<bool> DeleteAsync(CategoryEntity entity)
        {
            _context.Categories.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public IQueryable<CategoryEntity> GetAll()
        {
            return _context.Categories;
        }

        public async Task<CategoryEntity> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public bool IsUniqueName(CategoryEntity entity)
        {
            return !_context.Products.Any(p => p.Name == entity.Name);
        }

        public async Task<bool> UpdateAsync(CategoryEntity entity)
        {
            _context.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }
    }
}
