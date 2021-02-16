using System;
using WorkFlowPattern.CompositePattern.Step;

namespace WorkFlowPattern.CompositePattern.StepWithComposite
{
    public class Tasks : Algorithme
    {
        public Tasks(string name) : base(name) { }// _timer = new Stopwatch(); _timer.Start();

        public override void operation()
        {

            string tab = "";
            for (int i = 0; i < niveau; i++)
            {
                tab += "----";
            }
            Console.WriteLine(tab + "  Tasks : " + name);
            //_timer.Stop();

            //_elapsedMilliseconds = _timer.ElapsedMilliseconds;

            //Console.WriteLine(tab + "  Tasks : " + name + " Time Execution: " + _elapsedMilliseconds);

        }
    }
}
