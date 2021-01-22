using System;
namespace Packt.SharedCh06
{
    public class Employee : Person
    {
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }

        public new void WriteToConsole()
        {
            Console.WriteLine($"{base.Name} was born on {base.DateOfBirth:dd/MM/yy} " +
                $"and hired on {HireDate:dd/MM/yy}");
        }

        public override string ToString()
        {
            return $"{Name}'s code is {EmployeeCode}";
        }
    }
}
