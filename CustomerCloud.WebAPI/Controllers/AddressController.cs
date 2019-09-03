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

namespace AddressCloud.WebAPI.Controllers
{
    [RoutePrefix("api/customercloud/v1")]
    public class AddressController : ApiController
    {
        private readonly BaseLogic<AddressEntity, AddressDTO> _logic;

        public AddressController()
        {
            _logic = new BaseLogic<AddressEntity, AddressDTO>();
        }

        [HttpGet]
        [Route("address/{id}")]
        [ResponseType(typeof(AddressDTO))]
        public IHttpActionResult Get(Guid id)
        {
            AddressDTO dto = _logic.Read(id);
            if(dto == null)
            {
                return NotFound();
            }
            return Ok(dto);
        }

        [HttpPost]
        [Route("address")]
        public IHttpActionResult Post([FromBody] AddressDTO dto)
        {
            _logic.Create(dto);
            return Ok();
        }

        [HttpPut]
        [Route("address")]
        public IHttpActionResult Put([FromBody] AddressDTO dto)
        {
            _logic.Update(dto);
            return Ok();
        }

        [HttpDelete]
        [Route("address/{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            _logic.Delete(id);
            return Ok();
        }
    }
}
