using AutoMapper;
using CustomerCloud.DTOs;
using CustomerCloud.Entities;
using CustomerCloud.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTest
{
    [TestClass]
    public class OrderTest
    {

        [TestMethod]
        public void Create()
        {

            Mapper.Reset();
            OrderDTO order = CreateOrder();
            BaseLogic<OrderEntity, OrderDTO> logic = new BaseLogic<OrderEntity, OrderDTO>();
            logic.Create(order);
            var result = logic.Read(order.Id);
            Assert.IsNotNull(result);
            logic.Delete(order.Id);
        }

        [TestMethod]
        public void Read()
        {
            Mapper.Reset();
            OrderDTO order = CreateOrder();
            BaseLogic<OrderEntity, OrderDTO> logic = new BaseLogic<OrderEntity, OrderDTO>();
            logic.Create(order);
            var result = logic.Read(order.Id);
            Assert.IsNotNull(result);
            logic.Delete(order.Id);
        }



        private OrderDTO CreateOrder()
        {
            return new OrderDTO()
            {
                Id = Guid.NewGuid(),
                Details = new List<OrderDetailDTO>()
                {
                    new OrderDetailDTO()
                    {
                        Id = Guid.NewGuid(),
                        Product = new ProductDTO()
                        {
                            Id = Guid.NewGuid(),
                            Description = Faker.Lorem.Word(),
                            Price = Faker.Number.RandomNumber()
                        }
                    }
                }
            };
        }
    }
}
