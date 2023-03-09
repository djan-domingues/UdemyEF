using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace camada_teste.Models
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

        public virtual DbSet<Estoque> Estoques { get; set; } = null!;
        public virtual DbSet<Produto> Produtos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;User ID=sa;Password=senha@123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=Cliente01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.ToTable("Estoque");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.Estoques)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Estoque_Produtos");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.Cor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
