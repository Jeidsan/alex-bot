using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Models
{
    public class Tema : BaseClass
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public ICollection<Pergunta> Perguntas { get; set; }
    }
}
