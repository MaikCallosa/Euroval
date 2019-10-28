using Euroval.Entity.Entity;

namespace Euroval.Entity.Repository
{
    public class ReservaRepositoryAsync : RepositoryAsync<Reserva>
    {
        public ReservaRepositoryAsync(EurovalContext context, string[] dependeces) : base(context, dependeces)
        {
        }
    }
}
