using System;
using System.Collections.Generic;

namespace dal.mysql.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Estoques = new HashSet<Estoque>();
            Categoria = new HashSet<Categorium>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cor { get; set; }

        public virtual ICollection<Estoque> Estoques { get; set; }

        public virtual ICollection<Categorium> Categoria { get; set; }
    }
}
