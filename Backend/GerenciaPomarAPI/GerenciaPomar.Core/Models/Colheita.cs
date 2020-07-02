using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GerenciaPomar.Core.Models
{
    public class Colheita : EntidadeBase
    {
        public string Informacoes { get; set; }
        public DateTime DataColheita { get; set; }
        public double PesoBruto { get; set; }

        [ForeignKey(nameof(CodigoArvore))]
        public virtual Arvore Arvore { get; set; }
        public Guid CodigoArvore { get; set; }

        [ForeignKey(nameof(CodigoGrupoArvore))]
        public virtual GrupoArvore GrupoArvore { get; set; }
        public Guid CodigoGrupoArvore { get; set; }
    }
}
