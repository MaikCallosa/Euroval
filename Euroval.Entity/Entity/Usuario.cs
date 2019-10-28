namespace Euroval.Entity.Entity
{
    public partial class Usuario : BaseEntity
    {
        public string NombreUsuario { get; set; }
        public string Contrasenya { get; set; }
        public string Token { get; set; }
    }
}
