using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dal.mysql.Models
{
    public partial class Cliente01Context : DbContext
    {
        public Cliente01Context()
        {
        }

        public Cliente01Context(DbContextOptions<Cliente01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Estoque> Estoques { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=Cliente01;uid=root;pwd=senha@123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.ToTable("Estoque");

                entity.HasIndex(e => e.ProdutoId, "ProdutoId");

                entity.Property(e => e.Exemplo).HasColumnName("exemplo");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Estoques)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_produtoid_estoque");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasIndex(e => e.Cor, "Cor");

                entity.Property(e => e.Cor).HasMaxLength(50);

                entity.Property(e => e.Nome).HasMaxLength(100);

                entity.HasMany(d => d.Categoria)
                    .WithMany(p => p.Produtos)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProdutoCategorium",
                        l => l.HasOne<Categorium>().WithMany().HasForeignKey("CategoriaId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_c_p"),
                        r => r.HasOne<Produto>().WithMany().HasForeignKey("ProdutoId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_p_c"),
                        j =>
                        {
                            j.HasKey("ProdutoId", "CategoriaId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("ProdutoCategoria");

                            j.HasIndex(new[] { "CategoriaId" }, "FK_c_p");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
