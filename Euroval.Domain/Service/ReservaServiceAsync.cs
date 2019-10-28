using Euroval.Domain.Domain;
using Euroval.Domain.Helpers;
using Euroval.Entity.Entity;
using Euroval.Entity.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Euroval.Domain.Service
{
    public class ReservaServiceAsync : GenericServiceAsync<ReservaViewModel, Reserva>
    {
        public ReservaServiceAsync(IUnitOfWork unitOfWork) : base(unitOfWork.ReservaRepository, unitOfWork)
        {
        }

        public async Task<bool> ValidarReservaPista(DateTime fecha, int idPista, int idSocio)
        {
            return !(await _repository.Get(x => x.FechaInicio == fecha && x.PistaId == idPista).ConfigureAwait(false)).Any() &&
                (await _repository.Get(x => x.SocioId == idSocio && x.FechaInicio.Date == fecha.Date).ConfigureAwait(false)).Count() < Constants.MaxReservas;
        }
    }
}
