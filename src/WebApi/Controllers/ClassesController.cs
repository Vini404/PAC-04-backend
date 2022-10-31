using Domain.Entities;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController

    {
        private readonly ClassesRepository _classesRepository;

        public ClassesController(ClassesRepository classesRepository)
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
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(Classes classe)
        {
            try
            {
                classe.Validate();
                _classesRepository.Add(classe);
                _classesRepository.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Classes classe)
        {
            try
            {
                classe.Validate();
                _classesRepository.Update(classe);
                _classesRepository.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
