using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Application.Exceptions
{
    public class ApplicationFieldValidationException : Exception
    {
        public ApplicationFieldValidationException(string message) : base(message)
        {
        }
    }
}
