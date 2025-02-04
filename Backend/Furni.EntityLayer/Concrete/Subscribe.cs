using System.ComponentModel.DataAnnotations;

namespace Furni.EntityLayer.Concrete
{
    public class Subscribe
    {
        public int SubscribeId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
    }
}
