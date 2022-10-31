using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController
    {
        private readonly CoursesRepository _coursesRepository;

        public CoursesController(CoursesRepository coursesRepository)
        {
            _coursesRepository = coursesRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var course = _coursesRepository.GetById(id);
                return new OkObjectResult(course);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(Courses course)
        {
            try
            {
                course.Validate();
               
                _coursesRepository.Add(course).GetAwaiter().GetResult();
                _coursesRepository.SaveChangesAsync().GetAwaiter().GetResult();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Courses course)
        {
            try
            {
                course.Validate();

                _coursesRepository.Update(course);
                _coursesRepository.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

    }
}
