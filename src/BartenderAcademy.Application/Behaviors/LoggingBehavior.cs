using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using BartenderAcademy.Application.Interfaces;

namespace BartenderAcademy.Application.Behaviors
{
    /// <summary>
    /// Logs the start and end of each MediatR request, including user ID and elapsed time.
    /// </summary>
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        private readonly ICurrentUserService _currentUserService;

        public LoggingBehavior(
            ILogger<LoggingBehavior<TRequest, TResponse>> logger,
            ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId ?? "Anonymous";

            _logger.LogInformation("Handling {RequestName} for User: {UserId}", requestName, userId);

            var stopwatch = Stopwatch.StartNew();
            var response = await next().ConfigureAwait(false);
            stopwatch.Stop();

            _logger.LogInformation(
                "Handled {RequestName} for User: {UserId} in {ElapsedMilliseconds}ms",
                requestName,
                userId,
                stopwatch.ElapsedMilliseconds);

            return response;
        }
    }
}
