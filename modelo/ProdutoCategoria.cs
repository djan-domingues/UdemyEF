using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class ProdutoCategoria
    {
        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; } 

        public virtual Produtos Produto { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
