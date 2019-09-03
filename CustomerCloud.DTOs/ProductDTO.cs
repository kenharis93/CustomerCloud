using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCloud.DTOs
{
    [DataContract]
    public class ProductDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public decimal Price { get; set; }
    }
}
