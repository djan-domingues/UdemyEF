using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Produtos
    {
        public Produtos()
        {
            ProdutoCategoria = new HashSet<ProdutoCategoria>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cor { get; set; }

        public virtual Estoque? Estoques { get; set; }

        public virtual ICollection<ProdutoCategoria> ProdutoCategoria {get;set;}
    }
}
