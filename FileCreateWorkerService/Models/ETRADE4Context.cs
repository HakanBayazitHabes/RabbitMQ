using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FileCreateWorkerService.Models
{
    public partial class ETRADE4Context : DbContext
    {
        public ETRADE4Context()
        {
        }

        public ETRADE4Context(DbContextOptions<ETRADE4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("ITEMS");

                entity.HasIndex(e => new { e.Id, e.Itemcode, e.Itemname, e.Unitprice, e.Category1, e.Category2, e.Category3, e.Category4, e.Brand }, "IX7")
                    .HasFillFactor((byte)70);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Brand)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BRAND");

                entity.Property(e => e.Category1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY1");

                entity.Property(e => e.Category2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY2");

                entity.Property(e => e.Category3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY3");

                entity.Property(e => e.Category4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY4");

                entity.Property(e => e.Itemcode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ITEMCODE");

                entity.Property(e => e.Itemname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ITEMNAME");

                entity.Property(e => e.Unitprice).HasColumnName("UNITPRICE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
