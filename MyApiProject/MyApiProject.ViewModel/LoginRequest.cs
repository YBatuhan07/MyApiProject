using System.ComponentModel.DataAnnotations;

namespace MyApiProject.ViewModel
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Kullanıcı Adı zorunludur.")]
        [StringLength(50, ErrorMessage = "Kullanıcı Adı 50 karakterden fazla olamaz.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifre en az 6, en fazla 100 karakter uzunluğunda olmalıdır.")]
        public string Password { get; set; }
    }
}
