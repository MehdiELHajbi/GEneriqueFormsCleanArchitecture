using System;
using System.Linq.Expressions;

namespace Application.Features.Common.Pattern.ChartFlow
{
    public static class FluentFlowchartExtensions
    {
        public static Flowchart<T, R> AddStepFeature<T, R>(this Flowchart<T, R> chart, string StepFeatureName)
        {
            var StepFeature = new StepFeature<T, R> { Name = StepFeatureName };
            chart.ListestepFeature.Add(StepFeature);
            return chart;
        }

        public static Flowchart<T, R> YieldsResult<T, R>(this Flowchart<T, R> chart, R result)
        {
            chart.LastStepFeature().Result = result;
            return chart;
        }

        public static Flowchart<T, R> Requires<T, R>(this Flowchart<T, R> chart, Expression<Func<T, object>> field)
        {
            var specifier = new PropertySpecifier<T>(field);
            chart.LastStepFeature().RequiredField = specifier;
            return chart;
        }

        public static Flowchart<T, R> WithArrowPointingTo<T, R>(this Flowchart<T, R> chart, string pointsTo)
        {
            var arrow = new Fleche<T> { PointsTo = pointsTo };
            chart.LastStepFeature().ListeFleches.Add(arrow);
            return chart;
        }

        public static Flowchart<T, R> AndRule<T, R>(this Flowchart<T, R> chart, Func<T, bool> rule)
        {
            chart.LastStepFeature().LastFleche().Rule = rule;
            return chart;
        }

        public static StepFeature<T, R> LastStepFeature<T, R>(this Flowchart<T, R> chart)
        {
            return chart.ListestepFeature[chart.ListestepFeature.Count - 1];
        }

        public static Fleche<T> LastFleche<T, R>(this StepFeature<T, R> StepFeature)
        {
            return StepFeature.ListeFleches[StepFeature.ListeFleches.Count - 1];
        }
    }
}
