using Application.Contracts;
using Application.Features.Common.Pattern.Rule;
using Application.Features.DataBases.Commands.Create.Responses.KO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class IfDatabaseExisteStep : IRule<Context>
    {
        public string RuleDescrition { get; } = " DatabaseExisteStep permet si le nom de la  'DataBase' passer en parmetre existe deja dans la Bd";
        private List<object> ExceptedReult => new List<object>()
            {new { ExceptionDataBaseAlreadyExistsResponse  = new ExceptionDataBaseAlreadyExistsResponse(new { x=""}) }};
        //private AlreadyExists AlreadyExistsObject { get; set; }
        public IEnumerable<IRule<Context>> steps { get; set; }

        public ExceptionDataBaseAlreadyExistsResponse ExceptionDataBaseAlreadyExistsResponse;
        string IRule<Context>.ruleName => nameof(IfDatabaseExisteStep);

        private readonly string nameDatabse;
        private readonly IDataBaseRepository dataBaseRepository;
        public IfDatabaseExisteStep(string nameDatabse, IDataBaseRepository dataBaseRepository)
        {

            this.nameDatabse = nameDatabse;
            this.dataBaseRepository = dataBaseRepository;
            this.ExceptionDataBaseAlreadyExistsResponse = new ExceptionDataBaseAlreadyExistsResponse(this.nameDatabse);
            //AlreadyExistsObject = new AlreadyExists(this.nameDatabse + " is Already Exists", "String", "int");
            //AlreadyExistsObject.reponseKO.Specific.Add(new { detail = "String", facture = "int" });
            //ExceptedReult = new Dictionary<string, object>();
            //this.ExceptedReult.Add(Guid.NewGuid().ToString(), new AlreadyExists(nameof(this.nameDatabse) + " is Already Exists"));
        }


        public async Task<Context> Execute(Context ctx)
        {
            var existe = await this.dataBaseRepository.GetFirstOrDefault(s => s.NameDataBase == this.nameDatabse);

            if (existe != null)
            {
                //ExceptionAlreadyExistExtension(this.nameDatabse);
                //throw new ExceptionDataBaseAlreadyExistsResponse(this.nameDatabse);
                throw this.ExceptionDataBaseAlreadyExistsResponse;
            }




            return ctx;
        }

        //private void ExceptionAlreadyExistExtension(string nameDatabase)
        //{
        //    // ADD Cutom Errors
        //    IDictionary<string, object> objectError = new Dictionary<string, object>();

        //    objectError.Add("AlreadyExists", new AlreadyExistsDetailError(nameof(nameDatabase), nameDatabase, nameDatabase + " ne peut etre en double dans la BD"));
        //    objectError.Add("test", new AlreadyExistsDetailError(nameof(nameDatabase), nameDatabase, nameDatabase + " ne peut etre en double dans la BD"));

        //    throw new DataBaseAlreadyExistsResponse(nameDatabase);

        //}
    }

    //internal class AlreadyExistsDetailError
    //{
    //    public string Field { get; }
    //    public string Value { get; }
    //    public object Detail { get; }

    //    public AlreadyExistsDetailError(string field, string value, object detail)
    //    {
    //        Field = field;
    //        Value = value;
    //        Detail = detail;
    //    }

    //    public override bool Equals(object obj)
    //    {
    //        return obj is AlreadyExistsDetailError other &&
    //               Field == other.Field &&
    //               Value == other.Value &&
    //               EqualityComparer<object>.Default.Equals(Detail, other.Detail);
    //    }

    //    public override int GetHashCode()
    //    {
    //        return HashCode.Combine(Field, Value, Detail);
    //    }
    //}
}
