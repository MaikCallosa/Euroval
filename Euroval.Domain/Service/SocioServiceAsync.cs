using Euroval.Domain.Domain;
using Euroval.Entity.Entity;
using Euroval.Entity.UnitOfWork;

namespace Euroval.Domain.Service
{
    public class SocioServiceAsync : GenericServiceAsync<SocioViewModel, Socio>
    {
        public SocioServiceAsync(IUnitOfWork unitOfWork) : base(unitOfWork.SocioRepository, unitOfWork)
        {
        }
    }
}
