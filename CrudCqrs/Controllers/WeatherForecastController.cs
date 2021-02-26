using App.dd.project;
using DataBaseSchema;
using EntityFrameWorkShema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CrudCqrs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("DataBaseSchema", Name = "DataBaseSchema")]
        public string test([FromQuery] DatabaseOptions databseOption)
        {

            return CommunicationService.GEtSchemaJson(databseOption);
        }

        [HttpGet("EntityContext", Name = "EntityContext")]
        public string EntityContext([FromQuery] DatabaseOptions databseOption)
        {

            var entityContext = GeneratorEntityContext.genrate(databseOption);

            var json = JsonConvert.SerializeObject(entityContext, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

            return "Yes";

        }
    }
}
