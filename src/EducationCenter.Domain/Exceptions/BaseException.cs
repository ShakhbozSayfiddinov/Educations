using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenter.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        public int StatusCode { get; set; } 
        protected BaseException(string message,  int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
