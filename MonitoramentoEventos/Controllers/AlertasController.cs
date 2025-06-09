using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoramentoEventos.Data;
using MonitoramentoEventos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonitoramentoEventos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlertasController(AppDbContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alerta>>> GetAlertas()
        {
           
            return await _context.Alertas
                .Include(a => a.Usuario)
                .Include(a => a.Local)
                .ToListAsync();
        }

        // GET: api/Alertas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> GetAlerta(int id)
        {
            var alerta = await _context.Alertas
                .Include(a => a.Usuario)
                .Include(a => a.Local)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (alerta == null)
            {
                return NotFound();
            }

            return alerta;
        }

       
        [HttpPost]
        public async Task<ActionResult<Alerta>> PostAlerta(Alerta alerta)
        {
            _context.Alertas.Add(alerta);
            await _context.SaveChangesAsync();

           
            return CreatedAtAction(nameof(GetAlerta), new { id = alerta.Id }, alerta);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlerta(int id, Alerta alerta)
        {
            if (id != alerta.Id)
            {
                return BadRequest(); 
            }

            _context.Entry(alerta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent(); 
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlerta(int id)
        {
            var alerta = await _context.Alertas.FindAsync(id);
            if (alerta == null)
            {
                return NotFound();
            }

            _context.Alertas.Remove(alerta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

       
        private bool AlertaExists(int id)
        {
            return _context.Alertas.Any(e => e.Id == id);
        }
    }
}
