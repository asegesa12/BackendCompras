using BackendCompras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProveedorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Thread.Sleep(1500);
                var listProveedor = await _context.proveedor.ToListAsync();
                return Ok(listProveedor);

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> get(int id)
        {
            try
            {
                var proveedor = await _context.proveedor.FindAsync(id);

                if (proveedor == null)
                {
                    return NotFound();
                }

                return Ok(proveedor);

              
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
                var proveedor = await _context.proveedor.FindAsync(id);

                if(proveedor == null)
                {
                    return NotFound();
                }

                _context.proveedor.Remove(proveedor);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(Proveedor proveedor)
        {
            try
            {
                proveedor.FechaCreacion = DateTime.Now;
                _context.Add(proveedor);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = proveedor.Id }, proveedor);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Proveedor proveedor)
        {
            try
            {
                if( id != proveedor.Id)
                {
                    return BadRequest();
                }

                var proveedorItem = await _context.proveedor.FindAsync(id);

                if( proveedorItem == null)
                {
                    return NotFound();
                }

                proveedorItem.Cedula = proveedor.Cedula;
                proveedorItem.NombreComercial = proveedor.NombreComercial;
                proveedorItem.Estado = proveedor.Estado;

                await _context.SaveChangesAsync();
                return Ok(proveedor);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
