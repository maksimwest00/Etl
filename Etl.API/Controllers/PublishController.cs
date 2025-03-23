using Microsoft.AspNetCore.Mvc;

namespace Etl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        // GET: api/<PublishController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // Пример
        // GET api/<PublishController>?country=Poland&name=West Pomeranian Business School in Szczecin
        [HttpGet]
        public IActionResult Get(
            [FromQuery] string country,
            [FromQuery] string name)
        {
            return Ok();
        }

        // POST api/<PublishController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PublishController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PublishController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
