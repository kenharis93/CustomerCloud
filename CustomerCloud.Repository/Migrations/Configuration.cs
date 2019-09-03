namespace CustomerCloud.Repository.Migrations
{
    using CustomerCloud.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerCloud.Repository.CustomerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CustomerCloud.Repository.CustomerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Customers.AddOrUpdate(
                    new CustomerEntity()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Joe Smith",
                        Address = new AddressEntity()
                        {
                            Id = Guid.NewGuid(),
                            Street = "237 Ontario",
                            City = "Toronto",
                            Province = "Ont",
                            PostalCode = "A4A 2B2",
                        },
                        Orders = new List<OrderEntity>()
                        {
                            new OrderEntity()
                            {
                                Id = Guid.NewGuid(),
                                Details = new List<OrderDetailEntity>()
                                {
                                    new OrderDetailEntity()
                                    {
                                        Id = Guid.NewGuid(),
                                        Product = new ProductEntity()
                                        {
                                            Id = Guid.NewGuid(),
                                            Description = "Pants",
                                            Price = 95.32M
                                        }
                                    },
                                    new OrderDetailEntity()
                                    {
                                        Id = Guid.NewGuid(),
                                        Product = new ProductEntity()
                                        {
                                            Id = Guid.NewGuid(),
                                            Description = "Shoes",
                                            Price = 105.45M
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new CustomerEntity()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sally Jones",
                        Address = new AddressEntity()
                        {
                            Id = Guid.NewGuid(),
                            Street = "591 Yonge",
                            City = "Toronto",
                            Province = "Ont",
                            PostalCode = "C5C 3X3",
                        },
                        Orders = new List<OrderEntity>()
                        {
                            new OrderEntity()
                            {
                                Id = Guid.NewGuid(),
                                Details = new List<OrderDetailEntity>()
                                {
                                    new OrderDetailEntity()
                                    {
                                        Id = Guid.NewGuid(),
                                        Product = new ProductEntity()
                                        {
                                            Id = Guid.NewGuid(),
                                            Description = "Dress",
                                            Price = 65.12M
                                        }
                                    },
                                    new OrderDetailEntity()
                                    {
                                        Id = Guid.NewGuid(),
                                        Product = new ProductEntity()
                                        {
                                            Id = Guid.NewGuid(),
                                            Description = "Snow Pants",
                                            Price = 35.56M
                                        }
                                    }
                                }
                            }
                        }
                    }
                );
        }
    }
}
