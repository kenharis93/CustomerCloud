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

namespace OrderDetailCloud.WebAPI.Controllers
{
    [RoutePrefix("api/customercloud/v1")]
    public class OrderDetailController : ApiController
    {
        private readonly BaseLogic<OrderDetailEntity, OrderDetailDTO> _logic;

        public OrderDetailController()
        {
            _logic = new BaseLogic<OrderDetailEntity, OrderDetailDTO>();
        }

        [HttpGet]
        [Route("orderDetail/{id}")]
        [ResponseType(typeof(OrderDetailDTO))]
        public IHttpActionResult Get(Guid id)
        {
            OrderDetailDTO dto = _logic.Read(id);
            if(dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        [Route("orderDetail")]
        public IHttpActionResult Post([FromBody] OrderDetailDTO dto)
        {
            _logic.Create(dto);
            return Ok();
        }

        [HttpPut]
        [Route("orderDetail")]
        public IHttpActionResult Put([FromBody] OrderDetailDTO dto)
        {
            _logic.Update(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("orderDetail/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            _logic.Delete(id);
            return Ok();
        }
    }
}
