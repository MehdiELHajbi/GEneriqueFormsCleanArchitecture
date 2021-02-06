using Application.Features.Common.Models;
using Application.Features.DataBases.Commands.Create;
using Application.Features.DataBases.Commands.Create.Responses.DocumentationAPI;
using Application.Features.DataBases.Commands.Create.Responses.KO;
using Application.Features.DataBases.Commands.Update;
using Application.Features.DataBases.Queries;
using Application.Features.DataBases.Queries.ExportGetListDataBeses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DataBaseController : ApiControllerBase
    {
        public IFeatureManager FeatureManager { get; }

        public DataBaseController(IFeatureManager featureManager)
        {
            FeatureManager = featureManager;
        }


        [HttpGet("all", Name = "GetAllDatabases")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ListDataBasesVM>>> GetAllDatabases()
        {
            var dtos = await Mediator.Send(new GetListDataBesesQuery());
            return Ok(dtos);
        }

        [HttpGet("allWithPagination", Name = "GetAllDatabasesWithPagination")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedList<ListDataBasesDTO>>> GetAllDatabasesWithPagination([FromQuery] GetListDataBesesWithPaginationQuery query)
        {
            var dtos = await Mediator.Send(query);
            return Ok(dtos);
        }


        [HttpGet("csvDataBase", Name = "ExpoertListDataBase")]
        public async Task<FileResult> ExpoertListDataBase()
        {
            var dtos = await Mediator.Send(new ExportGetListDataBesesQuery());
            return File(dtos.Content, dtos.ContentType, dtos.FileName);
        }


        [HttpPost(Name = "AddDataBase")]
        //[ProducesResponseType(typeof(ExceptionValidationResponse), 400)]
        //[ProducesResponseType(typeof(ExceptionDataBaseAlreadyExistsResponse), 400)]

        //[ProducesResponseType(typeof(ReponseKO), 400)]
        //[SwaggerResponse(System.Net.HttpStatusCode.NotFound, Type = typeof(string))]

        public async Task<ActionResult<OneOfCreateDataBaseResponse>> Create([FromBody] CreateDataBesesCommand createCategoryCommand)
        {

            var response = await Mediator.Send(createCategoryCommand);
            return Ok(response);
        }


        [HttpPut(Name = "UpdatDataBase")]
        [ProducesResponseType(typeof(ExceptionValidationResponse), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ExceptionDataBaseAlreadyExistsResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UpdateDataBesesCommandResponse), StatusCodes.Status200OK)]

        //[ProducesDefaultResponseType]
        public async Task<ActionResult<UpdateDataBesesCommandResponse>> Update([FromBody] UpdateDataBesesCommand updateEventCommand)
        {
            var response = await Mediator.Send(updateEventCommand);
            return response;
        }



        [HttpGet("SecretPage", Name = "SecretPage")]
        //[FeatureGate("SecretPage")]
        public async Task<ActionResult<object>> SecretPage()
        {
            object response = new { };
            if (await FeatureManager.IsEnabledAsync("SecretPage"))
            {
                response = new
                { testValue = "YOYO" };

            }
            else
            {
                //Environment.SetEnvironmentVariable("FeatureManagement__SecretPage", "true", EnvironmentVariableTarget.Machine);

                response = new
                { testValue = "DADA" };
            }


            return await Task.FromResult(response);
        }
    }
}


// get attribute value to genrate test , number of result
//https://blog.dangl.me/archive/different-response-schemas-in-aspnet-core-swagger-api-definition-with-nswag/
