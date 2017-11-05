using System;

namespace shopGuru.Exceptions.Register
{
    public class InvalidEmailException : RegisterException
    {
        public InvalidEmailException() { }
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message, Exception inner) : base(message, inner) { }
    }
}
