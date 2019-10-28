using System;

namespace Euroval.Domain.Domain
{
    public class PistasDisponiblesViewModel
    {
        public PistasDisponiblesViewModel(int idPista, string nombrePista, DateTime fechaInicio)
        {
            IdPista = idPista;
            NombrePista = nombrePista;
            FechaInicio = fechaInicio;
        }

        public int IdPista { get; set; }

        public string NombrePista { get; set; }

        public DateTime FechaInicio { get; set; }
    }
}
