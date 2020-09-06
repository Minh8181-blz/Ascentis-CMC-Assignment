using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManager.Web.Models
{
    public class ApiResponseModel
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }

        public ApiResponseModel SetStatus(bool success)
        {
            Success = success;
            return this;
        }

        public ApiResponseModel SetMessage(string message)
        {
            Message = message;
            return this;
        }

        public ApiResponseModel SetData(object data)
        {
            Data = data;
            return this;
        }
    }
}
