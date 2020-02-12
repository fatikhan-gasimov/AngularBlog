using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AngularBlog.Models
{
    public partial class UdemyAngularBlogDbContext : DbContext
    {
        public UdemyAngularBlogDbContext()
        {
        }

        public UdemyAngularBlogDbContext(DbContextOptions<UdemyAngularBlogDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Article { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ShortDescription).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Article)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_Category");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedUserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Note).IsRequired();

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Comment_Article");
            });
        }
    }
}
