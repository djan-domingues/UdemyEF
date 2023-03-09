using System;
using System.Collections.Generic;

namespace camada_teste.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Estoques = new HashSet<Estoque>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cor { get; set; }

        public virtual ICollection<Estoque> Estoques { get; set; }
    }
}
