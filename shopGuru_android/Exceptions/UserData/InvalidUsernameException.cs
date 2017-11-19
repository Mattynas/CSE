using System;

namespace shopGuru_android.Exceptions.UserData
{
    public class InvalidUsernameException : UserDataException
    {
        public InvalidUsernameException() { }
        public InvalidUsernameException(string message) : base(message) { }
        public InvalidUsernameException(string message, Exception inner) : base(message, inner) { }
    }
}
