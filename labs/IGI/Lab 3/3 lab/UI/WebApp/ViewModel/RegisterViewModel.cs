using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Login { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Пароль не совпадает с потверждением")]
        public string ConfirmPassword { get; set; }
    }
}