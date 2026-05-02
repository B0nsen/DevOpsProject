using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Jysk.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Jysk.DAL.EF
{
    public class JyskContext : DbContext
    {
        public DbSet<Cargo> T_Cargo { get; set; }
        public DbSet<Category> T_Category { get; set; }
        public DbSet<Client> T_Client { get; set; }
        public DbSet<Delivery> T_Delivery { get; set; }
        public DbSet<Employee> T_Employee { get; set; }
        public DbSet<Manufacturer> T_Manufacturer { get; set; }
        public DbSet<Order> T_Order { get; set; }
        public DbSet<Product> T_Product { get; set; }
        public DbSet<Review> T_Review { get; set; }
        public DbSet<Storage> T_Storage { get; set; }
        public DbSet<Store> T_Store { get; set; }
        public DbSet<Supply> T_Supply { get; set; }
        public DbSet<User> T_User { get; set; }
        public DbSet<WorkHours> T_WorkHours { get; set; }
        public DbSet<WriteOff> T_WriteOff { get; set; }
        public JyskContext(DbContextOptions<JyskContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Storage>().HasMany(s => s.CargoFromId).WithOne(c => c.StorageFrom).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Storage>().HasMany(s => s.CargoToId).WithOne(c => c.StorageTo).OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
