using Microsoft.EntityFrameworkCore;
using stockManagement.Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace stockManagement.Data
{
    public class DBContextManagementStock : DbContext
    {
        public DBContextManagementStock(DbContextOptions<DBContextManagementStock> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<Login> Login { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(os =>
            {
                os.HasKey(u => u.Id).HasName("IdEmployee");
                os.Property(u => u.Cin).IsRequired(true).HasMaxLength(255);
                os.Property(u => u.FirstName).IsRequired(true).HasMaxLength(255);
                os.Property(u => u.LastName).IsRequired(true).HasMaxLength(255);
                os.Property(u => u.Function).IsRequired(true).HasMaxLength(255);
                os.Property(u => u.Email).IsRequired(true).HasMaxLength(50);
                os.Property(u => u.BirthDate).IsRequired(true);
                os.Property(u => u.Address).IsRequired(true).HasMaxLength(50);
                os.Property(u => u.PhoneNumber).IsRequired(true);

            });

            modelBuilder.Entity<Assignment>().HasIndex(p => p.IdEmployee).IsUnique(false); //to remove index isUnique in entityframework core
            //modelBuilder.Entity<Assignment>().HasIndex(p => p.IdMaterial).IsUnique(); //TO ADD  index isUnique in entityframework core

            modelBuilder.Entity<Assignment>(os =>
            {
                os.HasKey(u => u.Id).HasName("IdAssignment");

                os.Property(u => u.IdEmployee).IsRequired(true);
                os.HasOne<Employee>(s => s.Employee)
                .WithMany(ad => ad.Assignment)
                .HasForeignKey(ad => ad.IdEmployee).IsRequired(true);


                os.Property(u => u.IdMaterial).IsRequired(true);
                os.HasOne<Materials>(s => s.Materials)
               .WithMany(ad => ad.Assignment)
               .HasForeignKey(ad => ad.IdMaterial).IsRequired(true);

                os.Property(u => u.StartDate).IsRequired(true);
                os.Property(u => u.EndDate).IsRequired(true);
            });

            modelBuilder.Entity<Materials>(os =>
            {
                os.HasKey(u => u.Id).HasName("IdMaterials");
                os.Property(u => u.Label).IsRequired(true);
                os.Property(u => u.PurchasePrice).IsRequired(true);
                os.Property(u => u.Reference).IsRequired(true);
                os.Property(u => u.PurchaseDate).IsRequired(true);
                os.Property(u => u.Mark).IsRequired(true).HasMaxLength(255);
                os.Property(u => u.IsTaken).IsRequired(true);

            });

            modelBuilder.Entity<Login>(os =>
            {
                os.HasKey(u => u.Id).HasName("IdLogin");
                os.Property(u => u.Email).IsRequired(true);
                os.Property(u => u.Password).IsRequired(true);
                
            });

        }

    }
}
