using ApplicationCore.Interface;
using ApplicationCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMT_Web_Api.Controllers
{

    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
             var products = await _productService.GetAllProduct();

            if(products==null || products.Count()==0)
            {
                return NotFound();
            }

            return Ok(products);
        }
        

        // GET: api/category/5/Product
        [Route("api/category/{CategoryId}/Product")]
        [HttpGet("{Id}", Name = "GetByCategory")]

        public async Task<IActionResult> Get(int categoryId)
        {
            if(categoryId==0)
            {
                NotFound(StatusCodes.Status400BadRequest);
            }
            var products= await _productService.GetByCategoryId(categoryId);

            if (products == null || products.Count() == 0)
            {
                return NotFound();
            }
            return Ok(products);
        }
    }
}
