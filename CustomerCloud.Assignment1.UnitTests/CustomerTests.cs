using CustomerCloud.Assignment1.UnitTests.CustomerService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.Assignment1.UnitTests
{
    [TestClass]
    public class CustomerTests
    {
        CustomerDTO _dto;

        [TestInitialize]
        public void Init()
        {
            _dto = new CustomerDTO()
            {
                Id = Guid.NewGuid(),
                Name = "Joe Smith",
                Address = new AddressDTO()
                {
                    Id = Guid.NewGuid(),
                    City = "Toronto",
                    Number = 19,
                    PostalCode = "N5A4H7",
                    Province = "Ontario",
                    Street = "Humber Bvld."
                }
            };
        }
        [TestMethod]
        public void Create_Customer()
        {
            CustomerService.CustomerClient client = new CustomerClient("BasicHttpBinding_ICustomer");
            client.Open();
            client.Create(_dto);

            CustomerDTO result = client.Read(_dto.Id);
            Assert.IsNotNull(result);
        }
    }
}
