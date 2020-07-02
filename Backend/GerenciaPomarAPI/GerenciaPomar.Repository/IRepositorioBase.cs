using GerenciaPomar.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaPomar.Repository
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        Task<IList<T>> BuscarTodos();
        Task<IList<T>> BuscarTodos(int pagina, int total);
        Task<IList<T>> BuscarPorCondicao(Expression<Func<T, bool>> expression);

        public void Salvar(T entidade);
        void Excluir(Guid codigo);
    }
}
