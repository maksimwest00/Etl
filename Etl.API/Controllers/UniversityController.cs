using Etl.API.Services;
using Etl.Application.UniversityManagment.CreateUniversity;
using Microsoft.AspNetCore.Mvc;

namespace Etl.API.Controllers
{
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
            int countThreads = int.Parse(configuration.GetSection("MyVarriables")["CountThreads"]!);
            _uploadService = new UploadService(logger, httpClient, countThreads);

        }

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
