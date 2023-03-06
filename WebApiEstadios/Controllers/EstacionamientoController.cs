using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEstadios.Entidades;

namespace WebApiEstadios.Controllers
{
    [ApiController]
    [Route("estacionamiento")]
    public class EstacionamientoController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public EstacionamientoController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<List<Estacionamiento>>> GetAll()
        {
            return await _context.Estacionamientos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Estacionamiento>> GetById(int id)
        {
            return await _context.Estacionamientos.FirstOrDefaultAsync(x => x.EstacionamientoID == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Estacionamiento estacionamiento)
        {
            var existeEstadio = await _context.Estadios.AnyAsync(x => x.EstadioID == estacionamiento.EstadioID);

            if (!existeEstadio)
            {
                return BadRequest("No existe el estadio");
            }

            _context.Add(estacionamiento);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Estacionamiento estacionamiento, int id)
        {
            var existeEstac = await _context.Estacionamientos.AnyAsync(x => x.EstadioID == estacionamiento.EstadioID);

            if (!existeEstac)
            {
                return BadRequest("No existe el estacionamiento");
            }

            if(estacionamiento.EstacionamientoID != id)
            {
                return BadRequest("El id del estacionamiento no coincide con el establecido en la url");
            }

            _context.Update(estacionamiento);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exists = await _context.Estacionamientos.AnyAsync(x => x.EstacionamientoID == id);
            if (!exists)
            {
                return NotFound("No se encontro el registro en la base de datos");
            }

            _context.Remove(new Estacionamiento()
            {
                EstacionamientoID = id
            });
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
