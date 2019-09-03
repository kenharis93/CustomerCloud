using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCloud.Entities
{
    [Table("Products")]
    public class ProductEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}