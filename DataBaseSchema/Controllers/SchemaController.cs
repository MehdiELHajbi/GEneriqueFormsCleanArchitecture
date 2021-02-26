using EntityFrameWorkShema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DataBaseSchema.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchemaController : ControllerBase
    {

        private readonly ILogger<SchemaController> _logger;

        public SchemaController(ILogger<SchemaController> logger)
        {
            _logger = logger;
        }


        [HttpGet("GetSchema", Name = "GetShemaDataBase")]
        public string ShemaDataBase([FromQuery] DatabaseOptions databseOption)
        {
            var schema = Shemadatabase.GetShema("", databseOption);

            var json = JsonConvert.SerializeObject(schema, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });


            return json;
        }

    }
}
