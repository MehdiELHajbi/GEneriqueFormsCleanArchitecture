using Application.Features.DataBases.Commands.Create.Responses.KO;
using Application.Features.DataBases.Commands.Create.Responses.OK;

namespace Application.Features.DataBases.Commands.Create.Responses.DocumentationAPI
{
    // Pour la documentation API , cet classe permet de lister touts les types de retour possible
    public class OneOfCreateDataBaseResponse
    {
        #region OK
        public CreateDataBesesCommandResponse CreateDataBesesCommandResponse { get; set; }

        #endregion

        #region KO
        public ExceptionDataBaseAlreadyExistsResponse ExceptionDataBaseAlreadyExistsResponse { get; set; }
        public ExceptionValidationResponse ExceptionValidationResponse { get; set; }

        #endregion

    }
}
