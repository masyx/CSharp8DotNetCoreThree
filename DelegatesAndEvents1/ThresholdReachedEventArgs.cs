using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents1
{
    class ThresholdReachedEventArgs : EventArgs
    {
        public DateTime TimeThresholdReached { get; set; }
        public int Threashold { get; set; }

        public ThresholdReachedEventArgs(DateTime timeNow, int threshold)
        {
            TimeThresholdReached = timeNow;
            Threashold = threshold;
        }
    }
}
