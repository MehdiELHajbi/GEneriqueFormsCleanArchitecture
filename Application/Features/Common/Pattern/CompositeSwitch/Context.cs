using Application.Features.Common.BaseResponse;

namespace Application.Features.Common.Pattern.CompositeSwitch
{
    public abstract class Context
    {
        public ResponseAbstract Result { get; set; }
        public bool Continue { get; set; } = true;


        //public abstract WorkFlowSwitch<IContext> Switch(object decision);









    }
}
