using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace AAATryingThingsOut
{
    class AAATryingThingsOut
    {
        private const string Phone = "PHONE";
        private const string Email = "EMAIL";
        private const string FirstName = "FIRSTNAME";
        private const string MiddleName = "MIDDLENAME";
        private const string LastName = "LASTNAME";
        private const string Birthdate = "BIRTHDATE";
        private const string Mobile = "MOBILE";
        private const string Fax = "FAX";

        static void Main(string[] args)
        {
            var requestQuestions = new Dictionary<string, int>
            {
              { Phone, 1 },
              { Email, 2 },
              { FirstName, 3 },
              { MiddleName, 4 },
              { LastName, 5 },
              { Birthdate, 6 },
              { Mobile, 7 },
              { Fax, 8 }
            };

            requestQuestions[Phone] = 99;

            int number = requestQuestions[Phone];

            Console.WriteLine(number);
        }


    }
}
