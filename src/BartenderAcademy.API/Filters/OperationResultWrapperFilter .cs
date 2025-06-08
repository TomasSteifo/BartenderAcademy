using System;
using System.Threading.Tasks;
using BartenderAcademy.Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BartenderAcademy.API.Filters
{
    /// <summary>
    /// Wraps any controller action result into OperationResult<T> automatically.
    /// If a controller already returns OperationResult, leaves it untouched.
    /// </summary>
    public class OperationResultWrapperFilter : IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            // If the action already returned an OperationResult, do nothing.
            if (context.Result is ObjectResult { Value: IOperationResult _ })
            {
                await next();
                return;
            }

            // Only wrap ObjectResult (i.e. return data); skip other results (e.g., StatusCodeResult).
            if (context.Result is ObjectResult objectResult)
            {
                var data = objectResult.Value;
                var wrappedType = typeof(OperationResult<>).MakeGenericType(data?.GetType() ?? typeof(object));
                var okMethod = wrappedType.GetMethod(nameof(OperationResult<object>.Ok), new[] { data?.GetType() ?? typeof(object), typeof(string) });

                // Invoke OperationResult<T>.Ok(data, message) with empty message
                var wrapped = okMethod?.Invoke(null, new[] { data, string.Empty });

                context.Result = new ObjectResult(wrapped)
                {
                    StatusCode = objectResult.StatusCode ?? 200
                };
            }

            await next();
        }
    }
}
