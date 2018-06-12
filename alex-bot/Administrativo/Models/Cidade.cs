namespace Administrativo.Models
{
    public class Cidade : BaseClass
    {
        public string Nome { get; set; }
        public Estado EstadoId { get; set; }
    }
}