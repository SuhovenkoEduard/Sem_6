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
    public class StudInfoController : ControllerBase
    {
        private readonly StudInfoService _service;
        
        public StudInfoController(StudInfoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudInfoModel>> Get()
        {
            return _service.GetData().Select(StudInfoMapperModel.FromDto).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            StudInfoModel studInfoModel = GetModelById(id);
            
            if (studInfoModel == null)
            {
                return NotFound();
            }

            return Ok(studInfoModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] StudInfoModel model)
        {
            try
            {
                _service.Add(StudInfoMapperModel.ToDto(model));
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudInfoModel model)
        {
            try
            {
                StudInfoModel studInfoModel = GetModelById(id);

                studInfoModel.Gender = model.Gender;
                studInfoModel.Graduate = model.Graduate;
                studInfoModel.YearGraduate = model.YearGraduate;
                studInfoModel.FirstName = model.FirstName;
                studInfoModel.LastName = model.LastName;
                studInfoModel.MiddleName = model.MiddleName;
                studInfoModel.AddressId = model.AddressId;
                studInfoModel.CourseCode = model.CourseCode;
                
                _service.Update(StudInfoMapperModel.ToDto(studInfoModel));
                return Ok(studInfoModel);
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
                StudInfoModel courseModel = GetModelById(id);
                _service.Delete(StudInfoMapperModel.ToDto(courseModel));
                return Ok(courseModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private StudInfoModel GetModelById(int id)
        {
            return StudInfoMapperModel.FromDto(
                _service
                    .GetData()
                    .FirstOrDefault(x => x.Id == id));
        }
    }
}