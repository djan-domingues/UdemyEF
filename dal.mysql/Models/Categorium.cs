using System;
using System.Collections.Generic;

namespace dal.mysql.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Produtos = new HashSet<Produto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
