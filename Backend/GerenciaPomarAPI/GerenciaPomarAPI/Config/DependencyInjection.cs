using GerenciaPomar.Repository;
using GerenciaPomar.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciaPomar.API.Config
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped<IColheitaService, ColheitaService>();
            services.AddScoped<IGrupoArvoreService, GrupoArvoreService>();
        }
    }
}
