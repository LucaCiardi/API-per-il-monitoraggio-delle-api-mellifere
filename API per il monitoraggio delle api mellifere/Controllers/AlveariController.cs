using API_per_il_monitoraggio_delle_api_mellifere.Models;
using API_per_il_monitoraggio_delle_api_mellifere.Services.DTOs;
using API_per_il_monitoraggio_delle_api_mellifere.Services.Monitoring;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // GET: api/Alveari
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alveare>>> OttieniAlveari()
        {
            return await _contesto.Alveari.ToListAsync();
        }

        // GET: api/Alveari/5
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

        // POST: api/Alveari
        [HttpPost]
        public async Task<ActionResult<Alveare>> CreaAlveare(Alveare alveare)
        {
            _contesto.Alveari.Add(alveare);
            await _contesto.SaveChangesAsync();

            return CreatedAtAction(nameof(OttieniAlveare), new { id = alveare.Id }, alveare);
        }

        // PUT: api/Alveari/5
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

        // DELETE: api/Alveari/5
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
        private async Task<List<double>> GetLast24HoursTemperatures(int alveareId)
        {
            var ventiquattroOreFA = DateTime.Now.AddHours(-24);
            return await _contesto.Misurazioni
                .Where(m => m.AlveareId == alveareId && m.Timestamp >= ventiquattroOreFA)
                .OrderBy(m => m.Timestamp)
                .Select(m => m.Temperatura)
                .ToListAsync();
        }

        private async Task<List<double>> GetLast24HoursHumidity(int alveareId)
        {
            var ventiquattroOreFA = DateTime.Now.AddHours(-24);
            return await _contesto.Misurazioni
                .Where(m => m.AlveareId == alveareId && m.Timestamp >= ventiquattroOreFA)
                .OrderBy(m => m.Timestamp)
                .Select(m => m.Umidita)
                .ToListAsync();
        }

        private async Task<List<double>> GetLast24HoursBeeActivity(int alveareId)
        {
            var ventiquattroOreFA = DateTime.Now.AddHours(-24);
            return await _contesto.Misurazioni
                .Where(m => m.AlveareId == alveareId && m.Timestamp >= ventiquattroOreFA)
                .OrderBy(m => m.Timestamp)
                .Select(m => m.AttivitaApi)
                .ToListAsync();
        }

        [HttpGet("{id}/status")]
        public async Task<ActionResult<HiveStatus>> GetHiveStatus(int id)
        {
            var alveare = await _contesto.Alveari.FindAsync(id);
            if (alveare == null)
            {
                return NotFound();
            }

            var temperatures = await GetLast24HoursTemperatures(id);
            var humidityLevels = await GetLast24HoursHumidity(id);
            var beeActivity = await GetLast24HoursBeeActivity(id);

            if (temperatures.Count == 0 && humidityLevels.Count == 0 && beeActivity.Count == 0)
            {
                return NotFound("No data available for the last 24 hours for this hive.");
            }

            var hiveStatus = HiveMonitoringSystem.MonitorHive(temperatures, humidityLevels, beeActivity);
            return hiveStatus;
        }

    }
}
