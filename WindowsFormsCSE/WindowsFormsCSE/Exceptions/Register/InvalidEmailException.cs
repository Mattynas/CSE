using System;

namespace WindowsFormsCSE.Exceptions.Register
{
    class InvalidEmailException : RegisterException
    {
        public InvalidEmailException() { }
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message, Exception inner) : base(message, inner) { }
    }
}
