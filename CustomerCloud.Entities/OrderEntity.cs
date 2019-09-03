using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerCloud.Entities
{
    [Table("Orders")]
    public class OrderEntity : IEntity
    {
        public Guid Id { get; set; }
        public virtual ICollection<OrderDetailEntity> Details { get; set; }
    }
}