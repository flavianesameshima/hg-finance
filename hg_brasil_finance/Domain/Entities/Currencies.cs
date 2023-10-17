namespace hg_brasil_finance.Domain.Entities
{
    public class Currencies
    {
        public string source { get; set; }
        public USD USD { get; set; }
        public EUR EUR { get; set; }
        public GBP GBP { get; set; }
        public ARS ARS { get; set; }
        public CAD CAD { get; set; }
        public AUD AUD { get; set; }
        public JPY JPY { get; set; }
        public CNY CNY { get; set; }
        public BTC BTC { get; set; }
    }
}
