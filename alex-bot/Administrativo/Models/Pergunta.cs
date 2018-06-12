using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Models
{
    public class Pergunta : BaseClass
    {
        public Tema TemaId { get; set; }
        public string Descricao { get; set; }

        public ICollection<Resposta> Respostas { get; set; }

    }
}
