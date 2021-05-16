using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DevBetty.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonFormatterController : ControllerBase
    {
        private readonly ILogger<JsonFormatterController> _logger;

        public JsonFormatterController(ILogger<JsonFormatterController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            string body = null;

            using (var reader = new System.IO.StreamReader(Request.Body))
            {
                body = await reader.ReadToEndAsync();
            }

            if (string.IsNullOrWhiteSpace(body))
            {
                return BadRequest();
            }

            string output = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(body));
            return Ok(output);
        }
    }
}
