using System;
using Microsoft.EntityFrameworkCore;
using CursoEFCore.Domain;
using CursoEFCore.Data;
using Microsoft.Extensions.Logging;
namespace CursoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
         //InserirDadosEmMassa();
         ConsultarDados();
        }

          private static void ConsultarDados()
          {
            using (var db = new ApplicationContext())
            {
               // var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
                //var consultaPorMetodo = db.Clientes.Where(p => p.Id > 0).ToList();
                
                //resolver erro 
            }
          }

          public static void InserirDados()
        {
            var produto = new Produto                   //Adicionando um novo produto
            {
            Descricao = "Produto Outro",
            CodigoBarras = "123456789",
            Valor = 10m,
            TipoProduto = TipoProduto.MercadoriaParaRevenda,
            };

           using (var db = new ApplicationContext())     //Inserindo o produto no banco de dados
             {
            db.Add(produto);
            var registros = db.SaveChanges();
            Console.WriteLine($"Total de registros: {registros}");
             }

             var produtoOutro = new Produto                   //Adicionando um novo produto
            {
            Descricao = "Produto Gold",
            CodigoBarras = "12345672222289",
            Valor = 5m
            
            };
        }

        public static void InserirDadosEmMassa()
        {
            var produto = new Produto                   //Adicionando um novo produto
            {
            Descricao = "Produto Outro",
            CodigoBarras = "123456789",
            Valor = 10m
            };

            var cliente = new Cliente
            {
                Nome = "Fulano de Tal",
                CEP = "12345678",
                Cidade = "São Paulo",
                Estado = "SP",
                Telefone = "123456789"
            };

            using (var db = new ApplicationContext())     //Inserindo o produto no banco de dados
             {
            db.AddRange(produto, cliente);
            var registros = db.SaveChanges();
            Console.WriteLine($"Total de registros: {registros}");
             }
             
        }


    }
}
