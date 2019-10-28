using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Euroval.Domain.Service;
using Euroval.Domain.Domain;
using Microsoft.AspNetCore.Authorization;

namespace Euroval.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioServiceAsync _usuarioService;

        public UsuariosController(UsuarioServiceAsync usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UsuarioViewModel modelo)
        {
            var user = await _usuarioService.Authenticate(modelo.NombreUsuario, modelo.Contrasenya);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }


        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioViewModel>>> GetUsuario()
        {
            var items = await _usuarioService.GetAll();
            return Ok(items);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetOne(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] UsuarioViewModel usuario)
        {
            if (usuario == null || id != usuario.Id)
                return BadRequest();

            int val = await _usuarioService.Update(usuario);
            if (val == 0)
                return StatusCode(304);
            else if (val == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");
            else
                return Accepted(usuario);
        }

        
        // POST: api/Usuarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("Crear")]
        public async Task<ActionResult<UsuarioViewModel>> PostUsuario(UsuarioViewModel usuario)
        {
            if (usuario == null)
                return BadRequest();

            var id = await _usuarioService.Add(usuario);
            return Created($"api/Usuarios/{id}", usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioViewModel>> DeleteUsuario(int id)
        {
            int val = await _usuarioService.Remove(id);
            if (val == 0)
                return NotFound();
            else if (val == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");
            else
                return NoContent();
        }
    }
}
