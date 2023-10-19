namespace hg_brasil_finance.Domain.Entities
{
    public class ErrorResponse
    {
        public bool error { get; set; }
        public string message { get; set; } = string.Empty;
    }
}
