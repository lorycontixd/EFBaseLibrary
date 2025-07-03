using System.Text.Json.Serialization;

namespace BaseLibrary.Application.Dto.Common
{
    public class ApiResponse<T> where T : class
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; } = true;
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        [JsonPropertyName("data")]
        public T? Data { get; set; }
        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; } = 200;
        [JsonPropertyName("errors")]
        public List<string>? Errors { get; set; } = new List<string>();
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        // Success response with data
        public ApiResponse<T> SuccessResult(T data, string? message = null, int statusCode = 200)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = statusCode,
                Errors = null
            };
        }

        // Error response with a single error message
        public ApiResponse<T> ErrorResult(string message, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = new List<string> { message },
                StatusCode = statusCode,
                Data = null
            };
        }

        // Error response with message and optional errors
        public ApiResponse<T> ErrorResult(string message, List<string>? errors = null, int statusCode = 400)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors ?? new List<string> { message },
                StatusCode = statusCode,
                Data = null
            };
        }

    }
}
