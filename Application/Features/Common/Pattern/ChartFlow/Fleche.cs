using System;

namespace Application.Features.Common.Pattern.ChartFlow
{


    public class Fleche<TData>
    {
        public Fleche()
        {
            PointsTo = "";
            Rule = (_) => false;
        }

        public string PointsTo { get; set; }
        public Func<TData, bool> Rule { get; set; }
    }
}
