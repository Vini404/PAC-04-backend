using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repository;
using System.Threading.Tasks;
using System;
using Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController
    {
        private readonly PhotosRepository _photosRepository;

        public PhotosController(PhotosRepository photosRepository)
        {
            _photosRepository = photosRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var course = _photosRepository.GetById(id);
                return new OkObjectResult(course);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post(Photos photo)
        {
            try
            {
                _photosRepository.Add(photo);
                _photosRepository.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Photos photo)
        {
            try
            {
                _photosRepository.Update(photo);
                _photosRepository.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

    }
}
