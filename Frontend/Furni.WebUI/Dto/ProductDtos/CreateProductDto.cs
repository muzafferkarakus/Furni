namespace Furni.WebUI.Dto.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
        public IFormFile file { get; set; }
    }
}
