using QLSP_BE.Data;
using QLSP_BE.Repository.Interfaces;
using QLSP_BE.Service.Interfaces;

namespace QLSP_BE.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
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

        public Task<Product?> GetByIdAsync(int id)
            => _repo.GetByIdAsync(id);

        public Task AddAsync(Product product)
            => _repo.AddAsync(product);

        public Task UpdateAsync(Product product)
            => _repo.UpdateAsync(product);

        public Task DeleteAsync(int id)
            => _repo.DeleteAsync(id);
    }
}
