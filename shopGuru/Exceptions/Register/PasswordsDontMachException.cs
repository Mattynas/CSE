using System;

namespace shopGuru.Exceptions.Register
{
    public class PasswordsDontMachException : RegisterException
    {
        public PasswordsDontMachException() { }
        public PasswordsDontMachException(string message) : base(message) { }
        public PasswordsDontMachException(string message, Exception inner) : base(message, inner) { }
    }
}
