using System.ComponentModel.DataAnnotations;

namespace Furni.EntityLayer.Concrete
{
    public class Feature
    {
        public int FeatureId { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(250)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Feature1 { get; set; }
        [StringLength(100)]
        public string Feature2 { get; set; }
        [StringLength(100)]
        public string Feature3 { get; set; }
        [StringLength(100)]
        public string Feature4 { get; set; }
        [StringLength(100)]
        public string Image1 { get; set; }
        [StringLength(100)]
        public string Image2 { get; set; }
        [StringLength(100)]
        public string Image3 { get; set; }
    }
}
