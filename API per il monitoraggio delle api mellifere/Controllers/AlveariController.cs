using API_per_il_monitoraggio_delle_api_mellifere.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace API_per_il_monitoraggio_delle_api_mellifere.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlveariController : ControllerBase
    {
        private readonly ContestoApiario _contesto;

        public AlveariController(ContestoApiario contesto)
        {
            _contesto = contesto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alveare>>> OttieniAlveari()
        {
            return await _contesto.Alveari.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alveare>> OttieniAlveare(int id)
        {
            var alveare = await _contesto.Alveari.FindAsync(id);

            if (alveare == null)
            {
                return NotFound();
            }

            return alveare;
        }

        [HttpPost]
        public async Task<ActionResult<Alveare>> CreaAlveare(Alveare alveare)
        {
            _contesto.Alveari.Add(alveare);
            await _contesto.SaveChangesAsync();

            return CreatedAtAction(nameof(OttieniAlveare), new { id = alveare.Id }, alveare);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AggiornaAlveare(int id, Alveare alveare)
        {
            if (id != alveare.Id)
            {
                return BadRequest();
            }

            _contesto.Entry(alveare).State = EntityState.Modified;

            try
            {
                await _contesto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlveareEsiste(id))
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
        public async Task<IActionResult> EliminaAlveare(int id)
        {
            var alveare = await _contesto.Alveari.FindAsync(id);
            if (alveare == null)
            {
                return NotFound();
            }

            _contesto.Alveari.Remove(alveare);
            await _contesto.SaveChangesAsync();

            return NoContent();
        }

        private bool AlveareEsiste(int id)
        {
            return _contesto.Alveari.Any(e => e.Id == id);
        }
    }

}
