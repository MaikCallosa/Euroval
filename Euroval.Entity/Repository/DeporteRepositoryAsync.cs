using Euroval.Entity.Entity;

namespace Euroval.Entity.Repository
{
    public class DeporteRepositoryAsync : RepositoryAsync<Deporte>
    {
        public DeporteRepositoryAsync(EurovalContext context, string[] dependeces) : base(context, dependeces)
        {        
        }
    }
}
