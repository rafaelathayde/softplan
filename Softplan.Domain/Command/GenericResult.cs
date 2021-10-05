using System;
using System.Collections.Generic;
using System.Text;

namespace Softplan.Domain.Command
{
    public class GenericResult
    {   public GenericResult() { }

        public GenericResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
