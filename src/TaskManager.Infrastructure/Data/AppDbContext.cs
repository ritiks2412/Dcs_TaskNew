using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;

namespace TaskManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<Payment> Payments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Submission>()
        .HasOne(s => s.User)
        .WithMany() 
        .HasForeignKey(s => s.UserId)
        .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Submission>()
                .HasOne(s => s.Form)
                .WithMany()
                .HasForeignKey(s => s.FormId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }


}
