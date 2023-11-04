using BackendCompras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadMedidaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UnidadMedidaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Thread.Sleep(1500);
                var lisUnidadMedida = await _context.unidadMedida.ToListAsync();
                return Ok(lisUnidadMedida);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            try
            {
                var unidad = await _context.unidadMedida.FindAsync(id);

                if (unidad == null)
                {
                    return NotFound();
                }

                return Ok(unidad);


            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var unidad = await _context.unidadMedida.FindAsync(id);

                if (unidad == null)
                {
                    return NotFound();
                }

                _context.unidadMedida.Remove(unidad);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(UnidadMedidas unidad)
        {
            try
            {
                //proveedor.FechaCreacion = DateTime.Now;
                _context.Add(unidad);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = unidad.Id }, unidad);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, UnidadMedidas unidad)
        {
            try
            {
                if (id != unidad.Id)
                {
                    return BadRequest();
                }

                var unidadItem = await _context.unidadMedida.FindAsync(id);

                if (unidadItem == null)
                {
                    return NotFound();
                }

                unidadItem.descripcion = unidad.descripcion;
                unidadItem.estado = unidad.estado;
               

                await _context.SaveChangesAsync();
                return Ok(unidad);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
