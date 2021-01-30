using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Features.Common.Pattern.Rule
{
    public interface IRule<T> where T : class
    {
        Task<T> Execute(T ctx);



        IEnumerable<IRule<T>> steps { get; set; }

        string ruleName { get; }
        string RuleDescrition { get; }
        //string RuleExcptOutPut { get; }
    }

}
