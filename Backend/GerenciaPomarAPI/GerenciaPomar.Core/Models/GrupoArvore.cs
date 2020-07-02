using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciaPomar.Core.Models
{
    public class GrupoArvore : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Arvore> Arvores { get; set; }
    }
}
