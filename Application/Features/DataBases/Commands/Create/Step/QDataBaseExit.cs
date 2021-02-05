using Application.Contracts;
using Application.Features.Common.Pattern.Rule;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Application.Features.DataBases.Commands.Create.Step
{
    public class QDataBaseExit : IRule<Context>
    {
        public string RuleDescrition { get; } = " DatabaseExisteStep permet si le nom de la  'DataBase' passer en parmetre existe deja dans la Bd";
        public IEnumerable<IRule<Context>> steps { get; set; }

        string IRule<Context>.ruleName => nameof(Context);

        private readonly string nameDatabse;
        private readonly IDataBaseRepository dataBaseRepository;
        public QDataBaseExit(string nameDatabse, IDataBaseRepository dataBaseRepository)
        {

            this.nameDatabse = nameDatabse;
            this.dataBaseRepository = dataBaseRepository;
            //this.ExceptionDataBaseAlreadyExistsResponse = new ExceptionDataBaseAlreadyExistsResponse(this.nameDatabse);
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
                //throw this.ExceptionDataBaseAlreadyExistsResponse;
            }




            return ctx;
        }

    }
}
