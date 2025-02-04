using AutoMapper;
using Furni.BusinessLayer.Abstract;
using Furni.DtoLayer.Dtos.ProductDtos;
using Furni.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Furni.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var values = _productService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult ProductListById(int id)
        {
            var values = _productService.TGetById(id);
            return Ok(values);
        }

        [HttpGet("Get3ProductList")]
        public IActionResult Get3ProductList()
        {
            var values = _productService.TGet3ProductList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            _productService.TInsert(values);
            return Ok("Ürün Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var values = _productService.TGetById(id);
            _productService.TDelete(values);
            return Ok("Ürün Silindi");
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(values);
            return Ok("Ürün Güncellendi");
        }
    }

}
