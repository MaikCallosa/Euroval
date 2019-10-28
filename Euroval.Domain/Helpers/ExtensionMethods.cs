using Euroval.Domain.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Euroval.Domain.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<UsuarioViewModel> WithoutPasswords(this IEnumerable<UsuarioViewModel> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static UsuarioViewModel WithoutPassword(this UsuarioViewModel user)
        {
            user.Contrasenya = null;
            return user;
        }
    }
}
