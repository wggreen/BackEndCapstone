using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BackEndCapstone.Models;

namespace BackEndCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DbSet<Destination> Destinations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Messages>()
                  .HasOne(m => m.Sender)
                  .WithMany(t => t.SentMessages)
                  .HasForeignKey(m => m.SenderId)
                  .HasPrincipalKey(u => u.Id)
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Messages>()
                    .HasOne(m => m.Recipient)
                    .WithMany(t => t.ReceiviedMessages)
                    .HasForeignKey(m => m.RecipientId)
                    .HasPrincipalKey(u => u.Id)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}