using System;

namespace Euroval.Entity.Entity
{
    public partial class Reserva : BaseEntity
    {
        public int SocioId { get; set; }
        public int PistaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Pista Pista { get; set; }
        public virtual Socio Socio { get; set; }
    }
}
