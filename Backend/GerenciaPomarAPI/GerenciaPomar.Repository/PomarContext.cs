using GerenciaPomar.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciaPomar.Repository
{
    public class PomarContext : DbContext
    {
        public PomarContext(DbContextOptions<PomarContext> options)
            :base(options)
        {
            
        }


        public DbSet<Arvore> Arvores { get; set; }
        public DbSet<Colheita> Colheitas { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<GrupoArvore> GruposArvores { get; set; }
    }
}
