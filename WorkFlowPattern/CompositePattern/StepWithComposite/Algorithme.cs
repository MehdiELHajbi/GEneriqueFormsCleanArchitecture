﻿namespace WorkFlowPattern.CompositePattern.Step
{
    public abstract class Algorithme
    {

        public Algorithme(string name)
        {
            this.name = name;

        }
        public string name { get; set; }
        public int niveau { get; set; }

        #region Trace
        //public Stopwatch _timer;

        //public long _elapsedMilliseconds;
        #endregion

        public abstract void operation();


    }
}
