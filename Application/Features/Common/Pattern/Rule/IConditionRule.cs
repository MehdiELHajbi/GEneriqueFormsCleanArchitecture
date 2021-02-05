using System.Collections.Generic;

namespace Application.Features.Common.Pattern.Rule
{
    public interface IConditionRule<T> : IRule<T> where T : class
    {
        IEnumerable<IRule<T>> stepsIfTrue { get; set; }
        IEnumerable<IRule<T>> stepsIfFalse { get; set; }
    }
}
