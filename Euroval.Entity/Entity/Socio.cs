using System.Collections.Generic;

namespace Euroval.Entity.Entity
{
    public partial class Socio : BaseEntity
    {
        public Socio()
        {
            Reserva = new HashSet<Reserva>();
        }

        public string Nombre { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Reserva> Reserva { get; set; }
    }
}
