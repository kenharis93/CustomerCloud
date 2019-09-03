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

namespace CustomerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/customercloud/v1")]
    public class CustomerController : ApiController
    {
        private readonly BaseLogic<CustomerEntity, CustomerDTO> _logic;

        public CustomerController()
        {
            _logic = new BaseLogic<CustomerEntity, CustomerDTO>();
        }

        [HttpGet]
        [Route("customer/{id}")]
        [ResponseType(typeof(CustomerDTO))]
        public IHttpActionResult Get(Guid id)
        {
            CustomerDTO dto = _logic.Read(id);
            if(dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        [Route("customer")]
        public IHttpActionResult Post([FromBody] CustomerDTO dto)
        {
            _logic.Create(dto);
            return Ok();
        }

        [HttpPut]
        [Route("customer")]
        public IHttpActionResult Put([FromBody] CustomerDTO dto)
        {
            _logic.Update(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("customer/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            _logic.Delete(id);
            return Ok();
        }
    }
}
