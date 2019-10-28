using System;
using System.Threading.Tasks;
using Euroval.Entity.Entity;
using Euroval.Entity.Repository;
using Microsoft.EntityFrameworkCore;

namespace Euroval.Entity.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepositoryAsync<Deporte> _deporteRepository;
        private IRepositoryAsync<Pista> _pistaRepository;
        private IRepositoryAsync<Reserva> _reservaRepository;
        private IRepositoryAsync<Socio> _socioRepository;
        private IRepositoryAsync<Usuario> _usuarioRepository;

        internal EurovalContext _context;
        private bool _disposed;

        public UnitOfWork(EurovalContext context)
        {
            _context = context;
            _disposed = false;
        }
        public IRepositoryAsync<Deporte> DeporteRepository {

            get 
            {
                if (_deporteRepository == null)
                {
                    _deporteRepository = new DeporteRepositoryAsync(_context, new string[] { "" });
                }

                return _deporteRepository;
            }

        }

        public IRepositoryAsync<Pista> PistaRepository
        {

            get
            {
                if (_pistaRepository == null)
                {
                    _pistaRepository = new PistaRepositoryAsync(_context, new string[] { "Deporte" });
                }

                return _pistaRepository;
            }

        }

        public IRepositoryAsync<Reserva> ReservaRepository
        {

            get
            {
                if (_reservaRepository == null)
                {
                    _reservaRepository = new RepositoryAsync<Reserva>(_context, new string[]{ "Socio", "Pista", "Pista.Deporte" });
                }

                return _reservaRepository;
            }

        }

        public IRepositoryAsync<Socio> SocioRepository
        {

            get
            {
                if (_socioRepository == null)
                {
                    _socioRepository = new RepositoryAsync<Socio>(_context, new string[] { });
                }

                return _socioRepository;
            }

        }

        public IRepositoryAsync<Usuario> UsuarioRepository
        {

            get
            {
                if (_usuarioRepository == null)
                {
                    _usuarioRepository = new RepositoryAsync<Usuario>(_context, new string[] { });
                }

                return _usuarioRepository;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return -1;
            }
        }
    }
}
