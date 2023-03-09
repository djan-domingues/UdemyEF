using Microsoft.EntityFrameworkCore;

using modelo;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.sql
{
    public class SqlContexto : DbContext
    {
        public SqlContexto()
        {

        }
        public SqlContexto(DbContextOptions<SqlContexto> op) : base(op)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;User ID=sa;Password=senha@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=Cliente01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoCategoria>().HasKey(c => new { c.ProdutoId, c.CategoriaId });
        }

        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategoria { get; set; }
    }
}
