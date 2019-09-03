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
    public class CustomerTests
    {
        [TestMethod]
        public void Create()
        {
            Mapper.Reset();
            BaseLogic<CustomerEntity, CustomerDTO> customerLogic = new BaseLogic<CustomerEntity, CustomerDTO>();
            CustomerDTO cust = CreateCustomer();
            customerLogic.Create(cust);
            CustomerDTO result = customerLogic.Read(cust.Id);
            Assert.IsNotNull(result);
            customerLogic.Delete(cust.Id);
        }

        [TestMethod]
        public void Read()
        {
            Mapper.Reset();
            BaseLogic<CustomerEntity, CustomerDTO> customerLogic = new BaseLogic<CustomerEntity, CustomerDTO>();
            CustomerDTO cust = CreateCustomer();
            customerLogic.Create(cust);
            CustomerDTO result = customerLogic.Read(cust.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual(cust.Id, result.Id);
        }

        [TestMethod]
        public void Update()
        {
            Mapper.Reset();
            BaseLogic<CustomerEntity, CustomerDTO> customerLogic = new BaseLogic<CustomerEntity, CustomerDTO>();
            CustomerDTO cust = CreateCustomer();
            customerLogic.Create(cust);
            cust.Name = Faker.Name.FullName();
            customerLogic.Update(cust);
            CustomerDTO updatedCustomer = customerLogic.Read(cust.Id);
            Assert.IsNotNull(updatedCustomer);
            Assert.AreEqual(cust.Name, updatedCustomer.Name);
        }

        [TestMethod]
        public void Delete()
        {
            Mapper.Reset();
            BaseLogic<CustomerEntity, CustomerDTO> customerLogic = new BaseLogic<CustomerEntity, CustomerDTO>();
            CustomerDTO cust = CreateCustomer();
            customerLogic.Create(cust);
            customerLogic.Delete(cust.Id);
            CustomerDTO result = customerLogic.Read(cust.Id);
            Assert.IsNull(result);

        }

        private CustomerDTO CreateCustomer()
        {
            return new CustomerDTO()
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName()
            };
        }

    }
}
