using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Newtonsoft.Json;
using Obligatorio_Programacion.Models;
using System.Web.Http;

namespace Obligatorio_Programacion.Controllers
{
    public class CotizacionController : Controller
    {

        public CotizacionController()
        {

        }

        public IActionResult Index()
        {
            APICotizacion.APICotizacion apiCotizacion = new APICotizacion.APICotizacion();
            string resultado = apiCotizacion.getCotizacion();

            Moneda cotizacion = JsonConvert.DeserializeObject<Moneda>(resultado);
            double peso = cotizacion.Quotes.Usduyu.Value;
            return View(peso);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult Convertir(int numero)
        {
            return (IHttpActionResult)Json(numero);
        }

    }
}
