using Euroval.Entity.Entity;

namespace Euroval.Entity.Repository
{
    public class PistaRepositoryAsync : RepositoryAsync<Pista>
    {
        public PistaRepositoryAsync(EurovalContext context, string[] dependeces) : base(context, dependeces)
        {
        }
    }
}
