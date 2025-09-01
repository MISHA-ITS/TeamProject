using Microsoft.EntityFrameworkCore;
using SPR311_DreamTeam_Rozetka.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPR311_DreamTeam_Rozetka.DAL.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(ProductEntity entity)
        {
            _context.Products.Add(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public async Task<bool> DeleteAsync(ProductEntity entity)
        {
            _context.Products.Remove(entity);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public IQueryable<ProductEntity> GetAll()
        {
            return _context.Products;
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.id == id);
        }

        public bool IsUniqueName(ProductEntity entity)
        {
            return !_context.Products.Any(p => p.Name == entity.Name);
        }

        public async Task<bool> UpdateAsync(ProductEntity entity)
        {
            _context.Update(entity);
            var result = await _context.SaveChangesAsync();
            return result !=0;
        }
    }
}
