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
            // If it’s already an OperationResult<>, do nothing:
            if (context.Result is ObjectResult objectResult
                && objectResult.Value != null
                && objectResult.Value.GetType().IsGenericType
                && objectResult.Value.GetType().GetGenericTypeDefinition() == typeof(OperationResult<>))
            {
                await next();
                return;
            }

            // Only wrap ObjectResult (i.e. return data); skip other results (e.g., StatusCodeResult).
            if (context.Result is ObjectResult resultToWrap)
            {
                var data = resultToWrap.Value;
                var dataType = data?.GetType() ?? typeof(object);

                var wrappedType = typeof(OperationResult<>)
                                  .MakeGenericType(dataType);

                var okMethod = wrappedType.GetMethod(
                    nameof(OperationResult<object>.Ok),
                    new[] { dataType, typeof(string) });

                if (okMethod is null)
                {
                    throw new InvalidOperationException(
                        $"Could not find static Ok({dataType.Name}, string) method on {wrappedType.Name}");
                }

                // We know okMethod and data aren’t null here
                var wrapped = okMethod.Invoke(
                    null,
                    new object[] { data!, string.Empty })!;

                context.Result = new ObjectResult(wrapped)
                {
                    StatusCode = resultToWrap.StatusCode ?? 200
                };
            }

            await next();
        }
    }
}
