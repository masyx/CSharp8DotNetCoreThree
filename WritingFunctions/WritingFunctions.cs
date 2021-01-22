using System;

namespace WritingFunctions
{
    class WritingFunctions
    {
        public static void Main(string[] args)
        {

            //RunTimesTable();
            //RunCalculateTax();
            //RunCardinalToOrdinal();
            RunFactorial();
        }

        /// <summary>
        /// This function creates times table
        /// </summary>
        /// <param name="number">Enter the number</param>
        public static void TimesTable(byte number)
        {
            Console.WriteLine($"This is the {number} times table:");

            for (int row = 1; row <= 12; row++)
            {
                Console.WriteLine($"{row} * {number} = {row * number}");
            }
            Console.WriteLine();
        }

        public static void RunTimesTable()
        {
            bool isNumber;

            Console.WriteLine("Enter a number between 0 and 255: ");
            do
            {
                isNumber = byte.TryParse(Console.ReadLine(), out byte number);

                if (isNumber)
                {
                    TimesTable(number);
                }
                else
                {
                    Console.WriteLine("You did not enter a valid number!");
                }
            } while (isNumber);
        }

        public static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
        {
            decimal rate = twoLetterRegionCode switch
            {
                "CH" => 0.08M,
                "DK" or "NO" => 0.25M,
                "GB" or "FR" => 0.2M,
                "HU" => 0.27M,
                "OR" or "AK" or "MT" => 0.0M,
                "ND" or "WI" or "ME" or "VA" => 0.05M,
                "CA" => 0.0825M,
                _ => 0.06M,
            };
            return amount * rate;
        }

        public static void RunCalculateTax()
        {
            Console.WriteLine("Enter an amount: ");
            string amountInText = Console.ReadLine();
            Console.WriteLine("Enter a two-letter region code: ");
            string regionCode = Console.ReadLine();

            if (decimal.TryParse(amountInText, out decimal amount))
            {
                decimal taxToPay = CalculateTax(amount, regionCode);
                Console.WriteLine($"You must pay {taxToPay} in sales tax.");
            }
            else
            {
                Console.WriteLine("You did not enter a valid amount!");
            }
        }

        public static string CardinalToOrdinal(int number)
        {
            switch (number)
            {
                case 11:
                case 12:
                case 13:
                    return $"{number}th";
                default:
                    string numberAsText = number.ToString();
                    char lastDigit = numberAsText[numberAsText.Length - 1];
                    string suffix = string.Empty;
                    switch (lastDigit)
                    {
                        case '1':
                            suffix = "st";
                            break;
                        case '2':
                            suffix = "nd";
                            break;
                        case '3':
                            suffix = "rd";
                            break;
                        default:
                            suffix = "th";
                            break;
                    }
                    return $"{number}{suffix}";
            }
        }

        public static void RunCardinalToOrdinal()
        {
            for (int number = 0; number <= 40; number++)
            {
                Console.WriteLine($"{CardinalToOrdinal(number)}");
            }
            Console.WriteLine();
        }

        public static long Factorial(long number)
        {
            if (number == 0)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                return number * Factorial(number - 1);
            }
        }

        public static void RunFactorial()
        {
            bool isNumber;
            do
            {
                Console.Write("Write a number:");
                isNumber = long.TryParse(Console.ReadLine(), out long number);

                if (isNumber)
                {
                    Console.WriteLine($"{number:N0}! = {Factorial(number):N0}");
                }
                else
                {
                    Console.WriteLine("You did not enter a valid number!");
                }
            } while (isNumber);
        }
    }
}