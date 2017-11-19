using System;

namespace shopGuru_android.Exceptions.UserData
{
    public class InvalidEmailException : UserDataException
    {
        public InvalidEmailException() { }
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message, Exception inner) : base(message, inner) { }
    }
}
