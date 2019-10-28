using Euroval.Domain.Domain;
using Euroval.Entity.Entity;
using Euroval.Entity.UnitOfWork;

namespace Euroval.Domain.Service
{
    public class DeporteServiceAsync : GenericServiceAsync<DeporteViewModel, Deporte>
    {

        public DeporteServiceAsync(IUnitOfWork unitOfWork) : base(unitOfWork.DeporteRepository, unitOfWork)
        {
        }



    }
}
