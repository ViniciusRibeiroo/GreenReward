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

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromServices] AppDataContext context, [FromBody] LoginModel model)
        {
            // Verificar se o modelo é válido
            // if (!ModelState.IsValid)
            // {
            //     return BadRequest("Invalid model");
            // }

            // Verificar as credenciais do usuário
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Senha == model.Senha);

            if (user == null)
            {
                return Unauthorized("Invalid email or password");
            }

            return Ok();
            // Se as credenciais forem válidas, gerar um token JWT
            // var token = GenerateJwtToken(user.Email);
            // Retornar o token JWT como parte da resposta
            // return Ok(new { token });

        }

        // Método para gerar um token JWT
        // private string GenerateJwtToken(string email)
        // {
        //     // Chave secreta usada para assinar o token (deve ser mantida segura)
        //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sua-chave-secreta-aqui"));

        //     // Definir as credenciais do token (incluindo a chave e o algoritmo de assinatura)
        //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //     // Definir as reivindicações do token (neste exemplo, apenas o email do usuário)
        //     var claims = new[]
        //     {
        //         new Claim(JwtRegisteredClaimNames.Sub, email),
        //         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //     };

        //     // Criar o token JWT
        //     var token = new JwtSecurityToken(
        //         issuer: "sua-issuing-url-aqui",
        //         audience: "sua-audience-url-aqui",
        //         claims: claims,
        //         expires: DateTime.Now.AddMinutes(30), // Definir tempo de expiração do token
        //         signingCredentials: creds);

        //     // Retornar o token JWT como uma string
        //     return new JwtSecurityTokenHandler().WriteToken(token);
        // }
    
    }
}

public record LoginModel(string Email, string Senha);
