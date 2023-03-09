using System;
using System.Collections.Generic;

namespace camada_teste.Models
{
    public partial class Estoque
    {
        public int Id { get; set; }
        public int? ProdutoId { get; set; }
        public int? Quantidade { get; set; }
        public int? Exemplo { get; set; }

        public virtual Produto? Produto { get; set; }
    }
}
