﻿namespace Furni.WebUI.Dto.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile file { get; set; }
    }
}
