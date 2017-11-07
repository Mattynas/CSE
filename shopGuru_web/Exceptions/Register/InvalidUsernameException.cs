using System;

namespace shopGuru_web.Exceptions.Register
{
    public class InvalidUsernameException : RegisterException
    {
        public InvalidUsernameException() { }
        public InvalidUsernameException(string message) : base(message) { }
        public InvalidUsernameException(string message, Exception inner) : base(message, inner) { }
    }
}
