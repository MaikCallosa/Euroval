using Euroval.Domain.Domain;
using Euroval.Entity.Entity;
using Euroval.Entity.UnitOfWork;

namespace Euroval.Domain.Service
{
    public class PistaServiceAsync : GenericServiceAsync<PistaViewModel, Pista>
    {
        public PistaServiceAsync(IUnitOfWork unitOfWork) : base(unitOfWork.PistaRepository, unitOfWork)
        {
        }
    }
}
