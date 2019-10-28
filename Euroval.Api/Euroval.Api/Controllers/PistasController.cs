using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Euroval.Domain.Service;
using Euroval.Domain.Domain;

namespace Euroval.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PistasController : ControllerBase
    {

        private readonly PistaServiceAsync _pistaService;
        private readonly LogicServiceAsync _logicService;

        public PistasController(PistaServiceAsync pistaService, LogicServiceAsync logicService)
        {
            _pistaService = pistaService;
            _logicService = logicService;
        }

        // GET: api/Pistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PistaViewModel>>> GetPista()
        {
            var items = await _pistaService.GetAll();
            return Ok(items);
        }

        // GET: api/Pistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PistaViewModel>> GetPista(int id)
        {
            var pista = await _pistaService.GetOne(id);

            if (pista == null)
            {
                return NotFound();
            }

            return Ok(pista);
        }

        // GET: api/Pistas/buscador/2019-10-25/1/2
        [HttpGet("buscador/{fecha}/{idDeporte}/{idSocio}")]
        public async Task<ActionResult<PistasDisponiblesViewModel>> BuscadorPistas(DateTime fecha, int idDeporte, int idSocio)
        {
            var buscadorPistas = await _logicService.GetPistasDisponibles(fecha, idDeporte, idSocio);

            if (buscadorPistas == null)
            {
                return NotFound();
            }

            return Ok(buscadorPistas);
        }

        // PUT: api/Pistas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPista(int id, [FromBody] PistaViewModel pista)
        {
            if (pista == null || id != pista.Id)
                return BadRequest();

            int val = await _pistaService.Update(pista);
            if (val == 0)
                return StatusCode(304);
            else if (val == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");
            else
                return Accepted(pista);
        }

        // POST: api/Pistas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<PistaViewModel>> PostPista(PistaViewModel pista)
        {
            if (pista == null)
                return BadRequest();

            var id = await _pistaService.Add(pista);
            return Created($"api/Pistas/{id}", pista);
        }

        // DELETE: api/Pistas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PistaViewModel>> DeletePista(int id)
        {
            int val = await _pistaService.Remove(id);
            if (val == 0)
                return NotFound();
            else if (val == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");
            else
                return NoContent();
        }
    }
}
