using System;

namespace shopGuru_android.Exceptions.Process
{
    public class ReceiptNotReadableException : Exception
    {
        public ReceiptNotReadableException() { }
        public ReceiptNotReadableException(string message) : base(message) { }
        public ReceiptNotReadableException(string message, Exception inner) : base(message, inner) { }
    }
}