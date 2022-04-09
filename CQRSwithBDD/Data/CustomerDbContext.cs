using CQRSwithBDD.DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRSwithBDD.Data
{
    public class CustomerDbContext:DbContext
    {
    //    public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
    //: base(options)
    //    {
    //    }
        private const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=CQRSwithEF;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
             new Customer
             {
             Id = Guid.Parse("20000000-0000-0000-0000-000000000000"),
            FirstName = "fname",
             LastName = "lname",
             DateOfBirth = DateTime.Now,
             PhoneNumber = "+98(938)433-1111",
             Email = "Dizaji.akbar@yahoo.com",
             BankAccountNumber = "111111111",
             Active = true
            });
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
