using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Models
{
    public class Tema : BaseClass
    {
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Perguntas")]
        public ICollection<Pergunta> Perguntas { get; set; }
    }
}
