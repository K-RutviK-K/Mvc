using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace jwtApi.Dtos
{
    public class Response
    {
        public Response(object data, bool success, string message, int statusCode)
        {
            this.data = data;
            this.success = success;
            this.message = message;
            this.statusCode = statusCode;
        }

        public object data { get; set; }
        public bool success { get; set; } = false;
        public string message { get; set; }
        public int statusCode { get; set; }
        
    }
}
