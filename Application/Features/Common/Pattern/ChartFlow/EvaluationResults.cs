using System.Collections.Generic;

namespace Application.Features.Common.Pattern.ChartFlow
{
    public class EvaluationResults<T, R>
    {
        public R Result { get; set; }
        public List<PropertySpecifier<T>> RequiredFields { get; set; }
    }
}
