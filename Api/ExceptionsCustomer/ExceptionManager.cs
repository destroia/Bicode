using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ExceptionsCustomer
{
    public class ExceptionManager : IExceptionFilter
    {
        readonly IWebHostEnvironment HostEnvironment;
        readonly IModelMetadataProvider ModelMetadataProvider;
        public ExceptionManager(IWebHostEnvironment hostEnvironment, IModelMetadataProvider modelMetadataProvider)
        {
            HostEnvironment = hostEnvironment;
            ModelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;

            context.Result = new JsonResult(new ResponseException
            {
                Result = ModelMetadataProvider,
                Message = HostEnvironment.ApplicationName + "-- Tipo de excepcion : " +
                context.Exception.GetType() + " Mensage : " + context.Exception.Message,
                State = false
            });
        }
    }
}
