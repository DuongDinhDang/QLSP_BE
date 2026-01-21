using QLSP_BE.Data;

namespace QLSP_BE.Service.Interfaces
{
    public interface IProductService
    {
        Task<object> GetPagedAsync(int page, int pageSize);
        Task<Product?> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
