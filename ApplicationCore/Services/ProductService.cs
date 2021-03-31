using ApplicationCore.Interface;
using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _repository;
        private readonly ICategoryService _categoryService;

        public ProductService(IRepository<Product> repository, ICategoryService categoryService)
        {
            _repository = repository;
            _categoryService = categoryService;
        }

        public async Task<IEnumerable<Product>> GetAllProduct()
        {
            IEnumerable<Product> products = new List<Product>();
            try
            {
                products = await _repository.ListAll("spGetAllProducts");

                if (products == null)
                {
                    return null;
                }

                foreach(var product in products)
                {
                   product.Category= await _categoryService.GetById(product.CategoryId);
                }
            }
            catch (Exception ex)
            {
                //We can write exception in logger file.
                return null;
            }

            return products;
        }

        public async Task<IEnumerable<Product>> GetByCategoryId(int CategoryId)
        {
            IEnumerable<Product> products = new List<Product>();
            try
            {
                if (CategoryId == 0)
                {
                    return null;
                }
                products = await _repository.ListAllById(CategoryId, "spGetProductsByCategory");

                foreach (var product in products)
                {
                    product.Category = await _categoryService.GetById(product.CategoryId);
                }
            }
            catch (Exception ex)
            {
                //We can write exception in logger file.
                return null;
            }

            return products;
        }

    }
}
