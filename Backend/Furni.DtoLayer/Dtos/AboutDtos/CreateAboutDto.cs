﻿using System.ComponentModel.DataAnnotations;

namespace Furni.DtoLayer.Dtos.AboutDtos
{
    public class CreateAboutDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AboutImage { get; set; }
    }
}
