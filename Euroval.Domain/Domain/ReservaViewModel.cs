using System;

namespace Euroval.Domain.Domain
{
    public class ReservaViewModel : BaseDomain
    {

        public int SocioId { get; set; }

        public int PistaId { get; set; }

        public DateTime FechaReserva { get; set; }

        public int Duracion { get; set; }

        public virtual SocioViewModel Socio { get; set; }

        public virtual PistaViewModel Pista { get; set; }
    }
}
