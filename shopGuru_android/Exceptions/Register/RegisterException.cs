using System;

namespace shopGuru_android.Exceptions.Register
{
    public class RegisterException : Exception
    {
        public RegisterException() { }
        public RegisterException(string message) : base(message) { }
        public RegisterException(string message, Exception inner) : base(message, inner) { }
    }
}
