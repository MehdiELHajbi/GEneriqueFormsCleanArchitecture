using WorkFlowPattern.Builder.Contexts;
using WorkFlowPattern.Builder.Ibuilder;

namespace WorkFlowPattern.Builder.ConcreteBuilder
{
    public class ContextUpdateDataBase : IContextBuilder
    {

        ComputeContext UpdateDataBaseContext =
              new ComputeContext();
        public string req { get; set; }

        public string dataBaseRepository { get; set; }

        public void AddContext(Context context)
        {
            UpdateDataBaseContext.Context = context;
        }

        public ComputeContext GetContext()
        {
            return UpdateDataBaseContext;
        }
    }
}
