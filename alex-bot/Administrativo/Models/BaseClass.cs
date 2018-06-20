using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Models
{
    public abstract class BaseClass
    {     
        [Key]
        [DisplayName("Identificador")]
        [Column("Id")]
        public int Id { get; set; }
        
        [DisplayName("Cadastrado por")]
        public Administrador IncPor { get; set; }

        [DisplayName("Data de cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = false, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "--")]
        public DateTime DataInc { get; set; }

        [DisplayName("Modificado por")]
        public Administrador ModPor { get; set; }

        [DisplayName("Data da modificação")]
        [DisplayFormat(ApplyFormatInEditMode = true, ConvertEmptyStringToNull = false, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "--")]
        public DateTime DataMod { get; set; }
    }
}
