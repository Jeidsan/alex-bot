using System.ComponentModel;

namespace Administrativo.Models
{
    public class Estado : BaseClass
    {
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Unidade Federativa")]
        public string UF { get; set; }
    }
}