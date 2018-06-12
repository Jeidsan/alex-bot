namespace Administrativo.Models
{
    public class Endereco : BaseClass
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public Cidade CidadeId { get; set; }     
    }
}