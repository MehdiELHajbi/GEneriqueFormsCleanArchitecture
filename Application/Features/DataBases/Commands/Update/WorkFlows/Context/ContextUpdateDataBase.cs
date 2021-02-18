using Application.Contracts;
using Application.Features.Common.Pattern.CompositeSwitch;
using Domain.Entites;

namespace Application.Features.DataBases.Commands.Update.WorkFlows
{
    public class ContextUpdateDataBase : Context
    {
        public ContextUpdateDataBase(UpdateDataBesesCommand updateDataBesesCommand, IDataBaseRepository dataBaseRepository)
        {
            this.req = updateDataBesesCommand;
            this.dataBaseRepository = dataBaseRepository;
            this.dataBases = new DataBase();
        }

        public UpdateDataBesesCommand req { get; set; }
        public DataBase dataBases { get; set; }

        public IDataBaseRepository dataBaseRepository { get; set; }

    }
}
