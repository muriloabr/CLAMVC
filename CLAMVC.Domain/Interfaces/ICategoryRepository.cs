using CLAMVC.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CLAMVC.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetByIdAsync(int? id);//int nullable

        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> RemoveAsync (Category category);
    }
}
