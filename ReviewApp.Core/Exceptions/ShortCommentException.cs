using System;
namespace ReviewApp.Core.Exceptions
{
    public class ShortCommentException : Exception
    {
        public ShortCommentException() :
            base($"Il commento è più corto di dieci caratteri")
        {
        }
    }
}

