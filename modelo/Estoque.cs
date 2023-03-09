using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelo
{
    public class Estoque
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public int? Exemplo { get; set; }

        public virtual Produtos Produto { get; set; } = null!;
    }
}
