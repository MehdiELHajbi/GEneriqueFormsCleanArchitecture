using System.Collections.Generic;

namespace Application.Features.Common.Pattern.Rule
{
    public interface ISquenceRule<T> : IRule<T> where T : class
    {

        IEnumerable<IRule<T>> steps { get; set; }
    }
}
