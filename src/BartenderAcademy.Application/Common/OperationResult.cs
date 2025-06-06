namespace BartenderAcademy.Application.Common
{
    /// <summary>
    /// A uniform wrapper for API responses, indicating success/failure, a message, and optional data.
    /// </summary>
    public class OperationResult<T>
    {
        /// <summary>
        /// Indicates whether the operation succeeded.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// A user-friendly message (e.g., "Category created successfully" or an error).
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// The data returned by the operation (if any).
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Create a successful result with data and optional message.
        /// </summary>
        public static OperationResult<T> Ok(T data, string? message = null) =>
            new OperationResult<T> { Success = true, Data = data, Message = message ?? string.Empty };

        /// <summary>
        /// Create a failure result with an error message.
        /// </summary>
        public static OperationResult<T> Fail(string errorMessage) =>
            new OperationResult<T> { Success = false, Message = errorMessage };
    }
}
