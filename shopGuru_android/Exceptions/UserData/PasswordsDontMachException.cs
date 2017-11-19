using System;

namespace shopGuru_android.Exceptions.UserData
{
    public class PasswordsDontMachException : UserDataException
    {
        public PasswordsDontMachException() { }
        public PasswordsDontMachException(string message) : base(message) { }
        public PasswordsDontMachException(string message, Exception inner) : base(message, inner) { }
    }
}
