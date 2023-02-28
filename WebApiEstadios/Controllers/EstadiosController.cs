using Microsoft.AspNetCore.Mvc;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("api/estadios")]
    public class EstadiosController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Estadio>> Get() 
        {
            return new List<Estadio>()
            {
                new Estadio() { EstadioID = 1, Equipo = "Rayados"},
                new Estadio() { EstadioID = 2, Equipo = "Tigres" }
            };
        }
    }
}
