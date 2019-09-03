
using CustomerCloud.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.Repository
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base(@"Data Source=(localdb)\ProjectsV13;Database=CustomerCloud;Integrated Security=True;")
        {
            Database.Log = s => Debug.WriteLine(s);
        }

        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<OrderDetailEntity> OrderDetails { get; set; }
        public DbSet<OrderEntity> Orders { get; set; } 
        public DbSet<ProductEntity> Products { get; set; }
    }
}
