using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GerenciaPomar.Core.Models
{
    public class EntidadeBase
    {
        [Key]
        public Guid Codigo { get; set; }

        protected EntidadeBase()
        {
            Codigo = Guid.NewGuid();
        }

        public EntidadeBase(Guid codigo)
        {
            Codigo = codigo;
        }
    }
}
