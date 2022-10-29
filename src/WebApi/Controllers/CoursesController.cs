using AutoMapper;
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
        private readonly ClassesRepository _classesRepository;

        public CoursesController(ClassesRepository classesRepository)
        {
            _classesRepository = classesRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var course = _classesRepository.GetById(id);
                return new OkObjectResult(course);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

    }
}
