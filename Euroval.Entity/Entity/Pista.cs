using System.Collections.Generic;

namespace Euroval.Entity.Entity
{
    public partial class Pista: BaseEntity
    {
        public Pista()
        {
            Reserva = new HashSet<Reserva>();
        }

        public string Nombre { get; set; }
        public int DeporteId { get; set; }

        public virtual Deporte Deporte { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
