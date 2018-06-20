using System.ComponentModel;

namespace Administrativo.Models
{
    public class Endereco : BaseClass
    {
        [DisplayName("Identificador da rede de acompanhamento")]
        public int RedeId { get; set; }

        [DisplayName("Rede de acompanhamento")]
        public Rede Rede { get; set; }

        [DisplayName("Logradouro")]
        public string Logradouro { get; set; }

        [DisplayName("Número")]
        public string Numero { get; set; }

        [DisplayName("Complemento")]
        public string Complemento { get; set; }

        [DisplayName("Identificador da cidade")]
        public int CidadeId { get; set; }

        [DisplayName("Cidade")]
        public Cidade Cidade { get; set; }
    }
}