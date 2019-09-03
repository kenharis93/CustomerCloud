using CustomerCloud.DTOs;
using CustomerCloud.Entities;
using CustomerCloud.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProductCloud.WebAPI.Controllers
{
    [RoutePrefix("api/customercloud/v1")]
    public class ProductController : ApiController
    {
        private readonly BaseLogic<ProductEntity, ProductDTO> _logic;

        public ProductController()
        {
            _logic = new BaseLogic<ProductEntity, ProductDTO>();
        }

        [HttpGet]
        [Route("product/{id}")]
        [ResponseType(typeof(ProductDTO))]
        public IHttpActionResult Get(Guid id)
        {
            ProductDTO dto = _logic.Read(id);
            if(dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        [Route("product")]
        public IHttpActionResult Post([FromBody] ProductDTO dto)
        {
            _logic.Create(dto);
            return Ok();
        }

        [HttpPut]
        [Route("product")]
        public IHttpActionResult Put([FromBody] ProductDTO dto)
        {
            _logic.Update(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("product/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            _logic.Delete(id);
            return Ok();
        }
    }
}
