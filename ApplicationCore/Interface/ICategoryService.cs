using ApplicationCore.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetById(int CategoryId);
    }
}
