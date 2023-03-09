using CursoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class Produto
{
    public int Id { get; set; }
    public string CodigoBarras { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public decimal ValorPromocao { get; set; }
    public TipoProduto TipoProduto { get; set; }
    public string Observacao { get; set; }   
}