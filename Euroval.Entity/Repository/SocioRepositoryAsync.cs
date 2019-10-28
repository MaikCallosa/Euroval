using Euroval.Entity.Entity;

namespace Euroval.Entity.Repository
{
    public class SocioRepositoryAsync : RepositoryAsync<Socio>
    {
        public SocioRepositoryAsync(EurovalContext context, string[] dependeces) : base(context, dependeces)
        {
        }
    }
}
