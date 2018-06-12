namespace Administrativo.Models
{
    public class Anexo : BaseClass
    {
        public Resposta RespostaId { get; set; }
        public string Legenda { get; set; }
        public string Descricao { get; set; }
        public string Caminho { get; set; }
        public bool Adequada { get; set; } 
    }
}