using Etl.Application.UniversityManagment.Queries.GetUniversitiesByFilters;
using Microsoft.AspNetCore.Mvc;

namespace Etl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        [HttpGet]
        public async Task<IReadOnlyList<GetUniversitiesByFiltersResponse>> Get(
            [FromServices] GetUniversitiesByFiltersHandler handler,
            [FromQuery] string name,
            [FromQuery] string country)
        {
            return await handler.Handle(name, country);
        }
    }
}
