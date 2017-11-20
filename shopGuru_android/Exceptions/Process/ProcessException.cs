using System;

namespace shopGuru_android.Exceptions.Process
{
    public class ProcessException : Exception
    {
        public ProcessException() { }
        public ProcessException(string message) : base(message) { }
        public ProcessException(string message, Exception inner) : base(message, inner) { }
    }
}