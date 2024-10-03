using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using System.Reflection;

namespace DataAccess.Data
{
    public class TestTaskDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Incident> Incidents { get; set; }

        public TestTaskDbContext() { }

        public TestTaskDbContext(DbContextOptions options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer("Data Source=DESKTOP-MJPD6UB\\SQLEXPRESS;Initial Catalog=TestTaskDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}