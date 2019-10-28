using Euroval.Entity.Entity;
using Euroval.Entity.Repository;
using System;
using System.Threading.Tasks;

namespace Euroval.Entity.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        // Crear para todos las entidades un repositorio
        IRepositoryAsync<Deporte> DeporteRepository { get; }

        IRepositoryAsync<Pista> PistaRepository { get; }

        IRepositoryAsync<Reserva> ReservaRepository { get; }

        IRepositoryAsync<Socio> SocioRepository { get; }

        IRepositoryAsync<Usuario> UsuarioRepository { get; }

        Task<int> SaveAsync();



    }
}
