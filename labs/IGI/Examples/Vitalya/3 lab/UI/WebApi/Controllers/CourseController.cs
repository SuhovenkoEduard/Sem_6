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
    public class CourseController : ControllerBase
    {
        private readonly CourseService _service;
        
        public CourseController(CourseService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseModel>> Get()
        {
            return _service.GetData().Select(CourseMapperModel.FromDto).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            CourseModel courseModel = GetModelById(id);
            
            if (courseModel == null)
            {
                return NotFound();
            }

            return Ok(courseModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CourseModel model)
        {
            try
            {
                _service.Add(CourseMapperModel.ToDto(model));
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CourseModel model)
        {
            try
            {
                CourseModel courseModel = GetModelById(id);

                courseModel.Description = model.Description;
                courseModel.CourseName = model.CourseName;
                
                _service.Update(CourseMapperModel.ToDto(courseModel));
                return Ok(courseModel);
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
                CourseModel courseModel = GetModelById(id);
                _service.Delete(CourseMapperModel.ToDto(courseModel));
                return Ok(courseModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private CourseModel GetModelById(int id)
        {
            return CourseMapperModel.FromDto(
                _service
                    .GetData()
                    .FirstOrDefault(x => x.Id == id));
        }
    }
}