using ApplicationCore.Interface;
using ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMT_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories =  await _categoryService.GetAllCategory();

            if (categories == null || categories.Count() == 0)
            {
                return NotFound();
            }

            return Ok(categories);
        }

    }
}