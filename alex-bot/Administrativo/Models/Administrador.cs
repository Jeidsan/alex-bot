﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Models
{
    public class Administrador : BaseClass
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
