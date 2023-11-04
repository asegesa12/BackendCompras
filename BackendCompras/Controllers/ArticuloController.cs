using BackendCompras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArticuloController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Thread.Sleep(1500);
                var listArticulo = await _context.articulo.ToListAsync();
                return Ok(listArticulo);

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
                var articulo = await _context.articulo.FindAsync(id);

                if (articulo == null)
                {
                    return NotFound();
                }

                return Ok(articulo);


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
                var articulo = await _context.articulo.FindAsync(id);

                if (articulo == null)
                {
                    return NotFound();
                }

                _context.articulo.Remove(articulo);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(Articulo articulo)
        {
            try
            {

                _context.Add(articulo);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = articulo.Id }, articulo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, Articulo articulo)
        {
            try
            {
                if (id != articulo.Id)
                {
                    return BadRequest();
                }

                var articuloItem = await _context.articulo.FindAsync(id);

                if (articuloItem == null)
                {
                    return NotFound();
                }

                articuloItem.descripcion = articulo.descripcion;
                articuloItem.marca = articulo.marca;
                articuloItem.UnidadMedida = articulo.UnidadMedida;
                articuloItem.existencia = articulo.existencia;
                articuloItem.estado = articulo.estado;



                await _context.SaveChangesAsync();
                return Ok(articulo);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
