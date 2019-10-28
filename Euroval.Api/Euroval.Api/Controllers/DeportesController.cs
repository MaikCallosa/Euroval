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
    public class DeportesController : ControllerBase
    {

        private readonly DeporteServiceAsync _deporteService;

        public DeportesController(DeporteServiceAsync deporteServiceAsync)
        {
            _deporteService = deporteServiceAsync;
        }

        // GET: api/Deportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeporteViewModel>>> GetDeporte()
        {
            var items = await _deporteService.GetAll();
            return Ok(items);
        }

        // GET: api/Deportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeporteViewModel>> GetDeporte(int id)
        {
            var deporte = await _deporteService.GetOne(id);

            if (deporte == null)
            {
                return NotFound();
            }

            return Ok(deporte);
        }

        // PUT: api/Deportes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeporte(int id, [FromBody] DeporteViewModel deporte)
        {
            if (deporte == null || id != deporte.Id)
                return BadRequest();

            int val = await _deporteService.Update(deporte);
            if (val == 0)
                return StatusCode(304);
            else if (val == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");
            else
                return Accepted(deporte);
        }

        // POST: api/Deportes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DeporteViewModel>> PostDeporte(DeporteViewModel deporte)
        {
            if (deporte == null)
                return BadRequest();

            var id = await _deporteService.Add(deporte);
            return Created($"api/Deportes/{id}", deporte);
        }

        // DELETE: api/Deportes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeporteViewModel>> DeleteDeporte(int id)
        {
            int val = await _deporteService.Remove(id);
            if (val == 0)
                return NotFound();
            else if (val == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");
            else
                return NoContent();
        }
    }
}
