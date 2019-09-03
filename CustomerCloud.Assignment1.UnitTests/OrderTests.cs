using System;
using CustomerCloud.Assignment1.UnitTests.OrderService;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CustomerCloud.Assignment1.UnitTests
{
    [TestClass]
    public class OrderTests
    {
        private OrderDTO _dto;
        [TestInitialize]
        public void Init()
        {
            _dto = new OrderDTO()
            {
                Id = Guid.NewGuid(),
                Details = new OrderDetailDTO[]
                {
                    new OrderDetailDTO()
                    {
                        Id = Guid.NewGuid(),
                        Product = new ProductDTO()
                        {
                            Id = Guid.NewGuid(),
                            Description = "Shoes",
                            Price = 86.23M
                        }

                    }
                }
            };
        }
        
        [TestMethod]
        public void Order_Create_Test()
        {
            OrderClient client = new OrderClient("NetTcpBinding_IOrder");
            client.Open();
            client.Create(_dto);

            OrderDTO result = client.Read(_dto.Id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Order_Update_Test()
        {
            OrderClient client = new OrderClient("NetTcpBinding_IOrder");
            client.Open();
            client.Create(_dto);

            _dto.Details[0].Product.Description = "Pants";
            _dto.Details[0].Product.Price = 102.45M;
            _dto.Details[0].Id = Guid.NewGuid();
            _dto.Details[0].Product.Id = Guid.NewGuid();

            client.Update(_dto);

            OrderDTO result = client.Read(_dto.Id);
            Assert.IsNotNull(result);
            Assert.AreEqual("Pants", _dto.Details[0].Product.Description);
            Assert.AreEqual(102.45M, _dto.Details[0].Product.Price);
        }

        [TestMethod]
        public void Order_Delete_Test()
        {
            OrderClient client = new OrderClient("NetTcpBinding_IOrder");
            client.Open();

            OrderDTO exists = client.Read(_dto.Id);
            if (exists == null)
            {
                client.Create(_dto);
            }

            client.Delete(_dto.Id);

            OrderDTO result = client.Read(_dto.Id);
            Assert.IsNull(result);
        }

    }
}
