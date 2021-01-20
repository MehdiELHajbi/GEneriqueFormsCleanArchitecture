using Application.Features.Common.Models;
using Application.Features.DataBases.Commands.Create;
using Application.Features.DataBases.Commands.Update;
using Application.Features.DataBases.Queries;
using Application.Features.DataBases.Queries.ExportGetListDataBeses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DataBaseController : ApiControllerBase
    {




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
        public async Task<ActionResult<CreateDataBesesCommandResponse>> Create([FromBody] CreateDataBesesCommand createCategoryCommand)
        {
            var response = await Mediator.Send(createCategoryCommand);
            return Ok(response);
        }


        [HttpPut(Name = "UpdateEvent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesDefaultResponseType]
        public async Task<ActionResult<UpdateDataBesesCommandResponse>> Update([FromBody] UpdateDataBesesCommand updateEventCommand)
        {
            var response = await Mediator.Send(updateEventCommand);
            return response;
        }

    }
}
