using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Models
{
    public class Resposta : BaseClass
    {
        public Pergunta PerguntaId { get; set; }
        public string Descricao { get; set; }

        public ICollection<Anexo> Anexos { get; set; }
    }
}
