using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Models
{
    public class Rede : BaseClass
    {
        public string Nome { get; set; }
        public string NomeAbreviado { get; set; }
        public string Descricao { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }
    }
}
