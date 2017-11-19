using System;

namespace shopGuru_android.Exceptions.UserData
{
    public class InvalidPasswordException : UserDataException
    {
        public InvalidPasswordException() { }
        public InvalidPasswordException(string message) : base(message) { }
        public InvalidPasswordException(string message, Exception inner) : base(message, inner) { }
    }
}
