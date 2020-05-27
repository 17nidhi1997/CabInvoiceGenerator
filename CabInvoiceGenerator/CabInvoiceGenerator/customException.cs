using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceGenerator
{
    public enum ExceptionType
    {
        NULL_exception
    }
    public class customException : Exception
    {
        public string mgs;
        public customException(string message)
        {
            this.mgs = message;
        }
    }
}

