namespace modelo
{
    public class Categoria
    {
        public Categoria()
        {
            CategoriaProduto = new HashSet<ProdutoCategoria>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ProdutoCategoria> CategoriaProduto { get; set; }
    }
}