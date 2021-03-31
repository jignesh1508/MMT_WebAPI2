using ApplicationCore.Interface;
using ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            IEnumerable<Category> categories = new List<Category>();

            try
            {
                categories =await _repository.ListAll("spGetAllCategory");

                if (categories == null)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //We can write exception in logger file.
                return null;
            }

            return categories;

        }

        public async Task<Category> GetById(int CategoryId)
        {
            Category category = new Category();
            try
            {
                if (CategoryId == 0)
                {
                    return null;
                }
                 
                category = await _repository.GetById(CategoryId);
            }
            catch (Exception ex)
            {
                //We can write exception in logger file.
                return null;
            }

            return category;
        }


    }
}
