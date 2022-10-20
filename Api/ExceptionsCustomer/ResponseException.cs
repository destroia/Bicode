using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ExceptionsCustomer
{
    public class ResponseException
    {
        public object Result  { get; set; }
        public string Message { get; set; }
        public bool State { get; set; } = false;
    }
}
