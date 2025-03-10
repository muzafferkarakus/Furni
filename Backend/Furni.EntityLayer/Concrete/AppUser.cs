﻿using Microsoft.AspNetCore.Identity;

namespace Furni.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
