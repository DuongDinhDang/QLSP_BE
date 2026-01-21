using QLSP_BE.Data;

namespace QLSP_BE.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetPagedAsync(int page, int pageSize);
        Task<int> CountAsync();
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
