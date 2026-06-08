using AWESOME.Data;
using AWESOME.Models.Entidades;
using AWESOME.Services.Interfaces;

namespace AWESOME.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly SclDbContext _context;

    public AuthService(
        SclDbContext context)
    {
        _context = context;
    }

    public (Usuario? user, string? error)
        ValidateUser(
            string username,
            string password)
    {
        try
        {
            var user = _context.Usuarios
                .FirstOrDefault(x =>
                    x.NombreUsuario == username);

            if (user == null)
            {
                return (
                    null,
                    "El usuario no existe.");
            }

            if (!user.Activo)
            {
                return (
                    null,
                    "El usuario se encuentra inactivo.");
            }

            bool passwordOk =
                BCrypt.Net.BCrypt.Verify(
                    password,
                    user.PasswordHash);

            if (!passwordOk)
            {
                return (
                    null,
                    "La contraseña es incorrecta.");
            }

            return (user, null);
        }
        catch
        {
            return (
                null,
                "No fue posible conectar con SCL.");
        }
    }
}