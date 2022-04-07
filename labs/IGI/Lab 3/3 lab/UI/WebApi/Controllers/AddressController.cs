using System;
using System.Collections.Generic;
using System.Linq;
using Bll.Services;
using Microsoft.AspNetCore.Mvc;
using WebApi.Mappers;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _service;
        
        public AddressController(AddressService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AddressModel>> Get()
        {
            return _service.GetData().Select(AddressMapperModel.FromDto).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            AddressModel addressModel = GetModelById(id);
            
            if (addressModel == null)
            {
                return NotFound();
            }

            return Ok(addressModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AddressModel model)
        {
            try
            {
                _service.Add(AddressMapperModel.ToDto(model));
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AddressModel model)
        {
            try
            {
                AddressModel addressModel = GetModelById(id);

                addressModel.ExistAddress = model.ExistAddress;
                
                _service.Update(AddressMapperModel.ToDto(addressModel));
                return Ok(addressModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                AddressModel addressModel = GetModelById(id);
                _service.Delete(AddressMapperModel.ToDto(addressModel));
                return Ok(addressModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private AddressModel GetModelById(int id)
        {
            return AddressMapperModel.FromDto(
                _service
                    .GetData()
                    .FirstOrDefault(x => x.Id == id));
        }
    }
}