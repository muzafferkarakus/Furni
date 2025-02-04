using System.ComponentModel.DataAnnotations;

namespace Furni.WebUI.Dto.AccountDtos
{
    public class CreateNewUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Mail { get; set; }
        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre tekrar alanı zorunludur.")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }
    }
}
