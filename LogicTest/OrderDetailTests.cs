using AutoMapper;
using CustomerCloud.DTOs;
using CustomerCloud.Entities;
using CustomerCloud.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicTest
{
    [TestClass]
    public class OrderDetailTests
    {
        [TestMethod]
        public void Create()
        {
            Mapper.Reset();
            OrderDetailDTO order = CreateOrderDetail();
            BaseLogic<OrderDetailEntity, OrderDetailDTO> logic = new BaseLogic<OrderDetailEntity, OrderDetailDTO>();
            logic.Create(order);
            OrderDetailDTO result = logic.Read(order.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(order.Id, result.Id);
        }

        [TestMethod]
        public void Read()
        {
            Mapper.Reset();
            OrderDetailDTO order = CreateOrderDetail();
            BaseLogic<OrderDetailEntity, OrderDetailDTO> logic = new BaseLogic<OrderDetailEntity, OrderDetailDTO>();
            logic.Create(order);
            OrderDetailDTO result = logic.Read(order.Id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Delete()
        {
            Mapper.Reset();
            OrderDetailDTO order = CreateOrderDetail();
            BaseLogic<OrderDetailEntity, OrderDetailDTO> logic = new BaseLogic<OrderDetailEntity, OrderDetailDTO>();
            logic.Create(order);
            logic.Delete(order.Id);
            OrderDetailDTO result = logic.Read(order.Id);
            Assert.IsNull(result);

        }

        private OrderDetailDTO CreateOrderDetail()
        {
            return new OrderDetailDTO()
            {
                Id = Guid.NewGuid(),
                Product = new ProductDTO()
                {
                    Id = Guid.NewGuid(),
                    Description = Faker.Lorem.Word(),
                    Price = Faker.Number.RandomNumber()
                }
            };
        }
    }
}
