using System.Threading.Tasks;

namespace Application.Features.Common.Pattern.Rule
{
    public interface IRule<T> where T : class
    {
        Task<T> Execute(T ctx);





        string ruleName { get; }
        string RuleDescrition { get; }
        //string RuleExcptOutPut { get; }
    }

}
