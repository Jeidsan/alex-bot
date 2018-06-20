using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Models
{
    public class Rede : BaseClass
    {
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Nome curto")]
        public string NomeAbreviado { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Endereços")]
        public ICollection<Endereco> Enderecos { get; set; }
    }
}
