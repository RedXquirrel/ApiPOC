using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyApi.Interfaces;

namespace MyApi.ResponseTypes
{
    public abstract class BaseResponse
    {
        protected abstract void AssignFromHttpResponseContent(HttpContent responseContent);

        public bool Success { get; internal set; }

        public object Content { get; set; }

        public HttpStatusCode StatusCode { get; internal set; }

        public string ErrorMessage { get; internal set; }

        public string ErrorKey { get; internal set; }

        public ILogService LogService { get; internal set; }

        protected BaseResponse()
        {
            
        }

        protected BaseResponse(HttpResponseMessage response, ILogService logService)
        {
            Success = response.IsSuccessStatusCode;
            if(Success) Content = response.Content.ReadAsStringAsync().Result;
            StatusCode = response.StatusCode;
            ErrorMessage = "";
            ErrorKey = "";
            LogService = logService;

            AssignFromHttpResponseContent(response.Content);
        }
    }
}
