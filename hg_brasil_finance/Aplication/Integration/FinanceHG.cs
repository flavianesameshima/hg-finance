using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration
{
    public class FinanceHG : IFinanceStock, IFinanceDefault
    {        
        private readonly CacheConfig _cache;
        private readonly string _keyFinanceHG;
        private readonly IFinanceStock _stockFinance;
        private readonly IFinanceDefault _defaultFinance;

        public FinanceHG(string keyFinanceHG, CacheConfig cache = null)
        {
            _cache = cache;
            _keyFinanceHG = keyFinanceHG;
            _stockFinance = new FinanceStock(keyFinanceHG, cache);
            _defaultFinance = new FinanceDefault(keyFinanceHG, cache);
        }

        public ApiResponse<Dictionary<string, StockResponse>> GetStockPrice(IEnumerable<string> symbol)
            => _stockFinance.GetStockPrice(symbol);

        public ApiResponse<Dictionary<string, StockResponse>> GetStockDividends(IEnumerable<string> symbol)
            =>_stockFinance.GetStockDividends(symbol);

        public ApiResponse<Dictionary<string, StockResponse>> GetIbovespa()
            => _stockFinance.GetIbovespa();

        public ApiResponse<Dictionary<string, StockResponse>> GetIbovespa(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date)
            => _stockFinance.GetIbovespa(dayAgo, startDate, endDate, Date);

        public ApiResponse<Dictionary<string, StockResponse>> GetQuotations()
            => _stockFinance.GetQuotations();

        public ApiResponse<Dictionary<string, StockResponse>> GetTaxes()
            => _stockFinance.GetTaxes();

        public ApiResponse<Dictionary<string, StockResponse>> GetHistorical(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date, string mode)
            => _stockFinance.GetHistorical(dayAgo, startDate, endDate, Date, mode);

        public ApiResponse<Dictionary<string, StockResponse>> GetHistoricalStocks(IEnumerable<string> symbols, short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date)
            => _stockFinance.GetHistoricalStocks(symbols, dayAgo, startDate, endDate, Date);

        public ApiResponse<Dictionary<string, DefaultResponse>> GetAll()
            => _defaultFinance.GetAll();
    }
}
