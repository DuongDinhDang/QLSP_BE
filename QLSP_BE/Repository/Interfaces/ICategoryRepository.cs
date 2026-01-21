using QLSP_BE.Data;
namespace QLSP_BE.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetPagedAsync(int page, int pageSize);
        Task<int> CountAsync();
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
