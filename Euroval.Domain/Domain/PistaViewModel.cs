namespace Euroval.Domain.Domain
{
    public class PistaViewModel : BaseDomain
    {
        public string Nombre { get; set; }

        public int DeporteId { get; set; }

        public virtual DeporteViewModel Deporte { get; set; }
    }
}
