using hg_brasil_finance.Aplication;

namespace hg_brasil_finance.Domain.Entities
{
    public class DividendsResponse
    {
        public string kind { get; set; }
        public string currency { get; set; }
        public string isin_code { get; set; }
        public string label { get; set; }
        public double amount { get; set; }
        public string approved_in { get; set; }
        public string traded_until { get; set; }
        public string payment_date { get; set; }
    }
}
