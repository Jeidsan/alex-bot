using System.ComponentModel;

namespace Administrativo.Models
{
    public class Anexo : BaseClass
    {
        [DisplayName("Identificador da resposta")]
        public int RespostaId { get; set; }

        [DisplayName("Resposta")]
        public Resposta Resposta { get; set; }

        [DisplayName("Legenda")]
        public string Legenda { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [DisplayName("Caminho")]
        public string Caminho { get; set; }

        [DisplayName("Adequada")]
        public bool Adequada { get; set; } 
    }
}