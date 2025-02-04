using System.ComponentModel.DataAnnotations;

namespace Furni.EntityLayer.Concrete
{
    public class About
    {
        public int AboutId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(100)]
        public string AboutImage { get; set; }
    }
}
