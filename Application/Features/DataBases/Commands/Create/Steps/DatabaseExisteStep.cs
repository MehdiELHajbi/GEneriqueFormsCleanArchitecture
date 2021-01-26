using Application.Common.Exceptions;
using Application.Contracts;
using Application.Features.Common.Pattern.Rule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.DataBases.Commands.Create.Steps
{
    public class DatabaseExisteStep : IRule<Context>
    {
        private readonly string nameDatabse;
        private readonly IDataBaseRepository dataBaseRepository;
        public IEnumerable<IRule<Context>> steps { get; set; }



        public DatabaseExisteStep(string nameDatabse, IDataBaseRepository dataBaseRepository)
        {
            this.nameDatabse = nameDatabse;
            this.dataBaseRepository = dataBaseRepository;
        }


        public async Task<Context> Execute(Context ctx)
        {
            var existe = await this.dataBaseRepository.GetFirstOrDefault(s => s.NameDataBase == nameDatabse);

            if (existe != null)
                //ctx.Continue = false;
                throw new AlreadyExists(this.nameDatabse + " is AlreadyExists");

            return ctx;
        }
    }
}
