using Application.Features.DataBases.Commands.Update.Responses.KO;
using Application.Features.DataBases.Commands.Update.Responses.OK;

namespace Application.Features.DataBases.Commands.Update.Responses.DocumentationAPI
{
    public class OneOfUpdateDataBaseResponse
    {
        #region OK
        public UpdateDataBesesCommandResponse UpdateDataBesesCommandResponse { get; set; }

        #endregion

        #region KO
        public ExceptionUpdateDataBaseNotExisteResponse ExceptionUpdateDataBaseNotExisteResponse { get; set; }
        public ExceptionUpdateDataBaseAlreadyExistsResponse ExceptionUpdateDataBaseAlreadyExistsResponse { get; set; }


        #endregion
    }
}
