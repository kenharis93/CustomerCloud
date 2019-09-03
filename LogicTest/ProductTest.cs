using AutoMapper;
using CustomerCloud.DTOs;
using CustomerCloud.Entities;
using CustomerCloud.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LogicTest
{
    [TestClass]
    public class ProductTest
    {

        [TestMethod]
        public void Create()
        {
            Mapper.Reset();
            ProductDTO dto = CreateProduct();
            BaseLogic<ProductEntity, ProductDTO> logic = new BaseLogic<ProductEntity, ProductDTO>();
            logic.Create(dto);
            var result = logic.Read(dto.Id);
            Assert.IsNotNull(result);
            logic.Delete(dto.Id);
        }


        [TestMethod]
        public void Read()
        {
            Mapper.Reset();
            ProductDTO dto = CreateProduct();
            BaseLogic<ProductEntity, ProductDTO> logic = new BaseLogic<ProductEntity, ProductDTO>();
            logic.Create(dto);
            var result = logic.Read(dto.Id);
            Assert.IsNotNull(result);
            logic.Delete(dto.Id);
        }

        [TestMethod]
        public void Update()
        {
            Mapper.Reset();
            ProductDTO dto = CreateProduct();
            BaseLogic<ProductEntity, ProductDTO> logic = new BaseLogic<ProductEntity, ProductDTO>();
            logic.Create(dto);
            var result = logic.Read(dto.Id);
            Assert.IsNotNull(result);

            int newPrice = Faker.Number.RandomNumber();
            dto.Price = newPrice;
            logic.Update(dto);

            result = logic.Read(dto.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(newPrice, result.Price);

            logic.Delete(dto.Id);
        }

        [TestMethod]
        public void Delete()
        {
            Mapper.Reset();
            ProductDTO dto = CreateProduct();
            BaseLogic<ProductEntity, ProductDTO> logic = new BaseLogic<ProductEntity, ProductDTO>();
            logic.Create(dto);
            var result = logic.Read(dto.Id);
            Assert.IsNotNull(result);
            logic.Delete(dto.Id);
            result = logic.Read(dto.Id);
            Assert.IsNull(result);

        }

        private ProductDTO CreateProduct()
        {
            return new ProductDTO()
            {
                Id = Guid.NewGuid(),
                Description = Faker.Lorem.Word(),
                Price = Faker.Number.RandomNumber()

            };
        }

    }
}
