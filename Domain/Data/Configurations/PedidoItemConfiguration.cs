using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        void IEntityTypeConfiguration<PedidoItem>.Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
                builder.HasKey(p => p.Id);
                builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();   //HasDefaultValueSql("1") - informa o valor padrão de QTD de itens
                builder.Property(p => p.Valor).IsRequired();
                builder.Property(p => p.Desconto).IsRequired();
        }
    }
}