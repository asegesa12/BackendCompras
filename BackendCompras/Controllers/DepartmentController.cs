using BackendCompras.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BackendCompras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                Thread.Sleep(1500);
                var listDept = await _context.department.ToListAsync();
                return Ok(listDept);

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
                var department = await _context.department.FindAsync(id);

                if (department == null)
                {
                    return NotFound();
                }

                return Ok(department);


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
                var department = await _context.department.FindAsync(id);

                if (department == null)
                {
                    return NotFound();
                }

                _context.department.Remove(department);
                await _context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> Post(department department)
        {
            try
            {
             
                _context.Add(department);
                await _context.SaveChangesAsync();
                return CreatedAtAction("Get", new { id = department.Id }, department);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, department department)
        {
            try
            {
                if (id != department.Id)
                {
                    return BadRequest();
                }

                var deptItem = await _context.department.FindAsync(id);

                if (deptItem == null)
                {
                    return NotFound();
                }

                deptItem.nombre = department.nombre;
                deptItem.estado = department.estado;
                


                await _context.SaveChangesAsync();
                return Ok(department);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
