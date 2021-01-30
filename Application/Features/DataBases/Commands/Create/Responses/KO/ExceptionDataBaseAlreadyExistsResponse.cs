using Application.Common.Exceptions;

namespace Application.Features.DataBases.Commands.Create.Responses.KO
{
    public class ExceptionDataBaseAlreadyExistsResponse : BaseException
    {


        private static string msgAlreadyExists => "Name of Databse  is Already Exists";

        public ExceptionDataBaseAlreadyExistsResponse(object nameDataBase)
         : base(msgAlreadyExists, AddObjectErrors(nameDataBase))
        {

        }

        public static object AddObjectErrors(object nameDataBase)
        {
            AlreadyExistsDetailError errors = new AlreadyExistsDetailError();
            errors.AlreadyExistException.Field = nameof(nameDataBase);
            errors.AlreadyExistException.Value = nameDataBase;
            errors.AlreadyExistException.Detail = nameDataBase + " ne peut etre en double dans la BD";
            errors.AlreadyExistException.Type = nameDataBase.GetType().Name;

            return errors;
        }

    }

    public class AlreadyExistsDetailError
    {
        public AlreadyExist AlreadyExistException { get; set; }
        public AlreadyExistsDetailError()
        {
            AlreadyExistException = new AlreadyExist();
        }
    }
    public class AlreadyExist
    {
        public string Field { get; set; }
        public object Value { get; set; }
        public string Detail { get; set; }
        public string Type { get; set; }

    }


}
