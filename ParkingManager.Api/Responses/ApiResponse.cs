using ParkingManager.Core.CustomEntities;
namespace ParkingManager.Api.Responses
{
    public class ApiResponse<T>
    {
        public Message[] Messages { get; set; }
        public Pagination Pagination { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
        public IEnumerable<string>? Errors { get; set; }

        public ApiResponse(T data)
        {
            Success = true;
            Data = data;
        }

        public ApiResponse(string message)
        {
            Success = false;
            Message = message;
        }

        public ApiResponse(string message, IEnumerable<string> errors)
        {
            Success = false;
            Message = message;
            Errors = errors;
        }
    }
}