using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.DTOs
{
    [DataContract]
    public class AddressDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Province { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
    }
}
