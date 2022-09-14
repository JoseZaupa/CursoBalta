using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class LoginViewNodel
    {
        [Required(ErrorMessage = "Informa o E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        public string Password { get; set; }
    }
}