using System.ComponentModel.DataAnnotations;

namespace Furni.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        [StringLength(100)]
        public string ProductImage { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
