using System.Diagnostics;
using System.IO;

namespace Instrumenting
{
    class Instrumenting
    {
        public static void Main(string[] args)
        {
            // Use this example when debugging.  
            System.Diagnostics.Debug.WriteLine("Debug. Error in Widget 42");
            // Use this example when tracing.  
            System.Diagnostics.Trace.WriteLine("Trace. Error in Widget 42");
        }
    }
}
