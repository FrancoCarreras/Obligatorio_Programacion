using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Obligatorio_Programacion.Models;
using Obligatorio_Programacion.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Obligatorio_Programacion.Controllers
{
    public class LoginController : Controller
    {
        private readonly ObligatorioProgramacionContext _context;
        public LoginController(ObligatorioProgramacionContext context)
        {
            this._context = context;
        }

        public IActionResult IndexLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(Usuario user)
        {
            var password = Encriptar.EncriptarPassword(user.Password);
            try
            {
                Usuario usuario = await _context.Usuarios.Where(x => x.Email == user.Email && x.Password == password).FirstOrDefaultAsync();

                if (usuario == null)
                {
                    return BadRequest(new { message = "Usuario o contraseña invalidos" });
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("Correo", usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.IdRol.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Inicio", "Inicio");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Salir()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
