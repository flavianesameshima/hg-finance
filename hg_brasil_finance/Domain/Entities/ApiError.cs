using System.Net;

namespace hg_brasil_finance.Domain.Entities
{
    public class ApiError
    {
        public ApiResponse<T> HandleException<T>(string message, string statusCode)
          => new ApiResponse<T>(message, default(Root<T>), statusCode, false);
    }
}
