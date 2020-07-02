using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GerenciaPomar.API.Config
{
    public static class Swagger
    {
        public static void ConfigurarSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "",
                        Version = "",
                        Description = "",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Name = "Lucas Venturella",
                            Email = "lucas.venturella@hotmail.com"
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
