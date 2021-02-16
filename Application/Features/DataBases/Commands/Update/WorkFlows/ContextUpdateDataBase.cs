using Application.Contracts;
using Application.Features.Common.Pattern.CompositeSwitch;

namespace Application.Features.DataBases.Commands.Update.WorkFlows
{
    public class ContextUpdateDataBase : Context
    {
        public ContextUpdateDataBase(UpdateDataBesesCommand updateDataBesesCommand, IDataBaseRepository dataBaseRepository)
        {
            this.req = updateDataBesesCommand;
            this.dataBaseRepository = dataBaseRepository;
        }
        public bool Continue { get; set; } = true;

        public UpdateDataBesesCommand req { get; set; }

        public IDataBaseRepository dataBaseRepository { get; set; }
    }
}
