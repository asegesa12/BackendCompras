using BackendCompras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesCompraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdenesCompraController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Thread.Sleep(1500);
                var listOrdenes = await _context.ordenesCompra.ToListAsync();
                return Ok(listOrdenes);

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
                var ordenes = await _context.ordenesCompra.FindAsync(id);

                if (ordenes == null)
                {
                    return NotFound();
                }

                return Ok(ordenes);


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
                var ordenes = await _context.ordenesCompra.FindAsync(id);

                if (ordenes == null)
                {
                    return NotFound();
                }

                _context.ordenesCompra.Remove(ordenes);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(OrdenesCompra ordenes)
        {
            try
            {

                _context.Add(ordenes);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = ordenes.Id }, ordenes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, OrdenesCompra ordenes)
        {
            try
            {
                if (id != ordenes.Id)
                {
                    return BadRequest();
                }

                var ordenesItem = await _context.ordenesCompra.FindAsync(id);

                if (ordenesItem == null)
                {
                    return NotFound();
                    Console.WriteLine(ordenesItem);
                }

                ordenesItem.OrderNumber = ordenes.OrderNumber;
                ordenesItem.estado = ordenes.estado;
                ordenesItem.Articulo = ordenes.Articulo;
                ordenesItem.stock = ordenes.stock;
                ordenesItem.medida = ordenes.medida;
                ordenesItem.CostoUnitario = ordenes.CostoUnitario;
                ordenesItem.FechaOrden = ordenes.FechaOrden;

                await _context.SaveChangesAsync();
                return Ok(ordenes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
