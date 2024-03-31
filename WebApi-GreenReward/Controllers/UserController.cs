using GreenReward.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GreenReward.Server.Data;
using System.Collections.Generic;

namespace GreenReward.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers([FromServices] AppDataContext context)
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(
            [FromServices] AppDataContext context,
            [FromRoute] int id)
        {
            var user = await context
                .Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return user == null ? NotFound() : Ok(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDataContext context,
            [FromBody] User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDataContext context,
            [FromBody] User user,
            [FromRoute] int id)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            context.Users.Update(user);
            await context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDataContext context,
            [FromRoute] int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                context.Users.Remove(user);
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
