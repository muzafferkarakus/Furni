using System.ComponentModel.DataAnnotations;

namespace Furni.EntityLayer.Concrete
{
    public class Staff
    {
        public int StaffId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(100)]
        public string? ImageUrl { get; set; }
    }
}
