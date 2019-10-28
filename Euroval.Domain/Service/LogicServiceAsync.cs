using Euroval.Domain.Domain;
using Euroval.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euroval.Domain.Service
{
    public class LogicServiceAsync
    {
        private readonly PistaServiceAsync _pistaService;

        private readonly ReservaServiceAsync _reservaService;

        public LogicServiceAsync(
            PistaServiceAsync pistaService, 
            ReservaServiceAsync reservaService)
        {
            _pistaService = pistaService;

            _reservaService = reservaService;
        }

        public async Task<IEnumerable<PistasDisponiblesViewModel>> GetPistasDisponibles(DateTime fecha, int idDeporte, int idSocio)
        {
            var pistasDisponibles = new List<PistasDisponiblesViewModel>();

            var pistasDeporte = await _pistaService.Get(p => p.DeporteId == idDeporte);

            var reservasSocioFecha = (await _reservaService.Get(r => r.FechaInicio.Date == fecha.Date && r.SocioId == idSocio).ConfigureAwait(false)).ToList();

            if (reservasSocioFecha.Count < Constants.MaxReservas)
            {
                foreach (var pista in pistasDeporte)
                {
                    var reservas = await _reservaService.Get(r => r.FechaInicio.Date == fecha.Date && r.PistaId == pista.Id);

                    pistasDisponibles.AddRange(ObtenerHorariosDisponiblesPista(
                        fecha, 
                        pista, 
                        reservas));
                }
            }
            return await Task.FromResult(pistasDisponibles);
        }

        private IEnumerable<PistasDisponiblesViewModel> ObtenerHorariosDisponiblesPista(DateTime fecha, PistaViewModel pista, IEnumerable<ReservaViewModel> reservas) 
        {
            var listaPistasDisponibles = new List<PistasDisponiblesViewModel>();

            for (int i = Constants.HoraInicio.Hours; i <= Constants.HoraFin.Hours; i++)
            {
                var r = reservas.SingleOrDefault(p => p.FechaReserva.Hour == i);
                if (r == null)
                {
                    listaPistasDisponibles.Add(new PistasDisponiblesViewModel(
                        pista.Id, 
                        pista.Nombre, 
                        new DateTime(fecha.Year, fecha.Month, fecha.Day, i, 0, 0)
                        ));
                }
            }

            return listaPistasDisponibles;
        }
        public async Task<IEnumerable<ReservaViewModel>> GetReservasPorFecha(DateTime fecha)
        {
            return await _reservaService.Get(p => p.FechaInicio.Date == fecha.Date);
        }
    }
}
