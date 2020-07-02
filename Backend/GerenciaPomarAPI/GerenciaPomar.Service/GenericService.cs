using GerenciaPomar.Core.Models;
using GerenciaPomar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaPomar.Service
{
    public class GenericService<T> : IGenericService<T> where T : EntidadeBase
    {
        private readonly IRepositorioBase<T> repositorio;

        public GenericService(IRepositorioBase<T> repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<IList<T>> BuscarPorCondicao(Expression<Func<T, bool>> expression)
        {
            return repositorio.BuscarPorCondicao(expression);
        }

        public Task<IList<T>> BuscarTodos()
        {
            return repositorio.BuscarTodos();
        }

        public Task<IList<T>> BuscarTodos(int pagina, int total)
        {
            return repositorio.BuscarTodos(pagina, total);
        }

        public void Excluir(Guid codigo)
        {
            repositorio.Excluir(codigo);
        }

        public void Salvar(T entidade)
        {
            repositorio.Salvar(entidade);
        }
    }
}
