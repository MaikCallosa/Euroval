using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Euroval.Domain.Service;
using Euroval.Domain.Domain;
using Microsoft.AspNetCore.Authorization;

namespace Euroval.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SociosController : ControllerBase
    {
        private readonly SocioServiceAsync _socioService;

        public SociosController(SocioServiceAsync socioService)
        {
            _socioService = socioService;
        }

        // GET: api/Socios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SocioViewModel>>> GetSocio()
        {
            var items = await _socioService.GetAll();
            return Ok(items);
        }

        // GET: api/Socios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SocioViewModel>> GetSocio(int id)
        {
            var socio = await _socioService.GetOne(id);

            if (socio == null)
            {
                return NotFound();
            }

            return Ok(socio);
        }

        // PUT: api/Socios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSocio(int id, [FromBody] SocioViewModel socio)
        {
            if (socio == null || id != socio.Id)
                return BadRequest();

            int val = await _socioService.Update(socio);
            if (val == 0)
                return StatusCode(304);
            else if (val == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");
            else
                return Accepted(socio);
        }

        // POST: api/Socios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SocioViewModel>> PostSocio(SocioViewModel socio)
        {
            if (socio == null)
                return BadRequest();

            var id = await _socioService.Add(socio);
            return Created($"api/Socios/{id}", socio);
        }

        // DELETE: api/Socios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SocioViewModel>> DeleteSocio(int id)
        {
            int val = await _socioService.Remove(id);
            if (val == 0)
                return NotFound();
            else if (val == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");
            else
                return NoContent();
        }
    }
}
