using hg_brasil_finance.Domain.Entities;

namespace hg_brasil_finance.Aplication.Integration
{
    public class FinanceHG : IFinanceStock, IFinanceDefault
    {        
        private readonly IFinanceStock _stockFinance;
        private readonly IFinanceDefault _defaultFinance;

        public FinanceHG(string keyFinanceHG, CacheConfig cache = null)
        {
            _stockFinance = new FinanceStock(keyFinanceHG, cache);
            _defaultFinance = new FinanceDefault(keyFinanceHG, cache);
        }

        public ApiResponse<StockResponse> GetStockPrice(IEnumerable<string> symbol)
            => _stockFinance.GetStockPrice(symbol);

        public ApiResponse<DividendsResponse> GetStockDividends(IEnumerable<string> symbol)
            =>_stockFinance.GetStockDividends(symbol);

        public ApiResponse<StockResponse> GetIbovespa()
            => _stockFinance.GetIbovespa();

        public ApiResponse<StockResponse> GetIbovespa(short? dayAgo, DateTime? startDate, DateTime? endDate, DateTime? Date)
            => _stockFinance.GetIbovespa(dayAgo, startDate, endDate, Date);

        public ApiResponse<StockResponse> GetQuotations()
            => _stockFinance.GetQuotations();

        public ApiResponse<StockResponse> GetTaxes()
            => _stockFinance.GetTaxes();

        public ApiResponse<DefaultResponse> GetAll()
            => _defaultFinance.GetAll();
    }
}
