using Microsoft.AspNetCore.Mvc;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("api/estacionamiento")]
    public class EstacionamientoController : ControllerBase
    {
        [HttpGet]
        public ActionResult <Estacionamiento> Get()
        {
            return new Estacionamiento() { EstacionamientoID = 1, Capacidad = 10000, PrecioHora = 50, EstadioID = 1 };
        }
    }
}
