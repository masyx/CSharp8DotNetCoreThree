using System;
namespace Packt.SharedCh06
{
    public class PersonException : Exception
    {
        public PersonException() : base() { }

        public PersonException(string message) : base(message) { }

        public PersonException(string message, Exception InnerException)
            : base(message, InnerException) { }
    }
}
