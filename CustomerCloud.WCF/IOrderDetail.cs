using CustomerCloud.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CustomerCloud.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrderDetail
    {
        [OperationContract]
        void Create(OrderDetailDTO orderDetail);
        [OperationContract]
        OrderDetailDTO Read(Guid id);
        [OperationContract]
        void Update(OrderDetailDTO orderDetail);
        [OperationContract]
        void Delete(Guid id);

    }

}
