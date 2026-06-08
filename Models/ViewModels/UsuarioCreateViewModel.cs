using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AWESOME.Models.ViewModels;

public class UsuarioCreateViewModel
{
    [Required(ErrorMessage = "Ingrese el nombre de usuario.")]
    [Display(Name = "Usuario")]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ingrese la contraseña.")]
    [Display(Name = "Contraseña")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Seleccione un rol.")]
    public string Rol { get; set; } = string.Empty;

    public List<SelectListItem> RolesDisponibles { get; set; }
        = new();
}