using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Obligatorio_Programacion.Controllers
{
    [Authorize]
    public class InicioController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }
    }
}
