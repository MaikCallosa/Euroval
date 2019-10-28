using System.Collections.Generic;

namespace Euroval.Entity.Entity
{
    public partial class Deporte: BaseEntity
    {
        public Deporte()
        {
            Pista = new HashSet<Pista>();
        }

        public string Nombre { get; set; }

        public virtual ICollection<Pista> Pista { get; set; }
    }
}
