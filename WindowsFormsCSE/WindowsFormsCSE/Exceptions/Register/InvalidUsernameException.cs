using System;

namespace WindowsFormsCSE.Exceptions.Register
{
    class InvalidUsernameException : RegisterException
    {
        public InvalidUsernameException() { }
        public InvalidUsernameException(string message) : base(message) { }
        public InvalidUsernameException(string message, Exception inner) : base(message, inner) { }
    }
}
