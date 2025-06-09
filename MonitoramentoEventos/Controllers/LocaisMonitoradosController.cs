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
    public class LocaisMonitoradosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LocaisMonitoradosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalMonitorado>>> GetLocaisMonitorados()
        {
            return await _context.LocaisMonitorados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocalMonitorado>> GetLocalMonitorado(int id)
        {
            var localMonitorado = await _context.LocaisMonitorados.FindAsync(id);

            if (localMonitorado == null)
            {
                return NotFound();
            }

            return localMonitorado;
        }

        [HttpPost]
        public async Task<ActionResult<LocalMonitorado>> PostLocalMonitorado(LocalMonitorado localMonitorado)
        {
            _context.LocaisMonitorados.Add(localMonitorado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLocalMonitorado), new { id = localMonitorado.Id }, localMonitorado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalMonitorado(int id, LocalMonitorado localMonitorado)
        {
            if (id != localMonitorado.Id)
            {
                return BadRequest();
            }

            _context.Entry(localMonitorado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalMonitoradoExists(id))
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
        public async Task<IActionResult> DeleteLocalMonitorado(int id)
        {
            var localMonitorado = await _context.LocaisMonitorados.FindAsync(id);
            if (localMonitorado == null)
            {
                return NotFound();
            }

            _context.LocaisMonitorados.Remove(localMonitorado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalMonitoradoExists(int id)
        {
            return _context.LocaisMonitorados.Any(e => e.Id == id);
        }
    }
}