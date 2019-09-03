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
    public class Product : IProduct
    {
        private BaseLogic<ProductEntity, ProductDTO> _logic;

        public Product()
        {
            _logic = new BaseLogic<ProductEntity, ProductDTO>();
        }
        public void Create(ProductDTO product)
        {
            _logic.Create(product);
        }

        public void Delete(Guid id)
        {
            _logic.Delete(id);
        }

        public ProductDTO Read(Guid id)
        {
            return
            _logic.Read(id);
        }

        public void Update(ProductDTO product)
        {
            _logic.Update(product);
        }
    }
}
