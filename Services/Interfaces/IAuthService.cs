using AWESOME.Models.Entidades;

namespace AWESOME.Services.Interfaces;

public interface IAuthService
{
    (Usuario? user, string? error)
        ValidateUser(string username, string password);
}