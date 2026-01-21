using Microsoft.EntityFrameworkCore;
using QLSP_BE.Data;
using QLSP_BE.Repository.Interfaces;

namespace QLSP_BE.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly QlspContext _context;

        public CategoryRepository(QlspContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetPagedAsync(int page, int pageSize)
        {
            return await _context.Categories
                .Where(x => x.IsActive == true)
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            return await _context.Categories.CountAsync(x => x.IsActive == true);
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        }

        public async Task AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category == null) return;

            category.IsActive = false; // xóa mềm
            await _context.SaveChangesAsync();
        }
    }
}
