using System;
using AutoMapper;
using CustomerCloud.DTOs;
using CustomerCloud.Entities;
using CustomerCloud.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTest
{
    [TestClass]
    public class AddressTests
    {
        
        [TestInitialize]
        public void Init() { }
        [TestMethod]
        public void Create()
        {
            Mapper.Reset();
            BaseLogic<AddressEntity, AddressDTO> addressLogic = new BaseLogic<AddressEntity, AddressDTO>();
            AddressDTO addr = CreateAddress();
            addressLogic.Create(addr);
            AddressDTO result = addressLogic.Read(addr.Id);
            Assert.IsNotNull(result);
            addressLogic.Delete(addr.Id);
        }

        [TestMethod]
        public void Update()
        {
            Mapper.Reset();
            BaseLogic<AddressEntity, AddressDTO> addressLogic = new BaseLogic<AddressEntity, AddressDTO>();
            AddressDTO addr = CreateAddress();
            addressLogic.Create(addr);
            string newCity = Faker.Address.USCity();
            addr.City = newCity;
            addressLogic.Update(addr );
            AddressDTO updatedAddress = addressLogic.Read(addr.Id);
            Assert.AreEqual(newCity, updatedAddress.City);
            addressLogic.Delete(addr.Id);
        }

        [TestMethod]
        public void Delete()
        {
            Mapper.Reset();
            BaseLogic<AddressEntity, AddressDTO> addressLogic = new BaseLogic<AddressEntity, AddressDTO>();
            AddressDTO addr = CreateAddress();
            addressLogic.Create(addr);
            addressLogic.Delete(addr.Id);
            AddressDTO dto = addressLogic.Read(addr.Id);
            Assert.IsNull(dto);
        }

        private AddressDTO CreateAddress()
        {
            return new AddressDTO()
            {
                Id = Guid.NewGuid(),
                City = Faker.Address.USCity(),
                Street = Faker.Address.StreetName(),
                Number = Faker.Number.RandomNumber(),
                PostalCode = Faker.Address.CanadianZipCode(),
                Province = Faker.Address.Province()
            };
        }
    }
}
