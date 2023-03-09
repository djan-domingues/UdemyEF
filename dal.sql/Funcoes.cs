using Microsoft.EntityFrameworkCore;

using modelo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.sql
{
    public class Funcoes
    {

        public void ListarQuery()
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                var a = ctx.Produtos.FromSqlRaw("select * from produtos");

                a.ToList()
                    .ForEach(o =>
                    {
                        Console.WriteLine(o.Nome  + " == " + o.Cor);
                    });
            }
        }

        public void ListarPerfomatizado()
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                var a = ctx.Produtos
                    .AsNoTracking()
                    .Where(o => o.Cor == "Vermelho");

                a.ToList()
                    .ForEach(o => 
                    { 
                        Console.WriteLine(o.Cor); 
                    });
            }
        }
        class NovoObjeto
        {
            public string Nome { get; set; }
            public string Cor { get; set; }
            public int QuantoTem { get; set; }
            public int ? QuantoEraPraTer { get; set; }
            public string ? Categoria { get; set; }
        }
        public void SelecionarComInclude(int id)
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                //IQueryable<Produtos> a = ctx.Produtos.Include(o => o.Estoques);
                IQueryable<Produtos> a = ctx.Produtos;
                var p2 = ctx.Produtos
                    .Include(o => o.Estoques)
                    .Include("ProdutoCategoria.Categoria")
                    .Select(o => new NovoObjeto() {
                        Nome = o.Nome,
                        Cor = o.Cor,
                        QuantoTem = o.Estoques.Quantidade,
                        QuantoEraPraTer = o.Estoques.Exemplo,
                        Categoria = o.ProdutoCategoria.ToList().Select(p => p.Categoria.Nome).FirstOrDefault()
                    })
                    .FirstOrDefault();


                Console.WriteLine($"{p2.Nome}|{p2.Cor}|{p2.QuantoTem}|{p2.QuantoEraPraTer}|{p2.Categoria}|");
            }
        }
        public void ListarWhereDinamico(string nome, string cor, int ? quantidade = null, int ? exemplo = null)
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                //IQueryable<Produtos> a = ctx.Produtos.Include(o => o.Estoques);
                IQueryable<Produtos> a = ctx.Produtos
                    .Include(o => o.Estoques)
                    .Include("ProdutoCategoria.Categoria")
                    ;

                if (!string.IsNullOrEmpty(nome))
                {
                    a = a.Where(o => o.Nome.Equals(nome));
                }

                if (!string.IsNullOrEmpty(cor))
                {
                    a = a.Where(o => o.Cor.Equals(cor));
                }

                if (quantidade.HasValue)
                {
                    a = a.Where(o => o.Estoques.Quantidade > quantidade.Value);
                }

                if (exemplo.HasValue)
                {
                    a = a.Where(o => o.Estoques.Exemplo > exemplo.Value);
                }

                a.ToList()
                    .ForEach(o => 
                    { 
                        Console.WriteLine($"{o.Nome}-{o.Cor}-{o.Estoques.Quantidade}-{o.Estoques.Exemplo}"); 
                    });

            }
        }
        public void Listar()
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                var a = ctx.Produtos.Where(o => o.Cor != "Vermelho");
                a.ToList().ForEach(o => { Console.WriteLine(o.Cor); });


                var comlinq = (from b in ctx.Produtos
                              where b.Cor != "Vermelho"
                              select b).ToList();
                comlinq.ToList().ForEach(o => { Console.WriteLine(o.Cor); });

            }
        }
        public void Selecionar(int id)
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                Produtos p1 = ctx.Produtos.Find(id);
                Produtos p2 = ctx.Produtos.FirstOrDefault(x => x.Id == id+1);

                Console.WriteLine(p1.Nome + " | " + p1.Cor);
                Console.WriteLine(p2.Nome + " | " + p2.Cor);
            }
        }
        public void SelecionarLinq(int id)
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                //Lambda
                //Produtos p2 = ctx.Produtos.FirstOrDefault(x => x.Id == id + 1);
                Produtos p2 = (
                    from a in ctx.Produtos
                              where a.Id == id
                              select a
                              ).FirstOrDefault();

                Console.WriteLine(p2.Nome + " | " + p2.Cor);
            }
        }
        public void Adicionar(Produtos p)
        {
            using (SqlContexto ctx = new SqlContexto())
            {


                ctx.Produtos.Add(p);
                ctx.SaveChanges();
            }
        }
        public void Atualizar(Produtos p)
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                var encontrado = ctx.Produtos.FirstOrDefault(o => o.Id == p.Id);

                if (encontrado == null) return;

                //encontrado.Nome = p.Nome;
                encontrado.Cor = p.Cor;
                ctx.SaveChanges();
            }
        }
        public void Alterar(Produtos p)
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                ctx.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
        public void Deletar(int id)
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                var encontrado = ctx.Produtos.FirstOrDefault(o => o.Id == id);

                if (encontrado == null) return;

                ctx.Produtos.Remove(encontrado);

                ctx.SaveChanges();
            }
        }
        public void Deletar(Produtos p)
        {
            using (SqlContexto ctx = new SqlContexto())
            {
                ctx.Entry(p).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
    }
}
