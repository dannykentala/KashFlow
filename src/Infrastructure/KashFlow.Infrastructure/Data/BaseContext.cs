using KashFlow.Domain.DTOs.Setters;
using KashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KashFlow.Infrastructure.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        { }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        // Configuración de mapeo para el Enum StatusEnum en la tabla Coupons
            modelBuilder.Entity<Employee>()
                .Property(e => e.Role)
                .HasConversion<string>();

            modelBuilder.Entity<Payment>()
                .Property(e => e.Status)
                .HasConversion<string>();
        }
    }
}