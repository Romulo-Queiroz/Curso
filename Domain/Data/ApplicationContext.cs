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
           /*  modelBuilder.Entity<Pedido>()
                .HasMany(p => p.Itens)
                .WithOne(p => p.Pedido)
                .OnDelete(DeleteBehavior.Cascade); */

            modelBuilder.Entity<Cliente>(p =>
            {
                p.ToTable("Clientes");
                p.HasKey(p => p.Id);
                p.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
                p.Property(p => p.Telefone).HasColumnType("CHAR(11)");
                p.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();;
                p.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
                p.Property(p => p.Cidade).HasMaxLength(60).IsRequired();;

                p.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");
            });

            modelBuilder.Entity<Produto>(p =>
            {
                p.ToTable("Produtos");
                p.HasKey(p => p.Id);
                p.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
                p.Property(p => p.Descricao).HasColumnType("VARCHAR(60)")
                p.Property(p => p.Valor).IsRequired();
                p.Property(p => p.TipoProduto).HasConversion<string>();
            });

            modelBuilder.Entity<Pedido>(p =>
            {
                p.ToTable("Pedidos");
                p.HasKey(p => p.Id);
                p.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                p.Property(p => p.StatusPedido).HasConversion<string>();
                p.Property(p => p.TipoFrete).HasConversion<int>();
                p.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

                p.HasMany(p => p.Itens) //Muitos itens
                .WithOne(p => p.Pedido)     // Para um pedido
                .OnDelete(DeleteBehavior.Cascade);               //tipo de restrição: se eu deletar um pedido os itens do pedido será deletado
            });
            modelBuilder.Entity<PedidoItem>(p =>
            {
                p.ToTable("PedidoItens");
                p.HasKey(p => p.Id);
                p.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();   //HasDefaultValueSql("1") - informa o valor padrão de QTD de itens
                p.Property(p => p.Valor).IsRequired();
                p.Property(p => p.Desconto).IsRequired();
            });
        }
    }
}

//aletrar DB