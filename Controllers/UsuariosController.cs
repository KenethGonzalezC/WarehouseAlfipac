using AWESOME.Data;
using AWESOME.Models.Entidades;
using AWESOME.Models.ViewModels;
using AWESOME.Security;
using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AWESOME.Controllers;

[Authorize(Roles = Roles.Administrador)]
public class UsuariosController : Controller
{
    private readonly SclDbContext _context;

    public UsuariosController(
        SclDbContext context)
    {
        _context = context;
    }

    // ==========================
    // LISTADO
    // ==========================

    public async Task<IActionResult> Index()
    {
        var usuarios =
            await _context.Usuarios
                .ToListAsync();

        return View(usuarios);
    }

    // ==========================
    // CREAR
    // ==========================

    public IActionResult Create()
    {
        var model =
            new UsuarioCreateViewModel
            {
                RolesDisponibles =
                    ObtenerRoles()
            };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        UsuarioCreateViewModel model)
    {
        model.RolesDisponibles =
            ObtenerRoles();

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        bool existe =
            await _context.Usuarios.AnyAsync(x =>
                x.NombreUsuario ==
                model.NombreUsuario);

        if (existe)
        {
            ModelState.AddModelError(
                string.Empty,
                "Ya existe un usuario con ese nombre.");

            return View(model);
        }

        var passwordPlano =
            model.Password;

        var usuario =
            new Usuario
            {
                NombreUsuario =
                    model.NombreUsuario,

                PasswordHash =
                    BCrypt.Net.BCrypt.HashPassword(
                        passwordPlano),

                Rol =
                    model.Rol,

                Activo =
                    true,

                FechaCreacion =
                    DateTime.Now
            };

        _context.Usuarios.Add(usuario);

        await _context.SaveChangesAsync();

        TempData["PasswordCreada"] =
            passwordPlano;

        TempData["UsuarioCreado"] =
            usuario.NombreUsuario;

        return RedirectToAction(
            nameof(CreateSuccess));
    }

    public IActionResult CreateSuccess()
    {
        return View();
    }

    // ==========================
    // ACTIVAR / DESACTIVAR
    // ==========================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleActivo(
        int id)
    {
        var usuario =
            await _context.Usuarios.FindAsync(id);

        if (usuario == null)
        {
            return NotFound();
        }

        usuario.Activo =
            !usuario.Activo;

        await _context.SaveChangesAsync();

        return RedirectToAction(
            nameof(Index));
    }

    // ==========================
    // ELIMINAR
    // ==========================

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Eliminar(
        int id)
    {
        var usuario =
            await _context.Usuarios.FindAsync(id);

        if (usuario == null)
        {
            TempData["Error"] =
                "Usuario no encontrado.";

            return RedirectToAction(
                nameof(Index));
        }

        var usuarioActual =
            User.Identity?.Name;

        if (usuario.NombreUsuario ==
            usuarioActual)
        {
            TempData["Error"] =
                "No puede eliminar el usuario autenticado actualmente.";

            return RedirectToAction(
                nameof(Index));
        }

        _context.Usuarios.Remove(usuario);

        await _context.SaveChangesAsync();

        TempData["Success"] =
            $"Usuario '{usuario.NombreUsuario}' eliminado correctamente.";

        return RedirectToAction(
            nameof(Index));
    }

    // ==========================
    // ROLES
    // ==========================

    private List<SelectListItem>
        ObtenerRoles()
    {
        return new List<SelectListItem>
        {
            new()
            {
                Value = Roles.Administrador,
                Text = "Administrador"
            },

            new()
            {
                Value = Roles.Usuario,
                Text = "Usuario"
            },

            new()
            {
                Value = Roles.Digitador,
                Text = "Digitador"
            },

            new()
            {
                Value = Roles.Patio,
                Text = "Patio"
            }
        };
    }
}