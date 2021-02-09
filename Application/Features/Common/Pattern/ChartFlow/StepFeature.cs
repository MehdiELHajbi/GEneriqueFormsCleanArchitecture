using System.Collections.Generic;

namespace Application.Features.Common.Pattern.ChartFlow
{

    public class StepFeature<TData, TResult>
    {
        public StepFeature()
        {
            ListeFleches = new List<Fleche<TData>>();
            Result = default(TResult);
        }
        public TResult Result { get; set; }
        public string Name { get; set; }
        public PropertySpecifier<TData> RequiredField { get; set; }
        public List<Fleche<TData>> ListeFleches { get; set; }
    }
}
