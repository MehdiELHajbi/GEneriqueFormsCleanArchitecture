using System.Collections.Generic;

namespace Application.Features.Common.Pattern.Rule
{
    public interface ISquenceRule<T> : IRule<IContext> where T : class
    {

        IEnumerable<IRule<T>> steps { get; set; }
    }
}
