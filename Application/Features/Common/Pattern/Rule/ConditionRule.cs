namespace Application.Features.Common.Pattern.Rule
{
    public static class ConditionRule<T>
    {

        public static T Condition(bool condition, T nextStepsIfTrue, T nextStepsIfFalse)
        {
            if (condition)
                return nextStepsIfTrue;

            return nextStepsIfFalse;
        }
    }
}
