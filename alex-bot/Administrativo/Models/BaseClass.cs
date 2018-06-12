using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Models
{
    public abstract class BaseClass
    {
        public int Id { get; set; }

        public Administrador IncPor { get; set; }
        public DateTime DataInc { get; set; }

        public Administrador ModPor { get; set; }

        public DateTime DataMod { get; set; }

    }
}
