using RestSharp;

namespace hg_brasil_finance.Domain.Entities
{
    public class ApiResponse<T>
    {
        public ApiResponse(string message, Root<Dictionary<string, object>> data, string statusCode, bool cache = true)
        {
            Message = message;
            Response = data;
            StatusCode = statusCode;
            Cache = cache;
        }

        public string Message { get; set; }
        public Root<Dictionary<string, object>> Response { get; set; }
        public string StatusCode { get; set; }
        public bool Cache { get; set; }
    }
}
