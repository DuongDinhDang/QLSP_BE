using QLSP_BE.Data;
using QLSP_BE.Repository.Interfaces;
using QLSP_BE.Service.Interfaces;

namespace QLSP_BE.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<object> GetPagedAsync(int page, int pageSize)
        {
            var data = await _repo.GetPagedAsync(page, pageSize);
            var total = await _repo.CountAsync();

            return new
            {
                TotalItems = total,
                Page = page,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling((double)total / pageSize),
                Data = data
            };
        }

        public Task<Category?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task AddAsync(Category category)
            => _repo.AddAsync(category);

        public Task UpdateAsync(Category category)
            => _repo.UpdateAsync(category);

        public Task DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
