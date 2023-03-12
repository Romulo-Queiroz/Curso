using CursoEFCore.Data.Configurations;
using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace CursoEFCore
{
    public class ApplicationContext : DbContext
    {
        public static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole()); //cria um logger para o console
        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //https://www.connectionstrings.com/sql-server/
            optionsBuilder
            .UseLoggerFactory(_logger)  
            .EnableSensitiveDataLogging()  //habilita o log de dados sensíveis
            .UseSqlServer("Server=VOSTRO;Database=master;Trusted_Connection=True;");
           
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }      
    }
}