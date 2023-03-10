using CursoEFCore.Data.Configurations;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //https://www.connectionstrings.com/sql-server/
            optionsBuilder.UseSqlServer("Server=VOSTRO\\MSSQLSERVER01;Database=DB_Pedidos;User Id=teste;Password=874318");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }      
    }
}

//aletrar DB