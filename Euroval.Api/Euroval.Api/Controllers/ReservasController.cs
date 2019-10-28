using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Euroval.Domain.Service;
using Euroval.Domain.Domain;
using Euroval.Domain.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Euroval.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {

        private readonly ReservaServiceAsync _reservaService;
        private readonly LogicServiceAsync _logicService;

        public ReservasController(ReservaServiceAsync reservaService, LogicServiceAsync logicService)
        {
            _reservaService = reservaService;
            _logicService = logicService;
        }

        // GET: api/Reservas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaViewModel>>> GetReserva()
        {
            var items = await _reservaService.GetAll();
            return Ok(items);
        }

        // GET: api/Reservas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaViewModel>> GetReserva(int id)
        {
            var reserva = await _reservaService.GetOne(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }

        // GET: api/Reservas/listado/2019-10-25
        [HttpGet("listado/{fecha}")]
        public async Task<ActionResult<ReservaViewModel>> ListadoReservas(DateTime fecha)
        {
            var reserva = await _logicService.GetReservasPorFecha(fecha);

            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }

        // PUT: api/Reservas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, [FromBody] ReservaViewModel reserva)
        {
            if (reserva == null || id != reserva.Id)
                return BadRequest();

            int val = await _reservaService.Update(reserva);
            if (val == 0)
                return StatusCode(304);
            else if (val == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");
            else
                return Accepted(reserva);
        }

        // POST: api/Reservas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ReservaViewModel>> PostReserva(ReservaViewModel reserva)
        {
            if (reserva == null)
                return BadRequest();

            var ok = await _reservaService.ValidarReservaPista(reserva.FechaReserva, reserva.PistaId, reserva.SocioId);
            if (ok && 
                reserva.FechaReserva.Hour >= Constants.HoraInicio.Hours &&
                reserva.FechaReserva.Hour <= Constants.HoraFin.Hours)
            {
                var id = await _reservaService.Add(reserva);
                return Created($"api/Reservas/{id}", reserva);
            }
            else
            {
                return StatusCode(412, "No se puede realizar la reserva");
            }
        }

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReservaViewModel>> DeleteReserva(int id)
        {
            int val = await _reservaService.Remove(id);
            if (val == 0)
                return NotFound();
            else if (val == -1)
                return StatusCode(412, "DbUpdateConcurrencyException");
            else
                return NoContent();
        }
    }
}
