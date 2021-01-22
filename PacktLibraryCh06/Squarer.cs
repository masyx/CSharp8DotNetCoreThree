using System;
using System.Threading;

namespace Packt.SharedCh06
{
    public class Squarer
    {
        public static double Square<T>(T input) where T : IConvertible
        {
            var number = input.ToDouble(Thread.CurrentThread.CurrentCulture);
            return number * number;
        }

    }
}
