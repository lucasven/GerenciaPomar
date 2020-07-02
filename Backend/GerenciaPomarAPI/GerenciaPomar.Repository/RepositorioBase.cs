using GerenciaPomar.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaPomar.Repository
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeBase
    {
        private readonly PomarContext context;
        public DbSet<T> entidades;

        public RepositorioBase(PomarContext context)
        {
            this.context = context;
            entidades = context.Set<T>();
        }

        public void Adicionar(T entidade)
        {
            try
            {
                context.Entry(entidade).State = EntityState.Added;
                entidades.Add(entidade);

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Salvar(T entidade)
        {
            try
            {
                var entidadeBanco = entidades.Where(c => c.Codigo == entidade.Codigo).FirstOrDefault();

                if (entidadeBanco != null)
                {
                    context.Entry(entidadeBanco).State = EntityState.Detached;
                    Atualizar(entidade);
                }
                else
                    Adicionar(entidade);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Atualizar(T entidade)
        {
            try
            {
                entidades.Update(entidade);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<IList<T>> BuscarPorCondicao(Expression<Func<T, bool>> expression)
        {
            return await entidades.Where(expression).ToListAsync();
        }

        public async Task<IList<T>> BuscarTodos()
        {
            return await entidades.ToListAsync();
        }

        public async Task<IList<T>> BuscarTodos(int pagina, int total)
        {
            return await entidades.Skip(pagina > 0 ? (pagina - 1) * total : 0).Take(total).ToListAsync();
        }

        public void Excluir(Guid codigo)
        {
            try
            {
                var entidade = entidades.Where(c => c.Codigo == codigo).FirstOrDefault();
                entidades.Remove(entidade);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
