﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class ApiException : Exception
    {
        public int StatusCode { get; }
        public ApiException(string message,
            int statusCode = 500) : base(message)
        {
            StatusCode = statusCode;
        }
    }

}
