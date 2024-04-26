using GreenReward.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenReward.Server.Data;

namespace GreenReward.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialCOntroller : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetAllMaterial([FromServices] AppDataContext context)
        {
            return await context.Material.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMaterial(
            [FromServices] AppDataContext context,
            [FromRoute] int id)
        {
            var material = await context
                .Material
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return material == null ? NotFound() : Ok(material);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDataContext context,
            [FromBody] Material material)
        {
            context.Material.Add(material);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMaterial), new { id = material.Id }, material);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDataContext context,
            [FromBody] Material material,
            [FromRoute] int id)
        {
            if (id != material.Id)
            {
                return BadRequest();
            }

            context.Material.Update(material);
            await context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDataContext context,
            [FromRoute] int id)
        {
            var material = await context.Material.FirstOrDefaultAsync(x => x.Id == id);

            if (material == null)
            {
                return NotFound();
            }

            try
            {
                context.Material.Remove(material);
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
