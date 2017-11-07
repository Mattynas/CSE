using System;

namespace shopGuru_web.Exceptions.Register
{
    public class InvalidEmailException : RegisterException
    {
        public InvalidEmailException() { }
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message, Exception inner) : base(message, inner) { }
    }
}
