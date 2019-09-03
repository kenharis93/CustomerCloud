using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.DTOs
{
    [DataContract]
    public class OrderDetailDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public ProductDTO Product { get; set; }
    }
}
