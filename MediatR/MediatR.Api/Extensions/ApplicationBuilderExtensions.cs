using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MediatR.Api.Extensions
{
    
    public class CustomErrorMessage
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public static class ApplicationBuilderExtensions
    {
        public static void UseFluentValidationExceptonHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(x =>
            {
                x.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    if(!(exception is ValidationException validationException))
                    {
                        throw exception;
                    }

                    var errors = validationException.Errors;

                    var errorList = new List<CustomErrorMessage>();
                    foreach(var error in errors)
                    {
                        errorList.Add(new CustomErrorMessage() 
                        { 
                            PropertyName = error.PropertyName, 
                            ErrorMessage = error.ErrorMessage 
                        });
                    }
                    var errorAsJson = JsonSerializer.Serialize(errorList);
                    context.Response.StatusCode = 400;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(errorAsJson, Encoding.UTF8);
                });
            });
        }
    }
}
