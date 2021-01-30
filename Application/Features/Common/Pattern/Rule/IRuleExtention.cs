using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Features.Common.Pattern.Rule
{

    public static class IRuleExtention
    {
        public static T FirstOrDefaultFromMany<T>(
            this IEnumerable<T> source, Func<T, IEnumerable<T>> childrenSelector,
            Predicate<T> condition)
        {
            // return default if no items
            if (source == null || !source.Any()) return default(T);

            // return result if found and stop traversing hierarchy
            var attempt = source.FirstOrDefault(t => condition(t));

            if (!Equals(attempt, default(T))) return attempt;

            // recursively call this function on lower levels of the
            // hierarchy until a match is found or the hierarchy is exhausted
            return source.SelectMany(childrenSelector)
                .FirstOrDefaultFromMany(childrenSelector, condition);
        }


        public static IEnumerable<T> Flatten<T>(this T source, Func<T, IEnumerable<T>> selector)
        {
            return selector(source).SelectMany(c => Flatten(c, selector))
                                   .Concat(new[] { source });
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            return source.SelectMany(x => Flatten(x, selector))
                .Concat(source);
        }

        public static string GetChaine(this IRule<IContext> strategy)
        {
            var c = "";
            foreach (var st in strategy.steps)
            {
                if (st.steps == null)
                {
                    c = c + "-->" + st.ruleName;
                    //if (st.StrategieError != "")
                    //    return c;
                }

                else
                {
                    c = c + "; (" + st.ruleName + ")";
                    c = c + st.GetChaine();

                }
            }
            return c;
        }
    }

}
