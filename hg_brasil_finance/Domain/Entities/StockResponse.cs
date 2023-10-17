namespace hg_brasil_finance.Domain.Entities
{
    public class StockResponse
    {
        public string kind { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public string company_name { get; set; }
        public string document { get; set; }
        public string description { get; set; }
        public string website { get; set; }
        public string sector { get; set; }
        public Financials financials { get; set; }
        public string region { get; set; }
        public string currency { get; set; }
        public MarketTime market_time { get; set; }
        public Logo logo { get; set; }
        public double market_cap { get; set; }
        public double price { get; set; }
        public double change_percent { get; set; }
        public double change_price { get; set; }
        public string updated_at { get; set; }
    }
}
