using System.ComponentModel.DataAnnotations;

namespace Furni.EntityLayer.Concrete
{
    public class Contact
    {
        public int ContactId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(50)]
        public string Subject { get; set; }
        [StringLength(250)]
        public string Message { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
