using Microsoft.EntityFrameworkCore;
using QLSP_BE.Data;
using QLSP_BE.Repository.Interfaces;

namespace QLSP_BE.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly QlspContext _context;

        public ProductRepository(QlspContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Products
                .Include(x => x.Category)
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> CountAsync()
        {
            return await _context.Products.CountAsync(x => x.IsActive == true);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product == null) return;

            product.IsActive = false;
            await _context.SaveChangesAsync();
        }
    }
}