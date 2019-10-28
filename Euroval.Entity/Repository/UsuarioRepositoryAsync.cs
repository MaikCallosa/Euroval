using Euroval.Entity.Entity;

namespace Euroval.Entity.Repository
{
    public class UsuarioRepositoryAsync : RepositoryAsync<Usuario>
    {
        public UsuarioRepositoryAsync(EurovalContext context, string[] dependeces) : base(context, dependeces)
        {
        }
    }
}
