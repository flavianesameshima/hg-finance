using RestSharp;

namespace hg_brasil_finance.Domain.Entities
{
    public class ReturnAPI
    {
        public ReturnAPI(string mensagem, Root response, string statusCode)
        {
            Mensagem = mensagem;
            Response = response;
            StatusCode = statusCode;
        }
        public ReturnAPI(string mensagem,string statusCode)
        {
            Mensagem = mensagem;
            StatusCode = statusCode;
        }

        public string Mensagem { get; set; }
        public Root Response { get; set; }
        public string StatusCode { get; set; }
    }
}
