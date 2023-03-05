using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("api/estadios")]
    public class EstadiosController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EstadiosController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]
        public ActionResult<List<Estadio>> Get() 
        {
            return new List<Estadio>()
            {
                new Estadio() { EstadioID = 1, Equipo = "Rayados", Capacidad = 50000 , Ubicacion = "Guadalupe, Nuevo Leon" },
                new Estadio() { EstadioID = 2, Equipo = "Tigres" , Capacidad = 40000 , Ubicacion = "San Nicolas, Nuevo Leon" }
            };
        }

        [HttpPost]
        public async Task<ActionResult> Post(Estadio estadio)
        {
            dbContext.Add(estadio);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("/lista")]
        public async Task<ActionResult<List<Estadio>>> GetAll()
        {
            return await dbContext.Estadios.ToListAsync();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Estadio estadio, int id)
        {
            if(estadio.EstadioID != id)
            {
                return BadRequest("El id del estadio no coincide con el establecido en la url.");
            }

            dbContext.Update(estadio);
            await dbContext.SaveChangesAsync();
            return Ok();

        } 

    }
}
