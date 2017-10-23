﻿using System;

namespace WindowsFormsCSE.Exceptions.Register
{
    public class InvalidPasswordException : RegisterException
    {
        public InvalidPasswordException() { }
        public InvalidPasswordException(string message) : base(message) { }
        public InvalidPasswordException(string message, Exception inner) : base(message, inner) { }
    }
}