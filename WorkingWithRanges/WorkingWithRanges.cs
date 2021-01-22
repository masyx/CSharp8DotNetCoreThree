using System;

namespace WorkingWithRanges
{
    class WorkingWithRanges
    {
        static void Main(string[] args)
        {
            var name = "Samantha Jones";

            var indexOfSpace = name.IndexOf(' ');
            var firstName = name.Substring(0, indexOfSpace);
            var lastName = name.Substring(indexOfSpace + 1, name.Length - 1 - indexOfSpace);

            Console.WriteLine($"First name: {firstName}. Last name: {lastName}");


            ReadOnlySpan<char> nameAsSpan = name.AsSpan();
            int lengthOfLast = name.Length - name.IndexOf(' ') - 1;
            int lengthOfFirst = name.Length - lengthOfLast - 1;
            ReadOnlySpan<char> firstNameSpan = nameAsSpan[0..lengthOfFirst];
            
            ReadOnlySpan<char> lastNameSpan = nameAsSpan[^lengthOfLast..^0];
            Console.WriteLine($"First name: {firstNameSpan.ToString()}. " +
                $"Last name: {lastNameSpan.ToString()}");
        }
    }
}
