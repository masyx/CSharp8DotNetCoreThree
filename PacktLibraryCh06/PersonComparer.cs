using System;
using System.Collections.Generic;

namespace Packt.SharedCh06
{
    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);
            if (result == 0)
            {
                return result = x.Name.CompareTo(y.Name);
            }
            else
            {
                return result;
            }

        }
    }
}
