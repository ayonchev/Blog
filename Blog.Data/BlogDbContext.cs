using Blog.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext() { }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(Config.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>()
                        .HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() },
                                 new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() }
                                 );

            modelBuilder.Entity<Post>(post =>
            {
                post.Property(p => p.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                post.Property(p => p.Content)
                    .HasMaxLength(1000)
                    .IsRequired();

                post.HasOne(p => p.Category)
                    .WithMany(c => c.Posts)
                    .HasForeignKey(p => p.CategoryId);

                post.Property(p => p.DateCreated)
                    .HasDefaultValueSql("GETDATE()");

                post.HasOne(p => p.Author)
                    .WithMany(u => u.Posts)
                    .HasForeignKey(p => p.AuthorId);

                post.Property(p => p.AuthorId)
                    .IsRequired();
            });

            modelBuilder.Entity<Category>(category =>
            {
                category.HasIndex(c => c.Name)
                        .IsUnique();

                category.Property(c => c.Name)
                        .HasMaxLength(100)
                        .IsRequired();
            });

            modelBuilder.Entity<Comment>(comment =>
            {
                comment.Property(c => c.Content)
                       .HasMaxLength(400)
                       .IsRequired();

                comment.HasOne(c => c.Post)
                       .WithMany(p => p.Comments)
                       .HasForeignKey(c => c.PostId);

                comment.Property(c => c.DateCreated)
                       .HasDefaultValueSql("GETDATE()");

                comment.HasOne(c => c.Author)
                       .WithMany(u => u.Comments)
                       .HasForeignKey(c => c.AuthorId);
            });

            modelBuilder.Entity<ApplicationUser>()
                        .Property(u => u.Name)
                        .HasMaxLength(100)
                        .IsRequired();
        }
    }
}
