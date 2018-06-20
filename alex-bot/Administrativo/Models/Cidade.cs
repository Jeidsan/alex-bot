using System.ComponentModel;

namespace Administrativo.Models
{
    public class Cidade : BaseClass
    {
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Identificador do estado")]
        public int EstadoId { get; set; }

        [DisplayName("Estado")]
        public Estado Estado { get; set; }
    }
}