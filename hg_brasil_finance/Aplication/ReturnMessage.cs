using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication
{
    public class ReturnMessage<T>
    {
        public ApiResponse<T> Message(string message, string statusCode, Root<Dictionary<string, object>> response, bool cache = true)
        => new ApiResponse<T>(message, response, statusCode, cache);
    }
}
