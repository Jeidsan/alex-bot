using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Models
{
    public class Resposta : BaseClass
    {
        [DisplayName("Identificador da pergunta")]
        [Required(ErrorMessage = "Você precisa informar uma pergunta.")]
        public int PerguntaId { get; set; }

        [DisplayName("Pergunta")]
        public Pergunta Pergunta { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Anexos")]
        public ICollection<Anexo> Anexos { get; set; }

        [DisplayName("Nº de anexos")]
        public int QuantidadeAnexos { get { return Anexos == null ? 0 : Anexos.Count(); } }
    }
}
