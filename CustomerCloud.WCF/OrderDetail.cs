using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CustomerCloud.DTOs;
using CustomerCloud.Entities;
using CustomerCloud.Logic;

namespace CustomerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class OrderDetail : IOrderDetail
    {
        private BaseLogic<OrderDetailEntity, OrderDetailDTO> _logic;

        public OrderDetail()
        {
            _logic = new BaseLogic<OrderDetailEntity, OrderDetailDTO>();
        }
        public void Create(OrderDetailDTO orderdetail)
        {
            _logic.Create(orderdetail);
        }

        public void Delete(Guid id)
        {
            _logic.Delete(id);
        }

        public OrderDetailDTO Read(Guid id)
        {
            return
            _logic.Read(id);
        }

        public void Update(OrderDetailDTO customer)
        {
            _logic.Update(customer);
        }
    }
}
