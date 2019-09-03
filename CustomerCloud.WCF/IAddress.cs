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
    public interface IAddress
    {
        [OperationContract]
        void Create(AddressDTO address);
        [OperationContract]
        AddressDTO Read(Guid id);
        [OperationContract]
        void Update(AddressDTO address);
        [OperationContract]
        void Delete(Guid id);

    }

}
