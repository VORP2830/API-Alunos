using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API_Alunos.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email enválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatoria")]
        [StringLength(20, ErrorMessage = "A {0} deve ter no mínimo {2} e no maximo {1} caracteres.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
