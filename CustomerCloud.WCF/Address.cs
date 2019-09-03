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
    public class Address : IAddress
    {
        private BaseLogic<AddressEntity, AddressDTO> _logic;

        public Address()
        {
            _logic = new BaseLogic<AddressEntity, AddressDTO>();
        }
        public void Create(AddressDTO address)
        {
            _logic.Create(address);
        }

        public void Delete(Guid id)
        {
            _logic.Delete(id);
        }

        public AddressDTO Read(Guid id)
        {
            return
            _logic.Read(id);
        }

        public void Update(AddressDTO address)
        {
            _logic.Update(address);
        }
    }
}
