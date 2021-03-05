using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents1
{
    class Counter
    {
        private int _total;
        public int Threshold { get; set; }
        public EventHandler<ThresholdReachedEventArgs> ThresholdReached;

        public Counter(int threshold)
        {
            Threshold = threshold;
        }

        public void Add(int x)
        {
            _total += x;
            
            if (Threshold < _total)
            {
                return;
            }
            var thresholdEventArgs = new ThresholdReachedEventArgs(DateTime.Now, Threshold);
            OnTheasholdReached(thresholdEventArgs);
        }

        public virtual void OnTheasholdReached(ThresholdReachedEventArgs eventArgs)
        {
            ThresholdReached?.Invoke(this, eventArgs);
        }
    }
}
