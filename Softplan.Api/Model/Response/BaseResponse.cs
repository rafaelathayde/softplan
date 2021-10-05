using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace Softplan.Api.Dto.Response
{
    public class BaseResponse<TData> : StatusCodeResult where TData : class
    {

        public BaseResponse(TData data, bool success, HttpStatusCode statusCode) : base((int)statusCode)
        {
            Success = success;
            Data = data;
        }

        public BaseResponse(TData data, bool success, HttpStatusCode statusCode, IEnumerable<string> messages) : base((int)statusCode)
        {
            Success = success;
            Messages = messages;
            Data = data;
        }

        public bool Success { get; set; }
        public TData Data { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}