using System;

namespace WindowsFormsCSE.Exceptions.Register
{
    class PasswordsDontMachException : RegisterException
    {
        public PasswordsDontMachException() { }
        public PasswordsDontMachException(string message) : base(message) { }
        public PasswordsDontMachException(string message, Exception inner) : base(message, inner) { }
    }
}
