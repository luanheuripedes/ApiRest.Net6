using Domain.Entities;
using Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class ManagerContext : DbContext
    {
        public ManagerContext()
        {
            
        }

        //Recebo o meu Db Context por depedencia
        public ManagerContext(DbContextOptions options) : base(options)
        {
        }

        //Configuração com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = "server=localhost;port=3306;database=UserManagerApi;user=root;password=123456789";

            optionsBuilder.UseMySql(connection,ServerVersion.AutoDetect(connection));
        }

        //É UMA TABELA NO BD DA CLASSE USER
        public virtual DbSet<Usuario> Usuarios { get; set; }


        //Aplicando a configuração do UsuarioMap
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
