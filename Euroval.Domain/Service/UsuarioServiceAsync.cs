using Euroval.Domain.Domain;
using Euroval.Domain.Helpers;
using Euroval.Entity.Entity;
using Euroval.Entity.UnitOfWork;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Euroval.Domain.Service
{
    public class UsuarioServiceAsync : GenericServiceAsync<UsuarioViewModel, Usuario>
    {
        private readonly AppSettings _appSettings;
        public UsuarioServiceAsync(IUnitOfWork unitOfWork) : base(unitOfWork.UsuarioRepository, unitOfWork)
        {
        }

        public UsuarioServiceAsync(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings) : this(unitOfWork)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<UsuarioViewModel> Authenticate(string username, string password)
        {
            var user = await _repository.GetOne(x => x.NombreUsuario == username && x.Contrasenya == password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            var userVm = new UsuarioViewModel()
            {
                Id = user.Id,
                NombreUsuario = user.NombreUsuario,
                Token = tokenHandler.WriteToken(token)
            };

            return userVm.WithoutPassword();
        }
    }
}
