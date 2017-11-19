using System;

namespace shopGuru_android.Exceptions.UserData
{
    public class UserDataException : Exception
    {
        public UserDataException() { }
        public UserDataException(string message) : base(message) { }
        public UserDataException(string message, Exception inner) : base(message, inner) { }
    }
}
