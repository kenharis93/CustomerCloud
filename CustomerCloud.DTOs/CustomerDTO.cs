using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.DTOs
{
    [DataContract]
    public class CustomerDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public AddressDTO Address { get; set; }
        [DataMember]
        public List<OrderDTO> Orders { get; set; }
    }
}
