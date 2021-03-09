using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents1
{
    // CLASS THAT PUBLISHES AN EVENT
    internal class Counter
    {
        private int _total;
        public int Threshold { get; set; }

        // DECLARE AN EVENT USING EventHandler<T>
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

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

            // RAISING AN EVENT, THIS IS THE RIGHT WAY TO DO IT
            OnThresholdReached(thresholdEventArgs);

            // this is BAD PRACTICE, DON'T do it, just for study purpose here
            //ThresholdReached(this, args); /* OR */ ThresholdReached?.Invoke(this, args);
        }

        // Wrap event invocation inside protected virtual method
        // to allow derived classes to override invocation behavior
        public virtual void OnThresholdReached(ThresholdReachedEventArgs eventArgs)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            var thresholdReached = ThresholdReached;

            // Event will be null if there are no subscribers, checking for null
            // Call to raise the event
            ThresholdReached?.Invoke(this, eventArgs);
        }
    }
}
