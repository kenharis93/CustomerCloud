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

namespace OrderCloud.WebAPI.Controllers
{
    [RoutePrefix("api/customercloud/v1")]
    public class OrderController : ApiController
    {
        private readonly BaseLogic<OrderEntity, OrderDTO> _logic;

        public OrderController()
        {
            _logic = new BaseLogic<OrderEntity, OrderDTO>();
        }

        [HttpGet]
        [Route("order/{id}")]
        [ResponseType(typeof(OrderDTO))]
        public IHttpActionResult Get(Guid id)
        {
            OrderDTO dto = _logic.Read(id);
            if(dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        [Route("order")]
        public IHttpActionResult Post([FromBody] OrderDTO dto)
        {
            _logic.Create(dto);
            return Ok();
        }

        [HttpPut]
        [Route("order")]
        public IHttpActionResult Put([FromBody] OrderDTO dto)
        {
            _logic.Update(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("order/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            _logic.Delete(id);
            return Ok();
        }
    }
}
