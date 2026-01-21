using QLSP_BE.Data;

namespace QLSP_BE.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<object> GetPagedAsync(int page, int pageSize);
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
