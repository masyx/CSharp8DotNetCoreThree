using System;
using System.Linq;

namespace LinqWithObjects
{
    class LinqWithObjectsClass
    {
        static void Main(string[] args)
        {
            //LinqWithArrayOfStrings();
            LinqWithArrayOfExceptions();
        }

        static void LinqWithArrayOfStrings()
        {
            var names = new string[] { "Michael", "Pam", "Jim", "Dwight",
                "Angela", "Kevin", "Toby", "Creed" };

            //var query = names.Where(new Func<string, bool>(LongerThanFour));
            //var query = names.Where(LongerThanFour);
            var query = names.Where(name => name.Length > 4)
                .OrderBy(name => name.Length);

            foreach (var item in query)
            {
                Console.Write($"{item}, ");
            }
        }

        static bool LongerThanFour(string name)
        {
            return name.Length > 4;
        }

        static void LinqWithArrayOfExceptions()
        {
            Exception[] errors = new Exception[]
            {
                new ArgumentException(),
                new SystemException(),
                new IndexOutOfRangeException(),
                new InvalidOperationException(),
                new NullReferenceException(),
                new InvalidCastException(),
                new OverflowException(),
                new DivideByZeroException(),
                new ApplicationException()
            };

            foreach (Exception error in errors.OfType<ArithmeticException>())
            {
                Console.WriteLine(error);
            }
        }
    }
}
