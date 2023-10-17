using RestSharp;

namespace hg_brasil_finance.Domain.Entities
{
    public class ApiResponse<T>
    {
        public ApiResponse(string mensagem, Root<T> response, string statusCode, bool cache)
        {
            Mensagem = mensagem;
            Response = response;
            StatusCode = statusCode;
            Cache = cache;
        }

        public string Mensagem { get; set; }
        public Root<T> Response { get; set; }
        public string StatusCode { get; set; }
        public bool Cache { get; set; }
    }
}
