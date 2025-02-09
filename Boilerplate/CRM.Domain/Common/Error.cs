﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Common
{
    public class Error : ValueObject
    {
        public string Code { get; }
        public string Message { get; }
        public int StatusCode { get; }

        internal Error(string code, string message, int statusCode = 400)
        {
            Code = code;
            Message = message;
            StatusCode = statusCode;
        }

        internal Error(Exception ex, int statusCode = 500)
        {
            Code = "general.exception";
            Message = ex.Message;
            StatusCode = statusCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code);
        }
    }
}
