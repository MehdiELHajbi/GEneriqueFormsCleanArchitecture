using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Features.Common.Pattern.ChartFlow
{
    public class Flowchart<TData, TResult>
    {

        public List<StepFeature<TData, TResult>> ListestepFeature { get; set; }


        public Flowchart()
        {
            ListestepFeature = new List<StepFeature<TData, TResult>>();
        }

        public void Validate()
        {
            CheckForInvalidDestinations();
            CheckForDuplicateNames();
        }

        public EvaluationResults<TData, TResult> Evaluate(TData data)
        {
            var currentstepFeature = ListestepFeature[0];
            var visitedStepsFeatures = new List<StepFeature<TData, TResult>> { currentstepFeature };
            var currentFleche = currentstepFeature.ListeFleches.FirstOrDefault(Fleche => Fleche.Rule(data));

            while (currentFleche != null)
            {
                currentstepFeature = ListestepFeature.Where(shape => shape.Name.Equals(currentFleche.PointsTo)).Single();
                visitedStepsFeatures.Add(currentstepFeature);
                currentFleche = currentstepFeature.ListeFleches.FirstOrDefault(arrow => arrow.Rule(data));
            }

            return ComputeEvaluationResults(visitedStepsFeatures);
        }

        private EvaluationResults<TData, TResult> ComputeEvaluationResults(List<StepFeature<TData, TResult>> visitedShapes)
        {
            var results = new EvaluationResults<TData, TResult>();
            var lastShape = visitedShapes[visitedShapes.Count - 1];
            results.Result = lastShape.Result;
            results.RequiredFields = visitedShapes.Where(s => s.RequiredField != null)
                                                  .Select(s => s.RequiredField)
                                                  .Distinct(PropertySpecifier<TData>.Comparer)
                                                  .ToList();
            return results;
        }


        private void CheckForDuplicateNames()
        {
            var duplicateShapes = ListestepFeature.GroupBy(s => s.Name).Where(g => g.Count() > 1);
            if (duplicateShapes.Count() > 0)
            {
                string message = "The following shape names are duplicated: " +
                                 duplicateShapes.Aggregate(new StringBuilder(), (sb, s) => sb.Append(s.Key + " "), sb => sb.ToString());

                throw new InvalidOperationException(message);
            }
        }

        private void CheckForInvalidDestinations()
        {
            var names = ListestepFeature.Select(s => s.Name);
            var problemTransitions = ListestepFeature.SelectMany(s => s.ListeFleches)
                                           .Where(t => !names.Contains(t.PointsTo));
            if (problemTransitions.Count() > 0)
            {
                string message = "The following destination names are invalid: " +
                    problemTransitions.Aggregate(new StringBuilder(), (sb, t) => sb.Append(t.PointsTo + " "), sb => sb.ToString());

                throw new InvalidOperationException(message);
            }
        }
    }
}
