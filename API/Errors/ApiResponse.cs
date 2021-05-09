using System;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultForStatusCode(statusCode);
        }

        private string GetDefaultForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad request, you have made",
                401 => "Authorized, you are not",
                404 => "Resource found, it was not",
                500 => "Errors are the path to the dark side. Error lead to anger...",
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}