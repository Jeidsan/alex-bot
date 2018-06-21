using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Administrativo.Models
{
    public class Pergunta : BaseClass
    {
        [DisplayName("Identificador do tema")]
        [Required(ErrorMessage = "Você precisa escolher um tema.")]       
        public int TemaId { get; set; }

        [DisplayName("Tema")]
        public Tema Tema { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "É necessário informar uma descrição para a pergunta.")]
        public string Descricao { get; set; }

        [DisplayName("Nº de respostas")]
        public int QuantidadeRespostas { get { return Respostas == null ? 0 : Respostas.Count(); } }

        [DisplayName("Respostas")]
        public ICollection<Resposta> Respostas { get; set; }
    }
}
