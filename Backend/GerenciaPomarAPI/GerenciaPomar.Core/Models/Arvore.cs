using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GerenciaPomar.Core.Models
{
    public class Arvore : EntidadeBase
    {
        public string Descricao { get; set; }
        public int Idade 
        {
            get 
            {
                return CalculaIdade();
            }
        }
        public DateTime DataPlantio { get; set; }
        public Guid CodigoEspecie { get; set; }
        [ForeignKey(nameof(CodigoEspecie))]
        public virtual Especie Especie { get; set; }

        public Guid? GrupoArvoreCodigo { get; set; }
        //[ForeignKey(nameof(CodigoEspecie))]
        //public virtual GrupoArvore Grupo { get; set; }

        private int CalculaIdade()
        {
            //data inicial do datetime para calculo de idade
            DateTime dataZero = new DateTime(1, 1, 1);
            //diferença entre a data do plantio e o dia de hoje
            TimeSpan span = DateTime.Now - DataPlantio;
            //data inicial do datetime mais a diferença entre a data do plantio e o dia de hoje
            //assim se consegue a diferença em datetime para se poder extrair o numero de anos
            return (dataZero + span).Year - 1;
        }

        //private const int DiasAno = 365;
        ////metodo alternativo para calculo da idade da arvore
        //private int CalculaIdade2()
        //{
        //    //pegamos a diferença entre a data inicial e a data de plantio
        //    TimeSpan span = DateTime.Now - DataPlantio;
        //    //dividimos o numero de dias por 365 resultando no numero de anos (não funcionaria em anos bissextos?)
        //    return span.Days / DiasAno;
        //}
    }
}
