using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProduct();
        Task<IEnumerable<Product>> GetByCategoryId(int CategoryId);
    }
}
