namespace hg_brasil_finance.Domain.Entities
{
    public class DefaultResponse
    {
        public Currencies currencies { get; set; }
        public Stocks stocks { get; set; }
        public List<string> available_sources { get; set; }
        public Bitcoin bitcoin { get; set; }
        public List<Taxis> taxes { get; set; }
    }
}
