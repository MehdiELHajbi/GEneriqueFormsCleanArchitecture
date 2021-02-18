using Application.Features.Common.BaseResponse;

namespace Application.Features.DataBases.Commands.Update.Responses.KO
{

    public class ExceptionUpdateDataBaseAlreadyExistsResponse : KoObject<AlreadyExistsDetailErrors>
    {

        //public AlreadyExistsDetailError alreadyExistsDetailError { get; set; }
        private static string msgAlreadyExists => "Name of Databse  is Already Exists";

        public ExceptionUpdateDataBaseAlreadyExistsResponse(string nameDataBase)

        : base(msgAlreadyExists, AddObjectErrors(nameDataBase))
        {

        }

        public static AlreadyExistsDetailErrors AddObjectErrors(string nameDataBase)
        {
            var errors = new AlreadyExistsDetailErrors();
            errors.AlreadyExistException.Field = nameof(nameDataBase);
            errors.AlreadyExistException.Value = nameDataBase;
            errors.AlreadyExistException.Detail = nameDataBase + " ne peut etre en double dans la BD";
            errors.AlreadyExistException.Type = nameDataBase.GetType().Name;

            return errors;
        }

    }

    public class AlreadyExistsDetailErrors
    {
        public AlreadyExists AlreadyExistException { get; set; }
        public AlreadyExistsDetailErrors()
        {
            AlreadyExistException = new AlreadyExists();
        }
    }
    public class AlreadyExists
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public string Detail { get; set; }
        public string Type { get; set; }

    }
}
