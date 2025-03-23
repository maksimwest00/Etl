using Etl.Application.Universities.CreateUniversity;
using Microsoft.AspNetCore.Mvc;

namespace Etl.API.Controllers
{
    // TODO
    // countThreads вынести в конфиг

    [ApiController]
    [Route("[controller]")]
    public class UniversityController : ControllerBase
    {
        private UploadService _uploadService;

        public UniversityController(
            ILogger<UniversityController> logger,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory)
        {
            var httpClient = httpClientFactory.CreateClient();
            _uploadService = new UploadService(logger, httpClient, 10);
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            return Ok();
        }
        
        // Загрузка данных по 10ти странам
        [HttpPut(Name = "University")]
        public async Task<IActionResult> UpdateInfo(
            [FromServices] CreateUniversityHandler handler,
            CancellationToken cancellationToken = default)
        {
            bool result = await _uploadService.Upload(handler, cancellationToken);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
