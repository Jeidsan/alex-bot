using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Data
{
    public class DbInitializer
    {
        public static void Initialize(AlexContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
