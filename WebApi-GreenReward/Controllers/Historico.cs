using GreenReward.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenReward.Server.Data;

namespace GreenReward.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoCOntroller : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historico>>> GetAllHistoricos([FromServices] AppDataContext context)
        {
            return await context.Historico.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistorico(
            [FromServices] AppDataContext context,
            [FromRoute] int id)
        {
            var historico = await context
                .Historico
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return historico == null ? NotFound() : Ok(historico);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDataContext context,
            [FromBody] Historico historico)
        {
            context.Historico.Add(historico);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHistorico), new { id = historico.Id }, historico);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDataContext context,
            [FromBody] Historico historico,
            [FromRoute] int id)
        {
            if (id != historico.Id)
            {
                return BadRequest();
            }

            context.Historico.Update(historico);
            await context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDataContext context,
            [FromRoute] int id)
        {
            var historico = await context.Historico.FirstOrDefaultAsync(x => x.Id == id);

            if (historico == null)
            {
                return NotFound();
            }

            try
            {
                context.Historico.Remove(historico);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }

}
