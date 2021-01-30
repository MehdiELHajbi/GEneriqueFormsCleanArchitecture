using Application.Features.Common.Pattern.Rule;
using Application.Features.DataBases.Commands.Create.Responses;
using System;
using System.Collections.Generic;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class Context : IContext
    {
        public bool Continue { get; set; } = true;

        public int DataBase_id { get; set; }
        public CreateDataBesesCommandResponse ReponseObjectToApi { get; set; }

        public Dictionary<Guid, object> ExceptedReult { get; set; }
        public object errors { get; set; }
    }
}
