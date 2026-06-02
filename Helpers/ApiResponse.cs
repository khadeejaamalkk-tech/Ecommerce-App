namespace Ecommerce_App.Helpers
{
    public class ApiResponse<T>
    {
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ApiResponse<T> Success(T data, string message = "Success")
        {
            return new ApiResponse<T>
            {
                Status = true,
                StatusCode = 200,
                Message = message,
                Data = data
            };
        }
        public static ApiResponse<T> Fail(string message, int StatusCode = 400)
        {
            return new ApiResponse<T>
            {
                Status = false,
                StatusCode = StatusCode,
                Message = message,
                Data = default
            };
        }

    }
}
