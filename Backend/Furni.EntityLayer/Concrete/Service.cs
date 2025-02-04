using System.ComponentModel.DataAnnotations;

namespace Furni.EntityLayer.Concrete
{
    public class Service
    {
        public int ServiceId { get; set; }
        [StringLength(30)]
        public string ServiceName { get; set; }
        [StringLength(100)]
        public string ServiceDescription { get; set; }
        [StringLength(100)]
        public string ServiceImage { get; set; }
    }
}
