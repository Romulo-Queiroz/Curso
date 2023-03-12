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
         //InserirDados();
         InserirCliente();
         //ConsultarDados();
         //AtualizarDados();
          //ExcluirDados();
        }

        public static void ExcluirDados()
        {
            using (var db = new ApplicationContext())
            {
                var cliente = db.Clientes.Find(1);
                db.Remove(cliente);
                db.SaveChanges();
            }
        }
        private static void InserirCliente()
        {
            var cliente = new Cliente
            {
                Nome = "Rômulo",
                CEP = "12345678",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Telefone = "123456789"
            };

            using (var db = new ApplicationContext())
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
            }
        }
        private static void AtualizarDados()
        {
            using (var db = new ApplicationContext())
            {
                var cliente = db.Clientes.Find(1);
                cliente.Nome = "Rômulo 33";
                //db.Clientes.Update(cliente); n precisa do update neste caso.
                db.SaveChanges();
            }
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
            Descricao = "Produto One",
            CodigoBarras = "123456789",
            Valor = 10m
            };

            var cliente = new Cliente
            {
                Nome = "Rômulo33",
                CEP = "12345678",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
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
