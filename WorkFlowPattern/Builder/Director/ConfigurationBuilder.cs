using WorkFlowPattern.Builder.Contexts;
using WorkFlowPattern.Builder.Ibuilder;

namespace WorkFlowPattern.Builder.Director
{
    public class ConfigurationBuilder
    {
        public void BuildContext(IContextBuilder contextBuilder,
            Context contexts)
        {
            contextBuilder.AddContext(contexts);
        }
    }
}
