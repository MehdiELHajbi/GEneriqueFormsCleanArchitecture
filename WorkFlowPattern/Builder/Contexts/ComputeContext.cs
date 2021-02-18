namespace WorkFlowPattern.Builder.Contexts
{
    public class ComputeContext
    {
        public ResponseAbstract Result { get; set; }
        public Context Context { get; set; }
        public bool Continue { get; set; } = true;



    }

    public interface ResponseAbstract
    {


    }


}
