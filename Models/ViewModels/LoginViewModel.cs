using System.ComponentModel.DataAnnotations;

namespace AWESOME.Models.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Ingrese el usuario.")]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingrese la contraseña.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}