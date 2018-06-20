using System.ComponentModel;

namespace Administrativo.Models
{
    public class Administrador
    {
        [DisplayName("Identificador")]
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Login")]
        public string Login { get; set; }

        [DisplayName("Senha")]
        public string Senha { get; set; }
    }
}
