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
            return await dbContext.Estadios.Include(x => x.estacionamientos).ToListAsync();
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await dbContext.Estadios.AnyAsync(x => x.EstadioID == id);
            if (!exists)
            {
                return NotFound("No se encontro el registro en la base de datos");
            }

            dbContext.Remove(new Estadio()
            {
                EstadioID = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();

        }

    }
}
