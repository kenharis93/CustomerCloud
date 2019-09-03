using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCloud.Entities
{
    [Table("Addresses")]
    public class AddressEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }

    }
}