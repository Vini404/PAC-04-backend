using Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Domain.Dto.Certificates;
using Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {

        private readonly CertificatesRepository _certificatesRepository;
        private readonly InteractionsRepository _interactionsRepository;
        public CertificatesController(CertificatesRepository certificatesRepository, InteractionsRepository interactionsRepository)
        {
            _certificatesRepository = certificatesRepository;
            _interactionsRepository = interactionsRepository;
        }

        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var certificate = _certificatesRepository.GetAllCertificates();
                return new OkObjectResult(certificate);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var certificate = _certificatesRepository.GetById(id);
                return new OkObjectResult(certificate);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("GetCerticiatesByUser/{UserId}")]
        public async Task<ActionResult> GetCerticiatesByUser(string UserId)
        {
            try
            {
                var certificate = _certificatesRepository.GetByUser(UserId);
                return new OkObjectResult(certificate);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Certificates certificate)
        {
            try
            {
                certificate.Validate();
                _certificatesRepository.Add(certificate);
                _certificatesRepository.SaveChangesAsync();
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost("AproveCertificate/{id}")]
        public async Task<ActionResult> AproveCertificate(int id)
        {
            try
            {
                _interactionsRepository.CreateInteractionAproved(id);

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost("ReproveCertificate/{id}")]
        public async Task<ActionResult> ReproveCertificate([FromBody] ReproveCertificateRequest reproveRequest)
        {
            try
            {
                _interactionsRepository.CreateInteractionReproved(reproveRequest.CertificateId, reproveRequest.Description);

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut("AlterateCertificate/{id}")]
        public async Task<ActionResult> AlterCertificate([FromBody] AlterCertificateRequest alterRequest)
        {
            try
            {
                var currentCertificate = _certificatesRepository.GetById(alterRequest.id);
                //currentCertificate.FullPath = alterRequest.FullPath;
                currentCertificate.Description = alterRequest.Description;
                currentCertificate.Duration = alterRequest.Duration;

                _certificatesRepository.UpdateCertificate(currentCertificate);
                _interactionsRepository.CreateInteractionAltered(currentCertificate.ID, alterRequest.Description);

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPost("BlockCertificate/{id}")]
        public async Task<ActionResult> BlockCertificate(int id)
        {
            try
            {
                _interactionsRepository.CreateInteractionClosed(id);

                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet("GetStatCertificate/{id}")]
        public async Task<ActionResult> GetStatCertificate(int id)
        {
            try
            {
                var stat = _interactionsRepository.GetCertificateStatus(id);

                return new OkObjectResult(stat);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }


        [HttpPost("GetCertificateHistory/{id}")]
        public async Task<ActionResult> GetCertificateHistory(int id)
        {
            try
            {
                var history = _interactionsRepository.GetCertificateHistory(id);

                return new OkObjectResult(history);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
    
