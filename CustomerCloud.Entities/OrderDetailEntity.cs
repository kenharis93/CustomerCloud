using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCloud.Entities
{
    [Table("OrderDetails")]
    public class OrderDetailEntity : IEntity
    {
        public Guid Id { get; set; }
        public virtual ProductEntity Product { get; set; }
    }
}