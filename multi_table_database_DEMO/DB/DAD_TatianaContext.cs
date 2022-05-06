using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace multi_table_database_DEMO.DB
{
    public partial class DAD_TatianaContext : DbContext
    {
        public DAD_TatianaContext()
        {
        }

        public DAD_TatianaContext(DbContextOptions<DAD_TatianaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookCopy> BookCopies { get; set; } = null!;
        public virtual DbSet<BookTitle> BookTitles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=citizen.manukautech.info,6306;Initial Catalog=DAD_Tatiana;Persist ;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCopy>(entity =>
            {
                entity.ToTable("Book_Copy");

                entity.Property(e => e.BookCopyId).HasColumnName("BookCopyID");

                entity.Property(e => e.BookStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BookTitleId).HasColumnName("BookTitleID");

                entity.Property(e => e.CopyNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Edition)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.PublicationYear).HasColumnName("Publication_Year");

                entity.HasOne(d => d.BookTitle)
                    .WithMany(p => p.BookCopies)
                    .HasForeignKey(d => d.BookTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Copy_Book_Title");
            });

            modelBuilder.Entity<BookTitle>(entity =>
            {
                entity.ToTable("Book_Title");

                entity.Property(e => e.BookTitleId).HasColumnName("BookTitleID");

                entity.Property(e => e.Author)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Publisher)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
