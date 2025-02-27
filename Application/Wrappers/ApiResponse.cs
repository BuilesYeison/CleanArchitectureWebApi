using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Wrappers
{
    public class ApiResponse<T>
    {
        public bool Success { get; }
        public string Message { get; }
        public T Data { get; }

        public ApiResponse(T data, string message = "", bool success = true)
        {
            Data = data;
            Message = message;
            Success = success;
        }
    }

}
