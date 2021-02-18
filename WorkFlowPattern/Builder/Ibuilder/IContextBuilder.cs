using WorkFlowPattern.Builder.Contexts;

namespace WorkFlowPattern.Builder.Ibuilder
{
    public interface IContextBuilder
    {
        void AddContext(Context context);

        ComputeContext GetContext();
    }
}
