using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents1
{
    // Class which holds custom event info
    internal class ThresholdReachedEventArgs : EventArgs
    {
        public DateTime TimeThresholdReached { get; set; }
        public int Threshold { get; set; }

        public ThresholdReachedEventArgs() { }
        public ThresholdReachedEventArgs(DateTime timeNow, int threshold)
        {
            TimeThresholdReached = timeNow;
            Threshold = threshold;
        }
    }
}
