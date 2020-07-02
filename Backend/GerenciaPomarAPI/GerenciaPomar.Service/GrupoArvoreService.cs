using GerenciaPomar.Core.Models;
using GerenciaPomar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaPomar.Service
{
    public class GrupoArvoreService : IGrupoArvoreService
    {
        private readonly IRepositorioBase<GrupoArvore> repositorioGrupoArvore;
        private readonly IRepositorioBase<Arvore> repositorioArvore;

        public GrupoArvoreService(IRepositorioBase<GrupoArvore> repositorioGrupoArvore, 
            IRepositorioBase<Arvore> repositorioArvore)
        {
            this.repositorioGrupoArvore = repositorioGrupoArvore;
            this.repositorioArvore = repositorioArvore;
        }

        public void Salvar(GrupoArvore grupoArvore)
        {
            var codigosArvores = grupoArvore.Arvores.Select(c => c.Codigo).ToList();
            grupoArvore.Arvores = null;
            
            repositorioGrupoArvore.Salvar(grupoArvore);

            var arvoresExcluir = repositorioArvore.BuscarPorCondicao(c => c.GrupoArvoreCodigo == grupoArvore.Codigo).Result.ToList().Where(c => !codigosArvores.Contains(c.Codigo));
            foreach (var arvore in arvoresExcluir)
            {
                arvore.GrupoArvoreCodigo = null;
                repositorioArvore.Salvar(arvore);
            }
            foreach (var arvore in codigosArvores)
            {
                var entidadeArvoreBanco = repositorioArvore.BuscarPorCondicao(c => c.Codigo == arvore).Result.FirstOrDefault();
                entidadeArvoreBanco.GrupoArvoreCodigo = grupoArvore.Codigo;
                repositorioArvore.Salvar(entidadeArvoreBanco);
            }
        }
    }
}
