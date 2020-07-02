using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaPomar.Service
{
    public interface IGenericService<T> where T : class
    {
        Task<IList<T>> BuscarTodos();
        Task<IList<T>> BuscarTodos(int pagina, int total);
        Task<IList<T>> BuscarPorCondicao(Expression<Func<T, bool>> expression);

        void Salvar(T entidade);
        void Excluir(Guid codigo);
    }
}
