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
    public class Order : IOrder
    {
        private BaseLogic<OrderEntity, OrderDTO> _logic;

        public Order()
        {
            _logic = new BaseLogic<OrderEntity, OrderDTO>();
        }
        public void Create(OrderDTO order)
        {
            _logic.Create(order);
        }

        public void Delete(Guid id)
        {
            _logic.Delete(id);
        }

        public OrderDTO Read(Guid id)
        {
            return
            _logic.Read(id);
        }

        public void Update(OrderDTO order)
        {
            _logic.Update(order);
        }
    }
}
