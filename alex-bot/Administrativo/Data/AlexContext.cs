using Administrativo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Administrativo.Data
{
    public class AlexContext : DbContext
    {
        public AlexContext(DbContextOptions<AlexContext> options) : base(options) { }

        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Anexo> Anexos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<Rede> Redes { get; set; }
        public DbSet<Resposta> Respostas { get; set; }
        public DbSet<Tema> Temas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().ToTable("Administrador");
            modelBuilder.Entity<Anexo>().ToTable("Anexo");
            modelBuilder.Entity<Estado>().ToTable("Estado");
            modelBuilder.Entity<Cidade>().ToTable("Cidade");
            modelBuilder.Entity<Endereco>().ToTable("Endereco");
            modelBuilder.Entity<Resposta>().ToTable("Resposta");
            modelBuilder.Entity<Pergunta>().ToTable("Pergunta");
            modelBuilder.Entity<Rede>().ToTable("Rede");
            modelBuilder.Entity<Tema>().ToTable("Tema");
        }

    }
}
